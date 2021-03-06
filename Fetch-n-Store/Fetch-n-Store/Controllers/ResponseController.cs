﻿using Fetch_n_Store.DAL;
using Fetch_n_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fetch_n_Store.Controllers
{
    public class ResponseController : ApiController
    {
        ResponseRepository Repo = new ResponseRepository();
        // GET api/<controller>
        public IEnumerable<Response> Get()
        {
             return Repo.GetAllResponses();
        }

        // POST api/<controller>
        public void Post([FromBody]dynamic value)
        {
            Response _newResponse = new Response { URL = value.URL, HttpMethod = value.HttpMethod, ResponseTimeLength = value.ResponseTimeLength, StatusCode = value.StatusCode, TimeOfRequest = value.TimeOfRequest };

            Repo.AddResponse(_newResponse);
        }

        // DELETE api/<controller>/{i}
        public IHttpActionResult Delete(int id)
        {
            try
            {
                Repo.DeleteResponse(id);
                return Ok(string.Format("Response {0} removed from database.", id));
            }
            catch (ArgumentNullException)
            {
                return Ok("Error: Item does not exist in database.");
            }    
        }
    }
}