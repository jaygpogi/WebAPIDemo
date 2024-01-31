using WebAPIDemo.ViewModels;

namespace WebAPIDemo
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookView>> GetBooks(string filter, int page, int size);

        Task<BookView> GetBook(int id);

        Task<BookView> UpsertBook(int? id, UpsertBook upsertBook);

        Task DeleteBook(int id);
    }
}
