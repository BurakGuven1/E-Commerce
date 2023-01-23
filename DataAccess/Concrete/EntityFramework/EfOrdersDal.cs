using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrdersDal:EfEntityRepositoryBase<Orders,dbContext>,IOrdersDal
    {
        public Orders getAddandgetId(Orders product)
        {
            Orders returnproduct = product;

            using (dbContext context = new dbContext())
            {
                var addedEntity = context.Entry(product); //ref i yakala
                addedEntity.State = EntityState.Added; // bu aslında eklenebilecek bi nesne
                context.SaveChanges(); //ekle 
                returnproduct = addedEntity.Entity;
            }
            return returnproduct;
        }
    }
}
