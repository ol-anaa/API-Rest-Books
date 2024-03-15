using System.ComponentModel.DataAnnotations;

namespace Books.Data.Dtos.Manager;

public class ReadManagerDto
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public object Bookstore { get; set; }
}
