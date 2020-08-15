using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevTrack.Entities
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User ProjectLead { get; set; }
        public int WorkspaceId { get; set; }
        public Workspace Workspace { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Category> Categories { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}