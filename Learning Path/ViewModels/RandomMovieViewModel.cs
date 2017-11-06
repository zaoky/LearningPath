using System.Collections.Generic;
using Learning_Path.Models;

namespace Learning_Path.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}