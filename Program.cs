using System;
using BaltaCourse.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BaltaCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$;Encrypt=False";

            using (var connection = new SqlConnection(connectionString))
            {
                //connection.Open();
                //Console.WriteLine("Conectado");
                // using (var command = new SqlCommand())
                // {
                //     command.Connection = connection;
                //     command.CommandType = System.Data.CommandType.Text;
                //     command.CommandText = "SELECT [Id], [Title] FROM [Category]";
                //     var reader = command.ExecuteReader();
                //     while (reader.Read())
                //     {
                //         Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                //     }


                    //Usando o Dapper:
                    var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
                    foreach(var category in categories)
                    {
                        Console.WriteLine($"{category.Id} - {category.Title}");
                    }
            
            }

        }
    }
}