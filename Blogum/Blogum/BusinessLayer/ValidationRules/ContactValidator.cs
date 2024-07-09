using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using EntityLayer.Concrete;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contant>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Bir Ad Giriniz");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Lütfen Bir Soyad Giriniz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Lütfen Bir Mail Adresi Giriniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Lütfen Bir Konu Başlığı Yazınız");
            RuleFor(x => x.Message).NotEmpty().WithMessage("İletmek İstediniz Mesajı Boş Bırakmayınız");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Lütfen Daha Kısa Bir isim Giriniz");
            RuleFor(x => x.SurName).MaximumLength(50).WithMessage("Lütfen Daha Kısa Bir Soyad Giriniz");
            RuleFor(x => x.Mail).MaximumLength(150).WithMessage("Mail Adresi En Fazla 150 Karekter Olmalıdır");
            RuleFor(x => x.Subject).MaximumLength(250).WithMessage("Lütfen Konu Başlığını Daha Kısa Özetleyiniz");
            


        }
    }
}
