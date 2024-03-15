using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books.Models;

public class BookstoreViewModel
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da livraria é obrigatório")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "O nome deve ter entre 1 (um) e 50 (cinquenta) caracteres")]
    public string Name { get; set; }

    public virtual AddressViewModel Address { get; set; }
    public int AddressId { get; set; }

    public virtual ManagerViewModel Manager { get; set; }
    public int ManagerId { get; set; }

    [JsonIgnore]
    public virtual List<AutographSessionViewModel> AutographSession { get; set; }
}
