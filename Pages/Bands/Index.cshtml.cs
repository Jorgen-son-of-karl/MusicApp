using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public double AverageBandScore { get; set; }
        [FromQuery]
        public string SearchTerm { get; set; }
        private const string NameColumn = "Name (A-Z)";
        private const string GenreColumn = "Genre";
        private const string ScoreColumn = "Rating";
        private readonly string[] SortColumns = { NameColumn, GenreColumn, ScoreColumn };
        [FromQuery]
        public string SortColumn { get; set; }
        public SelectList SortColumnList { get; set; }

        public async Task OnGetAsync()
        {

            Bands = await database.Band.Include(b => b.Albums).ToListAsync();
            foreach(var band in Bands)
            {
                //if we create a new band that band wont have any albums so we skip calculating its score
                if(band.Albums.Count == 0)
                {
                    break;
                }
                else
                {                    
                    AverageBandScore = 0;
                    foreach(var album in band.Albums)
                    {
                        if(album.AverageRating == null)
                        {

                            break;
                        }
                        else
                        {
                            AverageBandScore += (double)album.AverageRating;
                        }                       
                    }
                    band.AverageRating = Math.Round(AverageBandScore / band.Albums.Count, 1);
                }

            }
            await database.SaveChangesAsync();
            SortColumnList = new SelectList(SortColumns);

            var query = database.Band.Include(b => b.Albums).AsNoTracking();

            if (SearchTerm != null)
            {
                query = query.Where(b =>
                    b.Name.ToLower().Contains(SearchTerm.ToLower())
                );
            }

            if (SortColumn != null)
            {
                if (SortColumn == NameColumn)
                {
                    query = query.OrderBy(b => b.Name);
                }
                else if (SortColumn == GenreColumn)
                {
                    query = query.OrderBy(b => b.Genre);
                }
                else if (SortColumn == ScoreColumn)
                {
                    query = query.OrderByDescending(b => b.AverageRating);
                }
            }

            Bands = await query.ToListAsync();
        }
    }
}
