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
                // now see if there is a genre associated with the song

                SongGenre songGenre = null;
                foreach(SongViewModel song in models)
                {
                    songGenre = db.SongGenres.FirstOrDefault(sg => sg.SongId == song.SongId);
                    if(songGenre != null)
                    {
                        song.GenreId = songGenre.GenreId;
                        song.GenreName = songGenre.Genre.Name;
                    }
                }
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
                SongGenre songGenre = db.SongGenres.FirstOrDefault(sg => sg.SongId == model.SongId);

                song.Title = model.Title;
                song.Album = model.Album;
                song.AlbumArt = model.AlbumArt;
                song.Artist = model.Artist;
                // for now, we only allow one genre per song. Keep SongGenre table to allow for future multiple genres
                // if song is SongGenre table, and the model has a song genre, update genre
                if(songGenre != null && model.GenreId >= 1)
                {
                    if(songGenre.GenreId != model.GenreId)
                    {
                        songGenre.GenreId = model.GenreId;
                    }
                }
                // if sonGenre == null song is not in the SongGenre table, add it
                else if(songGenre == null)
                {
                   db.SongGenres.AddOrUpdate(sg => new { sg.SongId, sg.GenreId },
                   new SongGenre
                   {
                       GenreId = model.GenreId,
                       SongId = model.SongId
                   });
                 }

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