using _1._14._2015_AlbumSearch.Data;
using _1._14._2015_AlbumSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using _1._14._2015_AlbumSearch.Data.Models;

namespace _1._14._2015_AlbumSearch.Adapters
{
    public class SongDataAdapter : ISongAdapter
    {

        public List<SongViewModel> Get()
        {
            List<SongViewModel> models = null;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                models = db.Songs.Select(s => new SongViewModel
                {
                    Album = s.Album,
                    AlbumArt = s.AlbumArt,
                    Artist = s.Artist,
                    SongId = s.SongId,
                    Title = s.Title
                }).ToList();
            }
            return models;
        }

        public void Post(SongViewModel model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                // first add song, then add song/genre entry 
                db.Songs.AddOrUpdate(s => new { s.Artist, s.Title },
                    new Song
                    {
                        Title = model.Title,
                        Album = model.Album,
                        AlbumArt = model.AlbumArt,
                        Artist = model.Artist,
                    });
                db.SaveChanges();
                Song song = db.Songs.FirstOrDefault(s => s.Title == model.Title);
                int gId = 1; // assign default genre ID
                if (model.GenreId > 1)
                {
                    gId = model.GenreId;
                }
                db.SongGenres.AddOrUpdate(sg => new { sg.SongId, sg.GenreId },
                    new SongGenre
                    {
                        GenreId = gId, 
                        SongId = song.SongId
                    });
                db.SaveChanges();
            }
            return;
        }

        public void Put(SongViewModel model)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                 
                Song song = db.Songs.FirstOrDefault(s => s.SongId == model.SongId);

                song.Title = model.Title;
                song.Album = model.Album;
                song.AlbumArt = model.AlbumArt;
                song.Artist = model.Artist;

                db.SaveChanges();
            }
            return;
        }

        public void Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                Song song = db.Songs.FirstOrDefault(s => s.SongId == id);

                db.Songs.Remove(song);

                db.SaveChanges();
            }
            return;
        }
    }
}