﻿using System;

namespace Learning_Path.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int StockNum { get; set; }
    }
}