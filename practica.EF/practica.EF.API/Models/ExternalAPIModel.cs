using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace practica.EF.API.Models
{
    public class ExternalAPIModel
    { 
        public int postId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }
}