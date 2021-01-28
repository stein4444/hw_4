using System.Collections.Generic;
using System.Linq;

namespace hw_4
{
    internal class LibarySevise
    {
        private LibraryDbContext context;
        public LibarySevise()
        {
            context = new LibraryDbContext();
        }
        public IEnumerable<Book> GetBooks()
        {
            return context.Books.OrderByDescending(s => s.Id);
        }

        //Task 1
        public IEnumerable<Book> GetBooksByPages(int Pages)
        {
            return context.Books.Where(s => s.Pages >= Pages);
        }

        //Task 2
        public IEnumerable<Book> GetBookByStartWith(string start)
        {
            return context.Books.Where(s => s.Name.StartsWith(start));
        }

        //Task 3
        public IEnumerable<Book> GetBooksByAuthorNameSurname(string name, string surname)
        {
            var autor = context.Authors.First(s => (s.Name == name && s.Surname == surname));
            var books = context.Books.Where(s => s.Id == autor.BookId);
            return books;
        }


        //Task4
        public IEnumerable<Book> GetBooksByCountry(string name)
        {
            var ctr = context.Countries.First(s => s.Name == name);
            var author = context.Authors.First(s => s.Id == ctr.AuthorId);
            var book = context.Books.Where(s => s.Id == author.BookId);
            return book;
        }

        //Task 5 
        public IEnumerable<Book> GetBooksBySymbols(int n)
        {
            return context.Books.Where(s => s.Name.Length < n);
        }

        //Task 6
        public IEnumerable<Book> GetBooksMaxPagesByCountry(string ctr)
        {
            var book = context.Books.Where(s => s.Pages == context.Books.Max(st => st.Pages)).Select(s => s);
            return book;
        }
        //task 7
        public IEnumerable<Author> GetAuthorLowestBooks()
        {
            var book = context.Authors.Where(s => context.Authors.Count(s => s.BookId));
            return book;
        }
        //Task 8
        public IEnumerable<Country> GetMaxAuthors()
        {

        }

        class Program
        {
            static void Main(string[] args)
            {
                LibarySevise libarySevise = new LibarySevise();

                //Task 1
                //foreach (var st in libarySevise.GetBooksByPages(300))
                //{
                //    Console.WriteLine($"{st.Name} {st.Pages}");
                //}
                //Task 2
                //foreach (var st in libarySevise.GetBookByStartWith("a"))
                //{
                //    Console.WriteLine($"{st.Name} {st.Pages}");
                //}
                //Task 3
                //foreach(var b in libarySevise.GetBooksByAuthorNameSurname("Hamlen", "Vogl"))
                //{
                //    Console.WriteLine($"{b.Name} {b.Pages}");
                //}
                //Task 4
                //foreach (var b in libarySevise.GetBook("Rosaceae"))
                //{
                //    Console.WriteLine($"{b.Name} {b.Pages}");
                //}
                //Task 5
                //foreach (var st in libarySevise.GetBooksBySymbols(8))
                //{
                //    Console.WriteLine($"{st.Name} {st.Pages}");
                //}
            }
        }
    }
}
