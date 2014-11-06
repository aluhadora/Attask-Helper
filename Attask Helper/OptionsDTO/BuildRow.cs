﻿using Attask_Helper.DTO;

namespace Attask_Helper.OptionsDTO
{
  public class BuildRow
  {
    public string DirectoryPath { get; set; }
    public string ProjectName { get; set; }
    public string MajorBuild { get; set; }
    public string MinorBuild { get; set; }
    public BuildStatus Status { get; set; }
    public string LastBuild { get; set; }

    public Profile Profile { get; set; }
  }
}
