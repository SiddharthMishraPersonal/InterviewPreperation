using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.Mime;
using System.Windows.Forms;
using SQLConnectionManager.Properties;

namespace SQLConnectionManager
{
  public partial class ConnectionManager : Form
  {
    private string _connectionString = string.Empty;
    private string _serverName = string.Empty;
    private string _userName = string.Empty;
    private string _password = string.Empty;
    private string _selectedDatabase = string.Empty;
    private List<string> _databaseList = new List<string>();

    public ConnectionManager()
    {
      InitializeComponent();
    }

    public string ConnectionString
    {
      get { return _connectionString; }
      private set { _connectionString = value; }
    }

    public string SelectedDatabase
    {
      get { return _selectedDatabase; }
      set { _selectedDatabase = value; }
    }

    private void radSQLAuthentication_CheckedChanged(object sender, EventArgs e)
    {
      var radSQL = sender as RadioButton;

      if (radSQL == null)
        return;

      var enable = radSQL.Checked;
      EnableSQLAuthentication(enable);

      btnTestConnection.Enabled = (!string.IsNullOrEmpty(_userName) && !string.IsNullOrEmpty(_password));
    }

    private void EnableSQLAuthentication(bool enable)
    {
      lbUserName.Enabled = enable;
      lbPassword.Enabled = enable;
      txtUserName.Enabled = enable;
      txtPassword.Enabled = enable;
    }


    private void btnOK_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      ConnectionString = string.Empty;
      this.Close();
    }

    private void btnTestConnection_Click(object sender, EventArgs e)
    {
      try
      {
        _serverName = txtServerName.Text;
        SelectedDatabase = cmbDatabaseList.Text;
        _userName = txtUserName.Text;
        _password = txtPassword.Text;

        if (string.IsNullOrEmpty(_serverName) && string.IsNullOrEmpty(SelectedDatabase))
        {
          MessageBox.Show(this, Resources.Server_Database_Required, Resources.Test_Connection, MessageBoxButtons.OK,
            MessageBoxIcon.Error);
          return;
        }

        if (string.IsNullOrEmpty(_serverName))
        {
          MessageBox.Show(this, Resources.Server_Required, Resources.Test_Connection, MessageBoxButtons.OK,
            MessageBoxIcon.Error);
          return;
        }

        if (string.IsNullOrEmpty(SelectedDatabase))
        {
          MessageBox.Show(this, Resources.Database_Required, Resources.Test_Connection, MessageBoxButtons.OK,
            MessageBoxIcon.Error);
          return;
        }

        var connectionString = GetConnectionString();
        txtConnectionString.Text = connectionString;
        SQLConnectionManager.TestConnection(connectionString);
        MessageBox.Show(this, Resources.Connection_Successful, Resources.Test_Connection, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


      }
      catch (Exception ex)
      {
        MessageBox.Show(this, ex.Message, Resources.Test_Connection, MessageBoxButtons.OK,
            MessageBoxIcon.Error);

      }

    }

    private string GetConnectionString()
    {
      if (!radSQLAuthentication.Checked)
      {
        ConnectionString = string.Format("Server={0};Database={1};Trusted_Connection=True;", _serverName,
          SelectedDatabase);
      }
      else
      {
        ConnectionString = string.Format("Server={0};Database={1};User Id={2};Password={3};", _serverName,
          SelectedDatabase, _userName, _password);
      }

      return ConnectionString;
    }

    private void ConnectionManager_Load(object sender, EventArgs e)
    {
      _serverName = txtServerName.Text;

      if (string.IsNullOrEmpty(_serverName) || !radWindowsAuthentication.Checked) return;

      var connectionString = GetConnectionString();
      RefreshDatabaseList(connectionString);
      GetConnectionString();
    }

    private void RefreshDatabaseList(string connectionString)
    {
      try
      {
        _databaseList.Clear();
        _databaseList = SQLConnectionManager.GetDatabaseList(connectionString);
        cmbDatabaseList.DataSource = _databaseList;
      }
      catch (Exception ex)
      {
        Trace.WriteLine(ex);
      }
    }



    private void btnRefreshDatabase_Click(object sender, EventArgs e)
    {
      var connectionString = GetConnectionString();
      RefreshDatabaseList(connectionString);
    }

    private void txtUserName_TextChanged(object sender, EventArgs e)
    {
      var txtUser = sender as TextBox;
      if (txtUser == null)
        return;

      btnTestConnection.Enabled = (!string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtPassword.Text));
    }

    private void txtPassword_TextChanged(object sender, EventArgs e)
    {
      var txtPass = sender as TextBox;
      if (txtPass == null)
        return;

      btnTestConnection.Enabled = (!string.IsNullOrEmpty(txtPass.Text) && !string.IsNullOrEmpty(txtPassword.Text));
    }

    private void txtConnectionString_TextChanged(object sender, EventArgs e)
    {
      var txtConnectionStr = sender as TextBox;
      if (txtConnectionStr == null)
        return;

      btnOK.Enabled = !string.IsNullOrEmpty(txtConnectionStr.Text);
    }
  }
}
