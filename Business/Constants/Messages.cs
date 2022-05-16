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
        public static string AuthorizationDenied = "Yetkiniz yok.";

        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Access Token başarıyla oluşturuldu";
    }
}

