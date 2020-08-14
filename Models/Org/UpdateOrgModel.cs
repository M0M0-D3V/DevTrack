using System;
using System.Collections.Generic;
using DevTrack.Entities;

namespace DevTrack.Models.Orgs
{
    public class UpdateOrgModel
    {
        public string Name { get; set; }
        public List<Member> Members { get; set; }
        public List<Workspace> Workspaces { get; set; }
        public List<Project> Projects { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}