using System.Linq;
using Attask_Helper.Utilities;

namespace Attask_Helper.Processes
{
  public static class GetSummaryProcess
  {
    public static string Summary(string directory, string fullChangeSet)
    {
      var changeSet = fullChangeSet;
      if (changeSet.IndexOf('(') > 0) changeSet = changeSet.Substring(0, changeSet.IndexOf('('));

      var command = string.Format("hg log -r {0}", changeSet);

      return HandleOutput(Command.Run(directory, command));
    }

    private static string HandleOutput(string output)
    {
      var lines = output.Lines();

      var line = lines.FirstOrDefault(x => x.StartsWith("summary:"));
      if (line == null) return string.Empty;

      return line.Substring(9).Trim();
    }
  }
}
