using System.ComponentModel.DataAnnotations;

namespace SimplePhoneBookApp.Models;

public class Contact
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Email { get; set; }
    public ContactTag Tag { get; set; } = ContactTag.None;
}

public enum ContactTag
{
    None = 0,
    Family = 1,
    Work = 2,
    Friends = 3
}