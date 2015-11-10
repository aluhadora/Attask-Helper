using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace Attask_Helper.OptionsDTO
{
  public static class Config
  {
    public static IDictionary<string, string> BuildNameConverter;
    public static IDictionary<string, IList<string>> DefaultReleases;
    public static IDictionary<string, string> ReleaseNames; 
    public static string TestMessage;
    private const string ConfigFileName = "Attask-Config.xml";

    static Config()
    {
      BuildNameConverter = new Dictionary<string, string>();
      DefaultReleases = new Dictionary<string, IList<string>>();
      ReleaseNames = new Dictionary<string, string>();
      ReadXml(GetXml());
    }

    private static string GetXml()
    {
      return GetXml(ConfigFileName, true) ??
        GetXml("Resources\\" + ConfigFileName, true) ??
        DownloadConfig() ?? GetXml(ConfigFileName, false) ?? 
        GetXml("Resources\\" + ConfigFileName, false);
    }

    private static string DownloadConfig()
    {
      try
      {
        using (var wc = new WebClient())
        {
          wc.DownloadFile(Properties.Resources.ConfigURL, ConfigFileName);
        }

        File.SetLastAccessTimeUtc(ConfigFileName, DateTime.UtcNow);
      }
      catch (Exception)
      {
      }

      return GetXml(ConfigFileName, false);
    }

    private static string GetXml(string path, bool youthMatters)
    {
      if (!File.Exists(path) || !ConfigIsYoung(path, youthMatters)) return null;
      
      try
      {
        File.SetLastAccessTimeUtc(path, DateTime.UtcNow);
      }
      catch (Exception)
      {
      }
      
      return File.ReadAllText(path);
    }

    private static bool ConfigIsYoung(string path, bool youthMatters)
    {
      if (!youthMatters) return true;
      return File.GetLastAccessTimeUtc(path).AddHours(1) > DateTime.UtcNow;
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