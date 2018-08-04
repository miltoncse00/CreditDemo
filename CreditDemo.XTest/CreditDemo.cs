using AutoMapper;
using AutoMapper.Configuration;
using CreditDemo.Business;
using CreditDemo.Common;
using CreditDemo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace CreditDemo.XTest
{
    public class CreditDemo
    {
        private SaleContext salesDbContext;
        private SalesBusiness salesBusiness;
        private IMapper mapper;
        public CreditDemo()
        {
            var options = new DbContextOptionsBuilder<SaleContext>()
                .UseInMemoryDatabase(databaseName: "CreditDemoDB")
                .Options;

            if (mapper == null)
            {
                mapper = Initialize();
            }
            salesDbContext = new SaleContext(options);
            salesBusiness = new SalesBusiness(salesDbContext, mapper);
        }

        public static IMapper Initialize()
        {
            return new MapperConfiguration((cfg =>
            {
                cfg.CreateMap<SaleModel, Sale>().ReverseMap();
                cfg.CreateMap<PaymentModel, Payment>().ReverseMap();

            })).CreateMapper();
        }

        [Fact]
        public async void TestSaveSales()
        {
            await salesBusiness.SaveSales(CreateTestData());
            var sales = await salesDbContext.Sales.ToListAsync();
            sales.Count.Should().Be(1);
            sales.First().Payments.Count.Should().Be(1);
            sales.First().Payments.First().Id.Should().NotBeEmpty();
        }

        [Fact]
        public void ValidateInputModelWithAnnotation()
        {
            var validationResult = ValidateModel(InvalidInputwithIdGreaterThan12Char());
            validationResult.Count.Should().Be(1);
            validationResult.First().ErrorMessage.Should().ContainAny("Id");

        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new System.ComponentModel.DataAnnotations.ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }


        private SaleModel InvalidInputwithIdGreaterThan12Char()
        {
            var sale = new SaleModel()
            {
                Id = "111111111111111111",
                CustomerId = "1234567",
                Currency = "US",
                LocationName = "America",
                OpeningDebit = 12.4M,
                SaleInvoiceNumber = "12345",
                OperatorName = "Alex",
                TimeStamp = DateTime.Now,
                Payments = new List<PaymentModel>() {
                new PaymentModel(){
                    Description="New Payment",
                    PaymentAmount=12.5M,
                    PaymentDate = DateTime.Now
                }
                }
            };
            return sale;
        }

        private SaleModel CreateTestData()
        {
            var sale = new SaleModel()
            {
                Id = "1234567",
                CustomerId = "1234567",
                Currency = "US",
                LocationName = "America",
                OpeningDebit = 12.4M,
                SaleInvoiceNumber = "12345",
                OperatorName = "Alex",
                TimeStamp = DateTime.Now,
                Payments = new List<PaymentModel>() {
                new PaymentModel(){
                    Description="New Payment",
                    PaymentAmount=12.5M,
                    PaymentDate = DateTime.Now
                }
                }
            };
            return sale;
        }
    }
}
