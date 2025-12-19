using System;
using System.Collections.Generic;
using System.Text;

namespace CManager.Presentation.ConsoleApp.Interfaces
{
    public interface IUserInputValidator
    {
        //validation methods, return true or false

        //validate name
        bool ValidateName(string content);


        //validate email
        bool ValidateEmail(string email);


        //validate telephone number
        bool ValidateTelephone(string telephone);

        //validate postal code
        bool ValidatePostalCode(string postalCode);
    }
}
