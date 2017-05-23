using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                HostWcf server = new HostWcf();
                server.Initialize();
                server.Open();
                Console.WriteLine("Server work!");
                Console.ReadLine();
                server.Close(); 

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }

        }
    }


    class  HostWcf
    {
        private ServiceHost CompanyHost;
        private ServiceHost DepartmentHost;
        private ServiceHost WorkerHost;
        private ServiceHost ComputerHost;
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
        public void Initialize()
        {
     
           CompanyHost = new ServiceHost(typeof(Logic.Offise), new Uri("net.tcp://192.168.240.1:8000/Icompany"));
           DepartmentHost = new ServiceHost(typeof(Logic.Departament), new Uri("net.tcp://192.168.240.1:8000/IDepartament"));
           WorkerHost = new ServiceHost(typeof(Logic.Worker), new Uri("net.tcp://192.168.240.1:8000/IWorker"));
            ComputerHost = new ServiceHost(typeof(Logic.PC), new Uri("net.tcp://192.168.240.1:8000/IPC"));
           CompanyHost.AddServiceEndpoint(typeof(Logic.Icompany), CreateBinding(), "");
            DepartmentHost.AddServiceEndpoint(typeof(Logic.IDepartament), CreateBinding(), "");
            WorkerHost.AddServiceEndpoint(typeof(Logic.IWorker), CreateBinding(), "");
            ComputerHost.AddServiceEndpoint(typeof(Logic.IPC), CreateBinding(), "");
        
        }
        public void Open()
        {
            ComputerHost.Open();
            CompanyHost.Open();
            WorkerHost.Open();
            DepartmentHost.Open();
        }
        public void Close()
        {
            ComputerHost.Close();
            CompanyHost.Close();
            WorkerHost.Close();
            DepartmentHost.Close();
        }
    }
}
