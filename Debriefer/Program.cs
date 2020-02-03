using System;
using Microsoft.EntityFrameworkCore;
using Debriefer.Control;
using Debriefer.Model;
using System.Linq;
using System.Collections;
   

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
            var seed = new DataSeed();
            using (var context = new ReportsDBContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.AddRange(seed.PlayerSeeds);
                context.AddRange(seed.ForceSeeds);
                context.AddRange(seed.ReportSeeds);
                context.SaveChanges();
                //Console.WriteLine(context.Players.Single(p => p.Name == "Johan").Forces.Count);
                //context.Players.Single(p => p.Name == "Johan").Forces.Add(seed.TestForce);
                //Console.WriteLine(context.Players.Single(p => p.Name == "Johan").Forces.Count);
                //var winners = context.Reports.Where(r => r.WinningPlayer.Name == "Johan");
                var winners2 = context.Reports.ToList().Where(r => r.WinningPlayer.Name == "Johan");
                foreach (var report in winners2)
                {
                    Console.WriteLine(report.LosingPlayer.Name);
                }



            }
            Console.WriteLine("OK");
        }
    }
}
