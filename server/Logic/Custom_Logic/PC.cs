using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using System.Text;

namespace Custom_Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "IPC" в коде и файле конфигурации.
    public class PC : IPC
    {
        public void AddWorker(int ComputerID, Jober wrk, int DepartmentID)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == DepartmentID);
            var i = Company.depart[index].computerList.FindIndex(p => p.computerID == ComputerID);
            var j = Company.depart[index].workerList.FindIndex(p => p.JoberID == wrk.JoberID);
            string temp = Company.depart[index].workerList[j].workerName;
            Company.depart[index].computerList[i].selfWorkerList.Add(temp);
        }

        public void ChangeComputer(int ComputerId, int DepartmentID,string newComputerName)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == DepartmentID);
            var i = Company.depart[index].computerList.FindIndex(p => p.computerID == ComputerId);
            Company.depart[index].computerList[i].computerName = newComputerName;
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
