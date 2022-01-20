using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;
using MusicApp.Models;

namespace MusicApp.Pages.Albums
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext database;

        public IndexModel(ApplicationDbContext database)
        {
            this.database = database;
        }
        private const string NameColumn = "Title (A-Z)";
        private const string ReleaseYearColumn = "Release Year";
        private const string ScoreColumn = "Rating";
        private readonly string[] SortColumns = { NameColumn, ReleaseYearColumn, ScoreColumn };
        [FromQuery]
        public string SortColumn { get; set; }
        public SelectList SortColumnList { get; set; }
        public IList<Album> Albums { get; set; }
        [FromQuery]
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            SortColumnList = new SelectList(SortColumns);

            var query = database.Album.Include(a => a.Band).AsNoTracking();

                        if (SearchTerm != null)
                        {
                            query = query.Where(a =>
                                a.Name.ToLower().Contains(SearchTerm.ToLower()) ||
                                a.Band.Name.ToLower().Contains(SearchTerm.ToLower())
                            );
                        }

            if (SortColumn != null)
            {
                if (SortColumn == NameColumn)
                {
                    query = query.OrderBy(c => c.Name);
                }
                else if (SortColumn == ReleaseYearColumn)
                {
                    query = query.OrderBy(c => c.ReleaseYear);
                }
                else if (SortColumn == ScoreColumn)
                {
                    query = query.OrderByDescending(c => c.AverageRating);
                }
            }

            Albums = await query.ToListAsync();
        
        }
    }
}
