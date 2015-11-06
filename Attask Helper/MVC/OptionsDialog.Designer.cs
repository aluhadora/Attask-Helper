namespace Attask_Helper.MVC
{
  partial class OptionsDialog
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.profileSelector = new CaselleProfiles.MVC.ProfileSelector.ProfileSelector();
      this.optionsPanel = new System.Windows.Forms.Panel();
      this.visibleCheckBox = new System.Windows.Forms.CheckBox();
      this.buttonPanel = new System.Windows.Forms.Panel();
      this.cancelButton = new System.Windows.Forms.Button();
      this.okButton = new System.Windows.Forms.Button();
      this.optionsPanel.SuspendLayout();
      this.buttonPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // profileSelector
      // 
      this.profileSelector.CurrentProfile = null;
      this.profileSelector.Dock = System.Windows.Forms.DockStyle.Top;
      this.profileSelector.Location = new System.Drawing.Point(0, 0);
      this.profileSelector.Name = "profileSelector";
      this.profileSelector.OptionsVisible = false;
      this.profileSelector.ProfileName = "";
      this.profileSelector.Size = new System.Drawing.Size(284, 25);
      this.profileSelector.TabIndex = 0;
      // 
      // optionsPanel
      // 
      this.optionsPanel.Controls.Add(this.visibleCheckBox);
      this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.optionsPanel.Location = new System.Drawing.Point(0, 25);
      this.optionsPanel.Name = "optionsPanel";
      this.optionsPanel.Padding = new System.Windows.Forms.Padding(12);
      this.optionsPanel.Size = new System.Drawing.Size(284, 236);
      this.optionsPanel.TabIndex = 2;
      // 
      // visibleCheckBox
      // 
      this.visibleCheckBox.AutoSize = true;
      this.visibleCheckBox.Checked = true;
      this.visibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.visibleCheckBox.Location = new System.Drawing.Point(15, 15);
      this.visibleCheckBox.Name = "visibleCheckBox";
      this.visibleCheckBox.Size = new System.Drawing.Size(56, 17);
      this.visibleCheckBox.TabIndex = 0;
      this.visibleCheckBox.Text = "Visible";
      this.visibleCheckBox.UseVisualStyleBackColor = true;
      // 
      // buttonPanel
      // 
      this.buttonPanel.Controls.Add(this.cancelButton);
      this.buttonPanel.Controls.Add(this.okButton);
      this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.buttonPanel.Location = new System.Drawing.Point(0, 216);
      this.buttonPanel.Name = "buttonPanel";
      this.buttonPanel.Size = new System.Drawing.Size(284, 45);
      this.buttonPanel.TabIndex = 1;
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.Location = new System.Drawing.Point(197, 10);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 10;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(116, 10);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 9;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // OptionsDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Window;
      this.ClientSize = new System.Drawing.Size(284, 261);
      this.Controls.Add(this.buttonPanel);
      this.Controls.Add(this.optionsPanel);
      this.Controls.Add(this.profileSelector);
      this.Name = "OptionsDialog";
      this.Text = "OptionsDialog";
      this.optionsPanel.ResumeLayout(false);
      this.optionsPanel.PerformLayout();
      this.buttonPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private CaselleProfiles.MVC.ProfileSelector.ProfileSelector profileSelector;
    private System.Windows.Forms.Panel optionsPanel;
    private System.Windows.Forms.CheckBox visibleCheckBox;
    private System.Windows.Forms.Panel buttonPanel;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.Button okButton;
  }
}