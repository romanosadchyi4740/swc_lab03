namespace swc_lab3.Models;

public class Payment
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public List<Book> Books { get; set; } = [];
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
}