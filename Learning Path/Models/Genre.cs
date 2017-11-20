using System.ComponentModel.DataAnnotations;

namespace Learning_Path.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string Name { get; set; }
    }
}