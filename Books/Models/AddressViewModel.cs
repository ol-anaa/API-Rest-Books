using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books.Models;

public class AddressViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O logradouro é obrigatório")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "O logradouro deve ter entre 1 (um) e 50 (cinquenta) caracteres")]
    public string PublicArea { get; set; }

    [Required(ErrorMessage = "O bairro é obrigatório")]
    [StringLength(50, MinimumLength = 1, ErrorMessage = "O bairro deve ter entre 1 (um) e 50 (cinquenta) caracteres")]
    public string Neighborhood { get; set; }

    [Required(ErrorMessage = "O número é obrigatório")]
    public int Number { get; set; }

    [JsonIgnore]
    public virtual BookstoreViewModel Bookstore { get; set; }
}
