using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Attask_Helper.OptionsDTO;
using Attask_Helper.Utilities;
using CaselleProfiles.DTO;

namespace Attask_Helper.MVC
{
  public partial class OptionsDialog : Form
  {
    public OptionsDialog()
    {
      InitializeComponent();

      profileSelector.ProfileChanged += ProfileChanged;

      Profiles = Options.Profiles.Select(x => new AttaskProfile(x)).ToList();
    }

    protected List<AttaskProfile> Profiles { get; set; }

    private void ProfileChanged(Profile obj)
    {
      visibleCheckBox.Checked = Profiles.First(x => x.ProfileName == obj.Name).Visible;
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      SaveProfiles();
      DialogResult = DialogResult.OK;
      Close();
    }

    private void SaveProfiles()
    {
      var reg = new RegistryEditor(false);

      for (int i = 0; i < Options.Profiles.Count; i++)
      {
        var op = Options.Profiles[i];
        var p = Profiles[i];

        op.Visible = p.Visible;
        reg.Write(p.ProfileName, "Visible", p.Visible);
      }
    }

    private void ProfileSelectorChanged(Profile obj)
    {
      //Raise(ProfileChangedEvent, null, null);
    }

    public AttaskProfile Profile
    {
      get { return Profiles.FirstOrDefault(x => x.ProfileName == profileSelector.ProfileName); }
      set { profileSelector.ProfileName = value.ProfileName; }
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }

    private void visibleCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      Profiles.First(x => x.ProfileName == profileSelector.ProfileName).Visible = visibleCheckBox.Checked;
    }
  }
}
