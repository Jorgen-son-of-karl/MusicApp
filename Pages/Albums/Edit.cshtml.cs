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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext database;

        public EditModel(ApplicationDbContext database)
        {
            this.database = database;
        }

        [BindProperty]
        public string SelectedBand { get; set; }
        public Album Album { get; set; }

        public List<string> BandNames { get; set; }

        private async Task LoadAlbum(int id)
        {
            Album = await database.Album.Include(a => a.Band).SingleAsync(m => m.ID == id);

        }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            await LoadAlbum(id);
            BandNames = await database.Band.Select(b => b.Name).ToListAsync();


            return Page();
        }
        //the album we chose to edit is accepted as a parameter
        public async Task<IActionResult> OnPostAsync(int id, Album album)
        {
            Band band = database.Band.Where(b => b.Name == SelectedBand).First();
            await LoadAlbum(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }


            //these fields allways gets updated, however if the user didnt edit one of the fields its old values are saved
            Album.Name = album.Name;
            Album.ReleaseYear = Album.ReleaseYear;
            Album.Band = band;

            await database.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
