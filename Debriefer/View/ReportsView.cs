using Debriefer.Model;
using System;
using System.Collections.Generic;
using Helpers;

namespace Debriefer.View

{
    internal class ReportsView
    {
        public Func<List<Report>> CurrentReports;
        private List<Report> reports;
        public Func<List<Player>> CurrentPlayers;
        public Action<DateTime, GameOverCause, ScenarioType, Player, Force, int, Player, Force, int, List<Round>> GenerateNewReport;
        private List<Player> players;
        public Action Callback;
        private DateTime date;
        private GameOverCause gameOverCause;
        private ScenarioType scenarioType;
        private Player winningPlayer;
        private Force winningForce;
        private int winScore;
        private Player losingPlayer;
        private Force losingForce;
        private int lossScore;
        private List<Round> rounds;
        private int numberOfRounds;

        internal void NewReportDataScreen()
        {
            players = CurrentPlayers();
            rounds = new List<Round>();

            //Date
            Console.WriteLine("Enter Date (yyyy/mm/dd)");
            Console.Write("Input: ");
            date = DateTime.Parse(Console.ReadLine());

            //Game Over Cause
            Console.WriteLine("\nSelect Game Over Cause");
            int i = 1;
            foreach (var cause in (GameOverCause[])Enum.GetValues(typeof(GameOverCause)))
            {
                Console.WriteLine($"[{i}] {cause.ToString()}");
                i++;
            }
            i = 1;
            Console.Write("Input: ");
            gameOverCause = (GameOverCause)Input.GetDigit();

            //Scenario
            Console.WriteLine("\n\nSelect Scenario:");
            foreach (var type in (ScenarioType[])Enum.GetValues(typeof(ScenarioType)))
            {
                Console.WriteLine($"[{i}] {type.ToString()}");
                i++;
            }
            i = 1;
            Console.Write("Input: ");
            scenarioType = (ScenarioType)Input.GetDigit();

            //Winning player
            Console.WriteLine("\n\nSelect winning player");
            foreach (var player in players)
            {
                Console.WriteLine($"[{i}] {player.Name}");
                i++;
            }
            i = 1;
            Console.Write("Input: ");
            winningPlayer = players[Input.GetDigit() - 1];

            //Winning force
            Console.WriteLine("\n\nSelect winning force");
            foreach (var force in winningPlayer.Forces)
            {
                Console.WriteLine($"[{i}] {force.Name}");
                i++;
            }
            i = 1;
            Console.Write("Input: ");
            winningForce = winningPlayer.Forces[Input.GetDigit() - 1];

            //Win score
            Console.WriteLine("\n\nEnter Win Score");
            Console.Write("Input: ");
            winScore = int.Parse(Console.ReadLine());

            //Losing player
            Console.WriteLine("\n\nSelect losing player");
            foreach (var player in players)
            {
                if (player != winningPlayer)
                {
                    Console.WriteLine($"[{i}] {player.Name}");
                    i++;
                }
            }
            i = 1;
            Console.Write("Input: ");
            losingPlayer = players[Input.GetDigit() - 1];

            //Losing force
            Console.WriteLine("\n\nSelect losing force");
            foreach (var force in losingPlayer.Forces)
            {
                Console.WriteLine($"[{i}] {force.Name}");
                i++;
            }
            i = 1;
            Console.Write("Input: ");
            losingForce = losingPlayer.Forces[Input.GetDigit() - 1];

            //Loss score
            Console.WriteLine("\n\nEnter Loss Score");
            Console.Write("Input: ");
            lossScore = int.Parse(Console.ReadLine());

            //Rounds
            Console.WriteLine("\n\nEnter number of rounds");
            Console.Write("Input: ");
            numberOfRounds = int.Parse(Console.ReadLine());
            for (int j = 1; j < numberOfRounds + 1; j++)
            {
                Console.Write($"Round #{j} comments: ");
                rounds.Add(new Round() { Number = j, Comment = Console.ReadLine() });
            }

            GenerateNewReport(date, gameOverCause, scenarioType, winningPlayer, winningForce, winScore, losingPlayer, losingForce, lossScore, rounds);
        }

        internal void DisplayAllReports()
        {
            reports = CurrentReports();
            string header = "#".PadRight(15, ' ') + "Date".PadRight(15, ' ') + "Winner".PadRight(15, ' ') + "Loser ".PadRight(15, ' ');
            Console.WriteLine(header);
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

            string firstRowOverhead = "Date".PadRight(15, ' ') + "Game Over Cause".PadRight(20, ' ') + "Scenario".PadRight(15, ' ') + "# of Rounds";
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
            Callback();
        }
    }
}