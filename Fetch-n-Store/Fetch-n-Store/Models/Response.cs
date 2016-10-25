using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Fetch_n_Store.Models
{
    public class Response
    {
        [Key]
        public int ResponseId { get; set; }
        public string URL { get; set; }
        public string StatusCode { get; set; }
        public string HttpMethod { get; set; }
        public string ResponseTimeLength { get; set; }
        public string TimeOfRequest { get; set; }

    }
}