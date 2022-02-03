using System.ComponentModel.DataAnnotations;

namespace DocumentMono.API.Model
{
    /// <summary>
    /// Kullanıcı giriş teği modeli
    /// </summary>
    public class LoginRequestModel
    {
        /// <summary>
        /// Kullanıcı adı
        /// </summary>
        [Required(ErrorMessage ="Kullanıcı boş geçilemez")]
        public string Username { get; set; }
        /// <summary>
        /// Parola
        /// </summary>
        [Required(ErrorMessage ="Parola boş geçilemez")]
        public string Password { get; set; }
    }
}
