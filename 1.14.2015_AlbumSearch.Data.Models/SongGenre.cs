using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._14._2015_AlbumSearch.Data.Models
{
    public class SongGenre
    {
        [Key]
        public int SongGenreId { get; set; }
        
        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }

        public int SongId { get; set; }
        [ForeignKey("SongId")]
        public virtual Song Song { get; set; }
    }
}
