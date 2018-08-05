using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CreditDemo.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditDemo.Controllers
{
    [Route("api/Sales")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly ISalesBusiness salesBusiness;

        public SalesController(ISalesBusiness salesBusiness)
        {
            this.salesBusiness = salesBusiness;
        }


        [HttpGet]
        [Produces("application/json", Type = typeof(SaleModel))]
        public async Task<IActionResult> GetAll()
        {
            try
            {

                var result = await salesBusiness.GetAll();

                return Ok(result);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.UnabledToGetRecords);
            }
        }

        [HttpGet]
        [Route("SaleId")]
        [Produces("application/json", Type = typeof(long))]

        public IActionResult SaleId()
        {
            try
            {

                var result = salesBusiness.GetSaleId();

                return Ok(result);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.UnabledToGetRecords);
            }
        }


        [HttpPost]
        [Produces("application/json", Type = typeof(SaleModel))]
        public async Task<IActionResult> Save([FromBody] SaleModel sale)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = await salesBusiness.SaveSales(sale);
                if (result)
                    return Ok();
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.UnabledToSaveRecords);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ErrorMessages.UnabledToSaveRecords);
            }

        }



    }
}