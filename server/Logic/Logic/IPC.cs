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
        bool AddWorker(string DepartName, string ComputerName, string WorkerName);
        [OperationContract]
        bool ChangeWorker(string DepartName, string ComputerName, string newWorkerName, string WorkerName);
        [OperationContract]
        bool DeleteWorker(string DepartName, string ComputerName, string WorkerName);
    }
}
