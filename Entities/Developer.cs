using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevTrack.Entities
{
    public class Developer
    {
        [Key]
        public int DeveloperId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public List<Task> Tasks { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}