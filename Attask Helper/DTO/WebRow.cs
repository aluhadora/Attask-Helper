using System;

namespace Attask_Helper.DTO
{
  public class WebRow
  {
    public string ProjectName { get; set; }
    public string LastBuildStatus { get; set; }
    public DateTime? LastBuildTime { get; set; }
    public DateTime? NextBuildTime { get; set; }
    public string LastBuildLabel { get; set; }
    public string Status { get; set; }
    public string Activity { get; set; }

    public string LastBuildNumber
    {
      get
      {
        var workingNumber = string.Empty;

        for (int i = LastBuildLabel.Length - 1; i >= 0; i--)
        {
          var c = LastBuildLabel[i];
          if (char.IsNumber(c)) workingNumber = workingNumber.Insert(0, new string(c, 1));
          else break;
        }

        return workingNumber;
      }
    }

    public string NextBuildNumber
    {
      get
      {
        if (LastBuildNumber == string.Empty) return string.Empty;
        var lastBuild = Convert.ToInt16(LastBuildNumber);

        if (Status == "Running")
        {
          if (Activity == "Sleeping" || Activity == "CheckingModifications")
            return (lastBuild + 1).ToString();
          if (Activity == "Building") return (lastBuild + 2).ToString();
          return Activity;
        }
        return Status;
      }
    }
  }
}
