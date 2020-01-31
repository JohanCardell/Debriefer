using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Debriefer.Model
{
    public enum Nation
    {
        Allies,
        America,
        Axis,
        GreatBritain,
        Germany,
        Russia
    }
    [Owned]
    public class Force
    {
        [ForeignKey ("Player")]
        [Column("id")]
        public string Id { get; private set; }
        public string Name { get; set; }
        public Nation Nation { get; set; }
        public int Points { get; set; }
        public virtual Player Player { get; set; }
        public Force()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}
