using System.ComponentModel.DataAnnotations;

namespace Books.Models;

public class AutographSessionViewModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    public DateTime ClosingSession {  get; set; }

    public virtual BookstoreViewModel Bookstore { get; set; }
    public virtual BookViewModel Book { get; set; }
    public int BookstoreId { get; set; }
    public int BookId { get; set; }
}
