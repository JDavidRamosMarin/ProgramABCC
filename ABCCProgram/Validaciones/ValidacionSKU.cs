using System.ComponentModel.DataAnnotations;

namespace ABCCProgram.Validaciones
{
    public class ValidacionSKU: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string sku = value.ToString();

            if (sku.Length != 6)
            {
                return new ValidationResult("El SKU debe tener 6 digitos.");
            }

            return ValidationResult.Success;
        }
    }
}
