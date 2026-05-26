using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnection.ViewModels
{
    public class RegisterVM
    {
        [MinLength(3,ErrorMessage = "Name must be minimum 3 symbols")]
        [MaxLength(20,ErrorMessage = "Name must be less 20 symbols")]
        public string Name { get; set; }
        [MinLength(3, ErrorMessage = "Surname must be minimum 3 symbols")]
        [MaxLength(20, ErrorMessage = "Surname must be less 20 symbols")]
        public string Surname { get; set; }
        [MinLength(3, ErrorMessage = "Username must be minimum 3 symbols")]
        [MaxLength(20, ErrorMessage = "Usename must be less 20 symbols")]
        public string Username { get; set; }
        [MaxLength(50,ErrorMessage ="Email must be less 50 symbols")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MinLength(8,ErrorMessage ="Password must be minimum 8 symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password),ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
