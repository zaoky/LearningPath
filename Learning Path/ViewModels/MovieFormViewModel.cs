using Learning_Path.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning_Path.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}