using Microsoft.AspNet.Identity;
using RealTalk.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace RealTalk.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        public ActionResult Search(string tagName)
        {
            IEnumerable<string> tagNames = db.Tags.ToList().Select(t => t.Name);
            if (tagNames.Contains(tagName))
            {
                Tag tag = db.Tags.Where(t => t.Name == tagName).FirstOrDefault();
                Boolean flag = db.Posts.Find(1).Tags.Contains(tag);
                IEnumerable<Post> filteredPosts = db.Posts.ToList().Where(p => p.Tags.Contains(tag));
                Random r = new Random();
                System.Diagnostics.Debug.WriteLine(filteredPosts.ToString());

                int postIndex = r.Next(filteredPosts.Count());
                int id = filteredPosts.ElementAt(postIndex).Id;
                return RedirectToAction("Details/" + id);
            }
            else if (tagName == null || tagName == "")
            {
                int postsCount = db.Posts.Count();
                Random r = new Random();
                int postIndex = r.Next(postsCount);
                int id = db.Posts.ToList().ElementAt(postIndex).Id;
                return RedirectToAction("Details/" + id);
            }
            else
                return RedirectToAction("Index");//ili custom error view
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);

            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,TagsText")] Post post)
        {
            if (ModelState.IsValid)
            {
                string username = User.Identity.GetUserName();
                ApplicationUser user = db.Users.Where(u => u.UserName == username).FirstOrDefault();
                post.User = user;
                post.Author = username;
                string[] splitUpTags = post.TagsText.Split(',');
                post.Tags = new List<Tag>();
                //AddTagToPost addTagToPost = new AddTagToPost();
                //addTagToPost.selectedPost = post.Id;
                foreach (string el in splitUpTags) {
                    Tag tag = new Tag(el);
                    //db.Tags.Add(tag);
                    post.Tags.Add(tag);
                }
                db.Posts.Add(post);
                //addTagToPost.selectedPost = post.Id;
                db.SaveChanges();
                System.Diagnostics.Debug.WriteLine("Saved post: "+post);
                return RedirectToAction("Index");
            }

            return View(post);
        }

        public ActionResult AddTagToPost(int id)
        {
            AddTagToPost model = new AddTagToPost();
            model.selectedPost = id;
            model.tags = db.Tags.ToList();
            ViewBag.PostTitle = db.Posts.Find(id).Title;
            return View(model);
        }

        [HttpPost]
        public ActionResult AddTagToPost(AddTagToPost model)
        {
            var tag = db.Tags.Find(model.selectedTag);
            var post = db.Posts.Find(model.selectedPost);
            post.Tags.Add(tag);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
