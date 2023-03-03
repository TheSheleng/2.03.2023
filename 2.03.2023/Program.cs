using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using MBL;

namespace _2._03._2023
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var MeinMenu = new MenuByList("Main menu:",
                "Add",
                "Delete",
                "Change",
                "Search",
                "Save",
                "Load"
            );

            var verses = new List<Verse>();

            while ( true )
            {
                switch (MeinMenu.GetChoice()) 
                {
                case 0: //Add
                {
                    Console.WriteLine("\n\tFill in the fields:");
                    var verse = new Verse();

                    Console.Write("Name: ");
                    verse.Name = Console.ReadLine();
                    Console.Write("Author: ");
                    verse.Author = Console.ReadLine();
                    Console.Write("Year: ");
                    verse.Year = int.Parse(Console.ReadLine());
                    Console.Write("Text: ");
                    verse.Text = Console.ReadLine();
                    Console.Write("Theme: ");
                    verse.Theme = Console.ReadLine();

                    verses.Add(verse);
                } break;
                case 1: //Delete
                {
                    var VersesPuncts = new string[verses.Count];
                    for (int i = 0; i < verses.Count; i++) VersesPuncts[i] = verses[i].Name;
                    MenuByList DeleteMenu = new MenuByList(
                        "Choose what to delete",
                        "Back",
                        VersesPuncts
                    );
                    int choise = DeleteMenu.GetChoice();
                    if (choise == 0) break;
                    verses.RemoveAt(choise - 1);
                }break;
                case 2: //Change
                {
                    var VersesPuncts = new string[verses.Count];
                    for (int i = 0; i < verses.Count; i++) VersesPuncts[i] = verses[i].Name;
                    MenuByList DeleteMenu = new MenuByList(
                        "What to change",
                        "Back",
                        VersesPuncts
                    );
                    int choise = DeleteMenu.GetChoice();
                    if (choise == 0) break;

                    Console.WriteLine("\n\tFill in the fields:");
                    var verse = new Verse();

                    Console.Write("Name: ");
                    verse.Name = Console.ReadLine();
                    Console.Write("Author: ");
                    verse.Author = Console.ReadLine();
                    Console.Write("Year: ");
                    verse.Year = int.Parse(Console.ReadLine());
                    Console.Write("Text: ");
                    verse.Text = Console.ReadLine();
                    Console.Write("Theme: ");
                    verse.Theme = Console.ReadLine();
                }break;
                case 3: //Search
                {
                    MenuByList SearchMenu = new MenuByList(
                        "What sign to look for",
                        "Back",
                        "Name",
                        "Author"
                    );
                    int choise = SearchMenu.GetChoice();
                    if (choise == 0) break;

                    Console.WriteLine("Enter key: ");
                    string find = Console.ReadLine();

                    var search = new List<Verse>(); 
                    switch (choise)
                    {
                        case 1: foreach (var item in verses) if (item.Name == find) search.Add(item); break;
                        case 2: foreach (var item in verses) if (item.Author == find) search.Add(item); break;
                    }
                }break;
                case 4: //Save
                {
                    Console.WriteLine("Enter file name: ");
                    string name = Console.ReadLine();

                    FileStream file = new FileStream(name, FileMode.Create, FileAccess.Write);
                    BinaryWriter bw = new BinaryWriter(file);
                    bw.Write(verses.Count);
                    foreach (var verse in verses)
                    {
                        bw.Write(verse.Name);
                        bw.Write(verse.Author);
                        bw.Write(verse.Year);
                        bw.Write(verse.Text);
                        bw.Write(verse.Theme);
                    }
                    bw.Close();
                    file.Close();
                }break;
                case 5: //Load
                {
                    Console.WriteLine("Enter file name: ");
                    string name = Console.ReadLine();

                    FileStream file = new FileStream(name, FileMode.Open, FileAccess.Read);
                    BinaryReader bw = new BinaryReader(file);

                    verses.Clear();
                    int Count = bw.ReadInt32();
                    for (int i = 0; i < Count; i++)
                    {
                        var verse = new Verse();
                        verse.Name = bw.ReadString();
                        verse.Author = bw.ReadString();
                        verse.Year = bw.ReadInt32();
                        verse.Text = bw.ReadString();
                        verse.Theme = bw.ReadString();
                        verses.Add(verse);
                    }

                    bw.Close();
                    file.Close();
                }break;
                }
            }
        }
    }
}
