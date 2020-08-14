using System.ComponentModel.DataAnnotations;

namespace DevTrack.Entities
{
    public class Favorite
    {
        [Key]
        public int FavoriteId { get; set; }
        public int UserId { get; set; }
        public User FavoritedBy { get; set; }
        public int ProjectId { get; set; }
        public Project FavProject { get; set; }
    }
}