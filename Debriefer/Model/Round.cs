using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Debriefer.Model
{
    [Owned]
    public class Round
    {
        [Column("id")]
        public string Id { get; set; }
        public int Number { get; set; }
        public string Comment { get; set; }

        public Round()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
