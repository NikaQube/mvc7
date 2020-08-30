using muscshop.Context;
using muscshop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace muscshop.Controllers
{
    public class StoreManagerController : Controller
    {
  

        StoreContext _storeContext = new StoreContext();
        // GET: StoreManager
        public ActionResult Index()
        {
            var albums = _storeContext.Albums;

            return View(albums);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var album = _storeContext.Albums.Where(x => x.AlbumId == id).FirstOrDefault();
            if (album == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(_storeContext.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(_storeContext.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(Album updateAlbum)
        {

            if(ModelState.IsValid)
            {

                //var oldAlbum = _storeContext.Albums.Where(x => x.AlbumId == updateAlbum.AlbumId).FirstOrDefault();

                //oldAlbum.UpdateAlb(updateAlbum);

                _storeContext.Entry(updateAlbum).State = EntityState.Modified;
                _storeContext.SaveChanges();
                return RedirectToAction("index");
            }

            else
            {
                //var errors = ModelState.Values.Where(x => x.Errors.Count > 0);

                //List<KeyValuePair<string, ModelState>> errorList = ModelState.Where(x => x.Value.Errors.Count > 0).ToList();

                //ViewBag.ErrorList = errorList;

                return Edit(updateAlbum.AlbumId);

                //var album = _database.Albums.Where(x => x.AlbumId == updateAlbum.AlbumId).FirstOrDefault();
                //ViewBag.ArtistId = new SelectList(_database.Artists, "ArtistId", "Name", album.Artist.ArtistId);
                //ViewBag.GenreId = new SelectList(_database.Genres, "GenreId", "Name", album.Genre.GenreId);
                //return View(album);
            }

        }

        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(_storeContext.Artists, "ArtistId", "Name", 1);
            ViewBag.GenreId = new SelectList(_storeContext.Genres, "GenreId", "Name", 1);
            return View();
        }

        [HttpPost]
        public ActionResult Create(Album newalbum)
        {
            if (!ModelState.IsValid)
            {
                List<KeyValuePair<string, ModelState>> errorList = ModelState.Where(x => x.Value.Errors.Count > 0).ToList();

                ViewBag.ErrorList = errorList;
                return Create();
            }



            _storeContext.Albums.Add(newalbum);
            _storeContext.SaveChanges();

            return RedirectToAction("index");
            
        }

        public ActionResult DeleteAlb(int id)
        {
            var deletealbum = _storeContext.Albums.Find(id); ;
            _storeContext.Albums.Remove(deletealbum);
           
            _storeContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Search(string parameter)
        {
            var albums = _storeContext.Albums.Where(x => x.Title.ToLower().Contains(parameter.ToLower()));

            return View("index", albums);
        }


        //public ActionResult recovery(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    var recuser = _storeContext.Users.Where(x => x.recoveryid == id).FirstOrDefault();
            
        
        //    return View(recuser);
        //}
    }
}