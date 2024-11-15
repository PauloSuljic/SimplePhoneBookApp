using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SimplePhoneBookApp.Data;
using SimplePhoneBookApp.Models;
using SimplePhoneBookApp.Data; // Adjust to your namespace
using SimplePhoneBookApp.Models; // Adjust to your namespace

namespace SimplePhoneBookApp.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        private readonly PhonebookContext _context;

        public CreateModel(PhonebookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contact Contact { get; set; }

        public void OnGet()
        {
            // No data is retrieved because the user is creating a new contact, and the form is blank.
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contacts.Add(Contact);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}