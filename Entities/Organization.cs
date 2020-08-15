using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevTrack.Models;

namespace DevTrack.Entities
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public User Organizer { get; set; }
        public List<Member> Members { get; set; }
        public List<Workspace> Workspaces { get; set; }
        public List<Project> Projects { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}