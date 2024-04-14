using ForumApp.Data;
using ForumApp.Data.Entities;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostsController : Controller
    {
        private readonly ForumAppDbContext _context;

        public PostsController(ForumAppDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts = await this._context.Posts.Select(p => new PostViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content
            }).ToListAsync();

            return View(posts);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var model = new PostViewModel();

            ViewBag.Title = "Create Post";


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Id != 0)
            {
                var dbEntity = await _context.Posts.FirstOrDefaultAsync(p => p.Id == model.Id);

                if (dbEntity == null)
                {
                    return NotFound();
                }

                dbEntity.Title = model.Title;
                dbEntity.Content = model.Content;

                this._context.Update(dbEntity);
                await this._context.SaveChangesAsync();
            }
            else
            {
                var post = new Post
                {
                    Title = model.Title,
                    Content = model.Content
                };

                await this._context.Posts.AddAsync(post);
                await this._context.SaveChangesAsync();
            }


            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var post = await this._context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            var model = new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content
            };

            ViewBag.Title = "Edit Post";

            return View(nameof(Create), model);
        }

        [HttpPost] 

        public async Task<IActionResult> Delete(int id)
        {
            var post = await this._context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            this._context.Posts.Remove(post);
            await this._context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
