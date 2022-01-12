using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicApp.Data;

namespace MusicApp.Pages.Bands
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext database;

        public DeleteModel(ApplicationDbContext database)
        {
            this.database = database;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var contact = await database.Band.FindAsync(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var band = await database.Band.FindAsync(id);

            // Check that the contact actually belongs to the logged-in user.


            database.Band.Remove(band);
            await database.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
