using PromotionEngineForCheckoutProcess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineForCheckoutProcess.Interfaces
{
    public interface IPromotionService
    {
        decimal GetPriceByPromotionType(OrderDetail orderDetail, Promotion promotion);      
    }
}
