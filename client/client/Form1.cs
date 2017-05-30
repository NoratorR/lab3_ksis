using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using Logic;
using System.Xml.Serialization;
using System.IO;

namespace client
{
    public partial class Form1 : Form
    {
        private connection connect;
        private Type curType;
        private IWorker worker;
        private Icompany compamy;
        private IPC pc;
        private IDepartament deparment;
        private List<Department> departList;
        private bool isConnect;
        private Department curDep;
        private string curWorkerStr;
        private string curComputerStr;
        private int DepID;
        private int CompID;
        private int WorkID;
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
          
            dataGridView1.ColumnCount = 2;
            dataGridView1.Rows.Add("Worker","Computers");

            dataGridView2.ColumnCount = 2;
            dataGridView2.Rows.Add("Computer","Workers");
      
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            DepID = CompID = WorkID = 0;


        }




        private void button1_Click(object sender, EventArgs e)
        {
            try {

                connect = new connection();
       
                compamy = connect.CreateCompanyChannel();
                deparment = connect.CreateDeparmentChannel();
                worker = connect.CreateWorkerChannel();
                pc = connect.CreatePCChannel();
                departList = compamy.StartConnection();
                if (departList.Count > 0)
                {
                    GetID();
                    UppdateDepartment();
                    UppdateComputer();
                    UppdateWorker();
                }
                label2.Text = "Server was found on 192.168.240.1";
                isConnect = true;
            }
            catch(Exception ex)
            {
                isConnect = false;
                MessageBox.Show(ex.ToString());
            }
            if(isConnect)
            {
                button5.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button6.Enabled = true;
            }
                
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                return;
            if (String.IsNullOrEmpty(curWorkerStr) && String.IsNullOrEmpty(curComputerStr) && String.IsNullOrEmpty(textBox2.Text))
                return;
            if (curType == typeof(Jober))
            {
                var index = departList.FindIndex(p => p.DepartmentID == curDep.DepartmentID);
                Jober jbr = departList[index].workerList.Find(p => p.workerName == curWorkerStr);
                worker.DeleteWorker(jbr.JoberID,curDep.DepartmentID);
                UppdateWorker();
                UppdateComputer();
            }
            if (curType == typeof(Computer))
            {
                var index = departList.FindIndex(p => p.DepartmentID == curDep.DepartmentID);
                Computer cmp = departList[index].computerList.Find(p => p.computerName == curComputerStr);
                pc.DeleteWorker(cmp.computerID,curDep.DepartmentID);
                UppdateWorker();
                UppdateComputer();
            }
            if (curType == typeof(Department))
            {
                deparment.DeleteDepartment(curDep);
                UppdateDepartment();
                if (comboBox1.Text == "")
                {
                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();
                    return;
                }
                  
                UppdateComputer();
                UppdateWorker();
                comboBox1.Text = curDep.departName;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            curType = typeof(Jober);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            curType = typeof(Department);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            curType = typeof(Computer);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" && curType != typeof(Department))
            {
                MessageBox.Show("Need Create Departament");
                return;
            }
            if (!IsEmptyBox())
                return;
            if (curType == typeof(Department))
            {
                Department dep = new Department();
                dep.departName = textBox2.Text;
                dep.DepartmentID = DepID;
                deparment.CreateDepartment(dep);
                DepID++;
                UppdateDepartment();
                comboBox1.Text = curDep.departName;
            }
            else
            {
                if (curType == typeof(Jober))
                {
                    Jober jbr = new Jober();
                    jbr.JoberID = WorkID;
                    jbr.workerName = textBox2.Text;
                    worker.CreateWorker(jbr,curDep.DepartmentID);
                    WorkID++;
                    UppdateWorker();
                }
                if (curType == typeof(Computer))
                {
                    Computer cmp = new Computer();
                    cmp.computerID = CompID;
                    cmp.computerName = textBox2.Text;
                    pc.CreateComputer(cmp, curDep.DepartmentID);
                    UppdateComputer();
                }
            }
        }

        private  bool IsEmptyBox()
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("name is not input!");
                return false;
            }
            return true;
        }

        private void UppdateDepartment()
        {
            comboBox1.Items.Clear();
            departList = compamy.GetAllRecords();
            if (departList == null)
                return;
            foreach (Department dep in departList)
            {
                comboBox1.Items.Add(dep.departName);
                curDep = dep;
              
                makeComboList();
            }
         
        }
        private void UppdateWorker()
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add("Worker", "Computers");
            departList = compamy.GetAllRecords();
            var index = departList.FindIndex(p => p.DepartmentID == curDep.DepartmentID);
            string worker, computer = "";
            foreach (Jober wrk in departList[index].workerList)
            {
               worker = wrk.workerName;
                foreach (String cmp in wrk.selfComputerList)
                   computer += cmp + " ";
                dataGridView1.Rows.Add(worker,computer);
                computer = "";
            }
            makeComboList();
        }
        private void UppdateComputer()
        {
            dataGridView2.Rows.Clear();
            dataGridView2.Rows.Add("Computer", "Workers");
            departList = compamy.GetAllRecords();
            var index = departList.FindIndex(p => p.DepartmentID == curDep.DepartmentID);
            string worker = "", computer;
            foreach (Computer cmp in departList[index].computerList)
            {
               computer = cmp.computerName;
                foreach (String jbr in cmp.selfWorkerList)
                    worker += jbr + " ";
                dataGridView2.Rows.Add(computer,worker);
                worker = "";
            }
            makeComboList();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                return;
            curDep = departList.Find(p => p.departName == comboBox1.Text);
            UppdateComputer();
            UppdateWorker();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                return;
            if(curType == typeof(Jober))
            { 

                if (String.IsNullOrEmpty(curWorkerStr) && String.IsNullOrEmpty(curComputerStr))
                    return;

                var index = departList.FindIndex(p => p.DepartmentID == curDep.DepartmentID);
                Jober jbr = departList[index].workerList.Find(p => p.workerName == curWorkerStr);
                Computer cmp = departList[index].computerList.Find(p => p.computerName == curComputerStr);
                worker.AddComputer(jbr.JoberID, cmp, curDep.DepartmentID);
                UppdateWorker();
                UppdateComputer();
            }
            if (curType == typeof(Computer))
            {

                if (String.IsNullOrEmpty(curWorkerStr) && String.IsNullOrEmpty(curComputerStr))
                     return;
                var index = departList.FindIndex(p => p.DepartmentID == curDep.DepartmentID);
                Jober jbr = departList[index].workerList.Find(p => p.workerName == curWorkerStr);
                Computer cmp = departList[index].computerList.Find(p => p.computerName == curComputerStr);
                pc.AddWorker(cmp.computerID,jbr,curDep.DepartmentID);
                UppdateWorker();
                UppdateComputer();
            }
             

        }

        private void makeComboList()
        {
            comboBox2.Items.Clear(); comboBox3.Items.Clear();
            var index = departList.FindIndex(p => p.DepartmentID == curDep.DepartmentID);
            foreach (Jober work in departList[index].workerList)
            {
                comboBox2.Items.Add(work.workerName);
                comboBox2.Text = work.workerName;
            }
            foreach (Computer comp in departList[index].computerList)
            {
                comboBox3.Items.Add(comp.computerName);
                comboBox3.Text = comp.computerName;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
                return;
            curWorkerStr = comboBox2.Text;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
                return;
            curComputerStr = comboBox3.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                return;
            if (String.IsNullOrEmpty(curWorkerStr) && String.IsNullOrEmpty(curComputerStr) && String.IsNullOrEmpty(textBox2.Text))
                return;
            if (curType == typeof(Jober))
            {
                var index = departList.FindIndex(p => p.DepartmentID == curDep.DepartmentID);
                Jober jbr = departList[index].workerList.Find(p => p.workerName == curWorkerStr);
                jbr.workerName = textBox2.Text;
                worker.ChangeWorker(jbr ,curDep.DepartmentID);
                UppdateWorker();
                UppdateComputer();
            }
            if (curType == typeof(Computer))
            {
                var index = departList.FindIndex(p => p.DepartmentID == curDep.DepartmentID);
                Computer cmp = departList[index].computerList.Find(p => p.computerName == curComputerStr);
                cmp.computerName = textBox2.Text;
                pc.ChangeComputer(cmp, curDep.DepartmentID);
                UppdateWorker();
                UppdateComputer();
            }
            if (curType == typeof(Department))
            {
                Department dep = departList.Find(p => p.DepartmentID == curDep.DepartmentID);
                dep.departName = textBox2.Text;
                dep.DepartmentID = curDep.DepartmentID;
                deparment.ChangeDepartment(dep);
                UppdateDepartment();
                comboBox1.Text = curDep.departName;
            }
        }

        private void GetID()
        {
            foreach(Department dep in departList)
            {
                DepID++;
                foreach (Jober jbr in dep.workerList)
                    WorkID++;
                foreach (Computer cmp in dep.computerList)
                    CompID++;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            compamy.SaveRecords();
        }
    }
}
