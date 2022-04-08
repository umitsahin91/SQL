using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DbSelect
{
    class Program
    {
        static void Main(string[] args)
        {
            var products = GetAllProduct();

            foreach (var product in products)
            {
                if (product.ProductPrice > 10)
                    System.Console.WriteLine($"Id : {product.ProductId} Name : {product.ProductName} Price : {product.ProductPrice}");
            }
        }

        static List<Product> GetAllProduct()
        {
            List<Product> products = null;
            using (var connection = GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    string sql = "select * from Urunler";
                    SqlCommand command = new SqlCommand(sql, connection);

                    var reader = command.ExecuteReader();

                    products = new List<Product>();
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            ProductId = (int)reader["UrunID"],
                            ProductName = reader["UrunAdi"].ToString(),
                            ProductPrice = (decimal)reader["BirimFiyati"]
                        });
                    }
                    reader.Close();
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
            return products;
        }

        static SqlConnection GetSqlConnection()
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;";

            return new SqlConnection(connectionString);
        }
    }
}
