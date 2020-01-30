using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debriefer.Models
{
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
        public Nation Nation1 { get; set; }
        public int? WinScore { get; set; }
        

        public int? LosingPlayerId { get; set; }
        public virtual Player LosingPlayer { get; set; }
        public Nation Nation2 { get; set; }
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
