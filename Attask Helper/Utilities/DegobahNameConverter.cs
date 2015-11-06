using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Attask_Helper.Utilities
{
  public static class DegobahNameConverter
  {
    private static readonly IDictionary<string, string> Converter; 

    static DegobahNameConverter()
    {
      Converter = new Dictionary<string, string>();
      var xml = Properties.Resources.DeathstarBuildConversions;

      XmlReader xr = new XmlTextReader(new StringReader(xml));

      while (xr.Read())
      {
        if (xr.Name != "build") continue;
        Converter.Add(xr.GetAttribute("degobah"), xr.GetAttribute("deathstar"));
      }
    }

    public static string ConvertDegobahNameToDeathstarName(string name)
    {
      if (!Converter.ContainsKey(name)) return name;
      return Converter[name];
    }
  }
}
