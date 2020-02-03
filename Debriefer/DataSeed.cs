using Debriefer.Model;
using System;
using System.Collections.Generic;

namespace Debriefer
{
    public class DataSeed
    {
        public Force TestForce = new Force { Id = "TestForce", Name = "Test", Nation = Nation.Allies, Period = Period.EarlyWar, Points = 100 };

        public List<Player> PlayerSeeds = new List<Player>
        {
            new Player
            {
                Id = "PlayerSeed1",
                Name = "Johan",
                Password = "password",
                Forces = new List<Force>()
            },
            new Player
            {
                Id = "PlayerSeed2",
                Name = "Kalle",
                Password = "password",
                Forces = new List<Force>()
            },
            new Player
            {
                Id = "PlayerSeed3",
                Name = "Vidar",
                Password = "password",
                Forces = new List<Force>()
            }
        };

        public List<Force> ForceSeeds = new List<Force>
        {
            new Force
            {
                Id = "ForceSeed1",
                Name = "Tanks",
                Nation = Nation.Germany,
                Period = Period.LateWar,
                Points = 100,
                PlayerId = "PlayerSeed1"
            },
            new Force
            {
                Id = "ForceSeed2",
                Name = "Kursk",
                Nation = Nation.Germany,
                Period = Period.MidWar,
                Points = 60,
                PlayerId = "PlayerSeed1"
            },
            new Force
            {
                Id = "ForceSeed3",
                Name = "T34s",
                Nation = Nation.Russia,
                Period = Period.MidWar,
                Points = 60,
                PlayerId = "PlayerSeed2"
            },
            new Force
            {
                Id = "ForceSeed4",
                Name = "Firefly",
                Nation = Nation.GreatBritain,
                Period = Period.LateWar,
                Points = 100,
                PlayerId = "PlayerSeed3"
            }
        };


        public List<Report> ReportSeeds = new List<Report>
        {
            new Report
            {
                Id = "ReportSeed1",
                Date = DateTime.Parse("2020-02-03"),
                GameOverCause = GameOverCause.ObjectiveTaken,
                ScenarioId = "ScenarioSeed1",
                Scenario = new Scenario()
                {
                    Id = "ScenarioId1",
                    ScenarioType = ScenarioType.Encounter,
                    Description = "Descriptive text"
                },
                Rounds = new List<Round>()
                {
                    new Round { Id = "RoundSeed1.1", Number = 1, Comment = "Comment text" },
                    new Round { Id = "RoundSeed1.2", Number = 2, Comment = "Comment text" }
                },
                WinningPlayerId = "PlayerSeed1",
                WinningForceId = "SeedForce1",
                WinScore = 6,
                LosingPlayerId = "PlayerSeed2",
                LosingForceId = "ForceSeed3",
                LossScore = 3,
            },

            new Report
            {
                Id = "ReportSeed2",
                Date = DateTime.Parse("2020-02-01"),
                GameOverCause = GameOverCause.TimeOut,
                ScenarioId = "ScenarioSeed2",
                Scenario = new Scenario()
                {
                    Id = "ScenarioId2",
                    ScenarioType = ScenarioType.NoRetreat,
                    Description = "This is NoRetreat"
                },
                Rounds = new List<Round>()
                {
                    new Round()
                    {
                        Id = "RoundSeed2.1",
                        Number = 1,
                        Comment = "This is round 1"
                    },
                    new Round()
                    {
                        Id = "RoundSeed2.2",
                        Number = 2,
                        Comment = "This is round 2"
                    }
                },
                WinningPlayerId = "PlayerSeed1",
                WinningForceId = "ForceSeed3",
                WinScore = 8,
                LosingPlayerId = "PlayerSeed3",
                LosingForceId = "ForceSeed4",
                LossScore = 1
            }
        };
    };
};





//    new Player
//    {
//        Name = "Kalle"
//    },
//    new Player
//    {
//        Name = "Vidar"
//    }
//};

//// {
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


