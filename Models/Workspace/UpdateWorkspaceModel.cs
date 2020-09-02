using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevTrack.Entities;

namespace DevTrack.Models.Workspaces
{
    public class UpdateWorkspaceModel
    {
        [Key]
        public int WorkspaceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User Creator { get; set; }
        public List<CoWorker> CoWorkers { get; set; }
        public List<Project> Projects { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}