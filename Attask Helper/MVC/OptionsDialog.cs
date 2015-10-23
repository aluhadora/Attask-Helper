using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Attask_Helper.OptionsDTO;
using Attask_Helper.Processes;
using Attask_Helper.Utilities;

namespace Attask_Helper.MVC
{
  public partial class OptionsDialog : Form
  {
    public OptionsDialog()
    {
      InitializeComponent();

      folderBrowseBox1.FolderPath = Options.Clarity147Directory;
      folderBrowseBox2.FolderPath = Options.Connect201602Directory;
      folderBrowseBox3.FolderPath = Options.DevelopmentDirectory;
      
      PopulateDefaultFilePaths();
    }

    private void PopulateDefaultFilePaths()
    {
      if (!Options.Clarity147Directory.IsNullOrTrimmedEmpty() && !Options.Connect201602Directory.IsNullOrTrimmedEmpty() &&
        !Options.DevelopmentDirectory.IsNullOrTrimmedEmpty()) return;
      var directories = DirectoriesProcess.Run();

      HandleBranch(directories, DirectoriesProcess.Clarity147Name, folderBrowseBox1);
      HandleBranch(directories, DirectoriesProcess.Connect201602Name, folderBrowseBox2);
      HandleBranch(directories, DirectoriesProcess.DevelopmentName, folderBrowseBox3);
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
    public string Connect201602Directory { get; set; }
    public string DevelopmentDirectory { get; set; }
    
    private void OKClicked(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Clarity147Directory = folderBrowseBox1.FolderPath;
      Connect201602Directory = folderBrowseBox2.FolderPath;
      DevelopmentDirectory = folderBrowseBox3.FolderPath;

      Close();
    }

    private void CancelClicked(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }
  }
}
