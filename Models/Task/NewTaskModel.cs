using System;
using System.ComponentModel.DataAnnotations;

namespace DevTrack.Models.Tasks
{
    public class NewTaskModel
    {
        [Required(ErrorMessage = " is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public Entities.User Reporter { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}