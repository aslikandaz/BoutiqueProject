using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ClothesTest();
            //CategoryTest();


            //ClothesCRUDTest();
        }

        private static void ClothesCRUDTest()
        {
            ClothesManager clothesManager = new ClothesManager(new EfClothesDal());
            foreach (var clothes in clothesManager.GetAll().Data)
            {
                Console.WriteLine(clothes.ClothesName);
            }

            clothesManager.Delete(new Clothes {ClothesId = 4});

            foreach (var clothes in clothesManager.GetAll().Data)
            {
                Console.WriteLine(clothes.ClothesName);
            }
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ClothesTest()
        {
            ClothesManager clothesManager = new ClothesManager(new EfClothesDal());
            var result = clothesManager.GetClothesDetails();
            if (result.Success == true)
            {
                foreach (var clothes in result.Data)
                {
                    Console.WriteLine(clothes.ClothesName + "/" + clothes.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}
