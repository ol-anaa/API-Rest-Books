using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books.Models;

public class ManagerViewModel
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [JsonIgnore]
    public virtual List<BookstoreViewModel> Bookstore { get; set; }

}
