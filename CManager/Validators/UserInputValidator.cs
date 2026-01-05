using CManager.Presentation.ConsoleApp.Interfaces;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace CManager.Presentation.ConsoleApp.Validators
{
    internal class UserInputValidator : IUserInputValidator
    {
        //method to validate name
        public bool ValidateName(string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return false;

            //Used Gemini PRO to write Regular Expression with parameters for length >2, <50, allow letters, spaces and hyphens only

            string regex = @"^[\p{L}\s\-]{2,50}$";

            content = content.Trim();

            //returns true if match is found -> Valid!

            return Regex.IsMatch(content, regex);
        }



        //method to validate email
        public bool ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            //built in .NET email validation method
            try
            {
                var addr = new MailAddress(email);

                if (addr.Address == email)
                {
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }

        }


        //method to validate telephone number
        public bool ValidateTelephone(string telephone)
        {
            if (string.IsNullOrWhiteSpace(telephone)) return false;

            var trimmedNum = telephone.Replace(" ", string.Empty);

            //Used Gemini PRO to write Regular Expression with parameters for length >8, <15, allow digits, spaces, hyphens, parentheses and plus sign only
            string pattern = @"^[\d\s\-\+\(\)]{8,15}$";

            //returns true if match is found -> Valid!
            return Regex.IsMatch(trimmedNum, pattern);
        }

        //method to validate postal code
        public bool ValidatePostalCode(string postalCode)
        {
            if (string.IsNullOrWhiteSpace(postalCode)) return false;

            var trimmedNum = postalCode.Replace(" ", string.Empty);

            //Used Gemini PRO to write Regular Expression
            string pattern = @"^\d{5}$";

            return Regex.IsMatch(trimmedNum, pattern);

        }

    }
}