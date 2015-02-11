using _1._14._2015_AlbumSearch.Data;
using _1._14._2015_AlbumSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _1._14._2015_AlbumSearch.Controllers
{
    public class SongGenreController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<SongGenreViewModel> models = null;
            using(ApplicationDbContext db = new ApplicationDbContext())
            {
                models = db.SongGenres.Select(g => new SongGenreViewModel
                {
                    SongGenreId = g.SongGenreId,
                    GenreId = g.GenreId,
                    SongId = g.SongId
                }).ToList();
            }
            return Ok(models);
        }




    }
}
