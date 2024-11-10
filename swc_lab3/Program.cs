using swc_lab3.Models;

namespace swc_lab3;

internal abstract class Program
{
    public static void Main()
    {
        using var context = new BookStoreDbContext();
        
        ControlsUserPrompt();
        if (!int.TryParse(Console.ReadLine().Trim(), out var option))
        {
            Console.WriteLine("Invalid input. Please restart and enter a valid number.");
            return;
        }

        switch (option)
        {
            case 1:
                var books = context.Books.ToList();
                books.ForEach(book => Console.WriteLine(book.ToString()));
                break;

            case 2:
                Console.WriteLine("Enter Book Title, Language, NumberInStock, PurchasePrice, SellingPrice:");
                string[] bookData = Console.ReadLine().Split(',');

                if (bookData.Length < 5)
                {
                    Console.WriteLine("Incorrect input format. Please restart and provide all required fields.");
                    break;
                }

                var newBook = new Book
                {
                    Title = bookData[0].Trim(),
                    Language = bookData[1].Trim(),
                    NumberInStock = int.Parse(bookData[2].Trim()),
                    Price = decimal.Parse(bookData[4].Trim())
                };

                context.Books.Add(newBook);
                context.SaveChanges();
                Console.WriteLine("Book added successfully.");
                break;

            case 3:
                Console.WriteLine("Enter Book ID to update:");
                Guid bookId;
                if (!Guid.TryParse(Console.ReadLine().Trim(), out bookId))
                {
                    Console.WriteLine("Invalid Book ID. Please restart.");
                    break;
                }

                var bookToUpdate = context.Books.Find(bookId);
                if (bookToUpdate == null)
                {
                    Console.WriteLine("Book not found.");
                    break;
                }

                Console.WriteLine("Enter new Title, Language, NumberInStock, PurchasePrice, SellingPrice:");
                string[] updateData = Console.ReadLine().Split(',');

                if (updateData.Length < 5)
                {
                    Console.WriteLine("Incorrect input format. Please restart.");
                    break;
                }

                bookToUpdate.Title = updateData[0].Trim();
                bookToUpdate.Language = updateData[1].Trim();
                bookToUpdate.NumberInStock = int.Parse(updateData[2].Trim());
                bookToUpdate.Price = decimal.Parse(updateData[4].Trim());

                context.SaveChanges();
                Console.WriteLine("Book updated successfully.");
                break;

            case 4:
                Console.WriteLine("Enter Book ID to delete:");
                Guid deleteBookId;
                if (!Guid.TryParse(Console.ReadLine().Trim(), out deleteBookId))
                {
                    Console.WriteLine("Invalid Book ID. Please restart.");
                    break;
                }

                var bookToDelete = context.Books.Find(deleteBookId);
                if (bookToDelete == null)
                {
                    Console.WriteLine("Book not found.");
                    break;
                }

                context.Books.Remove(bookToDelete);
                context.SaveChanges();
                Console.WriteLine("Book deleted successfully.");
                break;
            case 5:
                Console.WriteLine("Enter Author's First name, Last name:");
                string[] authorData = Console.ReadLine().Split(',');

                if (authorData.Length < 2)
                {
                    Console.WriteLine("Incorrect input format. Please restart and provide all required fields.");
                    break;
                }

                var newAuthor = new Author
                {
                    FirstName = authorData[0].Trim(),
                    LastName = authorData[1].Trim()
                };

                context.Authors.Add(newAuthor);
                context.SaveChanges();
                Console.WriteLine("Author added successfully.");
                break;
            
            case 0:
                return;
            default:
                Console.WriteLine("Invalid option. Please restart the program and choose a correct option.");
                return;
        }
    }
    
    private static void ControlsUserPrompt()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Get Books table");
        Console.WriteLine("2. Add new book to DB");
        Console.WriteLine("3. Update a book's details");
        Console.WriteLine("4. Delete a book");
        Console.WriteLine("5. Add new Author");
        // Console.WriteLine("0. Exit application.");

        Console.WriteLine("Choose option:");   
    }
}