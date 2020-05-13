using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooklistApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooklistApp.Pages.Booklists
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;

        }
        [BindProperty]
        public Booklist book { get; set; }
        public async Task<IActionResult> OnGet(int? Id)
        {
            book = new Booklist();
            if(Id == null)
            {
                return Page();
            }
            book = await _db.booklist.FindAsync(Id);
            if(book == null)
            {
                return NotFound();
            }
            return Page();


        }
        public async Task<IActionResult> OnPost(int Id)
        {
            if (ModelState.IsValid)
            {
                if(book.Id == 0)
                {
                    _db.booklist.Add(book);
                }
                else
                {
                    _db.booklist.Update(book);
                }
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