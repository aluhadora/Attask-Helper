using System.Collections.Generic;
using System.Linq;

namespace Attask_Helper.Utilities
{
  public static class StringUtility
  {
    /// <summary>
    /// Tests a string for null or the empty string.
    /// </summary>
    /// <param name="value">String to check.</param>
    /// <returns>Returns true if the string is null or if a trimmed version of the string is the empty string.</returns>
    [System.Diagnostics.DebuggerStepThrough]
    public static bool IsNullOrTrimmedEmpty(this string value)
    {
      return value == null || value.Trim() == string.Empty;
    }

    public static List<string> Lines(this string value)
    {
      value = value.Replace("\r", string.Empty);
      return value.Split('\n').ToList();
    }
  }
}
