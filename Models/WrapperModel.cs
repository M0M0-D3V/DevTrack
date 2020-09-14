using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DevTrack.Entities;

namespace DevTrack.Models
{
    [NotMapped]
    public class WrapperModel
    {
        public User User { get; set; }
        public List<Workspace> Workspaces { get; set; }
        public List<Project> Projects { get; set; }
        public Workspace Workspace { get; set; }
        public Project Project { get; set; }
    }
}