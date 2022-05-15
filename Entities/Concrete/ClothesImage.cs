using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete
{
    public class ClothesImage:IEntity
    {
        public int ImageId { get; set; }
        public int ClothesId { get; set; }
        public string ImagePath { get; set; }

    }
}
