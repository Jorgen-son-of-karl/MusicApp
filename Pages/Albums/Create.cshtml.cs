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
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext database;


        public CreateModel(ApplicationDbContext database)
        {
            this.database = database;

        }
        [BindProperty]
        public string SelectedBand { get; set; }
        [BindProperty]
        public Album Album { get; set; }
        public List<string> BandNames { get; set; }

        public async Task OnGetAsync()
        {   //variable to store all bands in order to pick one from a dropdownbox
            BandNames = await database.Band.Select(b => b.Name).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(Album album)
        {            
            //the name and releaseyear comes from our inputs
            Album.Name = album.Name;
            Album.ReleaseYear = album.ReleaseYear;
            //the band is set with the help of our dropdownbox, to minimalize  inputerrors
            Album.Band = database.Band.Where(b => b.Name == SelectedBand).First();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await database.Album.AddAsync(Album);
            await database.SaveChangesAsync();
            return RedirectToPage("./Details", new { id = Album.ID });
        }
    }
}
