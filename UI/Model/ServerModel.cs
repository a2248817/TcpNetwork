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
using System.Windows.Threading;

namespace UI.Model
{
    public class UIServer : INotifyPropertyChanged
    {
        private TcpListener Server { get; set; }
        private Task ListeningTask;
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<UIClient> LocalClients { get; set; } = new ObservableCollection<UIClient>();
        public ObservableCollection<UIClient> RemoteClients { get; set; } = new ObservableCollection<UIClient>();
        private string _Address;
        private string _Port;
        private bool _Listening;
        public string Address
        {
            get
            {
                return _Address;
            }
            set
            {
                if (value != _Address)
                {
                    _Address = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
                }
            }
        }
        public string Port
        {
            get
            {
                return _Port;
            }
            set
            {
                if (value != _Port)
                {
                    _Port = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
                }
            }
        }
        public bool Listening
        {
            get
            {
                return _Listening;
            }
            set
            {
                if (value != _Listening)
                {
                    _Listening = value;
                    Debug.WriteLine(_Listening);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
                }
            }
        }

        public UIServer()
        {
            ConfigureServer();
        }

        private IPAddress GetIPAddress()
        {
            var IP = new HttpClient().GetStringAsync("https://ipv4.icanhazip.com/").Result.Replace("\n", "");
            return IPAddress.Parse(IP);
        }

        private void ConfigureServer()
        {
            Server = new TcpListener(GetIPAddress(), 0);
            Server.Start();
            string[] IP = Server.LocalEndpoint.ToString().Split(':');
            Address = IP[0];
            Port = IP[1];
            Listening = false;
        }

        public void Start()
        {
            if (Listening == false)
            {
                Listening = true;
                Server.Start();
                string[] IP = Server.LocalEndpoint.ToString().Split(':');
                Address = IP[0];
                Port = IP[1];
                ListeningTask = Task.Run(() =>
                {
                    while (Listening)
                    {
                        try
                        {
                            var client = new UIClient(Server.AcceptTcpClient());
                            client.Start();
                            Application.Current.Dispatcher.Invoke(() => LocalClients.Add(client));
                        }
                        catch (Exception)
                        {

                        }
                    }
                    foreach (var client in LocalClients)
                    {
                        client.Stop();
                    }
                });
            }
        }

        public async Task Stop()
        {
            if (Listening == true)
            {
                Listening = false;
                Server.Stop();
                await ListeningTask;
                Address = "";
                Port = "";
                LocalClients.Clear();
            }
        }
    }

}
