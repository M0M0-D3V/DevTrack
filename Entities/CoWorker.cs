using System;
using System.ComponentModel.DataAnnotations;

namespace DevTrack.Entities
{
    public class CoWorker
    {
        [Key]
        public int WorkerId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int WorkspaceId { get; set; }
        public Workspace Workspace { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}