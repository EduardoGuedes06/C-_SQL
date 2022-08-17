using System;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{

    class ProgramS
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Encrypt=False";

        static void Main(string[] args)
        {        
            //CreateUser();
            UpdateUser();
            //DeleteUser();
            // ReadUser(repository);
            ReadUsers();
            //ReadWithRoles(connection);
        }


        static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }

        static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1); 
                Console.WriteLine(user.Name);
                
            }
        }

        static void CreateUser()
        {
            var user = new User()
            {
            Name = "Amanda",
            Email = "AmandaLuiza@gmail.com",
            PasswordHash = "HASH",
            Bio = "Equipe-Balta.io",
            Image = "https://...",
            Slug = "equipe-balta"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user);

                Console.WriteLine("Cadastro Realizado");
                
            }
        }

        static void UpdateUser()
        {
            var user = new User()
            {
                Id = 9,
                Name = "Amanda Luiza",
                Email = "AmandaLuiza@gmail.com",
                PasswordHash = "HASH",
                Bio = "Equipe-Balta.io",
                Image = "https://...",
                Slug = "equipe-balta"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user);

                Console.WriteLine("Atualização de cadastro de "+user.Name+ " Realizado");

            }
        }

        static void DeleteUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(8);
                connection.Delete<User>(user);

                Console.WriteLine("Decadastro Realizado do usuario: ");

            }
        }






    }


}