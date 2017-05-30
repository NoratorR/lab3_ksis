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
        public void AddWorker(int ComputerID, Jober wrk, int DepartmentID)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == DepartmentID);
            var i = Company.depart[index].computerList.FindIndex(p => p.computerID == ComputerID);
            Company.depart[index].computerList[i].selfWorkerList.Add(wrk.workerName);
            string temp = Company.depart[index].computerList[i].computerName;

            i = Company.depart[index].workerList.FindIndex(p => p.JoberID == wrk.JoberID);
            Company.depart[index].workerList[i].selfComputerList.Add(temp);
        }

        public void ChangeComputer(Computer cmp,int DepartID)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == DepartID);
            var i = Company.depart[index].computerList.FindIndex(p => p.computerID == cmp.computerID);
            Company.depart[index].computerList[i].computerName = cmp.computerName;
        }

        public void CreateComputer(Computer cmp, int DepartmentID)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == DepartmentID);
            Company.depart[index].computerList.Add(cmp);
        }

        public void DeleteWorker(int ComputerId, int DepartmentID)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == DepartmentID);
            var i = Company.depart[index].computerList.FindIndex(p => p.computerID == ComputerId);
            Company.depart[index].computerList.RemoveAt(i);
        }
    }
}
