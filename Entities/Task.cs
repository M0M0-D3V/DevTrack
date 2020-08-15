using System.ComponentModel.DataAnnotations;

namespace DevTrack.Entities
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
    }
}