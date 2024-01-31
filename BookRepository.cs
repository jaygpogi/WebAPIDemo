using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Models;
using WebAPIDemo.ViewModels;

namespace WebAPIDemo
{
    public class BookRepository : IBookRepository
    {
        private readonly WebAPIDemoContext _context;

        public BookRepository(WebAPIDemoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookView>> GetBooks(string filter, int page, int size)
        {
            return await _context.Books
                .Where(x => string.IsNullOrWhiteSpace(filter) || x.Title.Contains(filter))
                .Skip(page).Take(size)
                .Select(x => new BookView(x)).ToListAsync();
        }

        public async Task<BookView> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                return new BookView(book);
            }
            return null;
        }

        public async Task<BookView> UpsertBook(int? id, UpsertBook upsertBook)
        {
            var book = upsertBook.ToBook();
            if (id.HasValue)
            {
                book.Id = id.Value;
                _context.Entry(book).State = EntityState.Modified;
            }
            else
            {
                _context.Books.Add(book);
            }
            await _context.SaveChangesAsync();
            return new BookView(book);
        }

        public async Task DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}
