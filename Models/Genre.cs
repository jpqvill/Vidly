using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        public string Type { get; set; }
        public bool isActive { get; set; }
        public DateTime createdDate { get; set; }
    }
}