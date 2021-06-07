using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using UI.Model;
using UI.DataPackage;
using System.Threading.Tasks;
using System.Threading;
using UI.Network;

namespace UI
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void GridViewColumnHeader_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            GridViewColumnHeader header = sender as GridViewColumnHeader;
            header.Column.Width = 600 / 3;
            e.Handled = true;
        }

        public MessageServer Server { get; set; }
        private void ServerStart_Click(object sender, RoutedEventArgs e)
        {
            Server = new MessageServer();
            Server.Start();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        private void ServerStop_Click(object sender, RoutedEventArgs e)
        {
            Server.Stop();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
        public ObservableCollection<MessageClient> Clients { get; set; } = new ObservableCollection<MessageClient>();
        private void RemoteStart_Click(object sender, RoutedEventArgs e)
        {
            var client = new MessageClient();
            client.Start(RemoteAddress.Text, RemotePort.Text);
            Clients.Add(client);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        private void RemoteStop_Click(object sender, RoutedEventArgs e)
        {
            foreach (var client in Clients)
            {
                client.Stop();
            }
            Clients.Clear();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var client = (RemoteConnections.SelectedItem as MessageClient);
            client.Send($"{DateTime.Now}");
            //MSG.ItemsSource = Server.Clients[0].Messages;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            RemoteStop_Click(this, new RoutedEventArgs());
            ServerStop_Click(this, new RoutedEventArgs());
        }

        private void RemoteConnections_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MSG.ItemsSource = (RemoteConnections.SelectedItem as MessageClient)?.Messages;
        }
    }

}
