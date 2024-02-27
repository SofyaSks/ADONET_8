
using LibraryDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using LibraryDbContext db = new();

/*IReadOnlyList<BookAuthor> bookAuthors = db.BookAuthors
    .Include(bookAuthor => bookAuthor.Book)
    .Include(bookAuthor => bookAuthor.Author)
    .ToArray();

foreach (BookAuthor bookAuthor in bookAuthors)
    Console.WriteLine($"{bookAuthor.Author} {bookAuthor.Book}");*/

IReadOnlyList<BookAuthor> bookAuthors = db.BookAuthors
    .Include(bookAuthor => bookAuthor.Book)
    .Include(bookAuthor => bookAuthor.Author)
    .Where(bookAuthor => bookAuthor.BookId == 2)
    .ToArray();

foreach (BookAuthor bookAuthor in bookAuthors)
    Console.WriteLine($"{bookAuthor.Author} {bookAuthor.Book}");

Console.WriteLine("**************************************");

IReadOnlyList<BookAuthor> bookAuthors2 = db.BookAuthors
    .Include(bookAuthor => bookAuthor.Book)
    .Include(bookAuthor => bookAuthor.Author)
    .Where(bookAuthor => bookAuthor.AuthorId == 3)
    .ToArray();

foreach (BookAuthor bookAuthor in bookAuthors2)
    Console.WriteLine($"{bookAuthor.Author} {bookAuthor.Book}");

Console.WriteLine("**************************************");

IReadOnlyList<Book> books = db.Books
    .Include(book => book.BookAuthors)
    .ThenInclude(bookAuthors => bookAuthors.Author)
    .ToArray();

foreach (Book book in books) {
    Console.WriteLine(book.Title);

    foreach (BookAuthor bookAuthor in book.BookAuthors)
        Console.WriteLine(bookAuthor.Author.Name);
}

BookAuthor newBookAuthor = new BookAuthor
{
    Book = new Book { Title = "Репка" },
    Author = new Author { Name = "Сказка" }
};

db.BookAuthors.Add(newBookAuthor);
db.SaveChanges();

