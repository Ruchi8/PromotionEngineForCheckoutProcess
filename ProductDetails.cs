using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineForCheckoutProcess
{
    public class ProductDetails
    {
        public string ProductSKUId { get; set; }
        public decimal ProductPrice { get; set; }


        public ProductDetails(string productSKUId)
        {
            this.ProductSKUId = productSKUId;
            this.ProductPrice = this.ProductSKUId switch
            {
                "A" => 50,
                "B" => 30,
                "C" => 20,
                "D" => 15,
                _ => this.ProductPrice
            };


        }
    }
}
