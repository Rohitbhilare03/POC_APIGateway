using Basket.API.Data;
using Basket.API.Data.Interface;
using Basket.API.Entities;
using Basket.API.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketContext _BasketContext;

        public BasketRepository(IBasketContext basketContext)
        {
            _BasketContext = basketContext;
        }

        public async Task<BasketCart> GetBasket(string UserName)
        {
            var basket = await _BasketContext.Redis.StringGetAsync(UserName);
            if(basket.IsNullOrEmpty)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<BasketCart>(basket);
        }

        public async Task<BasketCart> UpdateBasket(BasketCart basket)
        {
            var updated = await _BasketContext.Redis.StringSetAsync(basket.UserName, JsonConvert.SerializeObject(basket));

            if(!updated)
            {
                return null;
            }
            return await GetBasket(basket.UserName);
        }
        public async Task<bool> DeleteBasket(string UserName)
        {
            return await _BasketContext.Redis.KeyDeleteAsync(UserName);

        }
    }
}
