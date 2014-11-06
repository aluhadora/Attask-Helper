using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Attask_Helper.Utilities;

namespace Attask_Helper.Processes
{
  public static class DirectoriesProcess
  {
    public const string Clarity147Name = "Clarity-4.2.147";
    public const string Connect201502Name = "2015.02";
    public const string ConnectName = "Connect";

    public const string Pattern = "default.*http://.*degobah/hg/{0}/";

    public static IDictionary<string, string> Run()
    {
      var dictionary = new Dictionary<string, string>();
      var files = GetHgrcFiles();

      foreach (var file in files)
      {
        var lines = File.ReadAllLines(file);
        foreach (var line in lines)
        {
          HandleBranch(line, dictionary, file, Clarity147Name);
          HandleBranch(line, dictionary, file, Connect201502Name);
          HandleBranch(line, dictionary, file, ConnectName);
        }
      }

      return dictionary;
    }

    private static void HandleBranch(string line, Dictionary<string, string> dictionary, string file, string branch)
    {
      if (Regex.IsMatch(line, Pattern.Replace(Pattern, branch)))
      {
        if (!dictionary.ContainsKey(branch)) dictionary.Add(branch, file.Substring(0, file.IndexOf("\\.hg")));
      }
    }

    private static IEnumerable<string> GetHgrcFiles()
    {
      var files = Command.Run("D:\\", "dir /s hgrc /b").Lines();
      files.RemoveAt(0);
      files.RemoveAt(0);
      files.RemoveAt(0);
      files.RemoveAt(0);

      files.RemoveAt(files.Count - 1);
      files.RemoveAt(files.Count - 1);
      files.RemoveAt(files.Count - 1);

      return files;
    }
  }
}
