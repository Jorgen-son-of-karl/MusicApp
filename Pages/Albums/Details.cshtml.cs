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
        [BindProperty]
        public int RatingScore { get; set; }
        [BindProperty]
        public string AlbumReview { get; set; }
        public Album Album { get; set; }
        public IList<Review> ReviewList { get; set; }
        public Review Review { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Album = await database.Album.Include(a => a.Band).FirstOrDefaultAsync(a => a.ID == id);
            ReviewList = await database.Review.Where(r => r.Album == Album).ToListAsync();

            if (Album == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            Album = await database.Album.Include(a => a.Band).FirstOrDefaultAsync(a => a.ID == id);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Review review = new Review
            {
                Content = AlbumReview,
                Rating = RatingScore,
                Album = Album
            };


            await database.Review.AddAsync(review);
            await database.SaveChangesAsync();
            return RedirectToPage("./Details", new { id = Album.ID });
        }
    }
}
