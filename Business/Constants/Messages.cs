using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ClothesAdded = "Ürün eklendi";
        public static string ClothesDeleted = "Ürün silindi";
        public static string ClothesUpdated = "Ürün güncellendi";
        public static string ClothesUnitPriceInvalid = "Ürün fiyatı geçersiz";
        public static string ClothesNameInvalid = "Ürün ismi geçersiz";
        public static string ClothesListed = "Ürünler Listelendi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ClothesImageLimit = "ürün resim sayısı aşıldı";
        public static string NoImages = "ürüne ait resim bulunamadı";
        public static string ImagesUpdated = "ürüne ait resim güncellendi";
    }
}

