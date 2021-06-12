using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngineForCheckoutProcess.Model
{
   public class OrderDetail
    {
        public int OrderID { get; set; }
        public List<ProductDetails> ProductDetail { get; set; }

        public OrderDetail(int _orderID, List<ProductDetails> _productDetail)
        {
            this.OrderID = _orderID;
            this.ProductDetail = _productDetail;
        }

    }
}
