﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepo<T> where T:class,IEntity,new()  //generic kısıt bu.
        //class : referans tip olabilir demek.
        // IEntity olabilir veya IEntity implemente edenler olabilir.
        //new, newlenebilir olmalı demek ( IEntityi saf dışı bıraktık böylece Product-Customer-Category istiyoruz sadece)
    {
        List<T> GetAll(Expression<Func<T,bool>> filter= null);

        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
