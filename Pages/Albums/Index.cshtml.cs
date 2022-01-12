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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext database;

        public IndexModel(ApplicationDbContext database)
        {
            this.database = database;
        }
        public IList<Album> Albums { get; set; }

        public async Task OnGetAsync()
        {
            Albums = await database.Album.Include(a => a.Band).ToListAsync(); 
        }
    }
}
