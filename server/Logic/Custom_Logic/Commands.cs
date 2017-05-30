using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Logic
{
    public class DepartmentCreater : ICommand
    {
        public int DepartID;

        public string DepartName;
    }

    public class WorkerCreater : ICommand
    {
        public int DepartID;

        public int WorkerID;

        public string WorkerName;
    }

    public class ComputerCreater : ICommand
    {
        public int DepartID;

        public int ComputerID;

        public string ComputerName;

    }

    public class ComputerAdder : ICommand
    {
        public int DepartID;

        public int ComputerID;

        public int WorkerID;
    }

    public class WorkerAdder : ICommand
    {
        public int DepartID;

        public int ComputerID;

        public int WorkerID;
    }

    public class DepartmentChanger : ICommand
    {
        public int DepartID;

        public string newDepartName;
    }

    public class WorkerChanger : ICommand
    {
        public int DepartID;

        public int WorkerID;

        public string newWorkerName;
    }

    public class ComputerChanger : ICommand
    {
        public int DepartID;

        public int ComputerID;

        public string neComputerName;

    }

    public class DepartmentDeleter : ICommand
    {
        public int DepartID;
    }

    public class WorkerDeleter : ICommand
    {
        public int DepartID;

        public int WorkerID;
    }

    public class ComputerDeleter : ICommand
    {
        public int DepartID;

        public int ComputerID;
    }

    public class RecordSaver : ICommand
    {
        public List<int> lat;
    }

    public class ConnectionStarter: ICommand
    {

    }

    public class RecordGet : ICommand
    {

    }



}
