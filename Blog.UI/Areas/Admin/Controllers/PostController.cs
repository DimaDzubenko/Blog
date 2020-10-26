using Blog.BussinesLayer.DataTransferObjects;
using Blog.BussinesLayer.Interfaces;
using Blog.UI.Helpers;
using Blog.UI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blog.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IService<PostDTO> _postService;
        public int PageSize = 10;

        public PostController(IService<PostDTO> postService)
        {
            _postService = postService;
        }

        public IActionResult Index(int page = 1)
        {
            var posts = _postService.GetAll();

            return View(new PostsListViewModel 
            { 
                Posts = posts
                    .OrderBy(c => c.PostId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PageViewModel = new PageViewModel
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = posts.Count()
                }
            });
        }

        public IActionResult Details(int id)
        {
            PostDTO post = null;
            try
            {
                post = _postService.Get(id);
            }
            catch
            {
                return RedirectToAction("Error", new { exeption = "The author doesn't exist in database anymore!" });
            }
            if (post == null)
            {
                return NotFound();
            }
            var _post = new PostViewModel
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content
            };

            ViewBag.Image = post.Image;

            return View(_post);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostViewModel _post)
        {
            PostDTO post = new PostDTO();
            if (ModelState.IsValid)
            {
                if (_postService.GetAll().Where(x => x.Title == _post.Title).Count() > 0)
                {
                    return RedirectToAction("Error", new { exeption = "The author already exist!" });
                }
                else
                {
                    post.PostId = _post.PostId;
                    post.Title = _post.Title;
                    post.Content = _post.Content;
                    post.Image = _post.Image != null ? ImageConverter.GetBytes(_post.Image) : null;
                    _postService.Add(post);
                    _postService.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(_post);
        }

        public IActionResult Edit(int id)
        {
            var post = _postService.Get(id);

            if (post == null)
            {
                return NotFound();
            }

            var _post = new PostViewModel
            {
                Title = post.Title,
                Content = post.Content
            };

            ViewBag.Image = post.Image;
            return View(_post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PostViewModel _post)
        {
            var post = _postService.Get(id);
            if (ModelState.IsValid)
            {
                try
                {
                    post.PostId = _post.PostId;
                    post.Title = _post.Title;
                    post.Content = _post.Content;
                    post.Image = _post.Image != null ? ImageConverter.GetBytes(_post.Image) : post.Image;
                    _postService.Update(post);
                    _postService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(_post);
        }

        public IActionResult Delete(int id)
        {
            var post = _postService.Get(id);
            if (post == null)
            {
                return NotFound();
            }
            var _post = new PostViewModel
            {
                Title = post.Title,
                Content = post.Content
            };
            ViewBag.Image = post.Image;
            return View(_post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            var post = _postService.Get(id);
            _postService.Delete(post);
            _postService.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error(string exeption)
        {
            return View((object)exeption);
        }
    }
}
