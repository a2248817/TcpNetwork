using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.Model;

namespace UI
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        private UIServer _Server { get; set; }
        public UIServer Server
        {
            get { return _Server; }
            set
            {
                _Server = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            }
        }
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
        public ObservableCollection<FileModel> FileExample { get; set; } = FileModel.fileModels;

        private void ServerStart_Click(object sender, RoutedEventArgs e)
        {
            if (Server == null)
            {
                Server = new UIServer();
            }
            Server.Start();
        }

        private async void ServerStop_Click(object sender, RoutedEventArgs e)
        {
            if (Server != null)
            {
                await Server.Stop();
            }
        }

        private void RemoteStart_Click(object sender, RoutedEventArgs e)
        {
            var client = new UIClient(new TcpClient());
            if (client.Connect(RemoteAddress.Text, Convert.ToInt32(RemotePort.Text).ToString()) == true)
            {
                Server.RemoteClients.Add(client);
            }
        }

        private void RemoteStop_Click(object sender, RoutedEventArgs e)
        {
            if (Server != null)
            {
                foreach (var client in Server.RemoteClients)
                {
                    client.Stop();
                }
                Server.RemoteClients.Clear();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FileExample.Add(new FileModel("local", $"{DateTime.Now}", 123456));
            foreach (var file in FileExample)
            {
                Debug.WriteLine($"{file.Source} {file.Name} {file.Size}");
            }
            Debug.WriteLine($"add{RemoteAddress.Width}  por{RemotePort.Width}");
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            RemoteStop_Click(this, new RoutedEventArgs());
            ServerStop_Click(this, new RoutedEventArgs());
        }
    }

}
