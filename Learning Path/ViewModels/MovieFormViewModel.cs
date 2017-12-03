using Learning_Path.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Learning_Path.ViewModels
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Display(Name = "Genre")]
        [Required]
        public int? GenreId { get; set; }
        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }
        [Display(Name = "Number in stock")]
        [Required]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20.")]
        public int? StockNum { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
        public string Title => (Id != 0) ? "Edit Movie" : "New Movie";

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            StockNum = movie.StockNum;
            GenreId = movie.GenreId;
        }
        
    }
}