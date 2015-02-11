using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1._14._2015_AlbumSearch.Adapters
{
    public static class SongAdapterFactory
    {
        public static ISongAdapter GetSongAdapter()
        {
            return new SongDataAdapter();
        }
    }
}