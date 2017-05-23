using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Logic;

namespace client
{
    class connection
    {

       
        private NetTcpBinding CreateBinding()
        {
            var binding = new NetTcpBinding();
            binding.SendTimeout = TimeSpan.MaxValue;
            binding.ReceiveTimeout = TimeSpan.MaxValue;
            binding.OpenTimeout = TimeSpan.MaxValue;
            binding.CloseTimeout = TimeSpan.MaxValue;
            binding.Security.Mode = SecurityMode.None;
            return binding;
        }
        public Icompany CreateCompanyChannel()
        {
            Uri tcpUri = new Uri("net.tcp://192.168.240.1:8000/Icompany");
            EndpointAddress address = new EndpointAddress(tcpUri);
            var factory = new ChannelFactory<Icompany>(CreateBinding(), address);
            return factory.CreateChannel();
        }
        public IWorker CreateWorkerChannel()
        {
            Uri tcpUri = new Uri("net.tcp://192.168.240.1:8000/IWorker");
            EndpointAddress address = new EndpointAddress(tcpUri);
            var factory = new ChannelFactory<IWorker>(CreateBinding(), address);
            return factory.CreateChannel();
        }
        public IDepartament CreateDeparmentChannel()
        {
            Uri tcpUri = new Uri("net.tcp://192.168.240.1:8000/IDepartament");
            EndpointAddress address = new EndpointAddress(tcpUri);
            var factory = new ChannelFactory<IDepartament>(CreateBinding(), address);
            return factory.CreateChannel();
        }
        public IPC CreatePCChannel()
        {
            Uri tcpUri = new Uri("net.tcp://192.168.240.1:8000/IPC");
            EndpointAddress address = new EndpointAddress(tcpUri);
            var factory = new ChannelFactory<IPC>(CreateBinding(), address);
            return factory.CreateChannel();
        }

       

    }
}
