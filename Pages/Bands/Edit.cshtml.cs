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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext database;

        public EditModel(ApplicationDbContext database)
        {
            this.database = database;
        }

        public Band Band { get; set; }

        private async Task LoadBand(int id)
        {
            Band = await database.Band.SingleAsync(b => b.ID == id);
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            await LoadBand(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, Band band)
        {
            await LoadBand(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }


           //updates the properties of our form-band and saves it to the band in our database
            Band.Name = band.Name;
            Band.Genre = band.Genre;
            Band.YearFormed = band.YearFormed;

            await database.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
