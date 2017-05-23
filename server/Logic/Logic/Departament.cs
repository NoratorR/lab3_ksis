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
        public bool AddDepartment(string DepartName)
        {
            Department departm = new Department();
            departm.departName = DepartName;
            Company.depart.Add(departm);

            return true;
        }

        public bool ChangeDepartment(string DepartName, string newDepartName)
        {
            var index = Company.depart.FindIndex(p => p.departName == DepartName);
            Company.depart[index].departName = newDepartName;
            return true;
        }

        public bool CreateEssense(string Essense, string DepartName, string name)
        {
            if (Essense == "Computer")
            {
                Computer computer = new Computer();
                computer.computerName = name;
                var index = Company.depart.FindIndex(p => p.departName == DepartName);
                Company.depart[index].computerList.Add(computer);
            }
            else
            {
                Jober worker = new Jober();
                worker.workerName = name;
                var index = Company.depart.FindIndex(p => p.departName == DepartName);
                Company.depart[index].workerList.Add(worker);
            }

            return true;

        }

        public bool DeleteDepartment(string DepartName)
        {
            var index = Company.depart.FindIndex(p => p.departName == DepartName);
            Company.depart.RemoveAt(index);
            return true;
        }
    }
}
