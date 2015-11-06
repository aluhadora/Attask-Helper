using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Attask_Helper.OptionsDTO
{
  public static class Config
  {
    public static IDictionary<string, string> BuildNameConverter;
    public static IDictionary<string, IList<string>> DefaultReleases;
    public static IDictionary<string, string> ReleaseNames; 
    public static string TestMessage;

    static Config()
    {
      BuildNameConverter = new Dictionary<string, string>();
      DefaultReleases = new Dictionary<string, IList<string>>();
      ReleaseNames = new Dictionary<string, string>();
      ReadXml(GetXml());
    }

    private static string GetXml()
    {
      return GetXml("Config.xml") ?? GetXml("Resources\\Config.xml") ?? DownloadConfig();
    }

    private static string DownloadConfig()
    {
      throw new NotImplementedException();
    }

    private static string GetXml(string path)
    {
      if (File.Exists(path)) return File.ReadAllText(path);
      return null;
    }

    private static void ReadXml(string xml)
    {
      XmlReader xr = new XmlTextReader(new StringReader(xml));

      while (xr.Read())
      {
        HandleBuild(xr);
        HandleTestMessage(xr);
        HandleRelease(xr);
      }
    }

    private static void HandleRelease(XmlReader xr)
    {
      if (xr.Name != "release") return;

      var degobah = xr.GetAttribute("degobah");
      var name = xr.GetAttribute("name");
      ReleaseNames.Add(degobah, name);
      var list = new List<string>();

      var subReader = xr.ReadSubtree();
      while (subReader.Read())
      {
        if (subReader.Name != "subrelease") continue;
        list.Add(subReader.GetAttribute("name"));
      }

      DefaultReleases.Add(name, list);
    }

    private static void HandleTestMessage(XmlReader xr)
    {
      if (xr.Name != "welcome") return;
      TestMessage = xr.GetAttribute("message");
    }

    private static void HandleBuild(XmlReader xr)
    {
      if (xr.Name != "build") return;
      BuildNameConverter.Add(xr.GetAttribute("degobah"), xr.GetAttribute("deathstar"));
    }
  }
}

//namespace Attask_Helper.Utilities
//{
//  public static class DegobahNameConverter
//  {
//    private static readonly IDictionary<string, string> Converter; 

//    static DegobahNameConverter()
//    {
//      Converter = new Dictionary<string, string>();
//      var xml = Properties.Resources.Config;

//      XmlReader xr = new XmlTextReader(new StringReader(xml));

//      while (xr.Read())
//      {
//        if (xr.Name != "build") continue;
//        Converter.Add(xr.GetAttribute("degobah"), xr.GetAttribute("deathstar"));
//      }
//    }

//    public static string ConvertDegobahNameToDeathstarName(string name)
//    {
//      if (!Converter.ContainsKey(name)) return name;
//      return Converter[name];
//    }
//  }
//}
