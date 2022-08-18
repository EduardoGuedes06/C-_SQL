using System;
using Blog.Models;
using Blog.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Screens.UserScreens;

namespace Blog.Screens.TagScreens
{
    public static class CreateTagScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Nova tag");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new Tag
            {
                Name = name,
                Slug = slug
            });
            Console.ReadKey();
            MenuTagScreens.Load();
        }

        public static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>(DataBase.Connection);
                repository.Create(tag);
                Console.WriteLine("Tag cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar a tag");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
