using ForumApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Data
{
    public class ForumAppDbContext : DbContext
    {
        private Post FirstPost { get; set; } = null!;

        private Post SecondPost { get; set; } = null!;

        private Post ThirdPost { get; set; } = null!;

        public ForumAppDbContext(DbContextOptions<ForumAppDbContext> options) : base(options)
        {
            //this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedPosts();

            modelBuilder.Entity<Post>().HasData(FirstPost, SecondPost, ThirdPost);
        }

        public DbSet<Post> Posts { get; set; }

        private void SeedPosts()
        {
            FirstPost = new Post
            {
                Id = 1,
                Title = "First Post",
                Content = "This is the first post"
            };

            SecondPost = new Post
            {
                Id = 2,
                Title = "Second Post",
                Content = "This is the second post"
            };

            ThirdPost = new Post
            {
                Id = 3,
                Title = "Third Post",
                Content = "This is the third post"
            };

        }
    }
}
