using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        // , ile birden fazla IResult parametresi geçebiliriz.
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    //parametreyle gönderdiğimiz iş kurallarını business a şu logic hatalı diyoruz. 
                    return logic; // kurala uymayanı döndür
                }
            }
            return null; 
        }
    }
}
