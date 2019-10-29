using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.Timers;
using System.IO;
using System.Xml;


// [16/3/2007 Created By Naveed khan]
// AT 11:03
// Student of : Kohat University of Science and Technology 
// Kohat Pakistan
// Email   : nidostyle@gmail.com
// contact : 0322-9093727

//updation
//  [9/4/2007 ]
// Created AT 11:51



namespace MyTaskManager
{
    public partial class MainClass : Form
    {
        #region Initilization

        private int noOfProcess;
        private string SelectedProcess;
        private string[] path ;
        private int index;
        Process[] process;
        Kill_List Window_kill_list;
        Kill_List Window_Except;
        

        #endregion
        

        public MainClass()
        {
            
            InitializeComponent();
           
            path = new string[100];
            GetProcesses();
            ConformXmlFile();
            Window_kill_list = new Kill_List("Kill List");
            Window_Except = new Kill_List("Except Window");

        }

         public MainClass(object j )
        {
            Kill_List kl = new Kill_List();
            kl.ReadXmlFile("Kill List.xml");
        }

        private void MainClass_Load(object sender, EventArgs e)
        {
           // MyInitializetion();
            AddtoControl();
           
        }

    
        #region AgainInitilizeLV Method
        private void AgainInitilizeLV()
        {
            this.lv = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lv.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.Location = new System.Drawing.Point(24, 67);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(331, 394);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
        }
#endregion

        #region Add To Control

        private delegate void AddtoControlDel();

        private void AddtoControl()
        {

            if (lv.InvokeRequired)
            {
                Invoke(new AddtoControlDel(AddtoControl), new object[] { });
            }
            else
                this.Controls.Add(lv);
        }

        #endregion

        #region AddListViewItemsTolv

        private delegate void AddListViewItemsTolvDel(ListViewItem list);
        private void AddListViewItemsTolv(ListViewItem listVI)
        {
            
            if (lv.InvokeRequired)
            {
                Invoke(new AddListViewItemsTolvDel(AddListViewItemsTolv), new object[] { listVI });
            }
            else
               this.lv.Items.AddRange(new ListViewItem[] { listVI });
        }
        #endregion

        #  region Get The process and and add to lv

        private void GetProcesses()
        {

            try
            {
                this.lv.Clear();
                //System.Windows.Forms.MessageBox.Show("No of process is " + noOfProcess);
                MyInitializetion();

                AddTimer();
                string[] Mem_Usage = new string[100];
                string[] ProcessNames = new string[100];
                process = Process.GetProcesses();
                noOfProcess = 0;
                int i = 0;
                ListViewItem lvi = new ListViewItem();
                foreach (Process pro in process)
                {
                    String pathx = "";
                    try
                    {
                        pathx = pro.Modules[0].FileName;
                        pathx = pathx.Replace("\\??\\", "");
                        path[i] = pathx.ToString();
                    }
                    catch (Win32Exception)
                    {
                        path[i] = "";
                    }
                    ProcessNames[i] = pro.ProcessName;
                    Mem_Usage[i] = Convert.ToString(pro.PagedMemorySize64);
                    lvi = new ListViewItem(ProcessNames[i]);
                    lvi.SubItems.Add(Mem_Usage[i]);
                    AddListViewItemsTolv(lvi);
                    i++;

                    noOfProcess++;
                }
            }
            catch
            {
            }
          }
        #endregion

      
        #region Check4Processes

        private void Check4Processes()
        {
            Process[] gPro = Process.GetProcesses();
            int Numpro = 0;
            string[] names = new string[100];
            string[] mem = new string[100];
         
            foreach (Process pro in gPro)
            {
                names[Numpro] = pro.ProcessName;
                mem[Numpro] = Convert.ToString(pro.PagedMemorySize64);
                Numpro++;
            }
            if (Numpro < noOfProcess)
            {
                //no of process are decreased
              
                //System.Windows.Forms.MessageBox.Show("Numpro 1 "+Numpro  +" No ofProcess : "+noOfProcess);
                GetProcesses();
                AddtoControl();
            }
            if (Numpro > noOfProcess)
            {
                // no of Process are increased
                //System.Windows.Forms.MessageBox.Show("Numpro 2 "+Numpro +" No ofProcess :"+noOfProcess);
                GetProcesses();
                AddtoControl();
            }
        }
        #endregion

        // Events

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            Check4Processes();
        }

        private void KillListButton_Clicked(object sender, EventArgs e)
        {
            if (Window_kill_list.IsDisposed)
                Window_kill_list = new Kill_List("Kill List");
            Window_kill_list.Show();
        }

        private void Except_btn_Clicked(object sender, EventArgs e)
        {
            
            if (Window_Except.IsDisposed)
                Window_Except = new Kill_List("Except_List");
            Window_Except.Show();
        }

       

        #region Get the Selected process (Evnent)
        private void RowSelect(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = lv.HitTest(e.X, e.Y);
           
            ListViewItem.ListViewSubItem subitem = null;
            if (info != null)
            {
                try
                {
                    subitem = info.Item.GetSubItemAt(e.X, e.Y);
                    index = info.Item.Index;
                }
                catch
                {

                }
            }
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {
                SelectedProcess = subitem.Text;
            }
            //System.Windows.Forms.MessageBox.Show("rr");
        }
        #endregion

        private void Add_Kill_List_Clicked(object sender, EventArgs e)
        {
            if (Window_kill_list.IsDisposed)
                Window_kill_list = new Kill_List("Kill List");
            if (!Window_kill_list.Check_Process_in_ExceptList(SelectedProcess, Window_kill_list))
            {
                Window_kill_list.txtbox.Text += SelectedProcess + "\r\n";
                Window_kill_list.AddOneToList("Kill List.xml");
                Window_kill_list.Show();
            }
            else
            {
                MessageBox.Show("The process you want to add in Kill List\n is already in Except List remove" +
                "from \n Except list or try another process", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Add Process to Except List
        private void Add_ExceptList_Clicked(object sender, EventArgs e)
        {
            if (Window_Except.IsDisposed)
                Window_Except = new Kill_List("Except Window");
            Window_Except.txtbox.Text += SelectedProcess + "\r\n";
            Window_Except.AddOneToList("Except List.xml");
            Window_Except.Show();
        }
        #endregion

        private void OpenContainingFolder(object sender, EventArgs e)
        {
            
           // System.Windows.Forms.MessageBox.Show(path[index]);
            if (!File.Exists(SelectedProcess))
            {
                Process p = new Process();
                p.StartInfo.FileName = "explorer.exe";
                p.StartInfo.Arguments = "/Select," + path[index];
                p.Start();
            }
            else
                System.Windows.Forms.MessageBox.Show("The process does no exist");
        }

        private void Kill_Selected_Process(object sender, EventArgs e)
        {
            int length = Window_kill_list.TotalTages();
            foreach (Process kill in process)
            {

                for (int i = 0; i < length; i++)
                {
                    bool same = (kill.ProcessName == Window_kill_list.PInKill_List[i]);
                    if (same && !kill.HasExited)
                    {
                           kill.Kill();

                    }
                    if(same)
                    {
                        MessageBox.Show("Sorry you are going to kill a process\n that you add in except list");
                    }
                }
                                         
                
            }
        }

        private void Ml_Kill_List_Clicked(object sender, EventArgs e)
        {
            KillListButton_Clicked(sender, e);
        }

        private void Ml_Except_List_Clicked(object sender, EventArgs e)
        {
            Except_btn_Clicked(sender, e);
        }

        private void MS_Kill_List_Clicked(object sender, EventArgs e)
        {
            KillListButton_Clicked(sender, e);
        }

        private void exceptListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Except_btn_Clicked(sender, e);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void OneSecCliceked(object sender, EventArgs e)
        {
            timer.Interval = 1000;
        }

        private void secToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer.Interval = 2000;
        }

        private void secToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            timer.Interval = 4000;
        }

        private void secToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            timer.Interval = 8000;
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void ForEnter(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
               if( TollBox.Text != "") 
                timer.Interval = Convert.ToInt64(sender.ToString());
            }
        }

        private void Kill_list_Process_Click(object sender, EventArgs e)
        {
            int killed = 0;
            int length = Window_kill_list.TotalTages();
            if (length == 0)
            {
                MessageBox.Show("List is Empty.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                foreach (Process kill in process)
                {
                    for (int i = 0; i < length; i++)
                    {
                        if ((kill.ProcessName == Window_kill_list.PInKill_List[i]) && !kill.HasExited)
                        {
                           // System.Windows.Forms.MessageBox.Show(kill.ProcessName + " Process killed");
                            kill.Kill();
                            killed++;
                            if (i == length)
                                length--;
                            break;
                        }
                       
                    }
                    if (killed == length)
                        break;
                }

            }
        }
        private void Run_Click(object sender, EventArgs e)
        {
            RunForm frm = new RunForm();
            frm.Show();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}