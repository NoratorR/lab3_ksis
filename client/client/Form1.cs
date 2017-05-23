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
        private string curDepName;
        private string curWorkerStr;
        private string curComputerStr;
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
                worker.DeleteComputer(curDepName, curComputerStr, curWorkerStr);
                UppdateWorker();
                UppdateComputer();
            }
            if (curType == typeof(Computer))
            {
                pc.DeleteWorker(curDepName,curComputerStr,curWorkerStr);
                UppdateWorker();
                UppdateComputer();
            }
            if (curType == typeof(Department))
            {
                deparment.DeleteDepartment(curDepName);
                UppdateDepartment();
                if (comboBox1.Text == "")
                {
                    dataGridView1.Rows.Clear();
                    dataGridView2.Rows.Clear();
                    return;
                }
                  
                UppdateComputer();
                UppdateWorker();
                comboBox1.Text = curDepName;
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
                deparment.AddDepartment(textBox2.Text);
                UppdateDepartment();
                comboBox1.Text = curDepName;
            }
            else
            {
                if (curType == typeof(Jober))
                {
                    deparment.CreateEssense("Worker", curDepName, textBox2.Text);
                    UppdateWorker();
                }
                if (curType == typeof(Computer))
                {
                    deparment.CreateEssense("Computer", curDepName, textBox2.Text);
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
                curDepName = dep.departName;
              
                makeComboList();
            }
         
        }
        private void UppdateWorker()
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add("Worker", "Computers");
            departList = compamy.GetAllRecords();
            var index = departList.FindIndex(p => p.departName == curDepName);
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
            var index = departList.FindIndex(p => p.departName == curDepName);
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
            curDepName = comboBox1.Text;
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
                worker.AddComputer(curDepName,curComputerStr,curWorkerStr);
                UppdateWorker();
                UppdateComputer();
            }
            if (curType == typeof(Computer))
            {

                if (String.IsNullOrEmpty(curWorkerStr) && String.IsNullOrEmpty(curComputerStr))
                    return;
                pc.AddWorker(curDepName,curComputerStr,curWorkerStr);
                UppdateWorker();
                UppdateComputer();
            }


        }

        private void makeComboList()
        {
            comboBox2.Items.Clear(); comboBox3.Items.Clear();
            var index = departList.FindIndex(p => p.departName == curDepName);
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
                worker.ChangeComputer(curDepName, curComputerStr,textBox2.Text ,curWorkerStr);
                UppdateWorker();
                UppdateComputer();
            }
            if (curType == typeof(Computer))
            {
                pc.ChangeWorker(curDepName, curComputerStr, textBox2.Text,curWorkerStr);
                UppdateWorker();
                UppdateComputer();
            }
            if (curType == typeof(Department))
            {
               
                deparment.ChangeDepartment(curDepName,textBox2.Text);
                UppdateDepartment();
                comboBox1.Text = curDepName;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            compamy.SaveRecords();
        }
    }
}
