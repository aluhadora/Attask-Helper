using System;
using System.ComponentModel;
using System.Windows.Forms;
using Attask_Helper.Utilities;

namespace Attask_Helper.MVC
{
  /// <summary>
  /// Combination of a textbox and a folder dialog with coordinated text fields and some customization
  /// </summary>
  public partial class FolderBrowseBox : UserControl
  {
    private string _dialogDescription;
    private bool _textBoxEditable;

    [Description("Specifies the default folder path on dialog entry and the selected folder path on exit")]
    public string FolderPath
    {
      get { return folderTextBox.Text; }
      set { folderTextBox.Text = value; }
    }

    [Description("Specifies the control's folder dialog description")]
    public string DialogDescription
    {
      get { return _dialogDescription; }
      set { _dialogDescription = value.IsNullOrTrimmedEmpty() ? string.Empty : value.Trim(); }
    }

    [Description("Specifies whether the control's textbox is editable or not")]
    public bool TextBoxEditable
    {
      get { return _textBoxEditable; }
      set
      {
        _textBoxEditable = value;
        folderTextBox.TabStop = _textBoxEditable;
        folderTextBox.ReadOnly = !_textBoxEditable;
      }
    }

    [Description("Specifies the width of the control's textbox and, hence, the control itself")]
    public int TextBoxWidth
    {
      get { return folderTextBox.Width; }
      set
      {
        browseButton.Left = folderTextBox.Left + value + (browseButton.Left - folderTextBox.Right);
        folderTextBox.Width = value;
        Width = browseButton.Right;
      }
    }

    [Description("Specifies the control to which focus should advance after folder dialog completion")]
    public Control NextFocusControl { get; set; }

    [Description("Specifies whether new folder creation is allowed or not")]
    public bool FolderCreationAllowed { get; set; }


    public FolderBrowseBox()
    {
      InitializeComponent();
    }

    private void BrowseButtonClick(object sender, EventArgs e)
    {
      var folderBrowserDialog = new FolderBrowserDialog
      {
        Description = _dialogDescription,
        ShowNewFolderButton = FolderCreationAllowed
      };

      if (!folderTextBox.Text.IsNullOrTrimmedEmpty())
      {
        folderBrowserDialog.SelectedPath = folderTextBox.Text;
      }

      if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
      {
        folderTextBox.Text = folderBrowserDialog.SelectedPath;
      }

      if (NextFocusControl != null)
      {
        NextFocusControl.Focus();
      }
    }

    private void FolderTextBoxPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        if (!_textBoxEditable)
        {
          browseButton.Focus();
        }
      }
    }
  }
}
