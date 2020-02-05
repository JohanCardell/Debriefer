using Debriefer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Debriefer.View

{
    internal class ReportsView
    {
        public List<Report> reports;
        public Action BackToMain;

        

        internal void DisplayAllReports()
        {
            string overHead = "#".PadRight(15, ' ') + "Date".PadRight(15, ' ') + "Winner".PadRight(15, ' ') + "Loser ".PadRight(15, ' ');
            Console.WriteLine(overHead);
            int number = 1;
            foreach (var r in reports)
            {
                string s =
                    number.ToString().PadRight(15, ' ') +
                    $"{r.Date.ToString("yyyy/MM/dd").PadRight(15, ' ')}" +
                    $"{r.WinningPlayer.Name.PadRight(15, ' ')}" +
                    $"{r.LosingPlayer.Name.PadRight(15, ' ')}";
                Console.WriteLine(s);
                number++;
            }
            Console.Write("Enter report to view: ");
            while (true)
            {
                if (int.TryParse(Console.ReadKey(false).KeyChar.ToString(), out int choice) && choice <= reports.Count)
                {
                    Console.WriteLine("Loading...");
                    Console.Clear();
                    DisplaySingleReport(reports[choice - 1]);
                    break;
                }
            }
        }

        internal void DisplaySingleReport(Report r)
        {

            string firstRowOverhead = "Date".PadRight(15, ' ') + "Game ender".PadRight(20, ' ') + "Scenario".PadRight(15, ' ') + "# of Rounds";
            string secondRowOverhead = "Winner".PadRight(15, ' ') + "Force name".PadRight(20, ' ') + "Nation".PadRight(15, ' ') + "Score";
            string thirdRowOverhead = "Loser".PadRight(15, ' ') + "Force name".PadRight(20, ' ') + "Nation".PadRight(15, ' ') + "Score";
            string firstRowStats = r.Date.ToString("yyyy/MM/dd").PadRight(15, ' ') + r.GameOverCause.ToString().PadRight(20, ' ') + r.Scenario.ScenarioType.ToString().PadRight(15, ' ') + $"{r.Rounds.Count}\n";
            string secondRowStats = r.WinningPlayer.Name.PadRight(15, ' ') + r.WinningForce.Name.PadRight(20, ' ') + r.WinningForce.Nation.ToString().PadRight(15, ' ') + $"{r.WinScore}\n";
            string thirdRowStats = r.LosingPlayer.Name.PadRight(15, ' ') + r.LosingForce.Name.PadRight(20, ' ') + r.LosingForce.Nation.ToString().PadRight(15, ' ') + $"{r.LossScore}\n";

            List<string> allRows = new List<string>() { firstRowOverhead, firstRowStats, secondRowOverhead, secondRowStats, thirdRowOverhead, thirdRowStats };
            foreach (var row in allRows)
            {
                Console.WriteLine(row);
            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadKey(true);
            BackToMain();
        }
    }
}