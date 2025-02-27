using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DemoLib
{
    public class Client
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public string Director { get; set; }

        public string Type { get; set; }

        public int Rating { get; set; }

        public int Discount { get; set; }


        //__________________________________________________________________________________________________________________


        private List<Order> orders_ = new List<Order>();

        public void AddOrder(Order ORDERS)
        {
            orders_.Add(ORDERS);
        }

        public List<Order> GetOrders()
        {

            return orders_;

        }

        public void CalcDiscount()
        {
            if(orders_.Count == 0) return;

            int sum = 0;
            foreach (Order ORDER in orders_)
            {
                sum += ORDER.Discounting();
            }

            Discount = sum / orders_.Count;
        }

    }
}
