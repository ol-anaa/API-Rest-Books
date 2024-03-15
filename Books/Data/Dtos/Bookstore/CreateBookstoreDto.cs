using System.ComponentModel.DataAnnotations;

namespace Books.Data.Dtos.Bookstore;

public class CreateBookstoreDto
{
    [Required(ErrorMessage = "O nome da livraria é obrigatório")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "O nome deve ter entre 1 (um) e 50 (cinquenta) caracteres")]
    public string Name { get; set; }

    public int AddressId { get; set; }
    public int ManagerId { get; set; }
}
