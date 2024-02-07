using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Лаб3.Models
{
    public interface IValueCalculator
    {
        
        decimal ValueProducts(IEnumerable<Product> products);
    }
    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscountHelper discounter;
        private static int counter = 0;
        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
            System.Diagnostics.Debug.WriteLine(string.Format("Instance {0} created", ++counter));
        }

        public decimal ValueProducts(IEnumerable<Product> products)
        {
            Func<int, int, string, double> f = (d, d1, d2) => {
                if (d2 == "a")
                    return d * d1;
                else
                    return 0; 
                    };

            f(1, 1, "f");

            System.Diagnostics.Debug.WriteLine(f(6, 10, "a").ToString());
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        }

        
    }
}