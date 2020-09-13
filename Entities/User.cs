using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevTrack.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Organization> MemberOf { get; set; }
        public List<Member> Members { get; set; }
        public List<Workspace> Workspace { get; set; }
        public List<CoWorker> CoWorkers { get; set; }
        public List<Project> Projects { get; set; }
        public List<Developer> Developers { get; set; }
        public List<Favorite> Favorites { get; set; }
    }
}