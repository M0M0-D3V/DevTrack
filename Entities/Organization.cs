using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevTrack.Models;

namespace DevTrack.Entities
{
    public class Organization
    {
        [Key]
        public int OrgId { get; set; }
        public string Name { get; set; }
        public List<Member> Members { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}