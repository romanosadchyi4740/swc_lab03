namespace swc_lab3.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int NumberInStock { get; set; }
    public string Language { get; set; } = "Ukrainian";
    public List<Author> Authors { get; set; } = [];
    public List<Genre> Genres { get; set; } = [];
    public List<Payment> Payments { get; set; } = [];

    public override string ToString()
    {
        return
            $"{nameof(Id)}: {Id}, {nameof(Title)}: {Title}," +
            $" {nameof(Price)}: {Price}, {nameof(NumberInStock)}: {NumberInStock}," +
            $" {nameof(Language)}: {Language}, {nameof(Authors)}: {Authors}, {nameof(Genres)}: {Genres}," +
            $" {nameof(Payments)}: {Payments}";
    }
}