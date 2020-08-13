using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevTrack.Entities;

namespace DevTrack.Models.Users
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public List<Organization> MemberOf { get; set; }
        public List<Member> Members { get; set; }
        public List<Workspace> Workspace { get; set; }
        public List<CoWorker> CoWorkers { get; set; }
        public List<Project> Projects { get; set; }
        public List<Developer> Developers { get; set; }
    }
}