using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IIPC" в коде и файле конфигурации.
    [ServiceContract]
    [ServiceKnownType(typeof(Company))]
    [ServiceKnownType(typeof(Departament))]
    [ServiceKnownType(typeof(Worker))]
    [ServiceKnownType(typeof(Computer))]
    public interface IPC
    {
        [OperationContract]
        void AddWorker(int ComputerID,Jober wrk,int DepartmentID);
        [OperationContract]
        void ChangeComputer(Computer cmp, int DepartID);
        [OperationContract]
        void DeleteWorker(int ComputerId, int DepartmentID);
        [OperationContract]
        void CreateComputer(Computer cmp,int DepartmentID);
    }
}
