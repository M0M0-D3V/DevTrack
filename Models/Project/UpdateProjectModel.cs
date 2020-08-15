using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevTrack.Entities;

namespace DevTrack.Models.Projects
{
    public class UpdateProjectModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public User ProjectLead { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Category> Categories { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Deadline { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}