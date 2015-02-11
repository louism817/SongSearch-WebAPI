using _1._14._2015_AlbumSearch.Data;
using _1._14._2015_AlbumSearch.Data.Models;
using _1._14._2015_AlbumSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity.Migrations;
using _1._14._2015_AlbumSearch.Adapters;

namespace _1._14._2015_AlbumSearch.Controllers
{
    public class SongController : ApiController
    {
        private ISongAdapter _adapter;

        public SongController()
        {
            _adapter = SongAdapterFactory.GetSongAdapter();
        }

        public SongController(ISongAdapter adapter)
        {
            _adapter = adapter;
        }

        public IHttpActionResult Get()
        {           
            return Ok(_adapter.Get());
        }
         
        public IHttpActionResult Post(SongViewModel model)
        {
            _adapter.Post(model);
            return Ok();
        }

        public IHttpActionResult Put(SongViewModel model)
        {
            _adapter.Put(model);
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            _adapter.Delete(id);
            return Ok();
        }
    }
}
