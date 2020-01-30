using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Debriefer.Models
{
    public class Player
    {
        [Column("id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public int? Wins { get; set; }
        public int? Losses { get; set; }
        public virtual IList<Force> Forces { get; set; }
        
        [InverseProperty("WinningPlayer")]
        public virtual IList<Report> WinReports { get; set; }

        [InverseProperty("LosingPlayer")]
        public virtual IList<Report> LossReports { get; set; }

        public Player()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
