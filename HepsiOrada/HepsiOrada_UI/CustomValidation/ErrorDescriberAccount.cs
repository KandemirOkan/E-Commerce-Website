using Microsoft.AspNetCore.Identity;

namespace HepsiOrada_UI.CustomValidation
{
    //Bu class Register işlemlerindeki uygulanması istediğimiz validationleri çeken kütüphaneden kalıtım almaktadır.
    public class ErrorDescriberAccount:IdentityErrorDescriber
    {
        public override IdentityError PasswordRequiresUpper()
        {
            var error = new IdentityError();
            error.Code = "Büyük Harf";
            error.Description = "Şifrenizde en az 1 büyük harf olması zorunludur.";
            return error;
        }
        public override IdentityError PasswordRequiresDigit()
        {
            var error2 = new IdentityError();
            error2.Code = "Digit";
            error2.Description = "Şifrenizde en az 1 adet rakam olmak zorundadır.";
            return error2;
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            var error2 = new IdentityError();
            error2.Code = "Digit";
            error2.Description = "Şifrenizde en az 1 adet noktalama işareti olmalıdır..";
            return error2;
        }

    }
}
