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
                Admin = true,
                Wins = 2,
                Losses = 2,
                Forces = new List<Force>()
            },
            new Player
            {
                Id = "PlayerSeed2",
                Name = "Kalle",
                Password = "password",
                Admin = false,
                Wins = 1,
                Losses = 1,
                Forces = new List<Force>()
            },
            new Player
            {
                Id = "PlayerSeed3",
                Name = "Vidar",
                Password = "password",
                Admin = false,
                Wins = 1,
                Losses = 1,
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

        public List<Scenario> ScenarioSeeds = new List<Scenario>
        {
            new Scenario
            {
                Id = "ScenarioSeed1",
                ScenarioType = ScenarioType.Encounter,
                Description = "Descriptive text"
            },
            new Scenario
            {
                Id = "ScenarioSeed2",
                ScenarioType = ScenarioType.NoRetreat,
                Description = "This is NoRetreat"
            },
            new Scenario
            {
                Id = "ScenarioSeed3",
                ScenarioType = ScenarioType.FreeForAll,
                Description = "This is FreeForAll"
            }
        };

        public List<Report> ReportSeeds = new List<Report>
        {
            new Report
            {
                Id = "ReportSeed1",
                Date = DateTime.Parse("2020-02-03"),
                GameOverCause = GameOverCause.Objective,
                ScenarioId = "ScenarioSeed1",
                Rounds = new List<Round>()
                {
                    new Round { Id = "RoundSeed1.1", Number = 1, Comment = "Comment text" },
                    new Round { Id = "RoundSeed1.2", Number = 2, Comment = "Comment text" }
                },
                WinningPlayerId = "PlayerSeed1",
                WinningForceId = "ForceSeed1",
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
                WinningForceId = "ForceSeed1",
                WinScore = 8,
                LosingPlayerId = "PlayerSeed3",
                LosingForceId = "ForceSeed4",
                LossScore = 1
            },
            new Report
            {
                Id = "ReportSeed3",
                Date = DateTime.Parse("2020-01-11"),
                GameOverCause = GameOverCause.TimeOut,
                ScenarioId = "ScenarioSeed2",
                Rounds = new List<Round>()
                {
                    new Round()
                    {
                        Id = "RoundSeed3.1",
                        Number = 1,
                        Comment = "This is round 1"
                    },
                    new Round()
                    {
                        Id = "RoundSeed3.2",
                        Number = 2,
                        Comment = "This is round 2"
                    }
                },
                WinningPlayerId = "PlayerSeed2",
                WinningForceId = "ForceSeed3",
                WinScore = 6,
                LosingPlayerId = "PlayerSeed1",
                LosingForceId = "ForceSeed1",
                LossScore = 3
            },
            new Report
            {
                Id = "ReportSeed4",
                Date = DateTime.Parse("2020-01-04"),
                GameOverCause = GameOverCause.Objective,
                ScenarioId = "ScenarioSeed3",
                Rounds = new List<Round>()
                {
                    new Round()
                    {
                        Id = "RoundSeed4.1",
                        Number = 1,
                        Comment = "This is round 1"
                    },
                    new Round()
                    {
                        Id = "RoundSeed4.2",
                        Number = 2,
                        Comment = "This is round 2"
                    },
                    new Round()
                    {
                        Id = "RoundSeed4.3",
                        Number = 2,
                        Comment = "This is round 2"
                    }
                },
                WinningPlayerId = "PlayerSeed3",
                WinningForceId = "ForceSeed4",
                WinScore = 5,
                LosingPlayerId = "PlayerSeed1",
                LosingForceId = "ForceSeed2",
                LossScore = 4
            }
        };
    };
};





