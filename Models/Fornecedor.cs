using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Fornecedores")]
    public class Fornecedor
    {
        [Key]
        [Display(Name = "CNPJ")]
        public int cnpjFornecedor { get; set; }

        [Required (ErrorMessage = "Campo Empresa é OBRIGATORIO")]
        [StringLength (30)]
        [Display(Name = "Empresa")]
        public string empresa { get; set; }

        [Display(Name = "Telefone")]
        public int telefone { get; set; }

        [Required (ErrorMessage = "Campo Nome é OBRIGATORIO")]
        [StringLength(150)]
        [Display(Name = "Endereco")]
        public string endereco { get; set; }
    }
}
