using System;
using System.Collections.Generic;

namespace DemoLib.Models
{
    public class MemoryClientsModel 
    {
        private List<Client> clients_ = new List<Client>();
        public MemoryClientsModel()
        {

            clients_.Add(new Client
            {
                ID = 1,
                Name = "Ладога",
                Director = "А.Бойков",
                PhoneNumber = "+7-900-112-17-42",
                Type = "ЗАО",
                Discount = 10,
                Rating = 10
            });

            clients_.Add(new Client
            {
                ID = 2,
                Name = "Байкал",
                Director = "В.Терёшин",
                PhoneNumber = "+7-910-640-47-12",
                Type = "ООО",
                Discount = 20,
                Rating = 1
            });

           /* clients_[0].AddOrder(new Order
            {
                ProductID = 1,
                ProductName = "Батон",
                ammount = 100,
                //ProductData = "09.11.2024",
                Price = 45
            });
            clients_[1].AddOrder(new Order
            {
                ProductID = 2,
                ProductName = "Молоко",
                //ProductType = "Молочное изделие",
                ammount = 10,
                //ProductData = 09.11.2024,
                //Shop = "Молочный ручеёк",
                //Adress = "Г.Торжок , Ул.Коровина , Д.67",
                Price = 145
            });
            
            */
        }
       
        public List<Client> GetClients()
        {
            return clients_;
        }

        public int ClientCount()
        {
            return clients_.Count;
        }

        public void UpdatedClientS(Client updatedClient)
        {
            for (int i = 0; i < clients_.Count; i++)
            {
                Client c = clients_[i];
                if (c.ID == updatedClient.ID)
                {
                    c = updatedClient;
                    UpdatedClients?.Invoke();
                    return;
                }
            }
        }  

        public event Action UpdatedClients;
       
    }

}

