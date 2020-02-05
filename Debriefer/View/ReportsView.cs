using Debriefer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Debriefer.View

{
    internal class ReportsView
    {
        private List<Report> reports;
        private DbSet<Report> reports2;

        public ReportsView(List<Report> reports)
        {
            this.reports = reports;
        }

        public ReportsView(DbSet<Report> reports2)
        {
            this.reports2 = reports2;
        }

        internal void DisplayAllReports()
        {
            Console.Clear();
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
            while (true)
            {
                if (int.TryParse(Console.ReadKey(false).KeyChar.ToString(), out int choice) && choice <= reports.Count)
                {
                    DisplaySingleReport(reports[choice - 1]);
                    break;
                }
            }
        }

        internal void DisplaySingleReport(Report r)
        {
            Console.Clear();


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

            //$"{r.Date.ToString("yyyy/MM/dd").PadRight(15, ' ')} " +
            //    $"{r.GameOverCause.ToString().PadRight(15, ' ')}" +
            //    $"{r.Scenario.ScenarioType.ToString().PadRight(15, ' ')}" +
            //    $"{r.Rounds.Count.ToString().PadRight(15, ' ')}" +
            //    $"{r.WinningPlayer.Name.PadRight(15, ' ')}" +
            //    $"{r.WinningForce.Name.PadRight(15, ' ')}" +
            //    $"{r.WinningForce.Nation.ToString().PadRight(15, ' ')}" +
            //    $"{r.WinScore.ToString()}" + "points".PadRight(15, ' ') +
            //    $"{r.LosingPlayer.Name.PadRight(15, ' ')}" +
            //    $"{r.LosingForce.Name.PadRight(15, ' ')}" +
            //    $"{r.LosingForce.Nation.ToString().PadRight(15, ' ')}";
            //Console.WriteLine(s);

            Console.ReadKey(true);
        }

    }
}