using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace APIFornecedores.Validations
{
    public class EmailValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string email = value.ToString();
            bool emailValido =Regex.IsMatch(email, @"^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$");

            if (emailValido)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("E-mail inválido.");
            }
        }
    }
}
