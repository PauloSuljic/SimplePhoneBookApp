using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimplePhoneBookApp.Data;
using SimplePhoneBookApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SimplePhoneBookApp.Data;
using SimplePhoneBookApp.Models;

namespace SimplePhoneBookApp.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        private readonly PhonebookContext _context;
        public IndexModel(PhonebookContext context)
        {
            _context = context;
        }

        public List<Contact> Contacts { get; set; }

        public async Task OnGetAsync()
        {
            Contacts = await _context.Contacts.ToListAsync();
        }
    }
}