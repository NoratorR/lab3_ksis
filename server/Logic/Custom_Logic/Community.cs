using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using System.Xml.Serialization;

namespace Custom_Logic
{

   static class Company
    {
       
   
        public static  List<Department> depart;

    }

  
   public class Department 
    {
       
        public List<Jober> workerList = new List<Jober>();
       
    
        public List<Computer> computerList = new List<Computer>();
       

        public string departName;
        

        public int DepartmentID;
        

    }

  public  class Jober
    {
        
   
        public List<string> selfComputerList = new List<string>();
       
      
        public string workerName;
        
        public int JoberID;

    }
   
   public class Computer 
    {
       
     
        public List<string> selfWorkerList = new List<string>();
      
   
        public string computerName;

        public int computerID;

    }

}

