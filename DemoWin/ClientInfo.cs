using DemoLib;
using DemoLib.Class;
using DemoLib.Presenters;
using DemoUIComponents;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Demo
{
    public partial class ClientInfo : Form
    {
        private Order order = new Order();
        Client client_ = new Client();
        private ClientPresenter presenter_;
        ConnectSQL SQL = new ConnectSQL();

        public Client ReturnClient()
        {
            return client_;
        }
        public ClientInfo()
        {
            InitializeComponent();

            Save.Enabled = false;
            DiscountTextBox.Enabled = false;
        }
       
           

           

        public void SetClient(Client client)
        {
            client_ = client;
            CompanyNameTextBox.Text = client.Name;
            ClientsType.Text = client.Type;
            NameClients.Text = client.Director;
            PhoneNumberTextBox.Text = client.PhoneNumber;
            RatingTextBox.Text = client.Rating.ToString();
            DiscountTextBox.Text = client.Discount.ToString(); 
            List<Order> oreder = client.GetOrders();
            for (int i = 0; i < oreder.Count; i++)
            {
                Order o = oreder[i];
                o.SummTotalWithDiscount =  o.CalculateTotalWithDiscount();
            }
            ProductView.DataSource = oreder;
        }
        private void ToReturn_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            ClientControl CL = new ClientControl();
            CL.Show();
        }
        private void Exit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
        private void Editinformation_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CompanyNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(NameClients.Text))
            {
                MessageBox.Show("Поля не могут быть пустыми!");
                Save.Enabled = false;
            }
            else
            {
                Save.Enabled = true;
            }
        }


        private void Save_Click(object sender, EventArgs e)
        {
            
            client_.Name = CompanyNameTextBox.Text;
            client_.Director = NameClients.Text;
            client_.PhoneNumber = PhoneNumberTextBox.Text;
            client_.Rating = int.Parse(RatingTextBox.Text);
            client_.Discount = int.Parse(DiscountTextBox.Text);
            
            MessageBox.Show("Информация о клиенте успешно сохранена!");


            this.Close(); 
        }

        private void RatingTextBox_TextChanged(object sender, EventArgs e)
        {
            int rating;
            if (int.TryParse(RatingTextBox.Text, out rating))
            {
                if (rating < 1 || rating > 10)
                {
                    MessageBox.Show("Введите число от 1 до 10.");
                    RatingTextBox.Text = ""; 
                }
            }
            else if (RatingTextBox.Text != "")
            {
                MessageBox.Show("Введите только числа.");
                RatingTextBox.Text = "";  
            }
        }

       


    }
}
