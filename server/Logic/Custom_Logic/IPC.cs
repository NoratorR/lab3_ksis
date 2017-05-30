using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using System.Text;

namespace Custom_Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IIPC" в коде и файле конфигурации.
   
    public interface IPC
    {
      
        void AddWorker(int ComputerID,Jober wrk,int DepartmentID);
       
        void ChangeComputer(int ComputerId,int DepartmentID, string newComputerName);
     
        void DeleteWorker(int ComputerId, int DepartmentID);
       
        void CreateComputer(Computer cmp,int DepartmentID);
    }
}
