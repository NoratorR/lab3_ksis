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
        public void AddComputer(int WorkerID, Computer cmp, int DepartmentID)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == DepartmentID);
            var i =  Company.depart[index].workerList.FindIndex(p => p.JoberID == WorkerID);
            Company.depart[index].workerList[i].selfComputerList.Add(cmp.computerName);

            string temp = Company.depart[index].workerList[i].workerName;

            i = Company.depart[index].computerList.FindIndex(p => p.computerID == cmp.computerID);
            Company.depart[index].computerList[i].selfWorkerList.Add(temp);
        


    }

        public void ChangeWorker(Jober jbr, int DepartmentID)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == DepartmentID);
            var i = Company.depart[index].workerList.FindIndex(p => p.JoberID == jbr.JoberID);
            Company.depart[index].workerList[i].workerName = jbr.workerName;

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
