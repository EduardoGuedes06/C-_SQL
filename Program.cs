using System;
using Microsoft.Data.SqlClient;

namespace Balta_Course
{

    class Program
    {

        static void Main(string[] args)
        {
            const string ConnectionString = "Server=localhost,1433;Database=balta;User ID=sa;Passworld=1q2w3e4r@#$";

            var connection = new SqlConnection(ConnectionString);
            {
                Console.WriteLine("Conectado");
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT [Id], [Title] FROM [Category]";

                    var reader = command.ExecuteReader();
                    while (reader.Read())
                        Console.WriteLine($"{reader.GetGuid(0)} - {reader.GetString(1)}");
                }
            }
        }

    }
}