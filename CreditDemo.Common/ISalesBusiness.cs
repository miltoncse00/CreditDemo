using CreditDemo.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreditDemo.Common
{
    public interface ISalesBusiness
    {
        Task<bool> SaveSales(SaleModel saleModel);
    }
}
