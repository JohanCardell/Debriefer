using System;
using Microsoft.EntityFrameworkCore;
using Debriefer.Logic;
using Debriefer.Models;
   

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
    /// Future features: images in report for each round
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
            var player = new Player { Name = "Test" };
            using (var context = new ReportsDBContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Add(player);
                context.SaveChanges();
            }

            using (var context = new ReportsDBContext())
            {
                var loadedPlayer = context.Players.FirstOrDefaultAsync();
                Console.WriteLine($"Player crated: {player.Name} with Id: {player.Id}");
            }
        }
    }
}
