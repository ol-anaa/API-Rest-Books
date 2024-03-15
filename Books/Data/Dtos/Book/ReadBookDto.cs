namespace Books.Data.Dtos.Book;

public class ReadBookDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int NumberOfPages { get; set; }
    public string PublishingCompany { get; set; }
    public DateTime PublicationDate { get; set; }
    public DateTime TimeOfQuery { get; set; } = DateTime.Now;
}
