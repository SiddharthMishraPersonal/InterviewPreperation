namespace SQLConnectionManager
{
  partial class LoadDataForm
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
      this.txtConnectionString = new System.Windows.Forms.TextBox();
      this.btnCreateConnectionString = new System.Windows.Forms.Button();
      this.btnTestConnectionToSQL = new System.Windows.Forms.Button();
      this.grpBoxLoadData = new System.Windows.Forms.GroupBox();
      this.txtFromQuery = new System.Windows.Forms.TextBox();
      this.radFromQuery = new System.Windows.Forms.RadioButton();
      this.cmbViewList = new System.Windows.Forms.ComboBox();
      this.radFromView = new System.Windows.Forms.RadioButton();
      this.cmbTableList = new System.Windows.Forms.ComboBox();
      this.radFromTable = new System.Windows.Forms.RadioButton();
      this.btnLoadData = new System.Windows.Forms.Button();
      this.btnClose = new System.Windows.Forms.Button();
      this.dtGrdView = new System.Windows.Forms.DataGridView();
      this.grpBoxLoadData.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dtGrdView)).BeginInit();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(12, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(92, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Connection string:";
      // 
      // txtConnectionString
      // 
      this.txtConnectionString.Location = new System.Drawing.Point(110, 6);
      this.txtConnectionString.Name = "txtConnectionString";
      this.txtConnectionString.Size = new System.Drawing.Size(403, 20);
      this.txtConnectionString.TabIndex = 1;
      this.txtConnectionString.TextChanged += new System.EventHandler(this.txtConnectionString_TextChanged);
      // 
      // btnCreateConnectionString
      // 
      this.btnCreateConnectionString.Location = new System.Drawing.Point(519, 4);
      this.btnCreateConnectionString.Name = "btnCreateConnectionString";
      this.btnCreateConnectionString.Size = new System.Drawing.Size(75, 23);
      this.btnCreateConnectionString.TabIndex = 2;
      this.btnCreateConnectionString.Text = "Create";
      this.btnCreateConnectionString.UseVisualStyleBackColor = true;
      this.btnCreateConnectionString.Click += new System.EventHandler(this.btnCreateConnectionString_Click);
      // 
      // btnTestConnectionToSQL
      // 
      this.btnTestConnectionToSQL.Enabled = false;
      this.btnTestConnectionToSQL.Location = new System.Drawing.Point(497, 32);
      this.btnTestConnectionToSQL.Name = "btnTestConnectionToSQL";
      this.btnTestConnectionToSQL.Size = new System.Drawing.Size(97, 23);
      this.btnTestConnectionToSQL.TabIndex = 3;
      this.btnTestConnectionToSQL.Text = "Test Connection";
      this.btnTestConnectionToSQL.UseVisualStyleBackColor = true;
      this.btnTestConnectionToSQL.Click += new System.EventHandler(this.btnTestConnectionToSQL_Click);
      // 
      // grpBoxLoadData
      // 
      this.grpBoxLoadData.Controls.Add(this.txtFromQuery);
      this.grpBoxLoadData.Controls.Add(this.radFromQuery);
      this.grpBoxLoadData.Controls.Add(this.cmbViewList);
      this.grpBoxLoadData.Controls.Add(this.radFromView);
      this.grpBoxLoadData.Controls.Add(this.cmbTableList);
      this.grpBoxLoadData.Controls.Add(this.radFromTable);
      this.grpBoxLoadData.Enabled = false;
      this.grpBoxLoadData.Location = new System.Drawing.Point(15, 62);
      this.grpBoxLoadData.Name = "grpBoxLoadData";
      this.grpBoxLoadData.Size = new System.Drawing.Size(579, 188);
      this.grpBoxLoadData.TabIndex = 4;
      this.grpBoxLoadData.TabStop = false;
      this.grpBoxLoadData.Text = "Load data from database";
      // 
      // txtFromQuery
      // 
      this.txtFromQuery.Enabled = false;
      this.txtFromQuery.Location = new System.Drawing.Point(106, 74);
      this.txtFromQuery.Multiline = true;
      this.txtFromQuery.Name = "txtFromQuery";
      this.txtFromQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtFromQuery.Size = new System.Drawing.Size(467, 108);
      this.txtFromQuery.TabIndex = 5;
      this.txtFromQuery.TextChanged += new System.EventHandler(this.txtFromQuery_TextChanged);
      // 
      // radFromQuery
      // 
      this.radFromQuery.AutoSize = true;
      this.radFromQuery.Location = new System.Drawing.Point(16, 74);
      this.radFromQuery.Name = "radFromQuery";
      this.radFromQuery.Size = new System.Drawing.Size(82, 17);
      this.radFromQuery.TabIndex = 4;
      this.radFromQuery.Text = "Build Query:";
      this.radFromQuery.UseVisualStyleBackColor = true;
      this.radFromQuery.CheckedChanged += new System.EventHandler(this.radFromQuery_CheckedChanged);
      // 
      // cmbViewList
      // 
      this.cmbViewList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cmbViewList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cmbViewList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbViewList.Enabled = false;
      this.cmbViewList.FormattingEnabled = true;
      this.cmbViewList.Location = new System.Drawing.Point(106, 45);
      this.cmbViewList.Name = "cmbViewList";
      this.cmbViewList.Size = new System.Drawing.Size(208, 21);
      this.cmbViewList.TabIndex = 3;
      this.cmbViewList.SelectedIndexChanged += new System.EventHandler(this.cmbViewList_SelectedIndexChanged);
      // 
      // radFromView
      // 
      this.radFromView.AutoSize = true;
      this.radFromView.Location = new System.Drawing.Point(16, 46);
      this.radFromView.Name = "radFromView";
      this.radFromView.Size = new System.Drawing.Size(76, 17);
      this.radFromView.TabIndex = 2;
      this.radFromView.Text = "From view:";
      this.radFromView.UseVisualStyleBackColor = true;
      this.radFromView.CheckedChanged += new System.EventHandler(this.radFromView_CheckedChanged);
      // 
      // cmbTableList
      // 
      this.cmbTableList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
      this.cmbTableList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
      this.cmbTableList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbTableList.FormattingEnabled = true;
      this.cmbTableList.Location = new System.Drawing.Point(106, 18);
      this.cmbTableList.Name = "cmbTableList";
      this.cmbTableList.Size = new System.Drawing.Size(208, 21);
      this.cmbTableList.TabIndex = 1;
      this.cmbTableList.SelectedIndexChanged += new System.EventHandler(this.cmbTableList_SelectedIndexChanged);
      // 
      // radFromTable
      // 
      this.radFromTable.AutoSize = true;
      this.radFromTable.Checked = true;
      this.radFromTable.Location = new System.Drawing.Point(16, 19);
      this.radFromTable.Name = "radFromTable";
      this.radFromTable.Size = new System.Drawing.Size(77, 17);
      this.radFromTable.TabIndex = 0;
      this.radFromTable.TabStop = true;
      this.radFromTable.Text = "From table:";
      this.radFromTable.UseVisualStyleBackColor = true;
      this.radFromTable.CheckedChanged += new System.EventHandler(this.radFromTable_CheckedChanged);
      // 
      // btnLoadData
      // 
      this.btnLoadData.Enabled = false;
      this.btnLoadData.Location = new System.Drawing.Point(519, 256);
      this.btnLoadData.Name = "btnLoadData";
      this.btnLoadData.Size = new System.Drawing.Size(75, 23);
      this.btnLoadData.TabIndex = 5;
      this.btnLoadData.Text = "Load Data";
      this.btnLoadData.UseVisualStyleBackColor = true;
      this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
      // 
      // btnClose
      // 
      this.btnClose.Location = new System.Drawing.Point(271, 526);
      this.btnClose.Name = "btnClose";
      this.btnClose.Size = new System.Drawing.Size(75, 23);
      this.btnClose.TabIndex = 6;
      this.btnClose.Text = "Close";
      this.btnClose.UseVisualStyleBackColor = true;
      this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
      // 
      // dtGrdView
      // 
      this.dtGrdView.AllowUserToOrderColumns = true;
      this.dtGrdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dtGrdView.Location = new System.Drawing.Point(15, 285);
      this.dtGrdView.Name = "dtGrdView";
      this.dtGrdView.Size = new System.Drawing.Size(579, 235);
      this.dtGrdView.TabIndex = 7;
      // 
      // LoadDataForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(606, 561);
      this.Controls.Add(this.dtGrdView);
      this.Controls.Add(this.btnClose);
      this.Controls.Add(this.btnLoadData);
      this.Controls.Add(this.grpBoxLoadData);
      this.Controls.Add(this.btnTestConnectionToSQL);
      this.Controls.Add(this.btnCreateConnectionString);
      this.Controls.Add(this.txtConnectionString);
      this.Controls.Add(this.label1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "LoadDataForm";
      this.Text = "Load Data";
      this.grpBoxLoadData.ResumeLayout(false);
      this.grpBoxLoadData.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dtGrdView)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtConnectionString;
    private System.Windows.Forms.Button btnCreateConnectionString;
    private System.Windows.Forms.Button btnTestConnectionToSQL;
    private System.Windows.Forms.GroupBox grpBoxLoadData;
    private System.Windows.Forms.RadioButton radFromQuery;
    private System.Windows.Forms.ComboBox cmbViewList;
    private System.Windows.Forms.RadioButton radFromView;
    private System.Windows.Forms.ComboBox cmbTableList;
    private System.Windows.Forms.RadioButton radFromTable;
    private System.Windows.Forms.Button btnLoadData;
    private System.Windows.Forms.Button btnClose;
    private System.Windows.Forms.TextBox txtFromQuery;
    private System.Windows.Forms.DataGridView dtGrdView;
  }
}

