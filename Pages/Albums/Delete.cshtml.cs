using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;
using MusicApp.Models;

namespace MusicApp.Pages.Albums
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext database;

        public DeleteModel(ApplicationDbContext database)
        {
            this.database = database;
        }
        public Album Album { get; set; }
        public Band Band { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Album = await database.Album.Include(a => a.Band).SingleOrDefaultAsync(a => a.ID == id);
            Band = Album.Band;

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            Album = await database.Album.Include(a => a.Band).Include(a => a.Reviews).SingleOrDefaultAsync(a => a.ID == id);

            Band = Album.Band;
            double TotalRating = 0;

            database.Album.Remove(Album);
            await database.SaveChangesAsync();

            // reset band score
            Band.AverageRating = 0;

            
            await database.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
