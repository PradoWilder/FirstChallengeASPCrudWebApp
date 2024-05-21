using Microsoft.AspNetCore.Mvc;
using FirstChallengeCRUDWebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace FirstChallengeCRUDWebApp.Controllers
{
    public class ArticleController : Controller
    {
        private static List<Article> _articles = new List<Article>
        {
            new Article { Id = 1, Title = "First Article", Content = "This is the content of the first article" },
            new Article { Id = 2, Title = "Second Article", Content = "This is the content of the second article" }
        };

        // GET: Article
        public IActionResult Index()
        {
            return View(_articles);
        }

        // GET: Article/Details/
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _articles.FirstOrDefault(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Article/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Article/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Content")] Article article)
        {
            if (ModelState.IsValid)
            {
                article.Id = _articles.Max(a => a.Id) + 1;
                _articles.Add(article);
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Article/Edit/
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _articles.FirstOrDefault(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }
            return View(article);
        }

        // POST: Article/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Content")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingArticle = _articles.FirstOrDefault(a => a.Id == id);
                if (existingArticle != null)
                {
                    existingArticle.Title = article.Title;
                    existingArticle.Content = article.Content;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Article/Delete/
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = _articles.FirstOrDefault(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Article/Delete/
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var article = _articles.FirstOrDefault(m => m.Id == id);
            if (article != null)
            {
                _articles.Remove(article);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
