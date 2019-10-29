using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; 

namespace SimpleTaskManager
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            // get an initial list of processes
            UpdateProcessList();
        }

        private void UpdateProcessList()
        {
            // clear the existing list of any items
            listBox1.Items.Clear();

            // loop through the running processes and add
            //each to the list
            foreach (Process p in Process.GetProcesses())
            {
                listBox1.Items.Add(p.ProcessName + " - " + p.Id);
            }
            // display the number of running processes in
            // a status message at the bottom of the page
            //label2.Text = "Processes running: " + listBox1.Items.Count.ToString();
        }



        Process[] procs;
        private void GetProcesses()
        {
            procs = Process.GetProcesses();
            if (Convert.ToInt32(label2.Text) != procs.Length) // Check if new processes have been started or terminated
            {
                listBox1.Items.Clear(); 
                for (int i = 0; i < procs.Length; i++)
                {
                    listBox1.Items.Add(procs[i].ProcessName);  // Add the process name to the listbox
                }
                label2.Text = procs.Length.ToString();  
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetProcesses(); 
        }

        // Check every 1 second for changes in the processes list
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetProcesses(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if ()
            //{
            //    MessageBox.Show("you donot press anything");
            //}
            try
            {
                procs[listBox1.SelectedIndex].Kill();

            }
            catch 
            {

                MessageBox.Show("you dont select anything");
            }


            // Kill the process coresponding to the selected index of listbox1 

            // loop through the running processes looking for a match
            // by comparing process name to the name selected in the listbox
            //foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            //{
            //    string[] arr = listBox1.SelectedItem.ToString().Split('-');
            //    string sProcess = arr[0].Trim();
            //    int iId = Convert.ToInt32(arr[1].Trim());

            //    if (p.ProcessName == sProcess && p.Id == iId)
            //    {
            //        p.Kill();
            //    }
            //}

            // update the list to show the killed process
            // has been removed
            UpdateProcessList();
        }

        private void kIllProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            procs[listBox1.SelectedIndex].Kill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateProcessList();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Browsers form2 = new Browsers();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
    }
}
