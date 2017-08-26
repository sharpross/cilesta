namespace Cilesta.Models.User
{
    using System.Text;

    public class RegistrationModel
    {
        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Error { get; set; }

        public bool IsValid()
        {
            var erros = new StringBuilder();

            if (string.IsNullOrEmpty(this.Login))
            {
                erros.AppendLine("Логин не может быть пустым.");
            }

            if (string.IsNullOrEmpty(this.Email))
            {
                erros.AppendLine("Email не может быть пустым.");
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                erros.AppendLine("Пароль не может быть пустым.");
            }

            if (this.Password.Length < 5)
            {
                erros.AppendLine("Пароль должен иметь минимум 5 символов.");
            }

            this.Error = erros.ToString();

            return true;
        }
    }
}