using WebAPIDemo.Models;

namespace WebAPIDemo.ViewModels
{
    public class BookView
    {
        public BookView(Book book)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            this.Description = book.Description;
            this.PublishedDate = book.PublishDateUtc.ToLocalTime();
            this.Category = ((Category)book.CategoryId).ToString();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Category { get; set; }
    }
}
