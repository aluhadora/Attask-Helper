namespace Attask_Helper.MVC
{
  partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.buildPanel = new System.Windows.Forms.Panel();
      this.defaultBuildRow = new Attask_Helper.MVC.BuildControl();
      this.changesetPanel = new System.Windows.Forms.Panel();
      this.changeSetSummaryLabel = new System.Windows.Forms.Label();
      this.changeSetComboBox = new System.Windows.Forms.ComboBox();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.resolutionTextBox = new System.Windows.Forms.TextBox();
      this.profileSelector = new CaselleProfiles.MVC.ProfileSelector.ProfileSelector();
      this.buildPanel.SuspendLayout();
      this.changesetPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // buildPanel
      // 
      this.buildPanel.Controls.Add(this.defaultBuildRow);
      this.buildPanel.Dock = System.Windows.Forms.DockStyle.Top;
      this.buildPanel.Location = new System.Drawing.Point(0, 25);
      this.buildPanel.Margin = new System.Windows.Forms.Padding(12);
      this.buildPanel.Name = "buildPanel";
      this.buildPanel.Padding = new System.Windows.Forms.Padding(12);
      this.buildPanel.Size = new System.Drawing.Size(691, 35);
      this.buildPanel.TabIndex = 1;
      // 
      // defaultBuildRow
      // 
      this.defaultBuildRow.BackColor = System.Drawing.SystemColors.Window;
      this.defaultBuildRow.BuildRow = null;
      this.defaultBuildRow.LastBuild = "";
      this.defaultBuildRow.Location = new System.Drawing.Point(12, 12);
      this.defaultBuildRow.MajorBuild = "";
      this.defaultBuildRow.Margin = new System.Windows.Forms.Padding(0);
      this.defaultBuildRow.MinorBuild = "";
      this.defaultBuildRow.Name = "defaultBuildRow";
      this.defaultBuildRow.Size = new System.Drawing.Size(664, 20);
      this.defaultBuildRow.Status = Attask_Helper.DTO.BuildStatus.Unknown;
      this.defaultBuildRow.TabIndex = 0;
      // 
      // changesetPanel
      // 
      this.changesetPanel.Controls.Add(this.changeSetSummaryLabel);
      this.changesetPanel.Controls.Add(this.changeSetComboBox);
      this.changesetPanel.Controls.Add(this.label4);
      this.changesetPanel.Controls.Add(this.label3);
      this.changesetPanel.Controls.Add(this.resolutionTextBox);
      this.changesetPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.changesetPanel.Location = new System.Drawing.Point(0, 60);
      this.changesetPanel.Margin = new System.Windows.Forms.Padding(0);
      this.changesetPanel.Name = "changesetPanel";
      this.changesetPanel.Padding = new System.Windows.Forms.Padding(12);
      this.changesetPanel.Size = new System.Drawing.Size(691, 437);
      this.changesetPanel.TabIndex = 2;
      // 
      // changeSetSummaryLabel
      // 
      this.changeSetSummaryLabel.AutoSize = true;
      this.changeSetSummaryLabel.Location = new System.Drawing.Point(244, 4);
      this.changeSetSummaryLabel.Name = "changeSetSummaryLabel";
      this.changeSetSummaryLabel.Size = new System.Drawing.Size(0, 13);
      this.changeSetSummaryLabel.TabIndex = 12;
      // 
      // changeSetComboBox
      // 
      this.changeSetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.changeSetComboBox.FormattingEnabled = true;
      this.changeSetComboBox.Location = new System.Drawing.Point(86, 1);
      this.changeSetComboBox.Name = "changeSetComboBox";
      this.changeSetComboBox.Size = new System.Drawing.Size(152, 21);
      this.changeSetComboBox.TabIndex = 11;
      this.changeSetComboBox.SelectedIndexChanged += new System.EventHandler(this.changeSetComboBox_SelectedIndexChanged);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(12, 30);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(60, 13);
      this.label4.TabIndex = 10;
      this.label4.Text = "Resolution:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(12, 4);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(61, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "Changeset:";
      // 
      // resolutionTextBox
      // 
      this.resolutionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.resolutionTextBox.Location = new System.Drawing.Point(14, 46);
      this.resolutionTextBox.Multiline = true;
      this.resolutionTextBox.Name = "resolutionTextBox";
      this.resolutionTextBox.ReadOnly = true;
      this.resolutionTextBox.Size = new System.Drawing.Size(662, 379);
      this.resolutionTextBox.TabIndex = 6;
      this.resolutionTextBox.Click += new System.EventHandler(this.ResolutionClicked);
      // 
      // profileSelector
      // 
      this.profileSelector.CurrentProfile = null;
      this.profileSelector.Dock = System.Windows.Forms.DockStyle.Top;
      this.profileSelector.Location = new System.Drawing.Point(0, 0);
      this.profileSelector.Name = "profileSelector";
      this.profileSelector.Size = new System.Drawing.Size(691, 25);
      this.profileSelector.TabIndex = 3;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Window;
      this.ClientSize = new System.Drawing.Size(691, 497);
      this.Controls.Add(this.changesetPanel);
      this.Controls.Add(this.buildPanel);
      this.Controls.Add(this.profileSelector);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Text = "AtTask Helper";
      this.Load += new System.EventHandler(this.Loaded);
      this.buildPanel.ResumeLayout(false);
      this.changesetPanel.ResumeLayout(false);
      this.changesetPanel.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel buildPanel;
    private System.Windows.Forms.Panel changesetPanel;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox resolutionTextBox;
    private BuildControl defaultBuildRow;
    private System.Windows.Forms.ComboBox changeSetComboBox;
    private System.Windows.Forms.Label changeSetSummaryLabel;
    private CaselleProfiles.MVC.ProfileSelector.ProfileSelector profileSelector;
  }
}