using System;
using System.Collections.Generic;
using DevTrack.Entities;

namespace DevTrack.Models.Categories
{
    public class UpdateCategoryModel
    {
        public string Name { get; set; }
        public List<Task> Tasks { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}