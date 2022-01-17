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
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext database;

        public DetailsModel(ApplicationDbContext database)
        {
            this.database = database;
        }

        public Album Album { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Album = await database.Album.FirstOrDefaultAsync(a => a.ID == id);

            if (Album == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
