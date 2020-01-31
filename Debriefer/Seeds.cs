using System;
using System.Collections.Generic;
using System.Text;
using Debriefer.Model;

namespace Debriefer
{
    public class Seeds
    {
        public List<Player> PlayerSeed = new List<Player>()
        {
            new Player
            {
                Name = "Johan"
            },
            new Player
            {
                Name = "Kalle"
            },
            new Player
            {
                Name = "Vidar"
            }
        };

        // {
        //var ForcesSeed1 = new List<Force>() {
        //        new Force
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Name = "Tanks",
        //            Nation = Nation.Germany,
        //            Points = 100
        //        },
        //        new Force
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Name = "Grenadiers",
        //            Nation = Nation.Germany,
        //            Points = 100
        //        },
        //        new Force
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Name = "Kursk",
        //            Nation = Nation.Germany,
        //            Points = 60
        //        }
        //    };
        //var ForceSeed2 = new List<Force>()
        //    {
        //        new Force
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Name = "Fireflies",
        //            Nation = Nation.GreatBritain,
        //            Points = 100
        //        },
        //        new Force
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Name = "Armored Rifles",
        //            Nation = Nation.America,
        //            Points = 100
        //        },
        //        new Force
        //        {
        //            Id = Guid.NewGuid().ToString(),
        //            Name = "Steel fist",
        //            Nation = Nation.Russia,
        //            Points = 100
        //        }
        //    };

        //var Id1 = Guid.NewGuid().ToString();
        //modelBuilder.Entity<Player>(p =>
        //    {
        //        p.HasData(new Player
        //        {
        //            Id = Id1,
        //            Name = "Johan"
        //        });
        //        p.OwnsOne(f => f.Forces).HasData(new
        //        {

        //            PlayerId = Id1,
        //            Name = "Fireflies",
        //            Nation = Nation.GreatBritain,
        //            Points = 100
        //        });
        //    });
        //    new Player
        //    {
        //        Name = "Kalle",
        //        Forces = ForceSeed2
        //    };
    
    }
}
