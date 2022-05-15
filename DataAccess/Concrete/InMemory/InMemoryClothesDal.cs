using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryClothesDal : IClothesDal
    {
        List<Clothes> _clothes;

        public InMemoryClothesDal()
        {
            _clothes = new List<Clothes>
            {
                new Clothes{ClothesId = 1, CategoryId = 1,ColorId = 1,ClothesName = "kazak",UnitsInStock =15, UnitPrice = 15,Description = "beyaz yünlü kazak"},
                new Clothes{ClothesId = 2, CategoryId = 1,ColorId = 1,ClothesName = "t-shirt",UnitsInStock =3, UnitPrice = 500,Description = "beyaz t-shirt"},
                new Clothes{ClothesId = 3, CategoryId = 2,ColorId = 2,ClothesName = "süveter",UnitsInStock =2, UnitPrice = 1500,Description = "yünlü süveter"},
                new Clothes{ClothesId = 4, CategoryId = 2,ColorId = 3,ClothesName = "pantolon",UnitsInStock =65, UnitPrice = 150,Description = "kot pantolon"},
                new Clothes{ClothesId = 5, CategoryId = 3,ColorId = 4,ClothesName = "etek",UnitsInStock =1, UnitPrice = 85,Description = "mavi etek"}
            };
        }

        public void Add(Clothes clothes)
        {
            _clothes.Add(clothes);
        }

        public void Delete(Clothes clothes)
        {
            Clothes clothesToDelete = _clothes.SingleOrDefault(c => c.ClothesId == clothes.ClothesId);
            _clothes.Remove(clothesToDelete);
        }

        public Clothes Get(Expression<Func<Clothes, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Clothes> GetAll()
        {
            return _clothes;
        }

        public List<Clothes> GetAll(Expression<Func<Clothes, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Clothes> GetById(int clothesId)
        {
            return _clothes.Where(c => c.ClothesId == clothesId).ToList();
        }

        public Clothes GetById(Expression<Func<Clothes, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ClothesDetailDto> GetClothesDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Clothes clothes)
        {
            Clothes clothesToUpdate = _clothes.SingleOrDefault(c => c.ClothesId == clothes.ClothesId);
            clothesToUpdate.ClothesName = clothes.ClothesName;
            clothesToUpdate.CategoryId = clothes.CategoryId;
            clothesToUpdate.ColorId = clothes.ColorId;
            clothesToUpdate.UnitsInStock = clothes.UnitsInStock;
            clothesToUpdate.UnitPrice = clothes.UnitPrice;
            clothesToUpdate.Description = clothes.Description;
        }
    }
}
