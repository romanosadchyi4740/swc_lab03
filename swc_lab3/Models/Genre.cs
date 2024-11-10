namespace swc_lab3.Models;

public class Genre
{
    public Guid Id { get; set; }
    public string GenreName { get; set; } = string.Empty;
    public List<Book> Books { get; set; } = [];
}