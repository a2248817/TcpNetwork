using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;

namespace UI.Network
{
    public class MessageServer : INotifyPropertyChanged
    {
        static string GetServerIP()
        {
            var ip = new HttpClient().GetStringAsync("https://ipv4.icanhazip.com/").Result;
            return ip.Replace("\n", "").Replace("\r", "");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        Socket _server;
        public IP LocalIP { get; set; }
        public MessageServer()
        {
            _server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _server.Bind(new IPEndPoint(IPAddress.Any, 0));
            var ip = GetServerIP();
            LocalIP = new IP(ip, _server.LocalEndPoint.ToString().Split(':')[1]);
        }

        Task _listening; 
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
        public ObservableCollection<MessageClient> Clients { get; set; } = new ObservableCollection<MessageClient>();
        public void Start()
        {
            if (State == true) return;
            State = true;
            _server.Listen(0);
            _listening = Task.Run(() =>
            {
                while (State == true)
                {
                    try
                    {
                        MessageClient messageClient = new MessageClient(_server.Accept());
                        messageClient.Start();
                        Application.Current.Dispatcher.Invoke(()=>
                        Clients.Add(messageClient));
                }
                    catch
                {
                    Stop();
                    break;
                }
            }
            });
        }
        public void Stop()
        {
            if (State == false) return;
            State = false;
            _server.Close();
            _listening.Wait();
            foreach (var client in Clients)
            {
                client.Stop();
            }
            Clients.Clear();
        }

    }
}
