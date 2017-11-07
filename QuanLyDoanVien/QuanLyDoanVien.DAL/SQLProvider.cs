using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyDoanVien.DAL
{
    public class SQLProvider
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["QuanLyDoanVien"].ConnectionString;

        public static DataTable Query(string storedProcedureName, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();

            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(storedProcedureName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        foreach (var item in parameters)
                            cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return dt;
        }

        public static bool Execute(string storedProcedureName, out string message, Dictionary<string, object> parameters = null)
        {
            message = "Unknown error";
            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(storedProcedureName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (parameters != null)
                    {
                        foreach (var item in parameters)
                            cmd.Parameters.AddWithValue(item.Key, item.Value);
                    }

                    var returnMessParam = new SqlParameter();
                    returnMessParam.ParameterName = "ReturnMess";
                    returnMessParam.Size = 255;
                    returnMessParam.SqlDbType = SqlDbType.NVarChar;
                    returnMessParam.Value = string.Empty;
                    returnMessParam.Direction = ParameterDirection.InputOutput;
                    cmd.Parameters.Add(returnMessParam);

                    int effectedRow = cmd.ExecuteNonQuery();
                    if (effectedRow > 0)
                    {
                        message = cmd.Parameters["ReturnMess"].Value + string.Empty;
                        return string.IsNullOrEmpty(message);
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    conn.Close();
                }
            }

            return false;
        }
    }
}
