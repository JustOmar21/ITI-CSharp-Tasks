using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics;


namespace DAL
{
    public class DBManager
    {
        SqlConnection SqlCN;
        SqlCommand SqlCmd;
        SqlDataAdapter DA;
        DataTable Dt;

        public DBManager()
        {
            try
            {
                SqlCN = new();
                SqlCN.ConnectionString = ConfigurationManager.ConnectionStrings["NorthEastCN"].ConnectionString;
                SqlCmd = new(string.Empty, SqlCN);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                DA = new(SqlCmd);
                Dt = new();
            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
        }

        public DataTable ExecuteDataTable(string SPName)
        {
            try
            {
                SqlCmd.Parameters.Clear();
                Dt.Clear();

                SqlCmd.CommandText = SPName;

                DA.Fill(Dt);
                return Dt;

            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return new();
        }
        public object ExecuteScaler(string SPName)
        {
            try
            {
                SqlCmd.Parameters.Clear();
                SqlCmd.CommandText = SPName;

                if (SqlCN.State == ConnectionState.Closed)
                    SqlCN.Open();

                return SqlCmd.ExecuteScalar();

            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            finally
            {
                SqlCN.Close();
            }
            return new();
        }
        public int ExecuteNonQuery(string SPName)
        {
            try
            {
                SqlCmd.Parameters.Clear();
                SqlCmd.CommandText = SPName;

                if (SqlCN.State == ConnectionState.Closed)
                    SqlCN.Open();

                return SqlCmd.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            finally
            {
                SqlCN.Close();
            }
            return -1;
        }

        public object ExecuteScaler(string SPName, Dictionary<string, object> Parameters)
        {
            try
            {
                SqlCmd.Parameters.Clear();
                SqlCmd.CommandText = SPName;

                foreach(KeyValuePair<string, object> param in Parameters)
                {
                    SqlCmd.Parameters.Add(new SqlParameter(param.Key,param.Value));
                }

                if (SqlCN.State == ConnectionState.Closed)
                    SqlCN.Open();

                return SqlCmd.ExecuteScalar();

            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            finally
            {
                SqlCN.Close();
            }
            return new();
        }

        public DataTable ExecuteDataTable(string SPName, Dictionary<string, object> Parameters)
        {
            try
            {
                SqlCmd.Parameters.Clear();
                Dt.Clear();

                SqlCmd.CommandText = SPName;
                foreach (KeyValuePair<string, object> param in Parameters)
                {
                    SqlCmd.Parameters.Add(new SqlParameter(param.Key, param.Value));
                }

                DA.Fill(Dt);
                return Dt;

            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            return new();
        }

        public int ExecuteNonQuery(string SPName, Dictionary<string, object> Parameters)
        {
            try
            {
                SqlCmd.Parameters.Clear();
                SqlCmd.CommandText = SPName;

                foreach (var Parameter in Parameters)
                    SqlCmd.Parameters.Add(new(Parameter.Key, Parameter.Value));

                if (SqlCN.State == ConnectionState.Closed)
                    SqlCN.Open();

                return SqlCmd.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Debug.WriteLine(Ex.Message);
            }
            finally
            {
                SqlCN.Close();
            }
            return -1;
        }

    }
}
