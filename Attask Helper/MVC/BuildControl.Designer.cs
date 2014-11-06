namespace Attask_Helper.MVC
{
  partial class BuildControl
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.copyBuildButton = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.minorBuildTextBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.majorBuildTextBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // copyBuildButton
      // 
      this.copyBuildButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
      this.copyBuildButton.Location = new System.Drawing.Point(228, -1);
      this.copyBuildButton.Name = "copyBuildButton";
      this.copyBuildButton.Size = new System.Drawing.Size(75, 22);
      this.copyBuildButton.TabIndex = 11;
      this.copyBuildButton.Text = "Copy";
      this.copyBuildButton.UseVisualStyleBackColor = true;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(175, 3);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(12, 16);
      this.label2.TabIndex = 10;
      this.label2.Text = ".";
      // 
      // minorBuildTextBox
      // 
      this.minorBuildTextBox.Location = new System.Drawing.Point(187, 0);
      this.minorBuildTextBox.Name = "minorBuildTextBox";
      this.minorBuildTextBox.ReadOnly = true;
      this.minorBuildTextBox.Size = new System.Drawing.Size(36, 20);
      this.minorBuildTextBox.TabIndex = 9;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(-3, 3);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(71, 13);
      this.label1.TabIndex = 8;
      this.label1.Text = "Build number:";
      // 
      // majorBuildTextBox
      // 
      this.majorBuildTextBox.Location = new System.Drawing.Point(74, 0);
      this.majorBuildTextBox.Name = "majorBuildTextBox";
      this.majorBuildTextBox.ReadOnly = true;
      this.majorBuildTextBox.Size = new System.Drawing.Size(100, 20);
      this.majorBuildTextBox.TabIndex = 7;
      this.majorBuildTextBox.TabStop = false;
      // 
      // BuildControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Window;
      this.Controls.Add(this.copyBuildButton);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.minorBuildTextBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.majorBuildTextBox);
      this.Margin = new System.Windows.Forms.Padding(0);
      this.Name = "BuildControl";
      this.Size = new System.Drawing.Size(381, 20);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button copyBuildButton;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox minorBuildTextBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox majorBuildTextBox;
  }
}
