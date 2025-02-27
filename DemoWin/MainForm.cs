using DemoLib;
using DemoLib.Models;
using DemoLib.Presenters;
using System.Drawing;
using System.Windows.Forms;

namespace Demo
{
    public partial class MainForm : Form
    {
        private MySQLClientsModel model_ = new MySQLClientsModel();
        private ClientPresenter presenter_;
        public MainForm()
        {
            InitializeComponent();

            this.Width = 1360;
            this.Height = 768;

            presenter_ = new ClientPresenter(model_);
            MainLayout.FlowDirection = FlowDirection.TopDown; // Можно менять на FlowDirection.LeftToRight
            MainLayout.AutoSize = true;
            MainLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            for (int i = 0; i < model_.ClientCount(); ++i)
            {
                var control = new DemoUIComponents.ClientControl();
                control.ClientSelected += Control_ClientSelected;
                MainLayout.Controls.Add(control);
                presenter_.AddView(control);
            }
            presenter_.Model__UpdatedClients();
        }
        private void Control_ClientSelected(DemoLib.Client client)
        {
            ClientInfo clientInfo = new ClientInfo();
            clientInfo.SetClient(client);
            clientInfo.ShowDialog();
            clientInfo.ReturnClient();
            Client X = clientInfo.ReturnClient();
            presenter_.UpdateClient(X);
        }
    }
}
