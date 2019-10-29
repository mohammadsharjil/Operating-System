using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Media;

namespace Project_FileSystemWatcher_
{
    public partial class MainForm : Form
    {
        public ListBox listBox;
        public const String startMonitoring = "Start Monitoring…";
        public const String stopMonitoring = "Stop Monitoring…";    

        public MainForm()
        {
            InitializeComponent();

            //Create a listBox to show activities of all Events.

            try
            {
                listBox = new ListBox();
                listBox.FormattingEnabled = true;
                listBox.Location = new System.Drawing.Point(15, 201);
                listBox.Name = "listBox";
                listBox.Size = new System.Drawing.Size(651, 308);
                listBox.TabIndex = 2;
                this.Controls.Add(listBox);
            }

            catch
            {
                MessageBox.Show("Error, Something is Wrong!");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Create FolderBrowserDialog object.

                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

                // Show a button to create a new folder.

                Console.Beep();
                folderBrowserDialog.ShowNewFolderButton = true;
                DialogResult dialogResult = folderBrowserDialog.ShowDialog();

                // Get selected path from FolderBrowserDialog control.

                if (dialogResult == DialogResult.OK)
                {
                    Console.Beep();
                    textBox1.Text = folderBrowserDialog.SelectedPath;
                    Environment.SpecialFolder root = folderBrowserDialog.RootFolder;

                }
            }

            catch
            {
                MessageBox.Show("Error, Something is Wrong!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create a new FileSystemWatcher object.

            FileSystemWatcher fsWatcher = new FileSystemWatcher();

            try
               {

            switch (button2.Text)
            {
                // Start Monitoring…
                   
                case startMonitoring:
                  
                        if (!textBox1.Text.Equals(String.Empty))
                        {
                            Console.Beep();
                            listBox.Items.Add("Started File System Watcher Service…");
                            fsWatcher.Path = textBox1.Text;

                            // Set Filter.

                            fsWatcher.Filter = (textBox2.Text.Equals(String.Empty)) ? "*.*" : textBox2.Text;

                            // Monitor files and subdirectories.

                            fsWatcher.IncludeSubdirectories = true;

                            // Monitor all changes specified in the NotifyFilters.

                            fsWatcher.NotifyFilter = NotifyFilters.Attributes |
                                                     NotifyFilters.CreationTime |
                                                     NotifyFilters.DirectoryName |
                                                     NotifyFilters.FileName |
                                                     NotifyFilters.LastAccess |
                                                     NotifyFilters.LastWrite |
                                                     NotifyFilters.Security |
                                                     NotifyFilters.Size;
                            fsWatcher.EnableRaisingEvents = true;

                            // Raise Event handlers.

                            fsWatcher.Changed += new FileSystemEventHandler(OnChanged);
                            fsWatcher.Created += new FileSystemEventHandler(OnCreated);
                            fsWatcher.Deleted += new FileSystemEventHandler(OnDeleted);
                            fsWatcher.Renamed += new RenamedEventHandler(OnRenamed);
                            fsWatcher.Error += new ErrorEventHandler(OnError);
                            button2.Text = stopMonitoring;
                            textBox1.Enabled = false;
                            textBox2.Enabled = false;
                        }

                        else
                        {
                            listBox.Items.Add("Please select folder to monitor….");
                        }

                        break;
                  

                // Stop Monitoring…

                case stopMonitoring:

                default:
                    Console.Beep();
                    fsWatcher.EnableRaisingEvents = false;
                    fsWatcher = null;
                    button2.Text = startMonitoring;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    listBox.Items.Add("Stopped FileSystemWatcher Service…");
                    break;                  
             }
        }

             catch
             {
                 MessageBox.Show("Error, Something is Wrong!");
             }

        }

        // FileSystemWatcher – OnCreated Event Handler

        public void OnCreated(object sender, FileSystemEventArgs e)
        {
            // Add event details in listbox.

            this.Invoke((MethodInvoker)delegate { listBox.Items.Add(String.Format("Path : {0} || Action : {1}", e.FullPath, e.ChangeType)); });
        }

        // FileSystemWatcher – OnChanged Event Handler
        
        public void OnChanged(object sender, FileSystemEventArgs e)
        {
            // Add event details in listbox.

            this.Invoke((MethodInvoker)delegate { listBox.Items.Add(String.Format("Path : {0} || Action : {1}", e.FullPath, e.ChangeType)); });
        }

        // FileSystemWatcher – OnRenamed Event Handler
        
        public void OnRenamed(object sender, RenamedEventArgs e)
        {
            // Add event details in listbox.

            this.Invoke((MethodInvoker)delegate { listBox.Items.Add(String.Format("Path : {0}|| Action : {1} to {2}", e.FullPath, e.ChangeType, e.Name)); });
        }

        // FileSystemWatcher – OnDeleted Event Handler
        
        public void OnDeleted(object sender, FileSystemEventArgs e)
        {
            // Add event details in listbox.

            this.Invoke((MethodInvoker)delegate { listBox.Items.Add(String.Format("Path : {0} || Action : {1}", e.FullPath, e.ChangeType)); });
        }

        // FileSystemWatcher – OnError Event Handler
        
        public void OnError(object sender, ErrorEventArgs e)
        {
            // Add event details in listbox.

            this.Invoke((MethodInvoker)delegate { listBox.Items.Add(String.Format("Error : {0}", e.GetException().Message)); });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer sd = new SoundPlayer("t1.wav");
                sd.Play();
            }
            catch
            {
                MessageBox.Show("Error, Something is Wrong!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SoundPlayer sd1 = new SoundPlayer("t2.wav");
                sd1.Play();              
                Application.Exit();                
            }
            catch
            {
                MessageBox.Show("Error, Something is Wrong!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Console.Beep();
                this.Hide();
                MainForm obj = new MainForm();
                obj.Show();
            }
            catch
            {
                MessageBox.Show("Error, Something is Wrong!");
            }
        }
    }
}
