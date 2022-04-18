using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    // temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; } // buradaki get bir şeyi return et demek
        string Message { get; }
        // bu propertylerin set edilme işlemi constructor içinde yapılacak
    }
}
