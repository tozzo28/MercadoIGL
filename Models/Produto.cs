using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProduto { get; set; }

        [Required(ErrorMessage = "Campo Fornecedor é OBRIGATORIO")]
        [Display(Name = "Fornecedor")]
        public int cnpjID { get; set; }

        // Propriedade de navegação para o Fornecedor
        [ForeignKey("cnpjID")]
        public Fornecedor fornecedor { get; set; }

        [Required(ErrorMessage = "Campo descricao é OBRIGATORIO")]
        [StringLength(50)]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Campo Valor Unitario é OBRIGATORIO")]
        public float valorUnitario { get; set; }

        [Required(ErrorMessage = "Campo Estoque é OBRIGATORIO")]
        public int estoque { get; set; }
    }
}
