using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1._14._2015_AlbumSearch.Models
{
 
    public class GenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
    }

    public class SongGenreViewModel
    {
        public int SongGenreId { get; set; }
        public int GenreId { get; set; }
        public int SongId { get; set; }
    }

    public class SongViewModel
    {
        public int SongId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string AlbumArt { get; set; }
        public int GenreId { get; set; } // song is set with a genre  - more can be added later
        public string GenreName { get; set; }
    }

    public class SearchViewModel
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Genre { get; set; }
    }
}


