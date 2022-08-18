using System;
using Blog.Models;
using Blog.Screens.TagScreens;
using Blog.Repositories;
using Microsoft.Data.SqlClient;
using Blog.Screens.UserScreens;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Encrypt=False";

        static void Main(string[] args)
        {
            DataBase.Connection = new SqlConnection(CONNECTION_STRING);

            DataBase.Connection.Open();

            Load();

            DataBase.Connection.Close();
            Console.ReadKey();
        }

        private static void Load() 
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Gestão de Usuarios");
            Console.WriteLine("2 - Gestão de Perfil");
            Console.WriteLine("3 - Gestão de Categoria");
            Console.WriteLine("4 - Gestão de Tags");
            Console.WriteLine("5 - Vincular Perfil/usuario");
            Console.WriteLine("6 - Vincular Post/Tag");
            Console.WriteLine("7 - Relatorios\n\n");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuTagScreens.Load();
                    break;
                case 2:
                    MenuTagScreens.Load();
                    break;
                case 3:
                    MenuTagScreens.Load();
                    break;
                case 4:
                    MenuTagScreens.Load();
                    break;
                case 5:
                    MenuTagScreens.Load();
                    break;
                case 6:
                    MenuTagScreens.Load();
                    break;
                case 7:
                    MenuTagScreens.Load();
                    break;
   


            }
        }

    }
}