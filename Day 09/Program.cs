namespace Day_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>
            {
                new Book(
                    "978-0262033848",
                    "Introduction to Algorithms",
                    new string[] { "Thomas H. Cormen", "Charles E. Leiserson", "Ronald L. Rivest", "Clifford Stein" },
                    new DateTime(2009, 7, 31),
                    99.95m
                ),
                new Book(
                    "978-0131103627",
                    "The C Programming Language",
                    new string[] { "Brian W. Kernighan", "Dennis M. Ritchie" },
                    new DateTime(1988, 4, 1),
                    67.50m
                ),
                new Book(
                    "978-0201633610",
                    "Design Patterns: Elements of Reusable Object-Oriented Software",
                    new string[] { "Erich Gamma", "Richard Helm", "Ralph Johnson", "John Vlissides" },
                    new DateTime(1994, 10, 31),
                    54.95m
                )
            };


            BookDel userDel = new BookDel(BookFunctions.GetTitle);

            Func<Book,string> bclDel = new Func<Book, string>(BookFunctions.GetDetails);

            BookDel anonDEl = delegate (Book book) { return book.ISBN; };

            BookDel arrowDEl = b => b.PublicationDate.ToShortDateString();

            LibraryEngine.ProcessBooks(books, userDel);
            //LibraryEngine.ProcessBooks(books, bclDel);
            LibraryEngine.ProcessBooks(books, anonDEl);
            LibraryEngine.ProcessBooks(books, arrowDEl);
        }
    }
    public delegate string BookDel(Book b);
    public class Book
    {
        public Book(string iSBN, string title, string[] authors, DateTime publicationDate, decimal price)
        {
            ISBN = iSBN;
            Title = title;
            Authors = authors;
            PublicationDate = publicationDate;
            Price = price;
        }

        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"ISBN: {ISBN}\nTitle: {Title}\nAuthors: {string.Join(", ", Authors)}\nPublication Date: {PublicationDate.ToShortDateString()}\nPrice: {Price:C}";
        }
    }

    public class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B.Title;
        }
        public static string GetDetails(Book B)
        {
            return B.ToString();
        }

        public static string GetAuthors(Book B)
        {
            return string.Join(", ", B.Authors);
        }

        public static string GetPrice(Book B)
        {
            return B.Price.ToString("C");
        }
    }
    public class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList
        ,BookDel fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr?.Invoke(B));
            }
        }

    } 
    
}
