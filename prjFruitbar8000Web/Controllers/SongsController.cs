using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using prjFruitbar8000Web.Models.Entities;

namespace prjFruitbar8000Web.Controllers
{
    public class SongsController : Controller
    {
        private FruitbarDB db = new FruitbarDB();

        // GET: Songs
        public async Task<ActionResult> Index()
        {
            return View(await db.Songs.ToListAsync());
        }

        // GET: Songs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Songs songs = await db.Songs.FindAsync(id);
            if (songs == null)
            {
                return HttpNotFound();
            }
            return View(songs);
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SongId,SongName,IsDeleted,Lyrics,Duration")] Songs songs)
        {
            if (ModelState.IsValid)
            {
                db.Songs.Add(songs);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(songs);
        }

        // GET: Songs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Songs songs = await db.Songs.FindAsync(id);
            if (songs == null)
            {
                return HttpNotFound();
            }
            return View(songs);
        }

        // POST: Songs/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SongId,SongName,IsDeleted,Lyrics,Duration")] Songs songs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(songs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(songs);
        }

        // GET: Songs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Songs songs = await db.Songs.FindAsync(id);
            if (songs == null)
            {
                return HttpNotFound();
            }
            return View(songs);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Songs songs = await db.Songs.FindAsync(id);
            db.Songs.Remove(songs);
            await db.SaveChangesAsync();
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
