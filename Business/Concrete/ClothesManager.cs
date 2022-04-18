using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class ClothesManager : IClothesService
    {
        IClothesDal _clothesDal;
        // clothes manager newlendiğinde constructor bana bir IClothesDal referansı ver
        public ClothesManager(IClothesDal clothesDal) // bu kısım constructor
        {
            _clothesDal = clothesDal;
        }

        [ValidationAspect(typeof(ClothesValidator))]
        public IResult Add(Clothes clothes)
        {

            _clothesDal.Add(clothes);
            return new SuccessResult(Messages.ClothesAdded);
        }

        public IResult Delete(Clothes clothes)
        {
            _clothesDal.Delete(clothes);
            return new SuccessResult(Messages.ClothesDeleted);
        }

        public IDataResult<List<Clothes>> GetAll()
        {
            //iş kodları
            // yetkisi var mı?
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Clothes>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Clothes>>(_clothesDal.GetAll(),Messages.ClothesListed);

        }

        public IDataResult<List<Clothes>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Clothes>>(_clothesDal.GetAll(c => c.CategoryId == id));
        }

        public IDataResult<List<Clothes>> GetAllByColorId(int id)
        {
            return new SuccessDataResult<List<Clothes>>(_clothesDal.GetAll(c => c.ColorId == id));
        }

        public IDataResult<Clothes> GetById(int clothesId)
        {
            return new SuccessDataResult<Clothes>(_clothesDal.Get(p=>p.ClothesId== clothesId));
        }

        public IDataResult<List<ClothesDetailDto>> GetClothesDetails()
        {
            return new SuccessDataResult<List<ClothesDetailDto>>(_clothesDal.GetClothesDetails());
        }

        public IResult Update(Clothes clothes)
        {
            _clothesDal.Update(clothes);
            return new SuccessResult(Messages.ClothesUpdated);
        }
    }
}
