using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public string? Duration { get; set; }
        public string? Location { get; set; }
    }
}
