using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        /// <summary>
        /// List all the Genres in our store
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            //var genres = new List<Genre>
            //{
            //    new Genre{Name="Disco"},
            //    new Genre{Name="Jazz"},
            //    new Genre{Name="Rock"}
            //};
            var genres = storeDB.Genres.ToList();

            return this.View(genres);
        }
        /// <summary>
        /// Get the Album Details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public ActionResult Details(int id)
        {
            //var album = new Album { Title = "Album" + id };
            var album = storeDB.Albums.Find(id);
            return View(album);
        }

        /// <summary>
        /// Browse the Music Detail
        /// </summary>
        /// <returns></returns>
        public ActionResult Browse(string genre)
        {
            //var genreModel = new Genre { Name = genre };
            var genreModel = storeDB.Genres.Include("Albums").Single(g => g.Name == genre);
            return View(genreModel);
        }       
        
    }
}
