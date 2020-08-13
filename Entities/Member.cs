using System.ComponentModel.DataAnnotations;

namespace DevTrack.Entities
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int OrgId { get; set; }
        public Organization Organization { get; set; }
    }
}