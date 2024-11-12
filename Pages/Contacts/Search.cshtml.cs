using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SimplePhoneBookApp.Data;

namespace SimplePhoneBookApp.Pages.Contacts;

public class SearchModel : PageModel
{
    private readonly PhonebookContext _context;

    public SearchModel(PhonebookContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> OnGetAsync(string searchTerm)
    {
        var results = await _context.Contacts
            .Where(c => c.Name.ToLower().Contains(searchTerm.ToLower()))
            .ToListAsync();

        return new JsonResult(results);
    }
}