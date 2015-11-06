using Attask_Helper.DTO;
using CaselleProfiles.DTO;

namespace Attask_Helper.OptionsDTO
{
  public class BuildRow
  {
    public Profile Profile { get; set; }
    public string DirectoryPath { get { return Profile.Directory; } }
    public string ProjectName { get { return Profile.Name; } }
    public string MajorBuild { get; set; }
    public string MinorBuild { get; set; }
    public BuildStatus Status { get; set; }
    public string LastBuild { get; set; }

    public AttaskProfile AttaskProfile { get; set; }

    public string DegobahName { get; set; }
    public string WebName { get; set; }
  }
}
