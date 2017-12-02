using System;
using System.ComponentModel.DataAnnotations;

namespace Learning_Path.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        [Display(Name = "Number in stock")]
        public int StockNum { get; set; }
    }
}