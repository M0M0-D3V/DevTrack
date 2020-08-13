using System;
using System.Collections.Generic;
using DevTrack.Entities;

namespace DevTrack.Models.Org
{
    public class UpdateOrgModel
    {
        public string Name { get; set; }
        public List<Member> Members { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}