using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using EntityLayer.Concrete;

namespace BusinessLayer.ValidationRules
{
  public  class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Lütfen Bir Açıklama Yazınız");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen En Az 3 Karakterlik Bir Ad Giriniz");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("50 Karakterlik Yazım Sınırını Geçtiniz, Lütfen Daha Az Bir Kategori Adı Giriniz ");
            RuleFor(x => x.CategoryDescription).MinimumLength(20).WithMessage("Sevgili Kullanıcım Lütfen En Az 20 Karakter Giriniz");
        }
    }
}
