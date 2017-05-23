using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IICompany" в коде и файле конфигурации.
    [ServiceContract]
    [ServiceKnownType(typeof(Company))]
    [ServiceKnownType(typeof(Departament))]
    [ServiceKnownType(typeof(Worker))]
    [ServiceKnownType(typeof(Computer))]
    public interface Icompany
    {
        [OperationContract] 
        List<Department> GetAllRecords();

        [OperationContract]
        List<Department> StartConnection();
        [OperationContract]
        void SaveRecords();
    }
}
