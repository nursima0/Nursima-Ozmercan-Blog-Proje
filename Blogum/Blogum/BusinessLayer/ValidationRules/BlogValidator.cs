using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using EntityLayer.Concrete;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Sevgili Kullanıcımız Lütfen Bu Alanı Doldurunuz");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen Daha Uzun Bir Başlık Oluşturunuz");
            RuleFor(x => x.BlogTitle).MaximumLength(15).WithMessage("Lütfen Daha Kısa Bir Başlık Yazınız");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Sevgili Kullanıcımız Lütfen Bu Alanı Boş Bırakmayınız");
            RuleFor(x => x.BlogContent).MinimumLength(10).WithMessage("Lütfen Açıklamayı Daha Uzun Yazınız");
            
        }

    }
}
