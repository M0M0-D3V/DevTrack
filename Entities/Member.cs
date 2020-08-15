using System;
using System.ComponentModel.DataAnnotations;

namespace DevTrack.Entities
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}