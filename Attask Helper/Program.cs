﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Attask_Helper.MVC;
using Attask_Helper.OptionsDTO;
using Attask_Helper.Utilities;
using CaselleProfiles.DTO;
using CaselleProfiles.Processes;
using BuildRow = Attask_Helper.OptionsDTO.BuildRow;

namespace Attask_Helper
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main(params string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      PopulateOptions();

      if (Config.TestMessage != null) MessageBox.Show(Config.TestMessage);

      var form = new MainForm {Profile = ComputeProfile(args)};

      new Presenter(form);
      Application.Run(form);
    }

    private static AttaskProfile ComputeProfile(string[] args)
    {
      var name = string.Join(" ", args);
      return Options.Profiles.FirstOrDefault(x => x.ProfileName == name && x.Visible) ?? Options.Profiles.FirstOrDefault(x => x.Visible);
    }

    private static void PopulateOptions()
    {
      var profiles = ProfilesProcess.Load();
      var reg = new RegistryEditor(false);

      Options.Profiles = new List<AttaskProfile>();

      foreach (var profile in profiles.OrderBy(x => x.Order))
      {
        var attaskProfile = new AttaskProfile
        {
          Index = profile.Order,
          ProfileName = profile.Name,
        };

        var visible = reg.ReadInt(profile.Name, "Visible");
        attaskProfile.Visible = !visible.HasValue || visible.Value != 0;
        reg.Write(attaskProfile.ProfileName, "Visible", attaskProfile.Visible ? 1 : 0);

        Options.Profiles.Add(attaskProfile);

        AddRow(attaskProfile, profile);

        var subProfileString = reg.Read(profile.Name, "SubProfiles");

        if (subProfileString == null) subProfileString = BuildSubProfilesFromDefault(profile, profiles);
        if (subProfileString.IsNullOrTrimmedEmpty()) continue;

        var subProfileNames = subProfileString.Split('|');

        foreach (var subProfileName in subProfileNames)
        {
          AddRow(attaskProfile, profiles.FirstOrDefault(x => x.Name == subProfileName));
        }

      }
    }

    private static string BuildSubProfilesFromDefault(Profile profile, IList<Profile> profiles)
    {
      var degobahDictionary = new Dictionary<string, Profile>();
      foreach (var p in profiles)
      {
        degobahDictionary.Add(DegobahName(p), p);
      }

      var releases = Config.DefaultReleases[Config.ReleaseNames[DegobahName(profile)]];

      var sb = new StringBuilder();

      foreach (var release in releases)
      {
        if (sb.Length > 0) sb.Append("|");
        var d = Config.ReleaseNames.First(x => x.Value == release).Key;
        sb.Append(degobahDictionary[d].Name);
      }

      var subProfiles = sb.ToString();

      var reg = new RegistryEditor(false);
      reg.Write(profile.Name, "SubProfiles", subProfiles);
      return subProfiles;
    }

    private static void AddRow(AttaskProfile attaskProfile, Profile caselleProfile)
    {
      var row = new BuildRow
      {
        Profile = caselleProfile,
        MajorBuild = "?",
        AttaskProfile = attaskProfile,
        DegobahName = DegobahName(caselleProfile),
        WebName = DegobahNameConverter.ConvertDegobahNameToDeathstarName(DegobahName(caselleProfile))
      };

      attaskProfile.Rows.Add(row);
    }

    private static string DegobahName(Profile profile)
    {
      var directory = Path.Combine(profile.Directory, ".hg", "hgrc");

      var line = File.ReadAllLines(directory).First(x => x.Contains("default = "));
      line = line.Substring(0, line.LastIndexOf("/"));
      line = line.Substring(line.LastIndexOf("/") + 1);
      return line;
    }
  }
}
