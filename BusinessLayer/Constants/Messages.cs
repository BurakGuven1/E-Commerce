﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda !";
        public static string ProductsListed = "Ürünler Listelendi !";
        public static string UnitPriceInvalid = "Fiyat Geçersiz !";
        public static string CartAdded = "sepet eklendi";
        public static string ProductCountOfCategoryError="Bir kategoride en fazla 21 ürün olabilir"; // sonrası için satış taktiği olarak kullanılabilir bu kısıtlama
        public static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var";
        public static string CategoryLimitExceded="Kategori limiti aşıldı";
    }
}
 