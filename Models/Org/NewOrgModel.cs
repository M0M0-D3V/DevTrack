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

        public List<Member> Members { get; set; }

    }
}