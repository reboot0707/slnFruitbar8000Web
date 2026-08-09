using prjFruitbar8000Web.Models.Entities;
using prjFruitbar8000Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace prjFruitbar8000Web.Controllers
{
    public class SongsController : Controller
    {
        private FruitbarDB db = new FruitbarDB();

        // GET: Songs
        public async Task<ActionResult> Index()
        {
            return RedirectToAction(nameof(ListVM));
        }

        // TODO: 處理直接新增歌曲, 但對應專輯, 創作者沒關聯到的情況 (先處理一起新增的介面, 再處理手動新增導致的例外情形)
        public async Task<ActionResult> ListVM()
        {
            var beQueryed = await db.Songs
                .Select(q => new
                {  // 先用匿名型別解決查詢語法問題
                    q.SongName,
                    ArtistNameListQuery = q.ArtistsSongs.Select(x => x.Artists.ArtistName),
                    AlbumName = q.SongsAlbums.Select(x => x.Albums.AlbumName).FirstOrDefault(),
                    ReleaseDate = q.SongsAlbums.Select(x => x.Albums.ReleaseDate).FirstOrDefault(),
                    CoverPic = q.SongsAlbums.Select( x => x.Albums.CoverPic).FirstOrDefault()
                }).ToListAsync();

            var data = beQueryed
                .Select(s => new SongsListViewModel
                {
                    SongName = s.SongName,
                    ArtistNameList = string.Join(", ", s.ArtistNameListQuery.ToList()),
                    AlbumName = s.AlbumName,
                    ReleaseDate = s.ReleaseDate,
                    CoverPic = s.CoverPic,
                });

            return View(data);
        }

        // GET: Songs/CreateVM
        public ActionResult CreateVM()
        {
            return View();
        }

        // POST: Songs/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateVM([Bind(Include = "SongId,SongName,Lyrics,Duration")] Songs songs)
        {
            if (ModelState.IsValid)
            {
                db.Songs.Add(songs);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(songs);
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
        public async Task<ActionResult> Create([Bind(Include = "SongId,SongName,Lyrics,Duration")] Songs songs)
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
