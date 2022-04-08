using System;
using System.Data.SqlClient;

namespace DbConnection
{
    class Program
    {
        static void Main(string[] args)
        {
            GetSqlConnection();
        }
        static void GetSqlConnection()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";

            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    System.Console.WriteLine("Bağlantı sağlandı");

                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}