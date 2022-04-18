using Business.Abstract;
using Business.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class ClothesImageManager : IClothesImageService
    {
        IClothesImageDal _clothesImageDal;

        public ClothesImageManager(IClothesImageDal clothesImageDal)
        {
            _clothesImageDal = clothesImageDal;
        }

        public IResult Add(IFormFile file, ClothesImage clothesImage)
        {
            var imageCount = _clothesImageDal.GetAll(c => c.ClothesId == clothesImage.ClothesId).Count;

            if (imageCount>= 5)
            {
                return new ErrorResult("Bir ürünün en fazla 5 resimi olabilir ");
            }

            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }

            clothesImage.ImagePath = imageResult.Message;
            _clothesImageDal.Add(clothesImage);
            return new SuccessResult("resim yüklendi ");
        }

        public IResult Delete(ClothesImage clothesImage)
        {
            var image = _clothesImageDal.Get(c => c.ImageId == clothesImage.ImageId);
            if (image == null)
            {
                return new ErrorResult("resim bulunamadı");
            }

            FileHelper.Delete(image.ImagePath);
            _clothesImageDal.Delete(clothesImage);
            return new SuccessResult("resim silindi");
        }

        public IDataResult<List<ClothesImage>> GetAll()
        {
            return new SuccessDataResult<List<ClothesImage>>(_clothesImageDal.GetAll());
        }


        public IDataResult<ClothesImage> GetById(int imageId)
        {
            return new SuccessDataResult<ClothesImage>(_clothesImageDal.Get(p => p.ImageId == imageId));
        }

        public IDataResult<List<ClothesImage>> GetImagesByClothesId(int clothesId)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, ClothesImage clothesImage)
        {
            var isImage = _clothesImageDal.Get(c => c.ImageId == clothesImage.ImageId);
            if (isImage == null)
            {
                return new ErrorResult("resim bulunamadı");
            }

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }

            clothesImage.ImagePath = updatedFile.Message;
            _clothesImageDal.Update(clothesImage);
            return new SuccessResult("resim güncellendi");
        }
    }
}
