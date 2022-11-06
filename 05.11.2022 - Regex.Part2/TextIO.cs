using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripByBusCacl
{
    public class TextIO
    {
        public string Name { get; }
        public TextIO()
        {
            Console.WriteLine("Задайте имя файла");
            Name = Console.ReadLine();
        }
        public TextIO(string name)
        {
            Name = name;
        }

        public void WriteToFile(string _text)
        {
            var sw = new StreamWriter(this.Name, true);
            sw.WriteLine(_text);
            sw.Close();
        }
        public List<string> ReadString()
        {
            var sr = new StreamReader(this.Name);
            var _arr = new List<string>();
            string _tmp;
            while ((_tmp = sr.ReadLine()) != null)
            {
                _arr.Add(_tmp);
            }
            sr.Close();
            return _arr;
        }
    }
}
