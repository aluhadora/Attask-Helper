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
      this.label1 = new System.Windows.Forms.Label();
      this.folderBrowseBox1 = new Attask_Helper.MVC.FolderBrowseBox();
      this.folderBrowseBox2 = new Attask_Helper.MVC.FolderBrowseBox();
      this.label2 = new System.Windows.Forms.Label();
      this.folderBrowseBox3 = new Attask_Helper.MVC.FolderBrowseBox();
      this.label3 = new System.Windows.Forms.Label();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(15, 17);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(102, 13);
      this.label1.TabIndex = 1;
      this.label1.Text = "Clarity 147 directory:";
      // 
      // folderBrowseBox1
      // 
      this.folderBrowseBox1.BackColor = System.Drawing.SystemColors.Window;
      this.folderBrowseBox1.DialogDescription = "";
      this.folderBrowseBox1.FolderCreationAllowed = false;
      this.folderBrowseBox1.FolderPath = "";
      this.folderBrowseBox1.Location = new System.Drawing.Point(133, 14);
      this.folderBrowseBox1.Name = "folderBrowseBox1";
      this.folderBrowseBox1.NextFocusControl = null;
      this.folderBrowseBox1.Size = new System.Drawing.Size(294, 21);
      this.folderBrowseBox1.TabIndex = 2;
      this.folderBrowseBox1.TextBoxEditable = false;
      this.folderBrowseBox1.TextBoxWidth = 216;
      // 
      // folderBrowseBox2
      // 
      this.folderBrowseBox2.BackColor = System.Drawing.SystemColors.Window;
      this.folderBrowseBox2.DialogDescription = "";
      this.folderBrowseBox2.FolderCreationAllowed = false;
      this.folderBrowseBox2.FolderPath = "";
      this.folderBrowseBox2.Location = new System.Drawing.Point(133, 41);
      this.folderBrowseBox2.Name = "folderBrowseBox2";
      this.folderBrowseBox2.NextFocusControl = null;
      this.folderBrowseBox2.Size = new System.Drawing.Size(294, 21);
      this.folderBrowseBox2.TabIndex = 4;
      this.folderBrowseBox2.TextBoxEditable = false;
      this.folderBrowseBox2.TextBoxWidth = 216;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(15, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(92, 13);
      this.label2.TabIndex = 3;
      this.label2.Text = "2016.02 directory:";
      // 
      // folderBrowseBox3
      // 
      this.folderBrowseBox3.BackColor = System.Drawing.SystemColors.Window;
      this.folderBrowseBox3.DialogDescription = "";
      this.folderBrowseBox3.FolderCreationAllowed = false;
      this.folderBrowseBox3.FolderPath = "";
      this.folderBrowseBox3.Location = new System.Drawing.Point(133, 68);
      this.folderBrowseBox3.Name = "folderBrowseBox3";
      this.folderBrowseBox3.NextFocusControl = null;
      this.folderBrowseBox3.Size = new System.Drawing.Size(294, 21);
      this.folderBrowseBox3.TabIndex = 6;
      this.folderBrowseBox3.TextBoxEditable = false;
      this.folderBrowseBox3.TextBoxWidth = 216;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(15, 71);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(116, 13);
      this.label3.TabIndex = 5;
      this.label3.Text = "Development directory:";
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.okButton.Location = new System.Drawing.Point(270, 106);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(75, 23);
      this.okButton.TabIndex = 7;
      this.okButton.Text = "OK";
      this.okButton.UseVisualStyleBackColor = true;
      this.okButton.Click += new System.EventHandler(this.OKClicked);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.cancelButton.Location = new System.Drawing.Point(351, 106);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 8;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.CancelClicked);
      // 
      // OptionsDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Window;
      this.ClientSize = new System.Drawing.Size(431, 144);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.okButton);
      this.Controls.Add(this.folderBrowseBox3);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.folderBrowseBox2);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.folderBrowseBox1);
      this.Controls.Add(this.label1);
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(547, 183);
      this.MinimumSize = new System.Drawing.Size(447, 183);
      this.Name = "OptionsDialog";
      this.Padding = new System.Windows.Forms.Padding(12);
      this.Text = "Options Dialog";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private FolderBrowseBox folderBrowseBox1;
    private FolderBrowseBox folderBrowseBox2;
    private System.Windows.Forms.Label label2;
    private FolderBrowseBox folderBrowseBox3;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
  }
}