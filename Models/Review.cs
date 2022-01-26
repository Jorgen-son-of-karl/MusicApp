using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Review
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
        public Album Album { get; set; }
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
    }
}
