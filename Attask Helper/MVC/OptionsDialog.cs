using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Attask_Helper.Processes;
using Attask_Helper.Utilities;

namespace Attask_Helper.MVC
{
  public partial class OptionsDialog : Form
  {
    public OptionsDialog()
    {
      InitializeComponent();

      PopulateDefaultFilePaths();
    }

    private void PopulateDefaultFilePaths()
    {
      var directories = DirectoriesProcess.Run();

      HandleBranch(directories, DirectoriesProcess.Clarity147Name, folderBrowseBox1);
      HandleBranch(directories, DirectoriesProcess.Connect201502Name, folderBrowseBox2);
      HandleBranch(directories, DirectoriesProcess.ConnectName, folderBrowseBox3);
    }

    public void HandleBranch(IDictionary<string, string> directories, string branch, FolderBrowseBox box)
    {
      if (!directories.ContainsKey(branch)) return;
      
      var path = directories[branch];
      if (path.IsNullOrTrimmedEmpty()) return;
      if (!Directory.Exists(path)) return;

      box.FolderPath = path;
    }

    public string Clarity147Directory { get; set; }
    public string Connect201502Directory { get; set; }
    public string ConnectDirectory { get; set; }
    
    private void OKClicked(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Clarity147Directory = folderBrowseBox1.FolderPath;
      Connect201502Directory = folderBrowseBox2.FolderPath;
      ConnectDirectory = folderBrowseBox3.FolderPath;

      Close();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }
  }
}
