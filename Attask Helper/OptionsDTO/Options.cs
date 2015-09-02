using System.Collections.Generic;

namespace Attask_Helper.OptionsDTO
{
  public static class Options
  {
    public static IList<Profile> Profiles { get; set; }

    public static string Clarity147Directory { get; set; }
    public static string Connect201511Directory { get; set; }
    public static string DevelopmentDirectory { get; set; }

    public const string Clarity147DirectoryKey = "Clarity147Directory";
    public const string Connect201511DirectoryKey = "Connect201511Directory";
    public const string DevelopmentDirectoryKey = "DevelopmentDirectory";
  }
}
