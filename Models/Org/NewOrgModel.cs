using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevTrack.Entities;

namespace DevTrack.Models.Orgs
{
    public class NewOrgModel
    {
        [Required(ErrorMessage = " is required.")]
        public string Name { get; set; }

        public int UserId { get; set; }
        public User Organizer { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}