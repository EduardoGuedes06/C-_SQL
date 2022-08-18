using Blog.Models;
using Blog.Repositories;
using Blog.Screens.UserScreens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.TagScreens
{
    internal class DeleteTagScreen
    {
        public static void Load()
        {
            Console.Clear();


            Console.WriteLine("Deletando uma tag");
            Console.WriteLine("-------------");

            Console.Write("Qual o Id: ");
            var id = Console.ReadLine();

            Delete(int.Parse(id));
            Console.ReadKey();
            MenuTagScreens.Load();
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(DataBase.Connection);
                repository.Delete(id);
                Console.WriteLine("Tag deletada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
