using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLConnectionManager.Properties;

namespace SQLConnectionManager
{
  public class SQLConnectionManager
  {

    public static bool TestConnection(string connectionString)
    {
      
      using (var sqlConnection = new SqlConnection(connectionString))
      {
        try
        {
          sqlConnection.Open();
          return true;
        }
        catch (SqlException ex)
        {
          throw ex;
        }
      }
    }

    public static List<string> GetDatabaseList(string connectionString)
    {
      var databaseList = new List<string>();
      using (var sqlConnection = new SqlConnection(connectionString))
      {
        sqlConnection.Open();
        using (var sqlCommand = new SqlCommand(Resources.SQL_GetDatabases, sqlConnection))
        {
          var reader = sqlCommand.ExecuteReader();
          while (reader.Read())
          {
            var databaseName = reader["name"] == DBNull.Value ? string.Empty : reader["name"].ToString();
            databaseList.Add(databaseName);
          }
        }

        sqlConnection.Close();
      }

      return databaseList;
    }

    public static List<string> GetTableList(string connectionString)
    {
      var tableList = new List<string>();
      try
      {
        using (var sqlConnection = new SqlConnection(connectionString))
        {
          sqlConnection.Open();
          var tableListDataTable = sqlConnection.GetSchema("Tables");
          var reader = tableListDataTable.CreateDataReader();
          while (reader.Read())
          {
            if (reader[2] == DBNull.Value)
            {
              break;
            }

            tableList.Add(string.Format("[{0}].[{1}]", reader[1].ToString(), reader[2].ToString()));
          }

          sqlConnection.Close();
        }
      }
      catch (Exception)
      {

        throw;
      }

      return tableList;
    }

    public static List<string> GetViewList(string connectionString)
    {
      var viewList = new List<string>();
      try
      {
        using (var sqlConnection = new SqlConnection(connectionString))
        {
          sqlConnection.Open();
          var tableListDataTable = sqlConnection.GetSchema("Views");
          var reader = tableListDataTable.CreateDataReader();
          while (reader.Read())
          {
            if (reader[2] == DBNull.Value)
            {
              break;
            }

            viewList.Add(string.Format("[{0}].[{1}]", reader[1].ToString(),reader[2].ToString()));
          }
          sqlConnection.Close();
        }
      }
      catch (Exception)
      {

        throw;
      }

      return viewList;
    }

    public static DataTable GetTableData(string connectionString, string tableName)
    {
      DataTable result = null;

      try
      {
        using (var sqlConnection = new SqlConnection(connectionString))
        {
          sqlConnection.Open();
          var command = string.Format("SELECT * FROM {0}", tableName);

          using (var sqlAdapter = new SqlDataAdapter(command, sqlConnection))
          {
            result = new DataTable();
            sqlAdapter.Fill(result);
          }

          sqlConnection.Close();
        }
      }
      catch (Exception)
      {
        throw;
      }

      return result;
    }

    public static DataTable ExecuteQuery(string connectionString, string query)
    {
      DataTable result = null;

      try
      {
        using (var sqlConnection = new SqlConnection(connectionString))
        {
          sqlConnection.Open();
          var command = query;

          using (var sqlAdapter = new SqlDataAdapter(command, sqlConnection))
          {
            result = new DataTable();
            sqlAdapter.Fill(result);
          }

          sqlConnection.Close();
        }
      }
      catch (Exception)
      {
        throw;
      }

      return result;
    }

  }
}
