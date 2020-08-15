using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevTrack.Entities;

namespace DevTrack.Models.Categories
{
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public List<Task> Tasks { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}