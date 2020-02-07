using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Debriefer.Model
{
    public enum Nation
    {
        Allies = 1,
        America,
        Axis,
        GreatBritain,
        Germany,
        Russia
    }
    public enum Period
    {
        EarlyWar = 1,
        MidWar,
        LateWar
    }
    public class Force
    {
        [Column("id")]
        public string Id { get;  set; }
        public string Name { get; set; }
        public Nation Nation { get; set; }
        public Period Period { get; set; }
        public int Points { get; set; }
        public string PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public Force()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}
