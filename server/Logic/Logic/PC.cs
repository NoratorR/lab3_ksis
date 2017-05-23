using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "IPC" в коде и файле конфигурации.
    public class PC : IPC
    {
        public bool AddWorker(string DepartName, string ComputerName, string WorkerName)
        {
            var index = Company.depart.FindIndex(p => p.departName == DepartName);
            List<Computer> lst = Company.depart[index].computerList;
            var i = lst.FindIndex(p => p.computerName == ComputerName);
            lst[i].selfWorkerList.Add(WorkerName);

            List<Jober> cst = Company.depart[index].workerList;
            i = cst.FindIndex(p => p.workerName == WorkerName);
            cst[i].selfComputerList.Add(ComputerName);
            return true;
        }

        public bool ChangeWorker(string DepartName, string ComputerName, string newWorkerName, string WorkerName)
        {
            var index = Company.depart.FindIndex(p => p.departName == DepartName);
            List<Computer> lst = Company.depart[index].computerList;
            var i = lst.FindIndex(p => p.computerName == ComputerName);
            var j = lst[i].selfWorkerList.FindIndex(p => p == WorkerName);
            lst[i].selfWorkerList[j] = newWorkerName;

            List<Jober> clt = Company.depart[index].workerList;
            i = clt.FindIndex(p => p.workerName == WorkerName);
            clt[i].workerName = newWorkerName;
            return true;
        }

        public bool DeleteWorker(string DepartName, string ComputerName, string WorkerName)
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
