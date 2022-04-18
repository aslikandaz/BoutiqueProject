using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ClothesDetailDto:IDto
    {
        public int ClothesId { get; set; }
        public string ClothesName { get; set; }
        public string CategoryName { get; set; }
        public string ColorName { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitPrice { get; set; }

    }
}
