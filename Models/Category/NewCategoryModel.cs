using System;
using System.ComponentModel.DataAnnotations;
using DevTrack.Entities;

namespace DevTrack.Models.Categories
{
    public class NewCategoryModel
    {
        [Required(ErrorMessage = " is required.")]
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}