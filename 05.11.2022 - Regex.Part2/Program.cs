using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TripByBusCacl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var TimeTable = new TextIO("Bus.txt");
            var _timeTable = new List<string>();
            _timeTable = TimeTable.ReadString();
            var _text = new TextAnalayser();
            var _text2 = new TextAnalayser();
            MatchCollection _tmp;
            MatchCollection _tmp2;
            int counter = 0;
            string _pattern = @"^(Химмаш)\s*\d{1,2}\:\d{1,2}", _pattern002 = @"\d{1,2}\:\d{1,2}";

            
            foreach (var item in _timeTable)
            {
                counter++;
                _text.Search(item, _pattern, out _tmp);
                try
                {
                    Console.WriteLine($"Cтрока № {counter}: {_tmp[0]}");
                    try
                    {
                        _text.Search(_tmp[0].ToString(), _pattern002, out _tmp);
                        Console.WriteLine($"Время отправления: {_tmp[0]}");
                    }
                    catch
                    {

                    }
                }
                catch
                {
                    Console.WriteLine($"Cтрока № {counter}: совпадений нет");
                }
            }
            

            // Task 2

            string myHoursRegex = @"\s(0|1|2){1}[0-9]{1}", myMinutesRegex = @"[0-9]{1}[0-9]{1}\z";

            Regex myHours = new Regex(@"\s(0|1|2){1}[0-9]{1}");
            MatchCollection matchesHours = myHours.Matches(_timeTable.ToString());


            Regex myMinutes = new Regex(@"[0-9]{1}[0-9]{1}\z");
            MatchCollection matchesMinutes = myMinutes.Matches(_timeTable.ToString());

            Console.Write("\nВведите номер остановки А: ");
            int stationA = int.Parse(Console.ReadLine());

            Console.Write("Введите номер остановки B: ");
            int stationB = int.Parse(Console.ReadLine());

            if (stationA == stationB || stationA > stationB)
            {
                Console.WriteLine("Ошибка ввода");
                return;
            }

            int[] commonQuantityOfMinutes = new int[counter];

            counter = 0;
            foreach (var item in _timeTable)
            {
                _text.Search(item, myHoursRegex, out _tmp);
                _text2.Search(item, myMinutesRegex, out _tmp2);

                try
                {
                    counter++;



                    Console.WriteLine($"Cтрока № {counter}:");
                    try
                    {
                        MatchCollection matches = myHours.Matches(_timeTable.ToString());
                        _text.Search(_tmp[0].ToString(), myHoursRegex, out _tmp);

                        var temp1 = _tmp[0].ToString();

                        //Rempving space in string
                        temp1 = temp1.Trim();

                        MatchCollection matches2 = myMinutes.Matches(_timeTable.ToString());
                        _text2.Search(_tmp2[0].ToString(), myMinutesRegex, out _tmp2);

                        var temp2 = _tmp2[0].ToString();

                        Console.WriteLine($"Часы отправления: {_tmp[0]}");
                        Console.WriteLine($"Минуты отправления: {_tmp2[0]}");

                        commonQuantityOfMinutes[counter] = (int.Parse(temp1) * 60) + int.Parse(temp2);
                        Console.WriteLine($"Общее колличество минут: {commonQuantityOfMinutes[counter]}");
                    }
                    catch
                    {
                    }
                }
                catch
                {
                    Console.WriteLine($"Cтрока № {counter}: совпадений нет");
                }

            }

            var TempResult = 0;

            for (int i = 0; i < commonQuantityOfMinutes.Length-1; i++)
            {
                if((i == stationA) && (stationA < stationB))
                
                {
                    TempResult= commonQuantityOfMinutes[i+1] - commonQuantityOfMinutes[i];
                }
            }

            Console.WriteLine($"Время в пути от станции A до B: {TempResult} минут");
            Console.ReadKey();
        }
    }
}
