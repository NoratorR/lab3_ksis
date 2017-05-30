using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using System.Text;

namespace Custom_Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IICompany" в коде и файле конфигурации.
   
    public interface Icompany
    {
        
        List<Department> GetAllRecords();
       

       
        List<Department> StartConnection();
        
        void SaveRecords();
      

    }
}
