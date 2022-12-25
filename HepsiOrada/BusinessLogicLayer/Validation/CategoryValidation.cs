using DataAccessLayer.Abstract;
using Entity.POCO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Validation
{
    //Gelen datanın adının boş geçilemez olduğu örnekteki gibi şeyleri kontrol ederek onaylama işlemi yaptığımız kısım. Aşağıdaki katmanlara inmeden DAL katmanından gelen data ile kontrol yapmamızı sağlıyor. Bu kısımda Fluent Validation kütüphanesini NugetPackage'dan indirerek kullandık.
    public class CategoryValidation:AbstractValidator<Category>
    {
        public CategoryValidation(ICategoryDAL categoryDAL)
        {
            RuleFor(c => c.Name).NotNull().WithMessage("İsim kısmı boş geçilemez.");
            CategoryDAL = categoryDAL;
            RuleFor(x => x.Name).Must(CategoryNameValidation).WithMessage("Alan adı mevcuttur.");
        }
        public ICategoryDAL CategoryDAL { get; }
        public bool CategoryNameValidation(string categoryname)
        {
            //CategoryDAL'dan datayı getirdi. Enumarable tam tabloyu getirirdi, Querable olarak önce filtreleyerek getirdi. Name kısmı yeni eklemek istediğimiz catergoryname ile aynıysa false dönüp işlem yapmıyor. Null ise bu name daha önce kullanılmamış diye yorumlayarak ekleme yapmamızı sağlayan method.
            Category entity = CategoryDAL.Get().AsQueryable().FirstOrDefault(x => x.Name == categoryname);
            if (entity == null)
            {
                return true;

            }
            return false;

        }
    }
}
