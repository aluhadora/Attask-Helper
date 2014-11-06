using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Attask_Helper.MVC;
using Attask_Helper.OptionsDTO;
using Attask_Helper.Utilities;
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

      PopulateOptions(args);

      var form = new MainForm {Profile = ComputeProfile(args)};

      new Presenter(form);
      Application.Run(form);
    }

    private static Profile ComputeProfile(string[] args)
    {
      var name = string.Join(" ", args);
      return Options.Profiles.FirstOrDefault(x => x.ProfileName == name) ?? Options.Profiles[0];
    }

    private static void PopulateOptions(IEnumerable<string> args)
    {
      var reg = new RegistryEditor(false);
      Options.Clarity147Directory = reg.Read(Options.Clarity147DirectoryKey);
      Options.ConnectDirectory = reg.Read(Options.ConnectDirectoryKey);
      Options.Connect201502Directory = reg.Read(Options.Connect201502DirectoryKey);

      ShowOptionsDialogIfNecessary(args);

      const string clarity = "Clarity 147";
      const string connect = "Connect";
      const string connect2015 = "2015.02";

      Options.Profiles = new List<Profile>
      {
        new Profile {Index = 0, ProfileName = clarity},
        new Profile {Index = 1, ProfileName = connect},
        new Profile {Index = 2, ProfileName = connect2015}
      };

      var profiles = Options.Profiles;

      AddRow(profiles[0], "Clarity 4.2.147", "4.2.147", Options.Clarity147Directory);
      AddRow(profiles[0], "Connect", connect, Options.ConnectDirectory);
      AddRow(profiles[0], "2015.02", connect2015, Options.Connect201502Directory);
      
      AddRow(profiles[1], "Connect", connect, Options.ConnectDirectory);
      AddRow(profiles[1], "2015.02", connect2015, Options.Connect201502Directory);
      
      AddRow(profiles[2], "2015.02", connect2015, Options.Connect201502Directory);
    }

    private static void ShowOptionsDialogIfNecessary(IEnumerable<string> args)
    {
      if (!ShouldShowOptions(args)) return;

      var form = new OptionsDialog();
      Application.Run(form);

      if (form.DialogResult != DialogResult.OK) Application.Exit();
      
      var reg = new RegistryEditor(false);
      
      Options.Clarity147Directory = form.Clarity147Directory;
      Options.ConnectDirectory = form.ConnectDirectory;
      Options.Connect201502Directory = form.Connect201502Directory;

      reg.Write(Options.Clarity147DirectoryKey, Options.Clarity147Directory);
      reg.Write(Options.ConnectDirectoryKey, Options.ConnectDirectory);
      reg.Write(Options.Connect201502DirectoryKey, Options.Connect201502Directory);

      if (ShouldShowOptions(args)) Application.Exit();
    }

    private static bool ShouldShowOptions(IEnumerable<string> args)
    {
      if (args.Contains("options")) return true;
      if (DirectoryCheck(Options.Clarity147Directory)) return true;
      if (DirectoryCheck(Options.ConnectDirectory)) return true;
      if (DirectoryCheck(Options.Connect201502Directory)) return true;

      return false;
    }

    private static bool DirectoryCheck(string dir)
    {
      if (dir.IsNullOrTrimmedEmpty()) return true;
      try
      {
        return !Directory.Exists(dir);
      }
      catch (Exception)
      {
        return true;
      }
    }

    private static void AddRow(Profile profile, string projectName, string majorBuild, string directory)
    {
      var row = new BuildRow
      {
        ProjectName = projectName,
        MajorBuild = majorBuild,
        DirectoryPath = directory,
        Profile = profile
      };

      profile.Rows.Add(row);
    }
  }
}
