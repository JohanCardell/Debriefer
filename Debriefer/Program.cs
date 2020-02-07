using Debriefer.Control;
using Debriefer.Model;
using System;


namespace Debriefer
{

    /// <summary>
    /// Tool that creates battle reports.
    /// 
    /// Battle Report contains info on:
    /// * Player 1 (Nation, list?)
    /// * Player 2 (Nation, list?)
    /// Date
    /// Mission
    /// Result
    /// Rounds with commentaries
    /// 
    /// Shows stats on nation winratio etc
    /// Future features: images in report for each round. Arrows, bubbles etc.
    /// 
    /// 
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Connecting...");
            var context = new ReportsDBContext();
            Console.WriteLine("Deleting current content on database...");
            context.Database.EnsureDeleted();
            Console.WriteLine("Checking database integrity...");
            context.Database.EnsureCreated();

            Console.WriteLine("Seeding database...");
            var seed = new DataSeed();
            context.AddRange(seed.PlayerSeeds);
            context.AddRange(seed.ForceSeeds);
            context.AddRange(seed.ScenarioSeeds);
            context.AddRange(seed.ReportSeeds);
            context.SaveChanges();

            Console.WriteLine("Creating new session...");
            var userSession = new UserSession(context);
            userSession.Run();
        }
    }
}
