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
        void AddComputer(int WorkerID,Computer cmp,int DepartmentID );
        [OperationContract]
        void ChangeWorker(Jober jbr,int DepartmentID);
        [OperationContract]
        void DeleteWorker(int WorkerID,int DepartmentID);
        [OperationContract]
        void CreateWorker(Jober jbr, int DepartmentID);
       
    }
}
