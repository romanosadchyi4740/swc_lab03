namespace swc_lab3.Models;

public class Author
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public List<Book> Books { get; set; } = [];
}