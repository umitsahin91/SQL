using System;
using System.Data.SqlClient;

namespace DbSelect
{
    class Program
    {
        static void Main(string[] args)
        {
           GetAllProduct();
        }

         static void GetAllProduct()
        {
             using (var connection = GetSqlConnection())
            {
                try
                {
                   connection.Open();
                   System.Console.WriteLine("Bağlantı sağlandı"); 
                   string sql="select * from Urunler";
                   SqlCommand command =new SqlCommand(sql,connection);

                   var reader=command.ExecuteReader();
                   while (reader.Read())
                   {
                       System.Console.WriteLine($"Ürün Adı : {reader[1]} | Fiyat : {reader[5]}");
                   }
                   reader.Close();
                }
                catch(Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

          static SqlConnection GetSqlConnection()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";

           return new SqlConnection(connectionString);
        }
    }
}
