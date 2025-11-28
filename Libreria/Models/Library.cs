using Libreria.Services;
namespace Libreria.Models
{
    //Tip: CTRL + . para crear interfaz de la clase automaticamente
    //Class witch implements the properties of the ILibrary Service Interface.

    public class Library : ILibrary
    {
        //privaye readonly para asignar el contenido una lista una sola vez en su inicializacion
        private readonly List<Book> books;
        private readonly object _lock = new();

        //Initialize data:
        public Library()
        {
            books = new List<Book>
            { 
                new Book { Id = 1, Title = "The Count of Monte Cristo", Price = 20.9M, Date = "1844", Description = "A man searchin vengeance" },
                new Book { Id = 2, Title = "Odisey", Price = 10.8M, Date = "285", Description = "A story full of tragedy and adventures"},
                new Book {Id = 3, Title = "Midsummer night's dream", Price = 11.2M, Date= "1600", Description = "A tragedy turned into comedy"}
            };
        }

        public Task<Book[]> GetBooksAsync()
        {
            return Task.FromResult(books.ToArray());
        }

        public Task<Book?> GetBookByIdAsync(int id)
        {
            var book = books.FirstOrDefault(book => book.Id == id);
            return Task.FromResult(book);
        }

        public Task AddBookAsync(Book newBook)
        {
            lock (_lock)
            {
                if (books.Count > 0)
                {
                    var maxId = books.Max(b => b.Id);
                    newBook.Id = maxId + 1;
                    books.Add(newBook);
                }
            }
            return Task.CompletedTask;
        }

        public Task<bool> DeleteAsync(int id)
        {
            lock (_lock)
            {
                if (books.Count > 0)
                {
                    var book = books.FirstOrDefault(b => b.Id == id);
                    books.Remove(book);

                }
                return Task.FromResult(true);
            }

        }


    }
}
