using Microsoft.AspNet.Identity;
using RealTalk.Models;
using System;
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
            System.Diagnostics.Debug.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            var username = User.Identity.GetUserName();
            //User user = db.Users.Where(u => u.Username == username).FirstOrDefault();
            System.Diagnostics.Debug.WriteLine(username);

            //User user = db.Users.Find(1);
            //System.Diagnostics.Debug.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>");
            //System.Diagnostics.Debug.WriteLine(user.Id);
            //System.Diagnostics.Debug.WriteLine("identity = " + User.Identity);
            //System.Diagnostics.Debug.WriteLine("identity id = " + User.Identity.GetUserId<int>());
            //System.Diagnostics.Debug.WriteLine("identity usename = " + User.Identity.GetUserName());

            return View(db.Posts.ToList());
        }

        //public ActionResult Search(string tagName)
        //{}

        // GET: Posts/Details/5
        public ActionResult Details(int? id, string tagName)
        {
            System.Diagnostics.Debug.WriteLine("D E T A I L S !!!");
            System.Diagnostics.Debug.WriteLine(tagName);
            if (tagName != null) 
            {
                System.Diagnostics.Debug.WriteLine("Tag name is not null!!!");
            }

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
        public ActionResult Create([Bind(Include = "Id,Title,Content")] Post post)
        {
            if (ModelState.IsValid)
            {
                //int userId = User.Identity.GetUserId<int>();
                int userId = 1;
                //post.User = db.Users.Find(userId);
                Console.WriteLine(db.Users.Find(userId));
                db.Posts.Add(post);
                db.SaveChanges();
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
