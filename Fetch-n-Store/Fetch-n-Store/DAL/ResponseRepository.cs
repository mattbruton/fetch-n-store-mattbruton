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
        public ResponseRepository()
        {
            Context = new ResponseContext();
        }
        public ResponseRepository(ResponseContext _context)
        {
            Context = _context;
        }
        public List<Response> GetAllResponses()
        {
            return Context.Responses.ToList();
        }
        public void AddResponse(Response _response)
        {
            Context.Responses.Add(_response);
            Context.SaveChanges();
        }

        public void DeleteResponse(int id)
        {
            Response _response = Context.Responses.FirstOrDefault(r => r.ResponseId == id);
            Context.Responses.Remove(_response);
            Context.SaveChanges();
        }
    }
}