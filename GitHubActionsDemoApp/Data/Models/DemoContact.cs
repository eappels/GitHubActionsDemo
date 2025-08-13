using SQLite;

namespace GitHubActionsDemoApp.Data.Models;

public class DemoContact
{
    [AutoIncrement, PrimaryKey]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public DemoContact() { }

    public DemoContact(string name, string email)
    {
        Name = name;
        Email = email;
    }
}