namespace LibraryDb
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public Book() { }
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

        public override string ToString()
        {
            return $"{Title} {Price}";
        }

    }
}
