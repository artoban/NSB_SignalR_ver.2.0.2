using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Microsoft.AspNet.SignalR.Client;

namespace BasicChat.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SignalrClientSharedConnectionProxyWindow : Window
    {
        public System.Threading.Thread Thread { get; set; }
        public string Host = "http://localhost:19897/";   

        public IHubProxy Proxy { get; set; }
        public HubConnection Connection { get; set; }

        public bool Active { get; set; }

        public SignalrClientSharedConnectionProxyWindow()
        {
            InitializeComponent();
        }

        private async void ActionSendButtonClick(object sender, RoutedEventArgs e)
        {
            await SendMessage();
        }

        private async Task SendMessage()
        {
            await Proxy.Invoke("send", ClientNameTextBox.Text + ": " + MessageTextBox.Text);
        }

        private  void ActionWindowLoaded(object sender, RoutedEventArgs e)
        {
            Active = true;
            Thread = new System.Threading.Thread(() =>
            {
                Connection = new HubConnection(Host);
                Proxy = Connection.CreateHubProxy("Chat");

                Proxy.On<string>("send", OnSendData);

                Connection.Start();

                while (Active)
                {
                    System.Threading.Thread.Sleep(10);
                }
            }) { IsBackground = true };
            Thread.Start();
        }

        private void OnSendData(string message)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() => MessagesListBox.Items.Insert(0, message))); 
        }

        private async void ActionMessageTextBoxOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                await SendMessage();
                MessageTextBox.Text = "";
            }
        }
    }
}
