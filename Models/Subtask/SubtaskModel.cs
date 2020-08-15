using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevTrack.Entities;

namespace DevTrack.Models.Subtasks
{
    public class SubtaskModel
    {
        [Key]
        public int SubtaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public int UserId { get; set; }
        public User Reporter { get; set; }
        public int DeveloperId { get; set; }
        public Developer AssignedTo { get; set; }
        public DateTime Deadline { get; set; }
        public List<Comment> Comments { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public int Number { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}