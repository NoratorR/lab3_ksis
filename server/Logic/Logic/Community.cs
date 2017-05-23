using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace Logic
{
 [DataContract]
   static class Company
    {
        [DataMember]
   
        public static  List<Department> depart;

    }

    [DataContract]
   public class Department 
    {
        [DataMember]
        public List<Jober> workerList = new List<Jober>();
        [DataMember]
    
        public List<Computer> computerList = new List<Computer>();
        [DataMember]

        public string departName; 
        

    }
    [DataContract]
  public  class Jober
    {
        [DataMember]
   
        public List<string> selfComputerList = new List<string>();
        [DataMember]
      
        public string workerName;

    }
    [DataContract]
   public class Computer 
    {
        [DataMember]
     
        public List<string> selfWorkerList = new List<string>();
        [DataMember]
   
        public string computerName;

    }

}

