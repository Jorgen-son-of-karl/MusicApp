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

        public Album Album { get; set; }

        private void CreateEmptyAlbum()
        {
            Album = new Album
            {

            };
        }

        public IEnumerable<Band> DisplayData { get; set; }

        public async Task OnGet()
        {
            CreateEmptyAlbum();

            DisplayData = await database.Band.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(Album album)
        {
            CreateEmptyAlbum();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Album.Name = album.Name;
            Album.ReleaseYear = album.ReleaseYear;
            Album.Band = album.Band;

            await database.Album.AddAsync(Album);
            await database.SaveChangesAsync();
            return RedirectToPage("./Details", new { id = Album.ID });
        }
    }
}
