using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UltimateRevisionPlannerWebsite
{
    public partial class SqlHelper
    {
        public static object ExecuteSqlStoredProcedureReturnValue(string storedProcedure, List<SqlParameter> parameters)
        {
            System.Configuration.Configuration rootWebConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Web");
            System.Configuration.ConnectionStringSettings connString;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString =
                    rootWebConfig.ConnectionStrings.ConnectionStrings["DefaultConnection"];

                using (var conn = new SqlConnection(connString.ConnectionString))
                {
                    var cmd = new SqlCommand(storedProcedure, conn) { CommandType = CommandType.StoredProcedure };
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                    }
                    cmd.Connection.Open();
                    var obj = cmd.ExecuteScalar();
                    return obj;
                }
            }
            return null;
        }

        public static DataTable ExecuteSqlStoredProcedureReturnDataTable(string storedProcedure, List<SqlParameter> parameters)
        {
            System.Configuration.Configuration rootWebConfig =
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/Web");
            System.Configuration.ConnectionStringSettings connString;
            if (rootWebConfig.ConnectionStrings.ConnectionStrings.Count > 0)
            {
                connString =
                    rootWebConfig.ConnectionStrings.ConnectionStrings["DefaultConnection"];

                SqlConnection myConnection = new SqlConnection(connString.ConnectionString);
                SqlCommand cmd = new SqlCommand(storedProcedure, myConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                myConnection.Open();

                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(param.ParameterName, param.Value));
                    }
                }

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                DataTable dt = new DataTable();
                dt.Load(dr);

                return dt;
            }
            return null;
        }
    }
}