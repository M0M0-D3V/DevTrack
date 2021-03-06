using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevTrack.Entities;

namespace DevTrack.Models.Subtasks
{
    public class UpdateSubtaskModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        // public int Develo perId { get; set; }
        public Developer AssignedTo { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Deadline { get; set; }
        public List<Comment> Comments { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public int Number { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}