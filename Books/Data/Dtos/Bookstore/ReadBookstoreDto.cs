using Books.Models;
using System.ComponentModel.DataAnnotations;

namespace Books.Data.Dtos.Bookstore;

public class ReadBookstoreDto
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da livraria é obrigatório")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "O nome deve ter entre 1 (um) e 50 (cinquenta) caracteres")]
    public string Name { get; set; }

    public virtual AddressViewModel Address { get; set; }
    public virtual ManagerViewModel Manager { get; set; }
}
