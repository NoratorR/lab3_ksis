using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Logic
{


   public class SetHandler

    {
        private Dictionary<Type, ICommandHandler> dic = new Dictionary<Type, ICommandHandler>();


        public void Signature()
        {
            Worker wrk = new Worker();
            Departament dep = new Departament();
            PC pc = new PC();
            Offise off = new Offise();
            Register(new DepartmentCreater().GetType(), new DepartmentCreaterHandler(dep));
            Register(new DepartmentChanger().GetType(), new DepartmentChangerHandler(dep));
            Register(new DepartmentDeleter().GetType(), new DepartmentDeleterHandler(dep));

            Register(new WorkerCreater().GetType(), new WorkerCreaterHandler(wrk));
            Register(new ComputerAdder().GetType(), new ComputerAdderHandler(wrk));
            Register(new WorkerChanger().GetType(), new WorkerChangerHandler(wrk));
            Register(new WorkerDeleter().GetType(), new WorkerDeleterHandler(wrk));

            Register(new ComputerCreater().GetType(), new ComputerCreaterHandler(pc));
            Register(new WorkerAdder().GetType(), new WorkerAdderHandler(pc));
            Register(new ComputerChanger().GetType(), new ComputerChangerHandler(pc));
            Register(new ComputerDeleter().GetType(), new ComputerDeleterHandler(pc));

            Register(new ConnectionStarter().GetType(), new ConnectionStarterHandler(off));
            Register(new RecordGet().GetType(), new RecordGetHandler(off));
            Register(new RecordSaver().GetType(), new RecordsSaverHandler(off));




        }
        private void Register(Type command, ICommandHandler handler)
        {
            dic.Add(command,handler);
        }

        public ICommandHandler GetHandler(Type command)
        {
            ICommandHandler handler = dic[command];
            return handler; 
        }


    }

}
