using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IClothesImageService
    {
        IResult Add(IFormFile file,ClothesImage clothesImage);
        IResult Update(IFormFile file,ClothesImage clothesImage );
        IResult Delete(ClothesImage clothesImage );
        IDataResult<List<ClothesImage>> GetAll();
        IDataResult<ClothesImage> GetById(int imageId);
        IDataResult<List<ClothesImage>> GetImagesByClothesId(int clothesId);

    }
}
