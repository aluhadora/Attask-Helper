using System.Collections.Generic;

namespace Attask_Helper.OptionsDTO
{
  public static class Options
  {
    public static IList<AttaskProfile> Profiles { get; set; }

    public const string VisibleKey = "AttaskVisible";
  }
}
