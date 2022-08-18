using System;
using Blog.Screens.TagScreens;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Screens.UserScreens
{
    internal class MenuTagScreens
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de tags");
            Console.WriteLine("----------------");
            Console.WriteLine("O que deseja fazer?\n");
            Console.WriteLine("1 - Listar tags");
            Console.WriteLine("2 - Cadastrar Tags");
            Console.WriteLine("3 - Atualizar tags");
            Console.WriteLine("4 - Deletar Tags\n\n");
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListTagsScreen.Load();
                    break;
                case 2:
                    CreateTagScreen.Load();
                    break;
                case 3:
                    UpdateTagScreen.Load();
                    break;
                case 4:
                    DeleteTagScreen.Load();
                    break;
                default: Load(); break;
            }



        }
    }
}
