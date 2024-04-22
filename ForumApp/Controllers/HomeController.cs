using ForumApp.Data;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ForumApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ForumAppDbContext context;

        public HomeController(ILogger<HomeController> logger,
            ForumAppDbContext _context)
        {
            _logger = logger;
            context = _context;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await this.context.Posts.Select(p => new PostViewModel()
            {
                Id = p.Id,
                Content = p.Content,
                Title = p.Title,
            })
                .ToListAsync();

            return View(posts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
