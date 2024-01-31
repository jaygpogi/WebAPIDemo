using WebAPIDemo.Models;

namespace WebAPIDemo.ViewModels
{
    public class UpsertBook
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDateLocal { get; set; }
        public string Category { get; set; }
    }

    public static class BookExtensions
    {
        public static Book ToBook(this UpsertBook book)
        {
            return new Book()
            {
                Title = book.Title,
                Description = book.Description,
                PublishDateUtc = book.PublishedDateLocal.ToUniversalTime(),
                CategoryId = (int)Enum.Parse(typeof(Category), book.Category)
            };
        }
    }
}
