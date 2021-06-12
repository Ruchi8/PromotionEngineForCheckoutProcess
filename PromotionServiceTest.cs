using NUnit.Framework;
using PromotionEngineForCheckoutProcess.Model;
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace PromotionEngineForCheckoutProcessTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
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

            promotions.Should().NotBeEmpty();
            promotions.Should().HaveCount(1);

        }
    }
}
