using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBL
{
    internal class MenuByList
    {
        string name;
        string[] items;
        public MenuByList(string name, string fItem, params string[] items)
        {
            this.name = name;

            this.items = new string[items.Length + 1];
            this.items[0] = fItem;
            for (int i = 0; i < items.Length; i++)
            {
                this.items[i + 1] = items[i];
            }
        }
        void PrintMenu(int chise)
        {
            Console.WriteLine($"\n\t{name}:");
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine($"\t {(chise == i ? ">" : "")} {items[i]};");
            }
        }
        public int GetChoice()
        {
            int chise = 0;
            while (true)
            {
                Console.Clear();
                PrintMenu(chise);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow: chise = (chise == 0 ? items.Length - 1 : chise - 1); break;
                    case ConsoleKey.DownArrow: chise = (chise == items.Length - 1 ? 0 : chise + 1); break;
                    case ConsoleKey.Enter: Console.Clear(); return chise;
                }
            }
        }
    }
}