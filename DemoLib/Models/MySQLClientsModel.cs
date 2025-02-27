using DemoLib.Class;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using MySqlX.XDevAPI;
using System.Security.Cryptography.X509Certificates;

namespace DemoLib.Models
{
    public class MySQLClientsModel : IClientsModel
    {
        ConnectSQL SQl = new ConnectSQL();
        private List<Client> client_ = new List<Client>();
        public List<Client> GetClients()
        {
            client_.Clear();
            string cs = SQl.GetConnect();
            try
            {
                using (var con = new MySqlConnection(cs))
                {
                    con.Open();
                    var stm = "SELECT ClientID, CompanyName, NameClient, ClientType, Phone, Rating FROM clients";
                    var cmd = new MySqlCommand(stm, con);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int clientID = reader.GetInt32(0);
                            string CompanyName = reader.GetString(1);
                            string NameClient = reader.GetString(2);
                            string ClientType = reader.GetString(3);
                            string Phone = reader.GetString(4);
                            int Rating = reader.GetInt32(5);
                            Client clients = new Client
                            {
                                ID = clientID,
                                Name = CompanyName,
                                Director = NameClient,
                                Type = ClientType,
                                PhoneNumber = Phone,
                                Rating = Rating,
                                Discount = 30
                            };

                            client_.Add(clients);
                        }
                    }
                    var Orderrr = "SELECT ClientID, ProductID, ProductName, ProductData, Price, ammount  FROM ordern";
                    var cmd1 = new MySqlCommand(Orderrr, con);
                    using (MySqlDataReader reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ClientID2 = reader.GetInt32(0);
                            int ProductID = reader.GetInt32(1);
                            string ProductName = reader.GetString(2);
                            DateTime ProductData = reader.GetDateTime(3);
                            int Price = reader.GetInt32(4);
                            int ammount = reader.GetInt32(5);
                            
                            Order order = new Order
                            {
                                ProductID = ProductID,
                                ProductName = ProductName,
                                ProductData = ProductData,
                                Price = Price,
                                ammount = ammount
                            };
                            order.Calc();
                            for (int i = 0; i < client_.Count; i++)
                            {

                                Client client = client_[i];
                                if (client.ID == ClientID2)
                                {
                                    client_[i].AddOrder(order);
                                }

                            }

                        }

                        foreach (Client client in client_)
                        {
                            client.CalcDiscount();
                        }

                        return client_;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void UpdatedClientS(Client updatedClient)
        {
            string cs = SQl.GetConnect();
            try
            {
                using (var con = new MySqlConnection(cs))
                {
                    con.Open();
                    var stm = @"UPDATE clients SET CompanyName = @CompanyName, NameClient = @NameClient, Phone = @Phone, Rating = @Rating WHERE ID = @ID";
                    using (var cmd = new MySqlCommand(stm, con))
                    {
                        cmd.Parameters.AddWithValue("@CompanyName", updatedClient.Name);
                        cmd.Parameters.AddWithValue("@NameClient", updatedClient.Director);
                        cmd.Parameters.AddWithValue("@Phone", updatedClient.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Rating", updatedClient.Rating);
                        cmd.Parameters.AddWithValue("@ID", updatedClient.ID);
                        cmd.ExecuteNonQuery();
                    }
                }
                UpdatedClients.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int ClientCount()
        {
            string cs = SQl.GetConnect();
            try
            {

                using (var con = new MySqlConnection(cs))
                {
                    con.Open();
                    var stm = "SELECT COUNT(*) FROM clients";
                    var cmd = new MySqlCommand(stm, con);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int Count = reader.GetInt32(0);
                            return Count;
                        }

                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public event Action UpdatedClients;


      



    }
}
