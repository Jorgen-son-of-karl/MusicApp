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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext database;

        public EditModel(ApplicationDbContext database)
        {
            this.database = database;
        }

        // This variable will contain the Contact object from the database.
        // Note that the variable name controls the "name" attributes in the HTML form.
        public Album Album { get; set; }

        // We need to load a Contact, including its PhoneNumbers, in both GET and POST, so we have a shared method for it.
        private async Task LoadAlbum(int id)
        {
            Album = await database.Album.Include(a => a.Band).SingleAsync(c => c.ID == id);
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            await LoadAlbum(id);

            return Page();
        }

        // The "contact" parameter is the Contact submitted through the HTML form, while the "Contact" variable is the Contact in the database.
        // In this method, we transfer the data we need from the "form contact" to the "database contact" and then save it.
        // Note that the variable names (Contact/contact) need to match because they are both connected to the "name" attributes in the HTML form, although uppercase/lowercase differences don't matter.
        public async Task<IActionResult> OnPostAsync(int id, Band band)
        {
            await LoadAlbum(id);

            if (!ModelState.IsValid)
            {
                return Page();
            }


            // Transfer the properties from the insecure (user-provided) Contact object to the "real" Contact object, from the database.
            // Note that this is the step that ensures the user cannot set the FreeCalls variable.
            A.FirstName = band.FirstName;
            Contact.LastName = band.LastName;
            Contact.EmailAddress = band.EmailAddress;

            await database.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
