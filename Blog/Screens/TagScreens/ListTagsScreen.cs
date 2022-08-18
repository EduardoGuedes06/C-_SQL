using System;
using Blog.Repositories;
using Blog.Screens.TagScreens;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Screens.UserScreens;

namespace Blog.Screens.TagScreens
{
    internal class ListTagsScreen
    {

        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de tags");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuTagScreens.Load();
        }

        private static void List()
        {
            var repository = new Repository<Tag>(DataBase.Connection);

            var tags = repository.Get();
            foreach (var item in tags)
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");





        }




    }
}
