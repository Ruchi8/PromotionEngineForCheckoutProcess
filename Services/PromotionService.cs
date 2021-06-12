using PromotionEngineForCheckoutProcess.Interfaces;
using PromotionEngineForCheckoutProcess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngineForCheckoutProcess.Services
{
    public static class PromotionService 
    {
        public static decimal GetPriceByPromotionType(OrderDetail orderDetail, Promotion promotion)
        {
            decimal promotionPrice = 0M;
          
            var countOfPromotedProductsInOrder = orderDetail.ProductDetail
                .GroupBy(x => x.ProductSKUId)
                .Where(promotedProductDetails => promotion.ProductDetails.Any(y => promotedProductDetails.Key == y.Key && promotedProductDetails.Count() >= y.Value))
                .Select(promotedProductDetails => promotedProductDetails.Count())
                .Sum();

            //get count of promoted products from promotion
            int countOfPromotedProductFromPromotion = promotion.ProductDetails.Sum(kvp => kvp.Value);
            while (countOfPromotedProductsInOrder >= countOfPromotedProductFromPromotion)
            {
                promotionPrice += promotion.PromotionPrice;
                countOfPromotedProductFromPromotion -= countOfPromotedProductsInOrder;
            }
            return promotionPrice;
        }
    }
}
