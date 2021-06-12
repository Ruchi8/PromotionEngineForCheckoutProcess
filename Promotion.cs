using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineForCheckoutProcess.Model
{
    public class Promotion
    {
        public int PromotionID { get; set; }
        public Dictionary<string, int> ProductDetails { get; set; }
        public decimal PromotionPrice { get; set; }

        public Promotion(int _promotionID, Dictionary<string, int> _productDetails, decimal _promotionPrice)
        {
            this.PromotionID = _promotionID;
            this.ProductDetails = _productDetails;
            this.PromotionPrice = _promotionPrice;
        }
    }
}
