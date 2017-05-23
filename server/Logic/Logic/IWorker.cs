using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IWorker" в коде и файле конфигурации.
    [ServiceContract]
    [ServiceKnownType(typeof(Company))]
    [ServiceKnownType(typeof(Departament))]
    [ServiceKnownType(typeof(Worker))]
    [ServiceKnownType(typeof(Computer))]
    public interface IWorker
    {
        [OperationContract]
        bool AddComputer(string DepartName, string ComputerName, string WorkerName);
        [OperationContract]
        bool ChangeComputer(string DepartName, string ComputerName, string newComputerName, string WorkerName);
        [OperationContract]
        bool DeleteComputer(string DepartName, string ComputerName, string WorkerName);
       
    }
}
