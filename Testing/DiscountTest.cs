using DemoLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.IO;
namespace DiscountTest
{
    [TestClass]
    public class OrderTests
    {
        List <Order> orders_ = new List<Order>() { new Order() { Price = 2600, ammount = 25 } };
        [DataTestMethod]
        [DataRow(2500, 5, 10000)] 
        [DataRow(0, 0, 0)]       
        [DataRow(5000, 5, 20000)] 
        [DataRow(1, 1, 1)]
        [DataRow(1500 , 2 , 2700)]
        public void DiscountTesting(int Price , int Ammount , int Expensive)
        {
            Order order = new Order { Price = Price, ammount = Ammount }; 

            order.Calc();
            double DISCOUNT = order.ITOG();

            Assert.AreEqual(Expensive, DISCOUNT);
        }


    }
    [TestClass]
    public class TestClients
    {   
        Order order = new Order();
        Client client_ = new Client() { ID = 1, Name = "MegaMarket", PhoneNumber = "89050022344", Director = "Man", Type = "ннн", Rating = 1 };

        [TestInitialize]
        public void ZEK()
        {
            Order order = new Order() { Price = 1000, ammount = 3 };
            client_.AddOrder(order);
        }
        [DataTestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(5000, 5, 20000)]
        [DataRow(1, 1, 1)]
        [DataRow(1500, 2, 2700)]
        public void TestClientDiscount(int Price ,  int ammount , double expected)
        {
            Order order = new Order { Price = Price, ammount = ammount };
            client_.AddOrder(order);
            client_.CalcDiscount();
            double actual = order.CalculateTotalWithDiscount();
            Assert.AreEqual(expected, actual);
        }

    }
}