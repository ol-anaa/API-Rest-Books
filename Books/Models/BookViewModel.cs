using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Books.Models
{
    public class BookViewModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O título deve ter entre 1 (um) e 50 (cinquenta) caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O autor é obrigatório")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O nome do autor deve ter entre 1 (um) e 50 (cinquenta) caracteres")]
        public string Author { get; set; }

        [Required(ErrorMessage = "O número de páginas é obrigatório")]
        public int NumberOfPages { get; set; }

        [Required(ErrorMessage = "O nome da editora é obrigatório")]
        [StringLength(80, MinimumLength = 1, ErrorMessage = "O nome da editora deve ter entre 1 (um) e 80 (oitenta) caracteres")]
        public string PublishingCompany { get; set; }

        [Required(ErrorMessage = "A data de publicação do livro é obrigatória")]
        public DateTime PublicationDate { get; set; }

        [JsonIgnore]
        public virtual List<AutographSessionViewModel> AutographSessions { get; set; }
    }
}
