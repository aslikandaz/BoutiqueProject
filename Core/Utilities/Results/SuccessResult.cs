using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        // bu işlemler true nun default verilmesini sağladı
        public SuccessResult(string message) : base(true, message) // buradaki base resultı kastediyo result içinde iki parametreli constructor çalışır
        {// mesaj basmak istersek bu metot çalışır

        }

        public SuccessResult() : base(true)
        {
            // sadece işlem bilgisi basmak istediğimizde bu metot çalışır
        }
    }
}
