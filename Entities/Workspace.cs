using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevTrack.Entities
{
    public class Workspace
    {
        [Key]
        public int WorkspaceId { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }
        public User Creator { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public List<Project> Projects { get; set; }
        public List<CoWorker> CoWorkers { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}