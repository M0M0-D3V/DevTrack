using System;
using System.ComponentModel.DataAnnotations;
using DevTrack.Entities;

namespace DevTrack.Models.Subtasks
{
    public class NewSubtaskModel
    {
        [Required(ErrorMessage = " is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User Reporter { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}