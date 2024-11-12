using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimplePhoneBookApp.Data; 
using SimplePhoneBookApp.Models; 

namespace SimplePhoneBookApp.Pages.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly PhonebookContext _context;

        public DeleteModel(PhonebookContext context)
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
            if (Contact != null)
            {
                _context.Contacts.Remove(Contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}