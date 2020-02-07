using Debriefer.Model;
using Helpers;
using System;
using System.Collections.Generic;

namespace Debriefer.View
{
    public class ForcesView
    {
        internal Action<string, Nation, Period, int> GenerateNewForce;
        public Func<List<Force>> CurrentForces;
        public Action Callback;

        internal void DisplayAll()
        {
            foreach (var force in CurrentForces())
            {
                string s = force.Name.PadRight(15, ' ') +
                            force.Nation.ToString().PadRight(15, ' ') +
                            force.Period.ToString().PadRight(20, ' ') +
                            force.Points.ToString().PadRight(20, ' ');
                Console.WriteLine(s);
            }
            Console.ReadKey(true);

            Callback();
        }
        internal void NewForceDataScreen()
        {
            string name;
            Nation nation;
            Period period;
            int points;
            int i = 1;

            //Name
            Console.WriteLine("Enter name");
            Console.Write("Input: ");
            name = Console.ReadLine();
            Console.WriteLine();

            //Nation
            Console.WriteLine("Select nation");
            foreach (var n in (Nation[])Enum.GetValues(typeof(Nation)))
            {
                Console.WriteLine($"[{i}] {n.ToString()}");
                i++;
            }
            i = 1;
            Console.Write("Input: ");
            nation = (Nation)Input.GetDigit();
            Console.WriteLine("\n");

            //Period
            Console.WriteLine("Select period");
            foreach (var p in (Period[])Enum.GetValues(typeof(Period)))
            {
                Console.WriteLine($"[{i}] {p.ToString()}");
                i++;
            }
            i = 1;
            Console.Write("Input: ");
            period = (Period)Input.GetDigit();
            Console.WriteLine("\n");

            //Points
            Console.WriteLine("Enter points");
            Console.Write("Input: ");
            points = int.Parse(Console.ReadLine());

            GenerateNewForce(name, nation, period, points);
            Callback();
        }
    }
}
