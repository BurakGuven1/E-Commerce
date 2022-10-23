using BusinessLayer.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program   
    {
        static void Main(string[] args)
        {
            ProductTest();
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetProductDetails();

            if (result.Success==true)
            {
                foreach (var product in result.Data) // varsa kategori ona göre bi ekran yapıyor.
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }
            else // bu kategoride sana göre bi ürün yoksa burası çalışıyor örneğin.
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
