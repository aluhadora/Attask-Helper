using System;
using System.Collections.Generic;
using Attask_Helper.OptionsDTO;

namespace Attask_Helper.MVC
{
  public interface IView
  {
    void FillResolution(string text);
    void RefreshBuildRow(BuildRow buildRow);
    void RefreshProfiles();
    void BindChangeSets(IList<string> revisions);

    IList<BuildRow> BuildRows { get; }
    string Resolution { get; }
    string ChangeSet { get; set; }
    AttaskProfile CurrentProfile { get; }
    string ChangeSetSummary { set; }
    
    event EventHandler ProfileChanged;
    event EventHandler Loaded;
    event EventHandler CopyBuild;
    event EventHandler CopyResolution;
    event EventHandler ChangeSetChanged;
  }
}
