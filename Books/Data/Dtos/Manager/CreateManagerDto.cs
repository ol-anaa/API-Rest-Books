using System.ComponentModel.DataAnnotations;

namespace Books.Data.Dtos.Manager;

public class CreateManagerDto
{
    [Required]
    public string Name { get; set; }
}
