using System;
using System.Collections.Generic;
using System.Text;
using Debriefer.Model;

namespace Debriefer.View
{
    public class PlayersView
    {
        public Func<List<Player>> CurrentPlayers;

        internal void DisplayAllPlayers()
        {
            foreach (var player in (CurrentPlayers()))
                {
                    Console.WriteLine(player.Name);
                }
            Console.ReadKey(true);
        }
    }
}
