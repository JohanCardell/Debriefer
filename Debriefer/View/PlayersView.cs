using System;
using System.Collections.Generic;
using System.Text;
using Debriefer.Model;

namespace Debriefer.View
{
    public class PlayersView
    {
        public Func<List<Player>> GetList;

        internal void DisplayAllPlayers()
        {
            foreach (var player in (GetList()))
                {
                    Console.WriteLine(player.Name);
                }
            Console.ReadKey(true);
        }
    }
}
