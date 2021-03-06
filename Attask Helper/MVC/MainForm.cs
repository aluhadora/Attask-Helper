﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Attask_Helper.OptionsDTO;
using Attask_Helper.Utilities;
using CaselleProfiles.DTO;

namespace Attask_Helper.MVC
{
  public partial class MainForm : Form, IView
  {
    private IDictionary<BuildRow, BuildControl> _rows;

    private event EventHandler LoadedEvent;
    private event EventHandler CopyBuildEvent;
    private event EventHandler CopyResolutionEvent;
    private event EventHandler ProfileChangedEvent;
    private event EventHandler ChangeSetChangedEvent;

    public MainForm()
    {
      InitializeComponent();

      defaultBuildRow.BuildRow = Options.Profiles.First().Rows[0];
      _rows = new Dictionary<BuildRow, BuildControl>
      {
        {defaultBuildRow.BuildRow, defaultBuildRow}
      };

      HookEventsForRow(defaultBuildRow);
      profileSelector.ProfileChanged += ProfileSelectorChanged;
      profileSelector.OptionsClicked += OptionsClicked;
      profileSelector.Filter = Filter;
      profileSelector.Reload();
    }

    private bool Filter(string profileName)
    {
      return Options.Profiles.First(x => x.ProfileName == profileName).Visible;
    }

    private void OptionsClicked()
    {
      var currentProfileName = profileSelector.ProfileName;

      using (var dialog = new OptionsDialog())
      {
        dialog.Profile = Profile;
        dialog.ShowDialog(this);

        if (dialog.DialogResult != DialogResult.OK) return;

        profileSelector.Reload();
        profileSelector.ProfileName = currentProfileName;
        
        if (!profileSelector.ProfileName.IsNullOrTrimmedEmpty()) return;
        var attaskProfile = Options.Profiles.FirstOrDefault(x => x.Visible);
        if (attaskProfile != null) profileSelector.ProfileName = attaskProfile.ProfileName;
      }
    }

    private void HookEventsForRow(BuildControl control)
    {
      control.CopyButtonClicked += (sender, args) => Raise(CopyBuildEvent, sender, args);
    }

    private static void Raise(EventHandler e, object sender, EventArgs args)
    {
      if (e != null) e(sender, args);
    }

    private void Loaded(object sender, EventArgs e)
    {
      Raise(LoadedEvent, sender, e);
    }

    private void ResolutionClicked(object sender, EventArgs e)
    {
      Raise(CopyResolutionEvent, sender, e);
    }

    #region Implementation of IView

    void IView.FillResolution(string text)
    {
      resolutionTextBox.Text = text;
    }

    void IView.RefreshBuildRow(BuildRow buildRow)
    {
      if (!_rows.ContainsKey(buildRow)) return;

      _rows[buildRow].MinorBuild = buildRow.MinorBuild;
      _rows[buildRow].MajorBuild = buildRow.MajorBuild;
      _rows[buildRow].LastBuild = buildRow.LastBuild;
      _rows[buildRow].Status = buildRow.Status;
    }

    private void ProfileSelectorChanged(Profile obj)
    {
      Raise(ProfileChangedEvent, null, null);
    }

    public AttaskProfile Profile
    {
      get { return Options.Profiles.FirstOrDefault(x => x.ProfileName == profileSelector.ProfileName); }
      set { profileSelector.ProfileName = value.ProfileName; }
    }

    void IView.RefreshProfiles()
    {
      if (Profile == null) return;

      defaultBuildRow.BuildRow = Profile.Rows[0];

      foreach (var control in _rows.Values)
      {
        if (control == defaultBuildRow) continue;
        buildPanel.Controls.Remove(control);
      }

      _rows = new Dictionary<BuildRow, BuildControl>
      {
        {defaultBuildRow.BuildRow, defaultBuildRow}
      };

      for (int i = 1; i < Profile.Rows.Count; i++)
      {
        var control = new BuildControl
        {
          BuildRow = Profile.Rows[i],
          Left = 12,
          Top = 12 + 26*i,
        };

        HookEventsForRow(control);

        _rows.Add(Profile.Rows[i], control);
        buildPanel.Controls.Add(control);
      }

      buildPanel.Height = 9 + _rows.Count*26;
    }

    void IView.BindChangeSets(IList<string> revisions)
    {
      changeSetComboBox.Items.Clear();
      changeSetComboBox.Items.AddRange(revisions.Cast<object>().ToArray());
    }
    
    IList<BuildRow> IView.BuildRows
    {
      get { return _rows.Keys.ToList(); }
    }

    string IView.Resolution
    {
      get { return resolutionTextBox.Text; }
    }

    string IView.ChangeSet
    {
      get { return changeSetComboBox.Text; }
      set { changeSetComboBox.Text = value; }
    }

    string IView.ChangeSetSummary
    {
      set { changeSetSummaryLabel.Text = value; }
    }

    AttaskProfile IView.CurrentProfile
    {
      get { return Profile; }
    }

    event EventHandler IView.ProfileChanged
    {
      add { ProfileChangedEvent += value; }
      remove { ProfileChangedEvent -= value; }
    }

    event EventHandler IView.Loaded
    {
      add { LoadedEvent += value; }
      remove { LoadedEvent -= value; }
    }

    event EventHandler IView.CopyBuild
    {
      add { CopyBuildEvent += value; }
      remove { CopyBuildEvent -= value; }
    }

    event EventHandler IView.CopyResolution
    {
      add { CopyResolutionEvent += value; }
      remove { CopyResolutionEvent -= value; }
    }

    event EventHandler IView.ChangeSetChanged
    {
      add { ChangeSetChangedEvent += value; }
      remove { ChangeSetChangedEvent -= value; }
    }

    #endregion

    private void changeSetComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      Raise(ChangeSetChangedEvent, sender, e);
    }
  }
}
