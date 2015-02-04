using System.Collections.Generic;

namespace Attask_Helper.OptionsDTO
{
  public static class Options
  {
    public static IList<Profile> Profiles { get; set; }

    public static string Clarity147Directory { get; set; }
    public static string Connect201505Directory { get; set; }
    public static string ConnectDirectory { get; set; }

    public const string Clarity147DirectoryKey = "Clarity147Directory";
    public const string Connect201505DirectoryKey = "Connect201505Directory";
    public const string ConnectDirectoryKey = "ConnectDirectory";
  }
}
