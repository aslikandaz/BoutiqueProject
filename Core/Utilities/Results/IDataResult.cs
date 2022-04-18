using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>:IResult//IResult mesaj ve işlem sonucu kodlarının tekrar yazılmamasını sağlar
    {
        //bool Success { get; } string Message { get; } interface , interface implemente ettiği için bunlar tekrar yazılmadı zaten varmış gibi
        T Data { get; } //data listelenecek türleri ifade ediyo kısıtlama yazmıyoruz çünkü her şey olabilir
    }
}
