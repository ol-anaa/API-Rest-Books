using Books.Models;
using System.ComponentModel.DataAnnotations;

namespace Books.Data.Dtos.AutographSession;

public class CreateAutographSessionDto
{
    public int BookstoreId { get; set; }
    public int BookId { get; set; }
    public DateTime ClosingSession { get; set; }
}
