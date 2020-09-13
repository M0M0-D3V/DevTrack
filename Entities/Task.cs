using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DevTrack.Entities
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User Reporter { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int DeveloperId { get; set; }
        public Developer AssignedTo { get; set; }
        public DateTime Deadline { get; set; }
        public List<Comment> Comments { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public int Number { get; set; }
        public List<Subtask> Subtasks { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}