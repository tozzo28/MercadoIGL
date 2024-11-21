using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MercadoIGL.Models
{
    [Table("Vendas")]
    public class Venda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int idVenda { get; set; }

        [Display(Name = "Produto")]
        public int ProdutoID { get; set; }
        [ForeignKey("ProdutoID")]
        public Produto produto { get; set; }

        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }
        [ForeignKey("ClienteID")]
        public Cliente cliente { get; set; }

        [Display(Name = "Funcionario")]
        public int FuncionarioID { get; set; }
        [ForeignKey("FuncionarioID")]
        public Funcionario funcionario { get; set; }

        [Display(Name = "Quantidade")]
        [Required]
        public int QntdVendida { get; set; }

        [Display(Name = "Valor Total")]
        public float valorTotal { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        public DateTime? data { get; set; }
    }
}
