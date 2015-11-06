using Attask_Helper.OptionsDTO;

namespace Attask_Helper.Utilities
{
  public static class DegobahNameConverter
  {
    public static string ConvertDegobahNameToDeathstarName(string name)
    {
      if (!Config.BuildNameConverter.ContainsKey(name)) return name;
      return Config.BuildNameConverter[name];
    }
  }
}
