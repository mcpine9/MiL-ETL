using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace IngramDataConnect.ETL.Utility
{
    static class BulkCopyToDB
    {

        public static void BulkCopyDataTableToTempTable(DataTable dt, ref bool failure)
        {
            CreateTable(ref failure);

            if (!failure)
                {
                var connectionString = ConfigurationManager.ConnectionStrings["MyiLibrary"].ConnectionString;

                try
                {
                    using (var connection =
                        new SqlConnection(connectionString))
                    {
                        connection.Open();

                        using (var bulkCopy = new SqlBulkCopy(connection))
                        {
                            bulkCopy.DestinationTableName = ConfigurationManager.AppSettings["DestinationTable"];
                            bulkCopy.WriteToServer(dt);
                        }
                    }
                    Console.WriteLine("BulkCopy was Successful.");
                }
                catch (Exception e)
                {
                    failure = true;
                    Console.WriteLine("There was an error in 'BulkCopyDataTableToTempTable()': " + e.Message);
                }
            }
        }

        public static void CreateTable(ref bool failure)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyiLibrary"].ConnectionString))
                using (var command = new SqlCommand(ConfigurationManager.AppSettings["SProc"], conn)
                {
                    CommandType = CommandType.StoredProcedure
                })
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    Console.WriteLine("Created Table Successfully.");
                }
            }
            catch (Exception e)
            {
                failure = true;
                Console.WriteLine("There was an error creating the new update table:" + e.Message);
            }
        }
    }
}
