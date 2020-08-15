using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevTrack.Entities;

namespace DevTrack.Models.Projects
{
    public class NewProjectModel
    {
        [Required(ErrorMessage = " is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User ProjectLead { get; set; }
        public int WorkspaceId { get; set; }
        public Workspace Workspace { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}