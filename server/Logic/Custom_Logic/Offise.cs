using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Custom_Logic
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "ICompany" в коде и файле конфигурации.
    public class Offise : Icompany
    {
       
        public List<Department> GetAllRecords()
        {
           
           
            return Company.depart;
        }

        public List<Department> StartConnection()
        {
            Company.depart = new List<Department>();
            string str = String.Empty;
            if(File.Exists("saveData.xml"))
            {
                str = File.ReadAllText("saveData.xml");
            }
            if (String.IsNullOrEmpty(str))
                return Company.depart;
            var xmlSerializer = new XmlSerializer(typeof(List<Department>));
            var stringReader = new StringReader(str);
            List<Department> collection = (List<Department>)xmlSerializer.Deserialize(stringReader);
            if(collection != null)
                Company.depart = collection;
            return Company.depart;
        }


        public void SaveRecords()
        {
            if (Company.depart == null)
                return;
            XmlSerializer xml = new XmlSerializer(typeof(List<Department>));
            StringWriter stringWriter = new StringWriter();
            xml.Serialize(stringWriter, Company.depart);
            File.WriteAllText("saveData.xml",stringWriter.ToString());
        }


    
    }
}
