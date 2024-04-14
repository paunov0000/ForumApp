using System.ComponentModel.DataAnnotations;

namespace ForumApp.Data.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [StringLength(DataConstants.Post.TitleMaxLength)]
        [Required]
        public string Title { get; set; } = null!;

        [StringLength(DataConstants.Post.ContentMaxLength)]
        [Required]
        public string Content { get; set; } = null!;
    }
}
