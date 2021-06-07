using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using UI.DataPackage;

namespace UI.Network
{
    public struct IP
    {
        public string Address { get; set; }
        public string Port { get; set; }
        public IP(string address, string port)
        {
            Address = address;
            Port = port;
        }

        public IP(EndPoint endPoint)
        {
            string[] str = endPoint.ToString().Split(':');
            Address = str[0];
            Port = str[1];
        }

        public override string ToString()
        {
            return $"{Address}:{Port}";
        }
    }

    public class MessageClient : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Socket _client;
        public MessageClient()
        {
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public MessageClient(Socket socket)
        {
            _client = socket;
        }
        public IP LocalIP { get; set; }
        public IP RemoteIP { get; set; }
        Task _reading;


        public ObservableCollection<MessagePackage> Messages { get; set; } = new ObservableCollection<MessagePackage>();
        private bool _state = false;
        public bool State
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
                }
            }
        }
        public void Start(string address = "", string port = "")
        {
            if (State == true) return;
            State = true;
            if (address != "" && port != "")
            {
                _client.Connect(IPAddress.Parse(address), Convert.ToInt32(port));
            }
            LocalIP = new IP(_client.LocalEndPoint);
            RemoteIP = new IP(_client.RemoteEndPoint);
            _reading = Task.Run(() =>
            {
                while (State == true)
                {
                    try
                    {
                        var msg = new MessagePackage(_client);
                        Application.Current.Dispatcher.Invoke(() =>
                        Messages.Add(msg));
                        Console.WriteLine($"localip: {LocalIP}  remoteip: {RemoteIP} {msg.Message}");
                    }
                    catch
                    {
                        Stop();
                        break;
                    }
                }
            }
            );
        }

        public void Stop()
        {
            if (State == false) return;
            State = false;
            _client.Close();
            _reading.Wait();
        }

        public void Send(string msg)
        {
            try
            {
                var messagePackage = new MessagePackage(msg);
                _client.Send(messagePackage.ToBytes());
                Messages.Add(messagePackage);
            }
            catch
            {
                Stop();
            }
        }
    }
}
