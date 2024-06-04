using System.ComponentModel.DataAnnotations;

namespace ActivityHub.Presantaion.Models
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "İsim gereklidir.")]
        public string FirstName { get; set; } = "Hakan";

        [Required(ErrorMessage = "Soyisim gereklidir.")]
        public string LastName { get; set; } = "Öztürk";

        [Required(ErrorMessage = "Email gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
