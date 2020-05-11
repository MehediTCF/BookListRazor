using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooklistApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooklistApp.Pages.Booklists
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;

        }
        [BindProperty]
        public Booklist book { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.booklist.AddAsync(book);
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