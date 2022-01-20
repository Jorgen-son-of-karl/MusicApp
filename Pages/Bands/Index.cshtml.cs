using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicApp.Data;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Pages.Bands
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext database;

        public IndexModel(ApplicationDbContext database)
        {
            this.database = database;
        }
        public IList<Band> Bands { get; set; }
        public IList<Album> Albums { get; set; } 
        public double averageBandScore { get; set; }
        public async Task OnGetAsync()
        {
            Bands = await database.Band.Include(b => b.Albums).ToListAsync();
            foreach(var band in Bands)
            {
                averageBandScore = 0;
                foreach(var album in band.Albums)
                {
                    averageBandScore += (double)album.AverageRating;
                }
                band.AverageRating = Math.Round(averageBandScore / band.Albums.Count, 1);
            }
            await database.SaveChangesAsync();
        }
    }
}
