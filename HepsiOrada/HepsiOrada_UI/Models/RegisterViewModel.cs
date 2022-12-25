using System.ComponentModel.DataAnnotations;

namespace HepsiOrada_UI.Models
{
    public class RegisterViewModel
    {
        //Register sayfasını yapabilmek için oluşturduğumuz sınıf. Burada Attribute'leri kullandık. Propertylere bazı zorunlulukları tanımladık. Kullanıcı veri girerken oluşan nesnede bu zorunluluklar karşılanmıyorsa, Attribute'lerin içlerine tanımladığımız ErrorMessage'ları gönderecek.
        [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage ="Email adresi girmek zorunludur.")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="Geçerli bir E-mail adresi girmeniz gerekmektedir.")]
        public string? Email { get; set; }

        [Required(ErrorMessage ="Şifre girmek zorunludur.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? PasswordConfirm { get; set; }
    }
}
