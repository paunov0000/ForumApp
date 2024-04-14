using ForumApp.Data;
using System.ComponentModel.DataAnnotations;

namespace ForumApp.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }

        [StringLength(DataConstants.Post.TitleMaxLength, MinimumLength = DataConstants.Post.TitleMinLength)]
        public string Title { get; set; } = null!;

        [StringLength(DataConstants.Post.ContentMaxLength, MinimumLength = DataConstants.Post.ContentMinLength)]
        public string Content { get; set; } = null!;
    }
}
