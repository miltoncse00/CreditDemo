using AutoMapper;
using CreditDemo.Common;
using CreditDemo.Data;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<SaleModel>> GetAll()
        {
            var result =await  saleContext.Sales.Include(m =>m.Payments).ToListAsync();
            var resultModel = mapper.Map<List<SaleModel>>(result);
            return resultModel;
        }

        public async Task<bool> SaveSales(SaleModel saleModel)
        {
            saleModel.TimeStamp = DateTime.UtcNow;
            var saleEntity = mapper.Map<Sale>(saleModel);
            saleContext.Sales.Add(saleEntity);
            var result = await saleContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
