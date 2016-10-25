using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Fetch_n_Store.Models;

namespace Fetch_n_Store.DAL
{
    public class ResponseRepository
    {
        public ResponseContext Context { get; set; }
        public ResponseRepository(ResponseContext _context)
        {
            Context = _context;
        }
        public List<Response> GetAllResponses()
        {
            return Context.Responses.ToList();
        }
        public Response GetResponseById(int id)
        {
            Response _response = Context.Responses.SingleOrDefault(r => r.ResponseId == id);
            return _response;
        }
    }
}