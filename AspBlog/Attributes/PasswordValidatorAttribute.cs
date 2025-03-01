using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace AspBlog.Attributes
{
    public class PasswordValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid (object value)
        {
            if (value is string password)
            {
                bool hasUppercase = Regex.IsMatch(password, "[A-Z]");
                bool hasLowercase = Regex.IsMatch(password, "[a-z]");
                bool hasNumber = Regex.IsMatch(password, "[0-9]");
                bool hasSpecialChar = Regex.IsMatch(password, "[^a-zA-Z0-9]");

                List<string> errors = new List<string>();

                if (!hasLowercase) errors.Add("Malé písmeno");
                if (!hasUppercase) errors.Add("Velké písmeno");
                if (!hasNumber) errors.Add("Číslo");
                if (!hasSpecialChar) errors.Add("Speciální znak");

                if (errors.Any())
                {
                    ErrorMessage = "Heslo musí obsahovat:\n" + string.Join("\n", errors);
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
