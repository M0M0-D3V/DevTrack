using System.ComponentModel.DataAnnotations;

namespace DevTrack.Entities
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
    }
}