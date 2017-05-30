using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using System.Text;

namespace Custom_Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Worker" в коде и файле конфигурации.
    public class Worker : IWorker
    {
        public void AddComputer(int WorkerID, Computer cmp, int DepartmentID)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == DepartmentID);
            var i =  Company.depart[index].workerList.FindIndex(p => p.JoberID == WorkerID);
           
            var j = Company.depart[index].computerList.FindIndex(p => p.computerID == cmp.computerID);
            string temp = Company.depart[index].computerList[j].computerName;
            Company.depart[index].workerList[i].selfComputerList.Add(temp);

        }

        public void ChangeWorker(int WorkerID, string newWorkerName, int DepartmentID)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == DepartmentID);
            var i = Company.depart[index].workerList.FindIndex(p => p.JoberID == WorkerID);
            Company.depart[index].workerList[i].workerName = newWorkerName;

        }

        public void CreateWorker(Jober jbr, int DepartmentID)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == DepartmentID);
            Company.depart[index].workerList.Add(jbr);

        }

        public void DeleteWorker(int WorkerID, int DepartmentID)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == DepartmentID);
            var i = Company.depart[index].workerList.FindIndex(p => p.JoberID == WorkerID);
            Company.depart[index].workerList.RemoveAt(i);
        }
    }
}
