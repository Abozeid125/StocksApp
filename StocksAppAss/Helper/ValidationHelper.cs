using System.ComponentModel.DataAnnotations;

namespace StocksAppAss.Helper
{
    public class ValidationHelper
    {
        public static void ModelValidations(object obj)
        {

            //Model validation
            ValidationContext validationContext = new ValidationContext(obj);
            List<ValidationResult> results = new List<ValidationResult>();
            bool IsValid = Validator.TryValidateObject(obj, validationContext, results, true);
            if (!IsValid)
            {

                throw new ArgumentException(results.FirstOrDefault()?.ErrorMessage);
            }
        }

    }
}
