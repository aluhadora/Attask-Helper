using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace Attask_Helper.Utilities
{
  public class RegistryEditor
  {
    private readonly RegistryKey _baseRegistryKey = Registry.CurrentUser;
    private const string SubKey = "SOFTWARE\\AtTaskHelper\\Options";
    private readonly bool _showError = true;

    public RegistryEditor()
    {
    }

    public RegistryEditor(bool showError)
    {
      _showError = showError;
    }

    public string Read(string keyName)
    {
      return (string)ActualRead(keyName);
    }

    private object ActualRead(string keyName)
    {
      // Opening the registry key
      RegistryKey rk = _baseRegistryKey;
      // Open a subKey as read-only

      RegistryKey sk1 = rk.OpenSubKey(SubKey);
      // If the RegistrySubKey doesn't exist -> (null)

      if (sk1 == null)
      {
        return null;
      }
      try
      {
        // If the RegistryKey exists I get its value

        // or null is returned.

        return sk1.GetValue(keyName.ToUpper());
      }
      catch (Exception e)
      {
        // AAAAAAAAAAARGH, an error!

        ShowErrorMessage(e, "Reading registry " + keyName.ToUpper());
        return null;
      }
    }

    public int? ReadInt(string keyName)
    {
      var value = ActualRead(keyName);

      try
      {
        return Convert.ToInt32(value);
      }
      catch (Exception)
      {
        return null;
      }
    }

    public bool Write(string keyName, object value)
    {
      try
      {
        // Setting

        RegistryKey rk = _baseRegistryKey;
        // I have to use CreateSubKey 

        // (create or open it if already exits), 

        // 'cause OpenSubKey open a subKey as read-only

        RegistryKey sk1 = rk.CreateSubKey(SubKey);
        // Save the value

        if (sk1 != null)
        {
          sk1.SetValue(keyName.ToUpper(), value);
          return true;
        }
        throw new ArgumentOutOfRangeException();
      }
      catch (Exception e)
      {
        // AAAAAAAAAAARGH, an error!

        ShowErrorMessage(e, "Writing registry " + keyName.ToUpper());
        return false;
      }
    }

    public bool DeleteKey(string keyName)
    {
      try
      {
        // Setting

        RegistryKey rk = _baseRegistryKey;
        RegistryKey sk1 = rk.CreateSubKey(SubKey);
        // If the RegistrySubKey doesn't exists -> (true)

        if (sk1 == null)
          return true;
        sk1.DeleteValue(keyName);

        return true;
      }
      catch (Exception e)
      {
        // AAAAAAAAAAARGH, an error!

        ShowErrorMessage(e, "Deleting SubKey " + SubKey);
        return false;
      }
    }

    public bool DeleteSubKeyTree()
    {
      try
      {
        // Setting

        RegistryKey rk = _baseRegistryKey;
        RegistryKey sk1 = rk.OpenSubKey(SubKey);
        // If the RegistryKey exists, I delete it

        if (sk1 != null)
          rk.DeleteSubKeyTree(SubKey);

        return true;
      }
      catch (Exception e)
      {
        // AAAAAAAAAAARGH, an error!

        ShowErrorMessage(e, "Deleting SubKey " + SubKey);
        return false;
      }
    }

    public int SubKeyCount()
    {
      try
      {
        // Setting

        RegistryKey rk = _baseRegistryKey;
        RegistryKey sk1 = rk.OpenSubKey(SubKey);
        // If the RegistryKey exists...

        if (sk1 != null)
          return sk1.SubKeyCount;
        return 0;
      }
      catch (Exception e)
      {
        // AAAAAAAAAAARGH, an error!

        ShowErrorMessage(e, "Retriving subkeys of " + SubKey);
        return 0;
      }
    }

    public int ValueCount()
    {
      try
      {
        // Setting

        RegistryKey rk = _baseRegistryKey;
        RegistryKey sk1 = rk.OpenSubKey(SubKey);
        // If the RegistryKey exists...

        return sk1 != null ? sk1.ValueCount : 0;
      }
      catch (Exception e)
      {
        // AAAAAAAAAAARGH, an error!

        ShowErrorMessage(e, "Retriving keys of " + SubKey);
        return 0;
      }
    }

    private void ShowErrorMessage(Exception e, string title)
    {
      if (!_showError)
      {
        return;
      }
      MessageBox.Show(e.Message,
        title
        , MessageBoxButtons.OK
        , MessageBoxIcon.Error);
    }
  }
}
