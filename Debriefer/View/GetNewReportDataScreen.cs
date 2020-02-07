using Debriefer.Model;
using Debriefer.Control;
using System;
using System.Collections.Generic;
using Helpers;

namespace Debriefer.View
{
    public class GetNewReportDataScreen
    {
        //public Func<List<Report>> ImportCurrentReports;
        public Func<List<Player>> ImportCurrentPlayers;
        public Action<DateTime, GameOverCause, ScenarioType, Player, Force, int, Player, Force, int, List<Round>> GenerateNewReport;
        //private List<Report> reports;
        private List<Player> players;
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



        internal void Display()
        {
            //reports = ImportCurrentReports();
            players = ImportCurrentPlayers();
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
            winningPlayer = players[Input.GetDigit()-1];

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
            for (int j = 1;  j< numberOfRounds+1; j++)
            {
                Console.Write($"Round #{j} comments: ");
                rounds.Add(new Round() { Number = j, Comment = Console.ReadLine()});
            }

            GenerateNewReport(date, gameOverCause, scenarioType, winningPlayer, winningForce, winScore, losingPlayer, losingForce, lossScore, rounds);
        }
    }
}
