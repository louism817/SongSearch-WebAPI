using _1._14._2015_AlbumSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace _1._14._2015_AlbumSearch.Adapters
{
    public interface ISongAdapter
    {
        List<SongViewModel> Get();
        void Post(SongViewModel model);
        void Put(SongViewModel model);
        void Delete(int id);
    }
}
