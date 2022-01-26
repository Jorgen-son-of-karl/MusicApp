using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;
using MusicApp.Models;

namespace MusicApp.Pages.Bands
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext database;

        public DeleteModel(ApplicationDbContext database)
        {
            this.database = database;
        }
        public Band Band { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Band = await database.Band.FindAsync(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var band = await database.Band.FindAsync(id);

            var albums = await database.Album.Include(a => a.Reviews).Where(a => a.Band == band).ToListAsync();

            var musicians = await database.Musician.Where(m => m.Band == band).ToListAsync();

            // delete on cascade did not work so this was our solution instead
            database.Musician.RemoveRange(musicians);

            database.Album.RemoveRange(albums);
            database.Band.Remove(band);
            await database.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
