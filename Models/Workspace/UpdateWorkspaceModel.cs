using System;
using System.Collections.Generic;
using DevTrack.Entities;

namespace DevTrack.Models.Workspaces
{
    public class UpdateWorkspaceModel
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public User Creator { get; set; }
        public List<CoWorker> CoWorkers { get; set; }
        public List<Project> Projects { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}