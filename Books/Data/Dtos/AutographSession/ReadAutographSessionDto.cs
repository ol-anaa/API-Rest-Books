using Books.Models;
using System.ComponentModel.DataAnnotations;

namespace Books.Data.Dtos.AutographSession;

public class ReadAutographSessionDto
{
    public int Id { get; set; }
    public BookViewModel Book { get; set; }
    public BookstoreViewModel Bookstore { get; set; }
    public DateTime ClosingSession { get; set; }
    public DateTime StartTime { get; set; }
}
