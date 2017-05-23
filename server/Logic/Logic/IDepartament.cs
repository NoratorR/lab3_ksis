using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceLogic" в коде и файле конфигурации.
    [ServiceContract]
    [ServiceKnownType(typeof(Company))]
    [ServiceKnownType(typeof(Departament))]
    [ServiceKnownType(typeof(Worker))]
    [ServiceKnownType(typeof(Computer))]
    public interface IDepartament
    {
        [OperationContract]
        bool AddDepartment(string DepartName);
        [OperationContract]
        bool DeleteDepartment(string DepartName);
        [OperationContract]
        bool ChangeDepartment(string DepartName, string newDepartName);
        [OperationContract]
        bool CreateEssense(string essense, string DepartName, string name);



    }
}
