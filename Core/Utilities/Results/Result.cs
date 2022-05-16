using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        public Result(bool success, string message):this(success) 
        {// buradaki this şu demek result classındaki constructora (tek parametreli olana) success gönder çalışsın
            // yani iki parametreli çalıştığı zaman otomatik olarak tek parametreli de çalışır
            // hem mesaj hemde işlem bilgisi basmak istiyorum
            Message = message; // get read only olduğu için constructor da set edilebilir
        }

        //constructor overloading (iki farklı metod varmış gibi)
        public Result(bool success)
        {
            // sadece işlem bilgisi basmak istiyorum
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }

        
    }
}
