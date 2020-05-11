using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooklistApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooklistApp.Pages.Booklists
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
                
        }
        [BindProperty]
        public Booklist book { get; set; }
        public async Task OnGet(int Id)
        {
            book =await _db.booklist.FindAsync(Id);
            

        }
        public async Task<IActionResult> OnPost(int Id)
        {
            if (ModelState.IsValid)
            {
                var bookFromDb = await _db.booklist.FindAsync(book.Id);
                bookFromDb.Name = book.Name;
                bookFromDb.Author = book.Author;
                await _db.SaveChangesAsync();
                return RedirectToPage("Booklists");
            }
            else
            {
                return Page();
            }
        }
    }
}