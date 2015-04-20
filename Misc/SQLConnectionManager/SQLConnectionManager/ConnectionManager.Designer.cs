namespace SQLConnectionManager
{
  partial class ConnectionManager
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
      this.txtServerName = new System.Windows.Forms.TextBox();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.txtPassword = new System.Windows.Forms.TextBox();
      this.lbPassword = new System.Windows.Forms.Label();
      this.txtUserName = new System.Windows.Forms.TextBox();
      this.radSQLAuthentication = new System.Windows.Forms.RadioButton();
      this.lbUserName = new System.Windows.Forms.Label();
      this.radWindowsAuthentication = new System.Windows.Forms.RadioButton();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.btnRefreshDatabase = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.cmbDatabaseList = new System.Windows.Forms.ComboBox();
      this.btnTestConnection = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.txtConnectionString = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(72, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Server Name:";
      // 
      // txtServerName
      // 
      this.txtServerName.Location = new System.Drawing.Point(90, 6);
      this.txtServerName.Name = "txtServerName";
      this.txtServerName.Size = new System.Drawing.Size(332, 20);
      this.txtServerName.TabIndex = 1;
      this.txtServerName.Text = "(local)";
      // 
      // groupBox1
      // 
      this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox1.Controls.Add(this.txtPassword);
      this.groupBox1.Controls.Add(this.lbPassword);
      this.groupBox1.Controls.Add(this.txtUserName);
      this.groupBox1.Controls.Add(this.radSQLAuthentication);
      this.groupBox1.Controls.Add(this.lbUserName);
      this.groupBox1.Controls.Add(this.radWindowsAuthentication);
      this.groupBox1.Location = new System.Drawing.Point(12, 32);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(416, 121);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Log on to the server";
      // 
      // txtPassword
      // 
      this.txtPassword.Enabled = false;
      this.txtPassword.Location = new System.Drawing.Point(104, 91);
      this.txtPassword.Name = "txtPassword";
      this.txtPassword.Size = new System.Drawing.Size(306, 20);
      this.txtPassword.TabIndex = 6;
      this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
      // 
      // lbPassword
      // 
      this.lbPassword.AutoSize = true;
      this.lbPassword.Enabled = false;
      this.lbPassword.Location = new System.Drawing.Point(35, 94);
      this.lbPassword.Name = "lbPassword";
      this.lbPassword.Size = new System.Drawing.Size(56, 13);
      this.lbPassword.TabIndex = 5;
      this.lbPassword.Text = "Password:";
      // 
      // txtUserName
      // 
      this.txtUserName.Enabled = false;
      this.txtUserName.Location = new System.Drawing.Point(104, 65);
      this.txtUserName.Name = "txtUserName";
      this.txtUserName.Size = new System.Drawing.Size(306, 20);
      this.txtUserName.TabIndex = 4;
      this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
      // 
      // radSQLAuthentication
      // 
      this.radSQLAuthentication.AutoSize = true;
      this.radSQLAuthentication.Location = new System.Drawing.Point(18, 42);
      this.radSQLAuthentication.Name = "radSQLAuthentication";
      this.radSQLAuthentication.Size = new System.Drawing.Size(176, 17);
      this.radSQLAuthentication.TabIndex = 1;
      this.radSQLAuthentication.Text = "User SQL Server Authentication";
      this.radSQLAuthentication.UseVisualStyleBackColor = true;
      this.radSQLAuthentication.CheckedChanged += new System.EventHandler(this.radSQLAuthentication_CheckedChanged);
      // 
      // lbUserName
      // 
      this.lbUserName.AutoSize = true;
      this.lbUserName.Enabled = false;
      this.lbUserName.Location = new System.Drawing.Point(35, 68);
      this.lbUserName.Name = "lbUserName";
      this.lbUserName.Size = new System.Drawing.Size(63, 13);
      this.lbUserName.TabIndex = 3;
      this.lbUserName.Text = "User Name:";
      // 
      // radWindowsAuthentication
      // 
      this.radWindowsAuthentication.AutoSize = true;
      this.radWindowsAuthentication.Checked = true;
      this.radWindowsAuthentication.Location = new System.Drawing.Point(18, 19);
      this.radWindowsAuthentication.Name = "radWindowsAuthentication";
      this.radWindowsAuthentication.Size = new System.Drawing.Size(165, 17);
      this.radWindowsAuthentication.TabIndex = 0;
      this.radWindowsAuthentication.TabStop = true;
      this.radWindowsAuthentication.Text = "User Windows Authentication";
      this.radWindowsAuthentication.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox2.Controls.Add(this.btnRefreshDatabase);
      this.groupBox2.Controls.Add(this.label4);
      this.groupBox2.Controls.Add(this.cmbDatabaseList);
      this.groupBox2.Location = new System.Drawing.Point(12, 159);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(416, 59);
      this.groupBox2.TabIndex = 3;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Connect to a database";
      // 
      // btnRefreshDatabase
      // 
      this.btnRefreshDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnRefreshDatabase.Location = new System.Drawing.Point(364, 23);
      this.btnRefreshDatabase.Name = "btnRefreshDatabase";
      this.btnRefreshDatabase.Size = new System.Drawing.Size(52, 23);
      this.btnRefreshDatabase.TabIndex = 8;
      this.btnRefreshDatabase.Text = "Refresh";
      this.btnRefreshDatabase.UseVisualStyleBackColor = true;
      this.btnRefreshDatabase.Click += new System.EventHandler(this.btnRefreshDatabase_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(15, 28);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(164, 13);
      this.label4.TabIndex = 7;
      this.label4.Text = "Select or enter a database name:";
      // 
      // cmbDatabaseList
      // 
      this.cmbDatabaseList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cmbDatabaseList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cmbDatabaseList.FormattingEnabled = true;
      this.cmbDatabaseList.Location = new System.Drawing.Point(185, 25);
      this.cmbDatabaseList.Name = "cmbDatabaseList";
      this.cmbDatabaseList.Size = new System.Drawing.Size(173, 21);
      this.cmbDatabaseList.TabIndex = 0;
      // 
      // btnTestConnection
      // 
      this.btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTestConnection.Location = new System.Drawing.Point(294, 224);
      this.btnTestConnection.Name = "btnTestConnection";
      this.btnTestConnection.Size = new System.Drawing.Size(134, 23);
      this.btnTestConnection.TabIndex = 4;
      this.btnTestConnection.Text = "Test Connection";
      this.btnTestConnection.UseVisualStyleBackColor = true;
      this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
      // 
      // btnOK
      // 
      this.btnOK.Enabled = false;
      this.btnOK.Location = new System.Drawing.Point(142, 357);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(75, 23);
      this.btnOK.TabIndex = 5;
      this.btnOK.Text = "OK";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.Location = new System.Drawing.Point(223, 357);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(75, 23);
      this.btnCancel.TabIndex = 6;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = true;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // groupBox3
      // 
      this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.groupBox3.Controls.Add(this.txtConnectionString);
      this.groupBox3.Location = new System.Drawing.Point(12, 253);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(416, 98);
      this.groupBox3.TabIndex = 7;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Connection String";
      // 
      // txtConnectionString
      // 
      this.txtConnectionString.Location = new System.Drawing.Point(6, 19);
      this.txtConnectionString.Multiline = true;
      this.txtConnectionString.Name = "txtConnectionString";
      this.txtConnectionString.ReadOnly = true;
      this.txtConnectionString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtConnectionString.Size = new System.Drawing.Size(404, 73);
      this.txtConnectionString.TabIndex = 0;
      this.txtConnectionString.TextChanged += new System.EventHandler(this.txtConnectionString_TextChanged);
      // 
      // ConnectionManager
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(440, 390);
      this.Controls.Add(this.groupBox3);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.btnTestConnection);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.txtServerName);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConnectionManager";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Connection Manager";
      this.Load += new System.EventHandler(this.ConnectionManager_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtServerName;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Label lbPassword;
    private System.Windows.Forms.TextBox txtUserName;
    private System.Windows.Forms.RadioButton radSQLAuthentication;
    private System.Windows.Forms.Label lbUserName;
    private System.Windows.Forms.RadioButton radWindowsAuthentication;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ComboBox cmbDatabaseList;
    private System.Windows.Forms.Button btnTestConnection;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.TextBox txtConnectionString;
    private System.Windows.Forms.Button btnRefreshDatabase;
  }
}