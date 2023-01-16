using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageService
    {
        IDataResult<List<Image>> getAll();

        IDataResult<Image> get(int productId);

        IDataResult<Image> add(IFormFile image, Product product);
        IResult deleteImage(Image image);
    }
}
