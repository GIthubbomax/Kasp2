using System;
using System.Collections.Generic;
using System.Linq;

namespace Kasp
{
    class Numsearcher
    {
        private const int count = 100;
        private const int valueforsearch = 15;
        private const int maxlimit = 100;
        private const int minlimit = -10;
/*
        static void Main(string[] args)
        {
            Random random = new Random();
            List<int> arraInts = new List<int>();
            for (int i = 0; i < count; i++)
            {
                arraInts.Add(random.Next(minlimit, maxlimit));
                Console.Write(arraInts.Last() + " ");
            }
            Console.WriteLine();

            FindParis(arraInts, valueforsearch);
            Console.ReadLine();
            
            List<double> arradDoubles = new List<double>();
            for (int i = 0; i < count; i++)
            {
                arradDoubles.Add(random.NextDouble()*(maxlimit-minlimit)+minlimit);
                Console.Write("{0:0.##}",arradDoubles.Last() );
                Console.Write(" ");
            }
            Console.WriteLine();

            FindParis(arradDoubles, valueforsearch);
            Console.ReadLine();
        }
*/
        static void FindParis(List<int> listnumber, int val)
        {
            for (int i = 0; i < listnumber.Count; i++)
            {
                int searchvalue = -(listnumber[i] - val);
                for (int j = i; j < listnumber.Count; j++)
                {
                    if (searchvalue == listnumber[j])
                        Console.WriteLine("Найдена пара({0})+({1}), в сумме дает {2} ", listnumber[i], listnumber[j],
                            val);
                }
            }
        }

        static void FindParis(List<double> listnumber, double val)
        {
            for (int i = 0; i < listnumber.Count; i++)
            {
                double searchvalue = -(listnumber[i] - val);
                for (int j = i; j < listnumber.Count; j++)
                {
                    if (searchvalue == listnumber[j])
                        Console.WriteLine("Найдена пара({0:0.##})+({1:0.##}), в сумме дает {3:0.##} ", listnumber[i], listnumber[j],
                            val);
                }
            }
        }
    }
}