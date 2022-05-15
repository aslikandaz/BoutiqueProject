using Business.Abstract;
using Business.Constants;
using System;
using Core.Utilities.Business;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Business.Concrete
{
    public class ClothesImageManager : IClothesImageService
    {
        IClothesImageDal _clothesImageDal;
        

        public ClothesImageManager(IClothesImageDal clothesImageDal)
        {
            _clothesImageDal = clothesImageDal;
            
        }

        public IResult Add( ClothesImage clothesImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckImageCount(clothesImage.ClothesId));
            if (result != null)
            {
                return result;
            }
            var imageResult = FileHelper.Add(file);
            if (!imageResult.IsSuccess)
            {
                return new ErrorResult("");
            }
            clothesImage.ImagePath = imageResult.Message;
            _clothesImageDal.Add(clothesImage);
            return new SuccessResult();
        }

        public IResult Delete(ClothesImage clothesImage)
        {
            var result = _clothesImageDal.GetById(x => x.ClothesId == clothesImage.ClothesId);
            if (result == null)
            {
                return new ErrorResult("Image not found");
            }
            FileHelper.Delete(result.ImagePath);
            _clothesImageDal.Delete(clothesImage);
            return new SuccessResult("Image was deleted succesfully");
        }

        public IDataResult<List<ClothesImage>> GetAll()
        {
            var result = (_clothesImageDal.GetAll());
            return new SuccessDataResult<List<ClothesImage>>(result);
        }

        public IDataResult<ClothesImage> GetById(int imageId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ClothesImage>> GetImagesByClothesId(int clothesId)
        {
            var result = _clothesImageDal.GetAll(c => c.ClothesId == clothesId);
            if (result.Count == 0)
            {
                return new ErrorDataResult<List<ClothesImage>>(Messages.NoImages);
            }
            return new SuccessDataResult<List<ClothesImage>>(result);
        }

        public IResult Update(IFormFile file, ClothesImage clothesImage)
        {
            var updatedFile = FileHelper.Update(file, clothesImage.ImagePath);
            if (!updatedFile.IsSuccess)
            {
                return new ErrorResult(updatedFile.Message);
            }
            clothesImage.ImagePath = updatedFile.Message;
            _clothesImageDal.Update(clothesImage);
            return new SuccessResult(Messages.ImagesUpdated);
        }

        private IResult CheckImageCount(int id)
        {
            var result = _clothesImageDal.GetAll(x => x.ClothesId == id).Count();
            if (result > 5)
            {
                return new ErrorResult(Messages.ClothesImageLimit);
            }
            return new SuccessResult();
        }
    }
}
