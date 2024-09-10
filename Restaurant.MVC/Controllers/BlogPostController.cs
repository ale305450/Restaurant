using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.MVC.Contracts;
using Restaurant.MVC.Models.BlogPost;

namespace Restaurant.MVC.Controllers
{
    public class BlogPostController : Controller
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        // GET: BlogPostController
        public async Task<ActionResult> Index()
        {
            var blogPosts = await _blogPostService.GetBlogPosts();
            return View(blogPosts);
        }

        // GET: BlogPostController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var blogPost = await _blogPostService.GetBlogPostDetails(id);
            return View(blogPost);
        }

        // GET: BlogPostController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: BlogPostController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateBlogPostVM blogPost)
        {
            try
            {
                var response = await _blogPostService.CreateBlogPost(blogPost);
                if(response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("",response.ValidationErrors);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("",ex.Message);
            }
            return View(blogPost);
        }

        // GET: BlogPostController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var blogPost = await _blogPostService.GetBlogPostDetails(id);
            return View(blogPost);
        }

        // POST: BlogPostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id,BlogPostVM blogPost)
        {
            try
            {
                var response = await _blogPostService.UpdateBlogPost(id,blogPost);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(blogPost);
        }

        // POST: BlogPostController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var response = await _blogPostService.DeleteBlogPost(id);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", response.ValidationErrors);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return BadRequest();
        }
    }
}
