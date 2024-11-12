using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimplePhoneBookApp.Data; 
using SimplePhoneBookApp.Models; 

namespace SimplePhoneBookApp.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly PhonebookContext _context;

        public EditModel(PhonebookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Contact = await _context.Contacts.FindAsync(id);

            if (Contact == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}