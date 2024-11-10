using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace APIFornecedores.Validations
{
    public class ApenasNumerosAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            bool apenasNumeros = Regex.IsMatch(value.ToString(), @"^\d+$");

            if (!apenasNumeros)
            {
                return new ValidationResult("Insira apenas números para o telefone.");
            }
            return ValidationResult.Success;
        }
    }
}
