using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Debriefer.Model
{
    public enum ScenarioType { FreeForAll = 1, Encounter, NoRetreat }
    
    public class Scenario
    {
        [Column("id")]
        public string Id { get; set; }
        public ScenarioType ScenarioType { get; set; }
        public string Description { get; set; }

        public Scenario()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
