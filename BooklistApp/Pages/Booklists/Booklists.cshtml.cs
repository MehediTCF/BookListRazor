using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooklistApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BooklistApp.Pages.Booklists
{
    public class BooklistsModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public BooklistsModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public IEnumerable<Booklist> books { get; set; }
        public async Task OnGet()
        {
            books = await _db.booklist.ToListAsync();
        }
        public async Task<IActionResult> OnPost(int Id)
        {
            var book = await _db.booklist.FindAsync(Id);
            if(book == null)
            {
                return NotFound();
            }
            _db.booklist.Remove(book);
            await _db.SaveChangesAsync();
            return RedirectToPage("Booklists");
        }
    }
}