using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Attask_Helper.DTO;
using Attask_Helper.OptionsDTO;
using Attask_Helper.Processes;

namespace Attask_Helper.MVC
{
  public class Presenter
  {
    private readonly IView _view;

    public Presenter(IView view)
    {
      _view = view;
      HookupEvents();
    }

    private AttaskProfile Profile
    {
      get { return _view.CurrentProfile; }
    }

    private void HookupEvents()
    {
      _view.Loaded += ViewLoaded;
      _view.CopyBuild += CopyBuild;
      _view.CopyResolution += CopyResolution;
      _view.ProfileChanged += ChangeProfile;
      _view.ChangeSetChanged += ChangeSetChanged;
    }

    private void ChangeSetChanged(object sender, EventArgs e)
    {
      _view.ChangeSetSummary = ComputeSummary(_view.ChangeSet);
      _view.FillResolution(CalculateResolution(_view.ChangeSet));
    }

    private string ComputeSummary(string changeSet)
    {
      if (Profile == null) return string.Empty;
      return GetSummaryProcess.Summary(Profile.Rows[0].DirectoryPath, changeSet);
    }

    private void ChangeProfile(object sender, EventArgs e)
    {
      _view.RefreshProfiles();
      LoadView();
    }

    private void CopyResolution(object sender, EventArgs e)
    {
      Copy(_view.Resolution);
    }

    private void CopyBuild(object sender, EventArgs e)
    {
      var row = ((IBuildRow)sender).BuildRow;

      Copy(string.Format("{0}.{1}", row.MajorBuild, row.MinorBuild));
    }

    private void Copy(string text)
    {
      Clipboard.SetText(text);
    }

    private void ViewLoaded(object sender, EventArgs e)
    {
      LoadView();
    }

    private void LoadView()
    {
      var revisions = GetCurrentRevision();
      _view.BindChangeSets(revisions);
      _view.ChangeSet = revisions.First();

      if (_view.ChangeSet == string.Empty) return;

      _view.RefreshProfiles();

      FillBuildInformation();
      _view.FillResolution(CalculateResolution(revisions.First()));
    }

    private IList<string> GetCurrentRevision()
    {
      if (Profile == null) return new List<string> { string.Empty};
      var row = Profile.Rows.First();
      return GetLastRevisionsProcess.GetRevisions(row.DirectoryPath);
    }

    private string CalculateResolution(string revision)
    {
      var resolutionBuilder = new StringBuilder();
      var firstRow = Profile.Rows[0];
      resolutionBuilder.AppendFormat("Build {0}.{1} revision {2}", firstRow.MajorBuild, firstRow.MinorBuild, revision);
      resolutionBuilder.AppendLine();

      for (int i = 1; i < Profile.Rows.Count; i++)
      {
        var row = Profile.Rows[i];
        resolutionBuilder.AppendFormat("Build {0}.{1}", row.MajorBuild, row.MinorBuild);
        resolutionBuilder.AppendLine();
      }

      resolutionBuilder.AppendLine();
      resolutionBuilder.AppendLine(GetFileListProcess.Run(revision, firstRow.DirectoryPath));

      return resolutionBuilder.ToString();
    }

    private void FillBuildInformation()
    {
      var webRows = WebRowsProcess.GetRows();

      foreach (var buildRow in Profile.Rows)
      {
        var webRow = webRows.FirstOrDefault(x => x.ProjectName == buildRow.WebName);
        buildRow.MinorBuild = webRow == null ? string.Empty : webRow.NextBuildNumber;
        buildRow.Status = webRow == null ? BuildStatus.Unknown : webRow.BuildStatus;
        buildRow.LastBuild = webRow == null ? string.Empty : webRow.LastBuildLabel;
        _view.RefreshBuildRow(buildRow);
      }
    }
  }
}
