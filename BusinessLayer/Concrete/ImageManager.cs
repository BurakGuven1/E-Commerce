using Core.Utilities.Results;
using Entities.Concrete;
using System;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Core.Utilities.FileHelpers;
using BusinessLayer.Abstract;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace BusinessLayer.Concrete
{
    public class ImageManager : IImageService
    {

        IImageDal _imageDal;
        IProductService _productService;

        public ImageManager(IImageDal imageDal, IProductService productDal)
        {
            _imageDal = imageDal;
            _productService = productDal;
        }

        public IDataResult<Image> add(IFormFile image, Product product)
        {
            var productget = _productService.GetById(product.ProductID);

            if (productget == null)
            {

                return new ErrorDataResult<Image>("product yok");
            }
            productget.Data.ProductPhoto = FileHelper.newPath(image);

           var result= _productService.Update(productget.Data);
            if (!result.Success)
            {

                return new ErrorDataResult<Image>("image eklenemedi");
            }
           

            
            return new SuccessDataResult<Image>("image eklendi");

        }

        public IResult deleteImage(Image image)
        {
            _imageDal.Delete(image);
            return new SuccessResult("silindi");
        }

        public IDataResult<Image> get(int productId)
        {
            var result = _imageDal.Get((ring) => ring.productId == productId);
            
            if (result != null)
            {
                return new SuccessDataResult<Image>(result);
            }
            return new ErrorDataResult<Image>();
        }

        public IDataResult<List<Image>> getAll()
        {
            throw new NotImplementedException();
        }
    }
}
