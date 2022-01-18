using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MusicApp.Data;
using MusicApp.Models;

namespace MusicApp.Pages.Reviews
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext database;

        public DeleteModel(ApplicationDbContext database)
        {
            this.database = database;
        }
        public Review Review{ get; set; }
        public Album Album { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Review = await database.Review.FindAsync(id);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var review = await database.Review.Include(r => r.Album).SingleOrDefaultAsync(r => r.ID == id);
            Album = review.Album;


            database.Review.Remove(review);
            await database.SaveChangesAsync();
            return RedirectToPage("./Index/Albums/Details/" + Album.ID);
        }
    }
}
