using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IShipperService
    {
        IDataResult<List<Shipper>> GetAll();
        IDataResult<Shipper> GetById(int shipperId);
        IResult Add(Shipper shipper);
        IResult Update(Shipper shipper);
        IResult Delete(Shipper shipper);
    }
}
