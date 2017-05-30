using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ServiceLogic" в коде и файле конфигурации.
    public class Departament : IDepartament
    {
        public void CreateDepartment(Department dep)
        {
            Company.depart.Add(dep);
        }

        public void ChangeDepartment(Department dep)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == dep.DepartmentID);
            Company.depart[index].departName = dep.departName;
           
        }

      

        public void DeleteDepartment(Department dep)
        {
            var index = Company.depart.FindIndex(p => p.DepartmentID == dep.DepartmentID);
            Company.depart.RemoveAt(index);

        }
    }
}
