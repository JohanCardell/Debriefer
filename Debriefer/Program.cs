using Debriefer.Control;
using Debriefer.Model;
using System;
using System.Linq;


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
    /// each model should have string id, based on GUID.
    /// When searching for an object, find, do not search on id (not optimized in cosmos)
    /// 
    /// many-to-many. Do not use cross-tables
    /// 
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Connecting to database...");
            var context = new ReportsDBContext();
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
