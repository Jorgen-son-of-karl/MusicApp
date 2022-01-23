using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;
using MusicApp.Models;

namespace MusicApp.Pages.Musicians
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext database;

        public EditModel(ApplicationDbContext database)
        {
            this.database = database;
        }

        [BindProperty]
        public string SelectedBand { get; set; }
        public Musician Musician { get; set; }

        public List<string> BandNames { get; set; }

        private async Task LoadMusician(int id)
        {
            Musician = await database.Musician.Include(m => m.Band).SingleAsync(m => m.ID == id);
        }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            await LoadMusician(id);
            BandNames = await database.Band.Select(b => b.Name).ToListAsync();


            return Page();
        }

 
        public async Task<IActionResult> OnPostAsync(int id, Musician musician)
        {
            Band band = database.Band.Where(b => b.Name == SelectedBand).First();
            await LoadMusician(id);


            if (!ModelState.IsValid)
            {
                return Page();
            }


            Musician.Name = musician.Name;
            Musician.BirthDay = musician.BirthDay;
            Musician.Country = musician.Country;
            Musician.Band = band;

            await database.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
