using System.Collections.Generic;

namespace Attask_Helper.OptionsDTO
{
  public class AttaskProfile
  {
    public int Index { get; set; }
    public string ProfileName { get; set; }
    public IList<BuildRow> Rows { get; set; }
    public bool Visible { get; set; }

    public AttaskProfile()
    {
      Rows = new List<BuildRow>();
    }
  }
}
