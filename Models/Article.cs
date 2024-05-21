using System.ComponentModel.DataAnnotations;

namespace FirstChallengeCRUDWebApp.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
