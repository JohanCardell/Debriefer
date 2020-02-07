using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Debriefer.Model
{
    public enum GameOverCause { TimeOut = 1, Objective }
    public class Report
    {
        [Column("id")]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public GameOverCause GameOverCause { get; set; }
        public string ScenarioId { get; set; }
        public virtual Scenario Scenario { get; set; }
        public virtual IList<Round> Rounds { get; set; }


        public string WinningPlayerId { get; set; }
        public virtual Player WinningPlayer { get; set; }
        public string WinningForceId { get; set; }
        public virtual Force WinningForce { get; set; }
        public int? WinScore { get; set; }
        

        public string LosingPlayerId { get; set; }
        public virtual Player LosingPlayer { get; set; }
        public string LosingForceId { get; set; }
        public virtual Force LosingForce { get; set; }
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
