using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Debriefer.Models
{
    public enum GameOverCause { TimeOut, ObjectiveTaken}
    [Owned]
    public class Scenario
    {
        [Column("id")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Scenario()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
