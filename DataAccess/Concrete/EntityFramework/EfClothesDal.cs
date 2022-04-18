using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfClothesDal : EfEntityRepositoryBase<Clothes, BoutiqueDbContext>, IClothesDal
    {
        public List<ClothesDetailDto> GetClothesDetails()
        {
            using (BoutiqueDbContext context = new BoutiqueDbContext())
            {
                var result = from p in context.Clothes
                    join c in context.Categories on p.CategoryId equals c.CategoryId
                    join r in context.Colors on p.ColorId equals r.ColorId
                    select new ClothesDetailDto
                    {
                        ClothesId = p.ClothesId, ClothesName = p.ClothesName, CategoryName = c.CategoryName,
                        ColorName = r.ColorName, UnitsInStock = p.UnitsInStock, UnitPrice = p.UnitPrice
                    };
                return result.ToList();
            }
        }
    }
}
