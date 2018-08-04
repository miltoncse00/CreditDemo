using AutoMapper;
using CreditDemo.Common;
using CreditDemo.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreditDemo.Business
{
    public class SalesBusiness : ISalesBusiness
    {
        private readonly SaleContext saleContext;
        private readonly IMapper mapper;

        public SalesBusiness(SaleContext saleContext, IMapper mapper)
        {
            this.saleContext = saleContext;
            this.mapper = mapper;
        }
        public async Task<bool> SaveSales(SaleModel saleModel)
        {
            var saleEntity = mapper.Map<Sale>(saleModel);
            saleContext.Sales.Add(saleEntity);
            var result = await saleContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
