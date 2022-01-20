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
        private const string nameColumn = "Title (A-Z)";
        private const string releaseYearColumn = "Release Year";
        private const string scoreColumn = "Rating";
        private string[] sortColumns = { nameColumn, releaseYearColumn, scoreColumn };
        [FromQuery]
        public string SortColumn { get; set; }
        public SelectList SortColumnList { get; set; }
        public IList<Album> Albums { get; set; }
        [FromQuery]
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            SortColumnList = new SelectList(sortColumns);

            Albums = await database.Album.Include(a => a.Band).ToListAsync();

            if (SearchTerm != null)
            {
                Albums = Albums.Where(a =>
                    a.Name.ToLower().Contains(SearchTerm.ToLower()) ||
                    a.Band.Name.ToLower().Contains(SearchTerm.ToLower())
                );
            }

/*            if (SortColumn != null)
            {
                if (SortColumn == firstNameColumn)
                {
                    query = query.OrderBy(c => c.FirstName);
                }
                else if (SortColumn == lastNameColumn)
                {
                    query = query.OrderBy(c => c.LastName);
                }
                else if (SortColumn == emailColumn)
                {
                    query = query.OrderBy(c => c.EmailAddress);
                }
            }

            Contacts = await query.ToListAsync();*/
        
        }
    }
}
