using AutoMapper;
using CreditDemo.Common;
using CreditDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditDemo
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SaleModel, Sale>().ReverseMap();
            CreateMap<PaymentModel, Payment>().ReverseMap();
        }
    }
}
