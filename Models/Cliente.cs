using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
        [Display (Name = "CPF")]
        public int cpfCliente { get; set; }

        [Required (ErrorMessage = "Campo Nome é OBRIGATORIO")]
        [StringLength (30)]
        [Display (Name = "Nome Completo")]
        public string nome { get; set; }

        [StringLength (150)]
        [Display (Name = "Endereco")]
        public string endereco { get; set; }
    }
}
