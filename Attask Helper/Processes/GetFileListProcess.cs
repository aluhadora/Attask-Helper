using System;
using System.Collections.Generic;
using System.Linq;
using Attask_Helper.Utilities;

namespace Attask_Helper.Processes
{
  public static class GetFileListProcess
  {
    public static string Run(string changeSet, string directory)
    {
      if (changeSet.Contains("(") && changeSet.Contains(")"))
      {
        changeSet = changeSet.Substring(changeSet.IndexOf("(") + 1);
        changeSet = changeSet.Substring(0, changeSet.LastIndexOf(")"));
      }

      changeSet = changeSet.Trim();

      return RunWithShortenedChangeSet(changeSet, directory);
    }

    private static IDictionary<string, string> _cachedChangeSets;

    private static string RunWithShortenedChangeSet(string changeSet, string directory)
    {
      if (_cachedChangeSets == null) _cachedChangeSets = new Dictionary<string, string>();

      if (!_cachedChangeSets.ContainsKey(changeSet)) _cachedChangeSets.Add(changeSet, ProcessChangeSet(changeSet, directory));

      return _cachedChangeSets[changeSet];
    }

    private static string ProcessChangeSet(string changeSet, string directory)
    {
      var command = string.Format("\"C:\\Program Files\\TortoiseHG\\hg\" log -v -r {0}", changeSet);

      return FilesFromOutput(Command.Run(directory, command));
    }

    private static string FilesFromOutput(string output)
    {
      if (output.IndexOf("files:") < 0) return string.Empty;
      output = output.Substring(output.IndexOf("files:"));
      output = output.Substring(0, output.IndexOf("description:"));
      output = output.Substring(6).Trim();

      var files = output.Split(' ');

      return string.Join(Environment.NewLine, files.ToArray());
    }
  }
}
