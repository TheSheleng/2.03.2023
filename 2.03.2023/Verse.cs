using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace _2._03._2023
{
    internal class Verse
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Text{ get; set; }
        public string Theme{ get; set; }
    }
}
