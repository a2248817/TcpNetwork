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

    public class UIClient : INotifyPropertyChanged
    {
        FileStream file = File.OpenWrite($"logs/{DateTime.Now.Ticks}.txt");
        public TcpClient Client { get; set; }
        private Task SendingTask;
        private Task ReceivingTask;
        private string _Address;
        private string _Port;
        private bool _Connecting;
        public event PropertyChangedEventHandler PropertyChanged;
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
        public bool Connecting
        {
            get
            {
                return _Connecting;
            }
            set
            {
                if (value != _Connecting)
                {
                    _Connecting = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
                }
            }
        }

        public UIClient(TcpClient client)
        {
            Client = client;
            Connecting = false;
        }

        public void Start()
        {
            if (Connecting == false)
            {
                Connecting = true;
                string[] IP = Client.Client.RemoteEndPoint.ToString().Split(':');
                Address = IP[0];
                Port = IP[1];
                SendingTask = Task.Run(() =>
                {
                    while (Connecting)
                    {
                        try
                        {
                            Client.Client.Send(Encoding.UTF8.GetBytes(DateTime.Now.ToString()));
                        }
                        catch (Exception)
                        {
                            Stop();
                        }
                    }
                });
                ReceivingTask = Task.Run(() =>
                {
                    while (Connecting)
                    {
                        byte[] buffer = new byte[1024];
                        int length = 0;
                        try
                        {
                            length = Client.Client.Receive(buffer);
                            if (length == 0)
                            {
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            Stop();
                            break;
                        }
                        byte[] data = new byte[length];
                        Array.Copy(buffer, data, length);
                        file.Write(data, 0, length);
                        file.WriteByte(Convert.ToByte('\n'));
                    }
                });
            }
        }

        public async void Stop()
        {
            if (Connecting == true)
            {
                Connecting = false;
                await SendingTask;
                await ReceivingTask;
                Client.Close();
            }
        }

        public bool Connect(string hostname, string port)
        {
            try
            {
                Client.Connect(hostname, Convert.ToInt32(port));
                Start();
                return true;
            }
            catch (Exception)
            {
                Debug.WriteLine($"無法連線至{hostname}:{port}");
                return false;
            }
        }
    }
}
