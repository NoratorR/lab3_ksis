using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Logic
{
    public class DepartmentCreaterHandler : ICommandHandler
    {
        private Departament dep;

        public DepartmentCreaterHandler(Departament dep)
        {
            this.dep = dep;
        }

        public object Execute(ICommand command)
        {
            var create = (DepartmentCreater)command;
            Department depart = new  Department();
            depart.DepartmentID = create.DepartID;
            depart.departName = create.DepartName;
            dep.CreateDepartment(depart);
            return null;
        }
    }

    public class WorkerCreaterHandler : ICommandHandler
    {
        private Worker wrk;

        public WorkerCreaterHandler(Worker wrk)
        {
            this.wrk = wrk;
        }

        public object Execute(ICommand command)
        {
            var create = (WorkerCreater)command;
            Jober jbr  = new Jober();
            jbr.JoberID = create.WorkerID;
            jbr.workerName = create.WorkerName;
            wrk.CreateWorker(jbr, create.DepartID);
            return null;
        }
    }

    public class ComputerCreaterHandler : ICommandHandler
    {
        private PC pc;

        public ComputerCreaterHandler(PC pc)
        {
            this.pc = pc;
        }

        public object Execute(ICommand command)
        {
            var create = (ComputerCreater)command;
            Computer cmp = new Computer();
            cmp.computerID = create.ComputerID;
            cmp.computerName = create.ComputerName;
            pc.CreateComputer(cmp,create.ComputerID); 
            return null;
        }

    }

    public class ComputerAdderHandler : ICommandHandler
    {
        private Worker wrk;

        public ComputerAdderHandler(Worker wrk)
        {
            this.wrk = wrk;
        }

        public object Execute(ICommand command)
        {
            var create = (ComputerAdder)command;
            var cmp = new Computer();
            cmp.computerID = create.ComputerID;
            wrk.AddComputer(create.WorkerID,cmp,create.DepartID);
            return null;
        }
    }

    public class WorkerAdderHandler : ICommandHandler
    {
        private PC pc;

        public WorkerAdderHandler(PC pc)
        {
            this.pc = pc;
        }

        public object Execute(ICommand command)
        {
            var create = (WorkerAdder)command;
            Jober cmp = new Jober();
            cmp.JoberID = create.WorkerID;
            pc.AddWorker(create.ComputerID, cmp, create.DepartID);
            return null;
        }
    }

    public class DepartmentChangerHandler : ICommandHandler
    {
        private Departament dep;

        public DepartmentChangerHandler(Departament dep)
        {
            this.dep = dep;
        }

        public object Execute(ICommand command)
        {
            var create = (DepartmentChanger)command;
            var depart = new Department();
            depart.DepartmentID = create.DepartID;
            dep.ChangeDepartment(depart,create.newDepartName);
            return null;
        }
    }

    public class WorkerChangerHandler : ICommandHandler
    {
        private Worker wrk;

        public WorkerChangerHandler(Worker wrk)
        {
            this.wrk = wrk;
        }

        public object Execute(ICommand command)
        {
            var create = (WorkerChanger)command;
            wrk.ChangeWorker(create.WorkerID,create.newWorkerName,create.DepartID);
            return null;
        }
    }

    public class ComputerChangerHandler : ICommandHandler
    {
        private PC pc;

        public ComputerChangerHandler(PC pc)
        {
            this.pc = pc;
        }

        public object Execute(ICommand command)
        {
            var create = (ComputerChanger)command;
          
            pc.ChangeComputer(create.ComputerID,create.DepartID,create.neComputerName);
            return null;
        }
    }

    public class DepartmentDeleterHandler : ICommandHandler
    {
        private Departament dep;

        public DepartmentDeleterHandler(Departament dep)
        {
            this.dep = dep;
        }

        public object Execute(ICommand command)
        {
            var create = (DepartmentDeleter)command;
            var depart = new Department();
            depart.DepartmentID = create.DepartID;
            dep.DeleteDepartment(depart);
            return null;
        }
    }

    public class WorkerDeleterHandler : ICommandHandler
    {
        private Worker wrk;

        public WorkerDeleterHandler(Worker wrk)
        {
            this.wrk = wrk;
        }

        public object Execute(ICommand command)
        {
            var create = (WorkerDeleter)command;
            wrk.DeleteWorker(create.WorkerID,create.DepartID);
            return null;
        }
    }

    public class ComputerDeleterHandler : ICommandHandler
    {

        private PC pc;

        public ComputerDeleterHandler(PC pc)
        {
            this.pc = pc;
        }

        public object Execute(ICommand command)
        {
            var create = (ComputerDeleter)command;

            pc.DeleteWorker(create.ComputerID,create.DepartID);
            return null;
        }
    }


    public class RecordsSaverHandler : ICommandHandler
    {
        private Offise off;

        public RecordsSaverHandler(Offise off)
        {
            this.off = off;
        }
        public object Execute(ICommand command)
        {
            var create = (RecordSaver)command;
            off.SaveRecords();
            return null;

        }
    }

    public class RecordGetHandler : ICommandHandler
    {
        private Offise off;

        public RecordGetHandler(Offise off)
        {
            this.off = off;
        }
        public object Execute(ICommand command)
        {
            var create = (RecordGet)command;
            return off.GetAllRecords();

        }
    }
            public class ConnectionStarterHandler : ICommandHandler
            {
                private Offise off;

                public ConnectionStarterHandler(Offise off)
                {
                    this.off = off;
                }
                public object Execute(ICommand command)
                {
                    var create = (ConnectionStarter)command;
                    return off.StartConnection();


                }


            }
        }
