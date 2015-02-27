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
    public class GenreController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<GenreViewModel> models = null;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                models = db.Genres.Select(g => new GenreViewModel
                {
                    GenreId = g.GenreId,
                    Name = g.Name
                }).ToList();
            }
            return Ok(models);
        }

        public IHttpActionResult Post(GenreViewModel model)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                Genre genre = new Genre
                {
                    Name = model.Name
                };
                db.Genres.Add(genre);
                db.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Put(GenreViewModel model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Genre genre = db.Genres.FirstOrDefault(g => g.GenreId == model.GenreId);
                if(genre != null)
                    {
                        genre.Name = model.Name;
                    }
                db.SaveChanges();
            }
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {                
                // make sure genre is not associated with any songs in the SongGenre table
                SongGenre songGenre = db.SongGenres.FirstOrDefault(sg => sg.GenreId == id);
                // if songGenre is null genre is on in SongGenre table
                if(songGenre == null)
                {   
                    Genre genre = db.Genres.FirstOrDefault(g => g.GenreId == id);
                    if(genre != null)
                    {
                        db.Genres.Remove(genre);
                        db.SaveChanges();
                    }                    
                };                
            }
            return Ok();
        }

    }
}
