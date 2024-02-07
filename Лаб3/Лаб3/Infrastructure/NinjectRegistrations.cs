using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Лаб3.Models;
using Ninject.Web.Common;

namespace Лаб3.Infrastructure
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IValueCalculator>().To<LinqValueCalculator>();
            Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithConstructorArgument("discountParam", 10M);
            Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WhenInjectedInto<LinqValueCalculator>().WithConstructorArgument("discountParam", 20M);
        }
    }
}