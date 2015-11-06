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

    public AttaskProfile(AttaskProfile p)
    {
      Index = p.Index;
      ProfileName = p.ProfileName;
      Rows = new List<BuildRow>();
      foreach (var buildRow in p.Rows)
      {
        Rows.Add(new BuildRow(buildRow) { AttaskProfile = this});
      }
      Visible = p.Visible;
    }
  }
}
