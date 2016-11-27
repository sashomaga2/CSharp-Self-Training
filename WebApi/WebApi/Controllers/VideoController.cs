using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class VideosController : ApiController
    {
        private VideoDb _db;

        public VideosController()
        {
            _db = new VideoDb();
            _db.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Video
        public IEnumerable<Video> GetAllVideos()
        {
            return _db.Videos;
        }

        // GET: api/Video/5
        public Video Get(int id)
        {
            var video = _db.Videos.Find(id);
            if(video == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return video;
            //return "value" + " " + id.ToString();
        }

        // POST: api/Video
        public HttpResponseMessage Post(Video video)
        {
            if (ModelState.IsValid)
            {
                _db.Videos.Add(video);
                _db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, video);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = video.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT: api/Video/5
        public HttpResponseMessage Put(int id, [FromBody]Video video)
        {
            if (ModelState.IsValid && id == video.Id)
            {
                _db.Entry(video).State = System.Data.Entity.EntityState.Modified;

                try
                {
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, video);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

        }

        // DELETE: api/Video/5
        public HttpResponseMessage DeleteVideo(int id)
        {
            Video video = _db.Videos.Find(id);
            if(video == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _db.Videos.Remove(video);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, video);
        }
    }
}
