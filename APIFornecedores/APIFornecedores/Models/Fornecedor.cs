using APIFornecedores.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APIFornecedores.Models
{
    public class Fornecedor
    {
        public Fornecedor()
        {
            DataCadastro = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do usuário é obrigatório", AllowEmptyStrings = false)]
        [StringLength(80, ErrorMessage ="O nome deve ter entre 5 e 80 caracteres", MinimumLength =5)]
        [PrimeiraLetraMauiscula]
        public string? Nome { get; set; }
        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [EmailValido]
        public string? Email { get; set; }

        [ApenasNumerosAttribute]
        public string? Telefone { get; set; }   

        [Required(ErrorMessage = "O CNPJ/CPF é obrigatório.")]
        [CnpjCpfValido]
        public string? CNPJ_CPF { get; set; }
        public string? NomeFantasia { get; set; }
        [JsonIgnore]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DataCadastro { get; set; }

    }

    
}
