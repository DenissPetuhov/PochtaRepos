using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PorchtaRissiiDesign1._0.App;

namespace PorchtaRissiiDesign1._0.Utils
{
    internal class UserCredentialValidator
    {
        private static int CREDENTIAL_MIN_LENGTH = 4;
        private static int CREDENTIAL_MAX_LENGTH = 15;

        public string validateLogin(string login, string password)
        {
            StringBuilder errorMeassage = new StringBuilder();

            string loginErrorMessage = validateLogin(login);
            if (!string.IsNullOrEmpty(loginErrorMessage))
                errorMeassage.AppendLine(loginErrorMessage);

            string passwordErrorMessage = validatePassword(password);
            if (!string.IsNullOrEmpty(passwordErrorMessage))
                errorMeassage.AppendLine(passwordErrorMessage);
            return errorMeassage.ToString();
        }
        public string validateRegist(string login, string password, string password2, string name)
        {
            StringBuilder errorMeassage = new StringBuilder();

            string loginErrorMessage = validateLogin(login);
            if (!string.IsNullOrEmpty(loginErrorMessage))
                errorMeassage.AppendLine(loginErrorMessage);

            string passwordErrorMessage = validatePassword(password);
            if (!string.IsNullOrEmpty(passwordErrorMessage))
                errorMeassage.AppendLine(passwordErrorMessage);

            string password2ErrorMessage = validatePassword2(password2);
            if (!string.IsNullOrEmpty(password2ErrorMessage))
                errorMeassage.AppendLine(password2ErrorMessage);

            string nameErrorMessage = validateName(name);
            if (!string.IsNullOrEmpty(nameErrorMessage))
                errorMeassage.AppendLine(nameErrorMessage);

            if (password != password2)
                errorMeassage.AppendLine("Пароли не совподают!");

            return errorMeassage.ToString();
        }
        private string validateLogin(string login)
        {
            string trimedLogin = login.Trim();
            string loginErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(trimedLogin))
                loginErrorMessage = "Поле Логин пустое";
            else if (trimedLogin.Length < CREDENTIAL_MIN_LENGTH)
                loginErrorMessage = "Логин слишком короткий";
            else if (trimedLogin.Length > CREDENTIAL_MAX_LENGTH)
                loginErrorMessage = "Логин слишком длинный";

            return loginErrorMessage;
        }
        private string validatePassword(string password)
        {
            string trimedPassword = password.Trim();
            string passwordErrorMessage = string.Empty;

            if (string.IsNullOrEmpty(trimedPassword))
                passwordErrorMessage = "Поле Пароль пустое";
            else if (trimedPassword.Length < CREDENTIAL_MIN_LENGTH)
                passwordErrorMessage = "Пароль слишком короткий";
            else if (trimedPassword.Length > CREDENTIAL_MAX_LENGTH)
                passwordErrorMessage = "Пароль слишком длинный";

            return passwordErrorMessage;
        }

        private string validatePassword2(string password2)
        {
            string tirmedPassword2 = password2.Trim();
            string password2ErrorMessage = string.Empty;
            if (string.IsNullOrEmpty(tirmedPassword2))
                password2ErrorMessage = "Поле Повторите пароль пустое";
            else if (tirmedPassword2.Length < CREDENTIAL_MIN_LENGTH)
                password2ErrorMessage = "Второй Пароль слишком короткий";
            else if (tirmedPassword2.Length > CREDENTIAL_MAX_LENGTH)
                password2ErrorMessage = "Второй Пароль слишком длинный";

            return password2ErrorMessage;
        }
        private string validateName(string name)
        {
            string trimedName = name.Trim();
            string nameErrorMessage = string.Empty;
            if (string.IsNullOrEmpty(trimedName))
                nameErrorMessage = "Поле Имя пустое!";
            else if (trimedName.Length < CREDENTIAL_MIN_LENGTH)
                nameErrorMessage = "Поле Имя слишком короткое";
            else if (trimedName.Length > CREDENTIAL_MAX_LENGTH)
                nameErrorMessage = "Поле Имя слишком длинное";

            return nameErrorMessage;
        }


    }
}
