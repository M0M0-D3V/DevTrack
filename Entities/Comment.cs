using System;
using System.ComponentModel.DataAnnotations;

namespace DevTrack.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public User Author { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}