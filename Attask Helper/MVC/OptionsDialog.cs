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
using CaselleProfiles.DTO;

namespace Attask_Helper.MVC
{
  public partial class OptionsDialog : Form
  {
    public OptionsDialog()
    {
      InitializeComponent();
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      //SaveProfiles();
      DialogResult = DialogResult.OK;
      Close();
    }

    private void ProfileSelectorChanged(Profile obj)
    {
      //Raise(ProfileChangedEvent, null, null);
    }

    public AttaskProfile Profile
    {
      get { return Options.Profiles.FirstOrDefault(x => x.ProfileName == profileSelector.ProfileName); }
      set { profileSelector.ProfileName = value.ProfileName; }
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }
  }
}
