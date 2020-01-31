using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debriefer.Model
{
    public enum GameOverCause { TimeOut, ObjectiveTaken }
    public class Report
    {
        [Column("id")]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public GameOverCause GameOverCause { get; set; }
        public int? ScenarioId { get; set; }
        public virtual Scenario Scenario { get; set; }
        public virtual IList<Round> Rounds { get; set; }


        public int? WinningPlayerId { get; set; }
        public virtual Player WinningPlayer { get; set; }
        public Force WinningForce { get; set; }
        public int? WinScore { get; set; }
        

        public int? LosingPlayerId { get; set; }
        public virtual Player LosingPlayer { get; set; }
        public Force LosingForce { get; set; }
        public int? LossScore { get; set; }

        public Report()
        {
            Id = Guid.NewGuid().ToString();
        }
        

        //public Report()
        //{
        //    this.Players = new HashSet<Player>();
        //}

    }
}
