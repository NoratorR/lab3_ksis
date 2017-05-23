using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Worker" в коде и файле конфигурации.
    public class Worker : IWorker
    {
       

        public bool AddComputer(string DepartName, string ComputerName, string WorkerName)
        {
          
            var index = Company.depart.FindIndex(p => p.departName == DepartName);
            List<Jober> lst = Company.depart[index].workerList;
            var i = lst.FindIndex(p => p.workerName == WorkerName);
            lst[i].selfComputerList.Add(ComputerName);
           
            
            List<Computer> cst = Company.depart[index].computerList;
            i = cst.FindIndex(p => p.computerName == ComputerName);
            cst[i].selfWorkerList.Add(WorkerName);
            return true;
        }

        public bool ChangeComputer(string DepartName, string ComputerName, string newComputerName, string WorkerName)
        {
            var index = Company.depart.FindIndex(p => p.departName == DepartName);
            List<Jober> lst = Company.depart[index].workerList;
            var i = lst.FindIndex(p => p.workerName == WorkerName);
            var j = lst[i].selfComputerList.FindIndex(p => p == ComputerName);
            lst[i].selfComputerList[j] = newComputerName;

            List<Computer> clt = Company.depart[index].computerList;
            i = clt.FindIndex(p => p.computerName == ComputerName);
            clt[i].computerName = newComputerName;

            return true;
        }

        public bool DeleteComputer(string DepartName, string ComputerName ,string WorkerName)
        {
            var index = Company.depart.FindIndex(p => p.departName == DepartName);
            List<Computer> lst = Company.depart[index].computerList;
            var i = lst.FindIndex(p => p.computerName == ComputerName);
            var j = lst[i].selfWorkerList.FindIndex(p => p == WorkerName);
            lst[index].selfWorkerList.RemoveAt(j);

            List<Jober> cst = Company.depart[index].workerList;
            i = cst.FindIndex(p => p.workerName == WorkerName);
            j = cst[i].selfComputerList.FindIndex(p => p == ComputerName);
            cst[index].selfComputerList.RemoveAt(j);
            return true;
        }

       
    }
}
