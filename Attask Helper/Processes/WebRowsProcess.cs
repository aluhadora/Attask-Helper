using System;
using System.Collections.Generic;
using System.Net;
using Attask_Helper.DTO;
using HtmlAgilityPack;

namespace Attask_Helper.Processes
{
  public static class WebRowsProcess
  {
    public static IList<WebRow> GetRows()
    {
      var client = new WebClient();
      var html = client.DownloadString(Properties.Resources.CCNet);

      return HandleHtml(html);
    }

    private static IList<WebRow> HandleHtml(string html)
    {
      const string rowPrefix = "projectData";

      var rows = new List<WebRow>();

      var doc = new HtmlDocument();
      doc.LoadHtml(html);

      for (int i = 0; i < 10; i++)
      {
        var id = rowPrefix + i;
        HandleID(rows, doc, id);
      }

      return rows;
    }

    private static void HandleID(List<WebRow> rows, HtmlDocument doc, string id)
    {
      var row = doc.GetElementbyId(id);
      if (row == null) return;

      var webRow = new WebRow();

      FillWebRow(webRow, row);

      rows.Add(webRow);
    }

    private static void FillWebRow(WebRow webRow, HtmlNode row)
    {
      webRow.ProjectName = row.ChildNodes[RowValues.ProjectName].InnerText.Trim();
      webRow.LastBuildStatus = row.ChildNodes[RowValues.LastBuildStatus].InnerText;
      webRow.LastBuildTime = ParseDate(row.ChildNodes[RowValues.LastBuildTime].InnerText);
      webRow.NextBuildTime = ParseDate(row.ChildNodes[RowValues.NextBuildTime].InnerText);
      webRow.LastBuildLabel = row.ChildNodes[RowValues.LastBuildLabel].InnerText;
      webRow.Status = row.ChildNodes[RowValues.CCNetStatus].InnerText;
      webRow.Activity = row.ChildNodes[RowValues.Activity].InnerText;
    }

    private static DateTime? ParseDate(string innerText)
    {
      DateTime result;
      if (DateTime.TryParse(innerText, out result)) return result;
      return null;
    }

    private static class RowValues
    {
      public const int ProjectName = 3;
      public const int LastBuildStatus = 5;
      public const int LastBuildTime = 7;
      public const int NextBuildTime = 9;
      public const int LastBuildLabel = 11;
      public const int CCNetStatus = 13;
      public const int Activity = 15;
    }
  }
}
