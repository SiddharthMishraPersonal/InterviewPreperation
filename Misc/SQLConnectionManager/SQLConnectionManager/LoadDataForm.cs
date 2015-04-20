using System;
using System.Windows.Forms;
using SQLConnectionManager.Properties;

namespace SQLConnectionManager
{
  public partial class LoadDataForm : Form
  {
    private string _connectionString = string.Empty;

    public LoadDataForm()
    {
      InitializeComponent();
    }

    private void btnCreateConnectionString_Click(object sender, EventArgs e)
    {
      var connectionManager = new ConnectionManager();
      connectionManager.ShowDialog(this);
      _connectionString = connectionManager.ConnectionString;
      connectionManager.Dispose();

      if (string.IsNullOrEmpty(_connectionString)) return;

      txtConnectionString.Text = _connectionString;
      BindTables(_connectionString);
      BindViews(_connectionString);
    }


    private void radFromTable_CheckedChanged(object sender, EventArgs e)
    {
      var radTable = sender as RadioButton;
      if (radTable == null)
        return;

      cmbTableList.Enabled = radTable.Checked;
    }

    private void radFromView_CheckedChanged(object sender, EventArgs e)
    {
      var radView = sender as RadioButton;
      if (radView == null)
        return;

      cmbViewList.Enabled = radView.Checked;
    }

    private void radFromQuery_CheckedChanged(object sender, EventArgs e)
    {
      var radQuery = sender as RadioButton;
      if (radQuery == null)
        return;

      txtFromQuery.Enabled = radQuery.Checked;
    }

    private void txtFromQuery_TextChanged(object sender, EventArgs e)
    {
      var txtQuery = sender as TextBox;
      if (txtQuery == null)
        return;

      btnLoadData.Enabled = !string.IsNullOrEmpty(txtQuery.Text);

    }

    private void cmbTableList_SelectedIndexChanged(object sender, EventArgs e)
    {
      var cmbTable = sender as ComboBox;
      if (cmbTable == null)
        return;

      btnLoadData.Enabled = cmbTable.SelectedItem != null;
    }

    private void cmbViewList_SelectedIndexChanged(object sender, EventArgs e)
    {
      var cmbView = sender as ComboBox;
      if (cmbView == null)
        return;

      btnLoadData.Enabled = cmbView.SelectedItem != null;
    }

    private void txtConnectionString_TextChanged(object sender, EventArgs e)
    {
      var textBoxConnectionString = sender as TextBox;
      if (textBoxConnectionString == null)
        return;

      grpBoxLoadData.Enabled = !string.IsNullOrEmpty(textBoxConnectionString.Text);
      btnTestConnectionToSQL.Enabled = !string.IsNullOrEmpty(textBoxConnectionString.Text);
    }

    private void btnTestConnectionToSQL_Click(object sender, EventArgs e)
    {
      try
      {
        if (string.IsNullOrEmpty(_connectionString))
        {
          MessageBox.Show(this, Resources.Server_Database_Required, Resources.Test_Connection, MessageBoxButtons.OK,
            MessageBoxIcon.Error);
          return;
        }
        var connectionString = _connectionString;
        SQLConnectionManager.TestConnection(connectionString);
        MessageBox.Show(this, Resources.Connection_Successful, Resources.Test_Connection, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        BindTables(connectionString);
      }
      catch (Exception ex)
      {
        MessageBox.Show(this, ex.Message, Resources.Test_Connection, MessageBoxButtons.OK,
            MessageBoxIcon.Error);

      }
    }

    private void BindTables(string connectionString)
    {
      var tableList = SQLConnectionManager.GetTableList(connectionString);
      cmbTableList.DataSource = tableList;
    }

    private void BindViews(string connectionString)
    {
      var viewList = SQLConnectionManager.GetViewList(connectionString);
      cmbViewList.DataSource = viewList;
    }

    private void btnLoadData_Click(object sender, EventArgs e)
    {
      try
      {
        _connectionString = txtConnectionString.Text;

        if (radFromQuery.Checked)
        {
          var query = txtFromQuery.Text;
          if (string.IsNullOrEmpty(query))
          {
            MessageBox.Show(this, "Please provide a query to execute.", "Load Data", MessageBoxButtons.OK,
              MessageBoxIcon.Error);
            return;
          }

          dtGrdView.DataSource = SQLConnectionManager.ExecuteQuery(_connectionString, query);


          return;
        }


        var table = string.Empty;

        if (radFromTable.Checked)
          table = cmbTableList.SelectedItem.ToString();

        if (radFromView.Checked)
          table = cmbViewList.SelectedItem.ToString();

        dtGrdView.DataSource = SQLConnectionManager.GetTableData(_connectionString, table);

      }
      catch (Exception ex)
      {
        MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
