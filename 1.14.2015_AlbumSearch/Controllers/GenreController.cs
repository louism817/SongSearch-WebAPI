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

    }
}
