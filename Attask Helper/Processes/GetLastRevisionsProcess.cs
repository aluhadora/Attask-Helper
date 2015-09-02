using System;
using System.Collections.Generic;
using System.Linq;
using Attask_Helper.Utilities;

namespace Attask_Helper.Processes
{
  public static class GetLastRevisionsProcess
  {
    public static IList<string> GetRevisions(string directory)
    {
      var hgUser = Environment.UserName;
      var command = string.Format("\"C:\\Program Files\\TortoiseHG\\hg\" log -l 15 -u {0}", hgUser);

      return HandleOutput(Command.Run(directory, command));
    }

    private static IList<string> HandleOutput(string output)
    {
      output = output.Substring(output.IndexOf("changeset"));
      var lines = output.Lines();
      lines.RemoveRange(lines.Count - 4, 3);

      var changesetLines = lines.Where(x => x.StartsWith("changeset")).ToList();
      var summmaryLines = lines.Where(x => x.StartsWith("summary")).ToList();

      var changesetSummary = new Dictionary<string, string>();
      for (int i = 0; i < changesetLines.Count; i++)
      {
        changesetSummary.Add(changesetLines[i].Substring(12), summmaryLines[i].Substring(13));
      }

      return HandleChangeSets(changesetSummary);
    }

    private static IList<string> HandleChangeSets(Dictionary<string, string> changesetSummary)
    {
      var changeSets = new List<string>();

      foreach (var item in changesetSummary)
      {
        var changeSetItmes = item.Key.Split(':');

        var changeSet = string.Format("{0} ({1})", changeSetItmes[0], changeSetItmes[1]);
        var summary = item.Value;

        if (!summary.StartsWith("Automated merge") &&
          !summary.StartsWith("Merge", StringComparison.CurrentCultureIgnoreCase))
        {
          changeSets.Add(changeSet.Substring(1));
          if (changeSets.Count >= 5) return changeSets;
        }
      }

      return changeSets;
    }
  }
}
