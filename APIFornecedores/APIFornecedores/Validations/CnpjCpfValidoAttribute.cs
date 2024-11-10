using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace APIFornecedores.Validations
{
    public class CnpjCpfValidoAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           string cnpjCpf = value.ToString();
            cnpjCpf = cnpjCpf.Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpjCpf.Length == 11 )
            {
                return ValidarCPF(cnpjCpf);

            }
            else if (cnpjCpf.Length == 14 )
            {
               return ValidarCNPJ(cnpjCpf);
            }
            else if (!long.TryParse(cnpjCpf, out _))
            {
                return new ValidationResult("O CNPJ/CPF devem receber apenas números.");
            }
            else
            {
                return new ValidationResult("CNPJ/CPF inválido.");
            }
        }

        private ValidationResult? ValidarCPF(string cnpjCpf)
        {
            var numeros = cnpjCpf.Select(c => int.Parse(c.ToString())).ToArray();

            if (numeros.Distinct().Count() == 1)
                return new ValidationResult("CPF inválido. Todos dígitos não podem ser iguais.");


            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += numeros[i] * (10 - i);

            int primeiroDigitoVerificador = (soma % 11 < 2) ? 0 : 11 - (soma % 11);

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += numeros[i] * (11 - i);

            int segundoDigitoVerificador = (soma % 11 < 2) ? 0 : 11 - (soma % 11);

            bool valido = numeros[9] == primeiroDigitoVerificador && numeros[10] == segundoDigitoVerificador;

            if (valido)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("CPF inválido.");
            }
        }
        private ValidationResult? ValidarCNPJ(string cnpjCpf)
        {
            var numeros = cnpjCpf.Select(c => int.Parse(c.ToString())).ToArray();

            if (numeros.Distinct().Count() == 1)
                return new ValidationResult("CNPJ inválido. Todos dígitos não podem ser iguais.");

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += numeros[i] * multiplicador1[i];

            int primeiroDigitoVerificador = (soma % 11 < 2) ? 0 : 11 - (soma % 11);

            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += numeros[i] * multiplicador2[i];

            int segundoDigitoVerificador = (soma % 11 < 2) ? 0 : 11 - (soma % 11);

            bool valido = numeros[12] == primeiroDigitoVerificador && numeros[13] == segundoDigitoVerificador;

            if (valido)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("CNPJ inválido.");
            }
        }
    }
}
