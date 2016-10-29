using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Fetch_n_Store.Models;

namespace Fetch_n_Store.DAL
{
    public class ResponseContext : DbContext
    {
        public virtual DbSet<Response> Responses { get; set; }
    }
}