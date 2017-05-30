using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using System.Text;

namespace Custom_Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceLogic" в коде и файле конфигурации.
   
    public interface IDepartament
    {

        
        void DeleteDepartment(Department dep);
     
        void ChangeDepartment(Department dep,string newDepartName);
     
        void  CreateDepartment(Department dep);


    }
}
