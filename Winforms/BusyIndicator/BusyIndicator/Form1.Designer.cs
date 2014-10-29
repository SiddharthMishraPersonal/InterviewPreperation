namespace BusyIndicator
{
  partial class Form1
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
      this.btnShow = new System.Windows.Forms.Button();
      this.btnHide = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.panel = new System.Windows.Forms.Panel();
      this.usBusyIndicator1 = new BusyIndicator.usBusyIndicator();
      this.panel.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnShow
      // 
      this.btnShow.Location = new System.Drawing.Point(26, 35);
      this.btnShow.Name = "btnShow";
      this.btnShow.Size = new System.Drawing.Size(75, 23);
      this.btnShow.TabIndex = 0;
      this.btnShow.Text = "Show";
      this.btnShow.UseVisualStyleBackColor = true;
      this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
      // 
      // btnHide
      // 
      this.btnHide.Location = new System.Drawing.Point(509, 35);
      this.btnHide.Name = "btnHide";
      this.btnHide.Size = new System.Drawing.Size(75, 23);
      this.btnHide.TabIndex = 1;
      this.btnHide.Text = "Hide";
      this.btnHide.UseVisualStyleBackColor = true;
      this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Location = new System.Drawing.Point(75, 137);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(453, 235);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "groupBox1";
      // 
      // panel
      // 
      this.panel.Controls.Add(this.usBusyIndicator1);
      this.panel.Location = new System.Drawing.Point(43, 96);
      this.panel.Name = "panel";
      this.panel.Size = new System.Drawing.Size(541, 380);
      this.panel.TabIndex = 3;
      this.panel.Visible = false;
      // 
      // usBusyIndicator1
      // 
      this.usBusyIndicator1.Location = new System.Drawing.Point(186, 106);
      this.usBusyIndicator1.Name = "usBusyIndicator1";
      this.usBusyIndicator1.Size = new System.Drawing.Size(150, 150);
      this.usBusyIndicator1.TabIndex = 0;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(641, 531);
      this.Controls.Add(this.panel);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnHide);
      this.Controls.Add(this.btnShow);
      this.Name = "Form1";
      this.Text = "Form1";
      this.panel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnShow;
    private System.Windows.Forms.Button btnHide;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Panel panel;
    private usBusyIndicator usBusyIndicator1;
  }
}

