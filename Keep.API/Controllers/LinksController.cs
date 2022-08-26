using Keep.DataService.Models;
using Keep.DataService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Keep.API.Controllers
{
    public class LinksController : ApiController
    {
        private readonly ILinkRepository _db;
        public LinksController(ILinkRepository db)
        {
            _db = db;
        }

        public List<Link> GetLinks()
        {
            return _db.GetLinks();
        }

        public Link GetLink(int id)
        {
            return _db.GetLinkById(id);
        }

        [HttpPost]
        public HttpResponseMessage AddLink(Link model)
        {
            try
            {
                _db.AddLink(model);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
            }catch(Exception x)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateLink(Link model)
        {
            try
            {
                _db.UpdateLink(model);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }
            catch (Exception x)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteLink(int id)
        {
            _db.DeleteLink(id);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            return response;
        }
    }
}
