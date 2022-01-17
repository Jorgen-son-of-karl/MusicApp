using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Album
    {
        public int ID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Release year")]
        public int ReleaseYear { get; set; }
        public List<Review> Reviews { get; set; }
        [Display(Name = "Average score")]
        public int? AverageRating { get; set; }
        public Band Band { get; set; }
    }
}
