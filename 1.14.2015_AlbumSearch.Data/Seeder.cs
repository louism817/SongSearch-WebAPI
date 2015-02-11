using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Migrations;
using _1._14._2015_AlbumSearch.Data.Models;

namespace _1._14._2015_AlbumSearch.Data
{
    public static class Seeder
    {
        public static void Seed(ApplicationDbContext db)
        {
            // Put in some Genres
            db.Genres.AddOrUpdate(g => g.Name,
                new Genre
                {
                    Name = "Hip Hop"
                },
                new Genre
                {
                    Name = "Gangsta Rap"
                },
                new Genre
                {
                    Name = "Metal"
                },
                new Genre
                {
                    Name = "Rock"
                },
                new Genre
                {
                    Name = "Country"
                },
                 new Genre
                {
                    Name = "Cross Over"
                }
                );
        }
    }
}
