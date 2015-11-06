using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

      var form = new MainForm {Profile = ComputeProfile(args)};

      new Presenter(form);
      Application.Run(form);
    }

    private static AttaskProfile ComputeProfile(string[] args)
    {
      var name = string.Join(" ", args);
      return Options.Profiles.FirstOrDefault(x => x.ProfileName == name) ?? Options.Profiles[0];
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
          ProfileName = profile.Name
        };
        Options.Profiles.Add(attaskProfile);

        AddRow(attaskProfile, profile, "Needs to go away");

        var subProfileString = reg.Read(profile.Name, "SubProfiles");

        if (subProfileString.IsNullOrTrimmedEmpty()) continue; 

        var subProfileNames = subProfileString.Split('|');

        foreach (var subProfileName in subProfileNames)
        {
          AddRow(attaskProfile, profiles.FirstOrDefault(x => x.Name == subProfileName), "Needs to go away");
        }

      }
    }

    private static void AddRow(AttaskProfile attaskProfile, Profile caselleProfile, string majorBuild)
    {
      var row = new BuildRow
      {
        Profile = caselleProfile,
        MajorBuild = majorBuild,
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
