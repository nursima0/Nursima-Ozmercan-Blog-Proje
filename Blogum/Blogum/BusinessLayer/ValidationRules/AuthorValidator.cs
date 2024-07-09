using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using EntityLayer.Concrete;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Sevgili Kullanıcımız Lütfen Yazar Adını Boş Geçmeyiniz");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Lütfen Bu Alanı Boş Geçmeyiniz");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Lütfen Yazar Hakkında Bir Açıklama Ekleyiniz");
            RuleFor(x => x.AuthorName).MinimumLength(3).WithMessage("Lütfen Yazar Adını Tam Giriniz");
        }
    }
}
