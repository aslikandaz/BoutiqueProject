using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class ClothesImagesController:ControllerBase
    {
         IClothesImageService _clothesImageService;

        public ClothesImagesController(IClothesImageService clothesImageService)
        {
            _clothesImageService = clothesImageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name="image")] IFormFile file, [FromForm] ClothesImage image)
        {
            var result = _clothesImageService.Add( image, file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(ClothesImage clothesImage)
        {

            var carDeleteImage = _clothesImageService.GetById(clothesImage.ImageId).Data;

            var result = _clothesImageService.Delete(carDeleteImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] ClothesImage clothesImage)
        {
            var result = _clothesImageService.Update(file, clothesImage);
            
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _clothesImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int imageId)
        {
            var result = _clothesImageService.GetById(imageId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyclothesid")]
        public IActionResult GetByImageId(int clothesId)
        {
            var result = _clothesImageService.GetImagesByClothesId(clothesId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
