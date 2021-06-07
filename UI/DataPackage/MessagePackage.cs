using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UI.DataPackage
{
    public class MessagePackage
    {
        private byte[] Header;
        private byte[] Body;
        public string Message { get { return Encoding.UTF8.GetString(Body); } }
        public MessagePackage(string body)
        {
            Body = Encoding.UTF8.GetBytes(body);
            Header = Encoding.UTF8.GetBytes(Body.Length.ToString().PadLeft(8));
        }

        public MessagePackage(byte[] message)
        {
            Header = new byte[8];
            Array.Copy(message, Header, 8);
            int length = int.Parse(Encoding.UTF8.GetString(Header));
            if (length <= 0)
            {
                throw new Exception();
            }
            Body = new byte[length];
            Array.Copy(message, 8, Body, 0, length);
        }
        public MessagePackage(Socket socket)
        {
            Header = new byte[8];
            int length = socket.Receive(Header, 0, 8, SocketFlags.None);
            if (length <= 0)
            {
                throw new Exception();
            }
            length = int.Parse(Encoding.UTF8.GetString(Header));
            Body = new byte[length];
            socket.Receive(Body, 0, length, SocketFlags.None);
        }

        //public MessagePackage(Stream stream)
        //{
        //Header = new byte[8];
        //int length = stream.Read(Header, 0, 8);
        //if (length <= 0)
        //{
        //throw new Exception();
        //}
        //length = int.Parse(Encoding.UTF8.GetString(Header));
        //Body = new byte[length];
        //stream.Read(Body, 0, length);
        //}


        public byte[] ToBytes()
        {
            byte[] bytes = Header.Concat(Body).ToArray();
            return bytes;
        }

        public override string ToString()
        {
            return Encoding.UTF8.GetString(ToBytes());
        }
    }
}
