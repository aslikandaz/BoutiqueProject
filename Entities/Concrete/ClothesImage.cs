using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class ClothesImage:IEntity
    {
        public int ImageId { get; set; }
        public int ClothesId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }

    }
}
