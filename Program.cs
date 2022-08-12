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
                //Usando o Dapper


                UpdadteCategories(connection);
                ListCategories(connection);
                //CreateCategory(connection);
            
            }

        }


        static void ListCategories(SqlConnection connection)
        {
            var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Title}");
            }
        }


        static void CreateCategory(SqlConnection connection)
        {
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
            var rows = connection.Execute(insertSql, new
            {
                category.Id,
                category.Title,
                category.Url,
                category.Order,
                category.Summary,
                category.Description,
                category.Featured
            });
            Console.WriteLine($"{rows} linhas inseridas");
        }

        static void UpdadteCategories(SqlConnection connection)
        {
            var updateQuery = "UPDATE [category] SET [Title]=@title WHERE [Id]=@id";
            var rows = connection.Execute(updateQuery, new
            {
                id = new Guid("d3894278-bf5c-4ce6-8a31-ae6bf0afaadd"),
                title = "Forntend 2022"
            });
            Console.WriteLine("Registro Atualizado");
        }

    }
}