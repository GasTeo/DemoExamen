using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoLib
{
    public class Order
    {

        /// <summary>
        /// Присваивание ID продукта
        /// </summary>
        public int ProductID { get; set; }

        public int ClientID { get; set; }

        /// <summary>
        /// Присваивание имени продукту
        /// </summary>
        public string ProductName { get; set; }


        /// <summary>
        /// Указание даты привоза продукта
        /// </summary>
        public DateTime ProductData { get; set; }


        /// <summary>
        /// указание цены продукта 
        /// </summary>
        public double Price { get; set; }

        public double summ { get; set; }

        /// <summary>
        /// указание количества продукта 
        /// </summary>
        public double ammount { get; set; }

        public void Calc() 
        { 

         summ = Price* ammount;

        }

        public double SummTotalWithDiscount { get; set; }
        public double CalculateTotalWithDiscount()
        {
            double Discount = Discounting();
            double Final = (summ * Discount) / 100;
            return Final;
        }
        public int Discounting()
        {
            int dis;
            if (summ >= 100000 && summ <= 1750000)
            {
                dis = 10; // от 100000 до 1750000
            }
            else if (summ > 1750000 && summ <= 2500000)
            {
                dis = 15; // от 1750001 до 2500000
            }
            else if (summ > 2500000 && summ <= 3500000)
            {
                dis = 25; // от 2500001 до 3500000
            }
            else if (summ > 3500000)
            {
                dis = 30; // больше 3500000
            }
            else
            {
                dis = 0; // меньше 100000
            }
            return dis;
        }

        public double ITOG()
        {
            double discountedSum = CalculateTotalWithDiscount();
            double TotalSum = summ;
            double difference = TotalSum - discountedSum;

            return difference;
        }

    }
}
