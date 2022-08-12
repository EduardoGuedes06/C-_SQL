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

            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Azure";
            category.Url = "Amazon.com";
            category.Description = "Destinado a AWS";
            category.Order = 8;
            category.Summary = "Zaas";
            category.Featured = false;

// SQL Injection
            var insertSql = @"INSERT INTO 
            [Category] 
                VALUES(NEWID(),
                    @Title, 
                    @Url, 
                    @Summary, 
                    @Order, 
                    @Description, 
                    @Featured)";

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
                {
                   var rows = connection.Execute(insertSql, new{
                        category.Id,
                        category.Title,
                        category.Url,
                        category.Order,
                        category.Summary,
                        category.Description,
                        category.Featured
                    });
                
                    Console.WriteLine($"{rows} linhas inseridas");

                }   //Usando o Dapper
                var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
                foreach(var item in categories)
                {
                    Console.WriteLine($"{item.Id} - {item.Title}");
                }
            
            }

        }
    }
}