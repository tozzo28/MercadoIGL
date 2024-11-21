using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Funcionarios")]
    public class Funcionario
    {
        [Key]
        [Display(Name = "CPF")]
        public int cpfFuncionario { get; set; }

        [Required (ErrorMessage = "Campo Nome é OBRIGATORIO")]
        [StringLength(30)]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required (ErrorMessage = "Campo Cargo é OBRIGATORIO")]
        [StringLength(20)]
        [Display(Name = "Cargo")]
        public string cargo { get; set; }
    }
}
