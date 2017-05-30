using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using System.Text;

namespace Custom_Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IWorker" в коде и файле конфигурации.
  
    public interface IWorker
    {
       
        void AddComputer(int WorkerID,Computer cmp,int DepartmentID );
     
        void ChangeWorker(int WorkerID,string newWorkerName ,int DepartmentID);
     
        void DeleteWorker(int WorkerID,int DepartmentID);
       
        void CreateWorker(Jober jbr, int DepartmentID);
       
    }
}
