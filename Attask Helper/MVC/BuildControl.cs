using System;
using System.Drawing;
using System.Windows.Forms;
using Attask_Helper.DTO;
using Attask_Helper.OptionsDTO;

namespace Attask_Helper.MVC
{
  public partial class BuildControl : UserControl, IBuildRow
  {
    private event EventHandler CopyButtonEvent;

    public BuildControl()
    {
      InitializeComponent();

      BuildRow = new BuildRow();

      copyBuildButton.Click += CopyButtonClick;
    }

    private BuildRow _buildRow;
    public BuildRow BuildRow
    {
      get { return _buildRow; }
      set
      {
        _buildRow = value;
        minorBuildTextBox.Text = MinorBuild;
        majorBuildTextBox.Text = MajorBuild;
      }
    }

    public event EventHandler CopyButtonClicked
    {
      add { CopyButtonEvent += value; }
      remove { CopyButtonEvent -= value; }
    }

    private void CopyButtonClick(object sender, EventArgs e)
    {
      if (CopyButtonEvent != null) CopyButtonEvent(this, e);
    }

    public string MinorBuild
    {
      get { return BuildRow != null ? BuildRow.MinorBuild : string.Empty; }
      set
      {
        if (BuildRow != null) BuildRow.MinorBuild = value;
        minorBuildTextBox.Text = value;
      }
    }

    public string MajorBuild
    {
      get { return BuildRow != null ? BuildRow.MajorBuild : string.Empty; }
      set
      {
        if (BuildRow != null) BuildRow.MajorBuild = value;
        majorBuildTextBox.Text = value;
      }
    }

    public string LastBuild
    {
      get { return BuildRow != null ? BuildRow.LastBuild : string.Empty; }
      set
      {
        if (BuildRow != null) BuildRow.LastBuild = value;
        lastBuildLabel.Text = value;
      }
    }

    public BuildStatus Status
    {
      get { return BuildRow != null ? BuildRow.Status : BuildStatus.Unknown; }
      set
      {
        if (BuildRow != null) BuildRow.Status = value;
        StatusImage = ComputeImage(value);
      }
    }

    private Image ComputeImage(BuildStatus status)
    {
      if (status == BuildStatus.Success) return Properties.Resources.Green;
      if (status == BuildStatus.Building) return Properties.Resources.Yellow;
      if (status == BuildStatus.BrokenAndBuilding) return Properties.Resources.Orange;
      if (status == BuildStatus.Broken) return Properties.Resources.Red;

      return Properties.Resources.Grey;
    }

    private Image StatusImage
    {
      set { statusPictureBox.BackgroundImage = value; }
    }
  }
}
