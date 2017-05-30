using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Custom_Logic
{
   public class TCPServer
    {
    
        private int port = 11000;
        IPAddress ipr = IPAddress.Any;
        TcpListener tcp = null;
        NetworkStream stream;
        Byte[] bytes;
        Thread listen;
        SetHandler rpc;
        TcpClient client;

        public TCPServer(SetHandler value)
        {
            this.rpc = value;
        }
        public void Initializer()
        {
            tcp = new TcpListener(ipr, port);
            tcp.Start();

        }
        public void Open()
        {
            Thread listen = new Thread(StartAccept);
            listen.Start();
        }


        private void StartAccept()
        {
            while (true)
            {
                client = tcp.AcceptTcpClient();
                Console.WriteLine("Client connected {0}", client.Client.RemoteEndPoint);
                Thread handlerStarter = new Thread(StartListen);
                handlerStarter.Start();
            }
        }


        private void StartListen()
        {
            while (true)
            {

                stream = client.GetStream();
                bytes = new byte[4096];
                string src = String.Empty;
                Serializer srz = new Serializer();
                while (stream.DataAvailable || src.Length == 0)
                {
                    var bytesRead = stream.Read(bytes, 0, bytes.Length);
                    src += Encoding.UTF8.GetString(bytes, 0, bytesRead);
                }

                ICommand command = srz.Deserialize(src);
                Console.WriteLine("new command: {0}",command.ToString());
                ICommandHandler handl = rpc.GetHandler(command.GetType());
                object resp = handl.Execute(command);

                string request = srz.Serialize(new Response { data = (List<Department>)resp });
                var respBytes = Encoding.UTF8.GetBytes(request);
                stream.Write(respBytes, 0, respBytes.Length);
            }            
           
        }

        public void Close()
        {
            listen.Abort();
            Console.WriteLine("Connection end");
        }
    }
}

