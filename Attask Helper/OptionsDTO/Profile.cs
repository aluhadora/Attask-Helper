using System.Collections.Generic;

namespace Attask_Helper.OptionsDTO
{
  public class Profile
  {
    public int Index { get; set; }
    public string ProfileName { get; set; }
    public IList<BuildRow> Rows { get; set; } 

    public Profile()
    {
      Rows = new List<BuildRow>();
    }
  }
}
