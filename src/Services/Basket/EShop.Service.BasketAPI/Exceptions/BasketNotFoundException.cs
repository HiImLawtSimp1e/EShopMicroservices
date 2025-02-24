﻿namespace EShop.Service.BasketAPI.Exceptions
{
    public class BasketNotFoundException : NotFoundException
    {
        public BasketNotFoundException(string username) : base("Basket", username)
        {

        }
    }
}
