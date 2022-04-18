using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {

        public ErrorDataResult(T data, string message) : base(data, false, message)
        {
            // data ve mesaj
        }

        public ErrorDataResult(T data) : base(data, false)
        {
            //sadece data
        }

        public ErrorDataResult(string message) : base(default, false, message)
        {
            // sadece mesaj (data default)
        }

        public ErrorDataResult() : base(default, false)
        {
            // boş hiçbirşey dönmüyo
        }
    }
}
