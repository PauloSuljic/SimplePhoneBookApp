using Microsoft.EntityFrameworkCore;
using SimplePhoneBookApp.Models;

namespace SimplePhoneBookApp.Data;

public class PhonebookContext : DbContext
{ 
        public PhonebookContext(DbContextOptions<PhonebookContext> options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
}
