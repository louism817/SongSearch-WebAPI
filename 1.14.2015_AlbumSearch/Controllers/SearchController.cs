using _1._14._2015_AlbumSearch.Data;
using _1._14._2015_AlbumSearch.Data.Models;
using _1._14._2015_AlbumSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1._14._2015_AlbumSearch.Controllers
{
    public class SearchController : ApiController
    {

        //public IHttpActionResult Get(string artist="", string title="", string album="", string genre="")
        //{
        //    List<SongViewModel> models = null;
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        var q = db.Songs.AsQueryable();
        //        if(artist !=  null && artist.Length > 0)
        //        {
        //            q =+ 
        //        }

        //        models = db.Songs.Where(s => s.Artist.Contains(artist)).Select(s => new SongViewModel
        //        {
        //            Album = s.Album,
        //            AlbumArt = s.AlbumArt,
        //            Artist = s.Artist,
        //            SongId = s.SongId,
        //            Title = s.Title
        //        }).ToList();
        //    }
        //    return Ok(models);
        //}


         public IHttpActionResult Get(string artist="", string title="", string album="", string genre="")
        {
            List<SongViewModel> models = new List<SongViewModel>();

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                IQueryable<Song> q = db.Songs.AsQueryable();
                q = q.Where(s => s.Artist.Contains(artist) || s.Title.Contains(title) || s.Album.Contains(album) || db.SongGenres.Any(sg=>sg.Genre.Name == genre && sg.SongId == s.SongId));

                //q = q.Where(s => s.Artist.Contains(artist) || s.Title.Contains(title) || s.Album.Contains(album));

                //if(artist !=  null && artist.Length > 0)
                //{
                //    q = q.Where(s => s.Artist.Contains(artist) || s.Title.Contains(title) || s.Album.Contains(album));
                //}

                //if (title != null && title.Length > 0)
                //{
                //    q = q.Where(s => s.Title.Contains(title));
                //}

                //if (album != null && album.Length > 0)
                //{
                //    q = q.Where(s => s.Album.Contains(album));
                //}

                models = q.Select(s => new SongViewModel
                {
                    Album = s.Album,
                    AlbumArt = s.AlbumArt,
                    Artist = s.Artist,
                    SongId = s.SongId,
                    Title = s.Title
                }).ToList();

            }

             //foreach(var song in songs)
             //{
             //   SongViewModel model = new SongViewModel{ 
             //       Title = song.Title,
             //       Artist = song.Artist,
             //       Album = song.Album,
             //       AlbumArt = song.AlbumArt,
             //       SongId = song.SongId
             //       };
             //   models.Add(model);
             //}

            return Ok(models);
        }

    }
}

//customer =>       customer.LastName.Contains(LookupValue)
//using (OrdersDbContext db = new OrdersDbContext())
//{
//    sqlToExecute = "SELECT * FROM Orders";
//    IQueryable<Order> q = db.Orders.Include(o => o.User).AsQueryable();

//    switch (DateTime.Now.Month)
//    {
//        case 1:
//            sqlToExecute = "SELECT * FROM Orders WHERE Total > 50";
//            q = q.Where(o => o.Total > 50);
//            break;
//        default:
//            sqlToExecute = "SELECT * FROM Orders WHERE OrderDate < GETDATE()";
//            q = q.Where(o => o.OrderDate < DateTime.Today);
//            break;
//    }

//    //Press "Execute" in SQL Management Studio (We deferred execution until RIGHT NOW)
//    List<Order> filteredOrderList = q.ToList();

//    firstOne = filteredOrderList.FirstOrDefault();

//    //Lazy LoadingUser
//    //string firstName = firstOne.User.FirstName;