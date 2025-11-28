using Libreria.Models;

namespace Libreria.Services
{
    //Service Interface defining the contract for library operations
    public interface ILibrary
    {
        Task AddBookAsync(Book newBook);
        Task<bool> DeleteAsync(int id);
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book[]> GetBooksAsync();
    }
}