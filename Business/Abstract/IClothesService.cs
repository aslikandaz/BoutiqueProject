using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IClothesService
    {
        IDataResult<List<Clothes>> GetAll();
        IDataResult<List<Clothes>> GetAllByCategoryId(int id);
        IDataResult<List<Clothes>> GetAllByColorId(int id);
        IResult Add(Clothes clothes);
        IResult Update(Clothes clothes);
        IResult Delete(Clothes clothes);
        IDataResult<List<ClothesDetailDto>> GetClothesDetails();
        IDataResult<Clothes> GetById(int clothesId);
    }
}
