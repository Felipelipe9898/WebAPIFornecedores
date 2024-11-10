using System.ComponentModel.DataAnnotations;

namespace APIFornecedores.Validations
{
    public class PrimeiraLetraMauisculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var primeiraLetra = value.ToString()[0].ToString();
            if (primeiraLetra != primeiraLetra.ToUpper())
            {
                return new ValidationResult("A primeira letra do nome do Fornecedor deve ser maiúscula.");
            }

            return ValidationResult.Success;
        }
    }
}
