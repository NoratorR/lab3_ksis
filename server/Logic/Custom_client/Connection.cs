using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom_Logic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Custom_client
{
    class Connection
    {
        StringWriter writer;
        NetworkStream stream;
        TcpClient client;
        string requ;

        public  object CommandFunction(ICommand command)
        {
            var xml = new ClientSerializer();
            writer = xml.ResponseSerialize(command);
            SendToServer();
            TakeRequest();
            Response res =  xml.Deserialize(requ);
            return res.data;

        }

        private void TakeRequest()
        {
            requ = String.Empty;
            byte[] bytes = new byte[4096];
            while (stream.DataAvailable || requ.Length == 0)
            {
                var i = stream.Read(bytes, 0, bytes.Length);
                requ += Encoding.UTF8.GetString(bytes,0,i);
            }

        }
        public Connection()
        {
            IPEndPoint endP = new IPEndPoint(IPAddress.Parse("192.168.240.1"), 11000);
            client = new TcpClient();
            client.Connect(endP);
            stream = client.GetStream();
        }

        private void SendToServer()
        {
          
            byte[] bytes = new byte[4096];
            bytes = Encoding.UTF8.GetBytes(writer.ToString()); 
            stream.Write(bytes,0,bytes.Length);

        }


        public List<Department> StartConnection()
        {
           return (List<Department>)CommandFunction(new ConnectionStarter {  });
        }

        public List<Department>  GetRecords()
        {
            return (List<Department>)CommandFunction(new RecordGet {  });
        }


        public void AddWorker(int WorkerId, Computer cmp,int DepartId)
        {
            CommandFunction(new WorkerAdder { WorkerID = WorkerId, ComputerID = cmp.computerID, DepartID = DepartId});
            
        }
        
        public void CreateWorker(Jober jbr, int DepartId)
        {
            CommandFunction(new WorkerCreater { WorkerID = jbr.JoberID, WorkerName = jbr.workerName, DepartID  = DepartId });
        }

        public void ChangeWorker(int WorkerID, int DepartID,string newWorkerName)
        {
            CommandFunction( new WorkerChanger { WorkerID = WorkerID, newWorkerName = newWorkerName, DepartID = DepartID});
        }

        public void DeleteWorker(int WorkerID, int DepartID)
        {
            CommandFunction(new WorkerDeleter { WorkerID = WorkerID, DepartID = DepartID });
        }
        public void AddComputer(int ComputerID, Jober jbr, int DepartID)
        {
            CommandFunction(new ComputerAdder { ComputerID = ComputerID,WorkerID = jbr.JoberID  ,DepartID = DepartID });
        }

        public void CreateComputer(Computer cmp, int DepartID)
        {
            CommandFunction(new ComputerCreater { ComputerID = cmp.computerID,ComputerName = cmp.computerName, DepartID = DepartID });
        }

        public void ChangeComputer(int ComputerID, int DepartID, string newComputer)
        {
            CommandFunction(new ComputerChanger { ComputerID = ComputerID, neComputerName = newComputer, DepartID = DepartID });
        }

        public void DeleteComputer(int ComputerID, int DepartID)
        {
            CommandFunction(new ComputerDeleter { ComputerID = ComputerID, DepartID = DepartID });
        }
       

        public void CreateDepartment(Department dep)
        {
            CommandFunction(new DepartmentCreater { DepartID = dep.DepartmentID, DepartName = dep.departName });
        }

        public void ChangeDepartment(Department dep, string newDepartmentName)
        {
            CommandFunction(new DepartmentChanger { newDepartName = newDepartmentName,  DepartID = dep.DepartmentID });
        }

        public void DeleteDepartment(Department dep)
        {
            CommandFunction(new DepartmentDeleter { DepartID = dep.DepartmentID });
        }

        public void SaveRecords(List<int> id)
        {
            CommandFunction(new RecordSaver { lat = id });
        }




    }
}
