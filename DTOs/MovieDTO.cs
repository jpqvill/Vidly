using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter movie name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        //[DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        [Range(1, 20)]
        public int Stock { get; set; }
        public Genre Genre { get; set; }
        public byte GenreId { get; set; }
    }
}