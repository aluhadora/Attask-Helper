using System.Collections.Generic;

namespace Attask_Helper.OptionsDTO
{
  public static class Options
  {
    public static IList<Profile> Profiles { get; set; }

    public static string Clarity147Directory { get; set; }
    public static string Connect201602Directory { get; set; }
    public static string DevelopmentDirectory { get; set; }

    public const string Clarity147DirectoryKey = "Clarity147Directory";
    public const string Connect201602DirectoryKey = "Connect201602Directory";
    public const string DevelopmentDirectoryKey = "DevelopmentDirectory";
  }
}
