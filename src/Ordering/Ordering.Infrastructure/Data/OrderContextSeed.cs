using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailablity = retry.Value;

            try
            {
                orderContext.Database.Migrate();
                if (!orderContext.Orders.Any())
                {
                    orderContext.Orders.AddRange(GetPreconfigureOrders());
                    await orderContext.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                if (retryForAvailablity < 3)
                {
                    retryForAvailablity++;
                    var log = loggerFactory.CreateLogger<OrderContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(orderContext, loggerFactory, retryForAvailablity);
                }
            }
        }

        private static IEnumerable<Order> GetPreconfigureOrders()
        {
            return new List<Order> { new Order() { UserName = "rohit", FirstName = "Rohit", LastName = "Bhilare", EmailAddress = "rohit.bhilare03@gmail.com", AddressLine = "Panvel", Country = "India", ZipCode = "410206" } };
        }
    }
}
