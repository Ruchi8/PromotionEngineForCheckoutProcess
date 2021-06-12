using PromotionEngineForCheckoutProcess.Model;
using PromotionEngineForCheckoutProcess.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngineForCheckoutProcess
{
    class Program
    {
        static void Main(string[] args)
        {
                        
            Dictionary<String, int> product_A_Price = new Dictionary<String, int>();
            product_A_Price.Add("A", 50);
            Dictionary<String, int> product_B_Price = new Dictionary<String, int>();
            product_B_Price.Add("B", 30);
            Dictionary<String, int> product_C_And_D_Price = new Dictionary<String, int>();
            product_C_And_D_Price.Add("C", 20);
            product_C_And_D_Price.Add("D", 15);

            // Addding product in a list

            List<Promotion> promotions = new List<Promotion>()
            {
              new Promotion(1, product_A_Price, 130),
              new Promotion(2, product_B_Price, 45),
              new Promotion(3, product_C_And_D_Price, 30)
            };

            //create orders
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            OrderDetail orderDetail_ScenarioA = new OrderDetail(1, new List<ProductDetails>() { new ProductDetails("A"), new ProductDetails("B"), new ProductDetails("C")});
            OrderDetail orderDetail_ScenarioB = new OrderDetail(2, new List<ProductDetails>() { new ProductDetails("A"), new ProductDetails("A"), new ProductDetails("A"), new ProductDetails("A"), new ProductDetails("A"), new ProductDetails("B"), new ProductDetails("B"), new ProductDetails("B"), new ProductDetails("B"), new ProductDetails("B"), new ProductDetails("C") });
            OrderDetail orderDetail_ScenarioC = new OrderDetail(2, new List<ProductDetails>() { new ProductDetails("A"), new ProductDetails("A"), new ProductDetails("A"), new ProductDetails("B"), new ProductDetails("B"), new ProductDetails("B"), new ProductDetails("B"), new ProductDetails("B"), new ProductDetails("C"), new ProductDetails("D") });
            orderDetails.AddRange(new OrderDetail[] { orderDetail_ScenarioA, orderDetail_ScenarioB, orderDetail_ScenarioC });

            //check if order meets promotion
            foreach (OrderDetail order in orderDetails)
            {
                List<decimal> promotionPrice = promotions
                    .Select(promotion => PromotionService.GetPriceByPromotionType(order, promotion))
                    .ToList();
                decimal priceWithoutDiscount = order.ProductDetail.Sum(x => x.ProductPrice);
                decimal priceAfterPromotionDiscount = promotionPrice.Sum();
                Console.WriteLine($"OrderID: {order.OrderID} => Price without discount: {priceWithoutDiscount.ToString("0.00")} | Price with discount: {priceAfterPromotionDiscount.ToString("0.00")} | Final price: {(priceWithoutDiscount - priceAfterPromotionDiscount).ToString("0.00")}");
            }


        }


       
    }
}
