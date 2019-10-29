using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace SimpleTaskManager
{
    public partial class Browsers : Form
    {
        public Browsers()
        {
            InitializeComponent();
        }

        private void Browsers_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Title = "Select a file to Run";
                dialog.Filter = "Executable files  |*.exe";
                // DialogResult result = dialog.ShowDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = dialog.FileName;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some error occur to start the process");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Process process = new Process();
                Process.Start(textBox1.Text);
            }
            catch (System.ObjectDisposedException ex)
            {
                MessageBox.Show("Error occur In dispose Exception " + ex.Message);
            }
            catch (System.ComponentModel.Win32Exception ewin32)
            {
                MessageBox.Show("Error occur in Win32 Exception " + ewin32.Message);
            }
            catch (ArgumentException eArgument)
            {
                MessageBox.Show("Error in Argument Exception " + eArgument.Message);
            }
            catch (InvalidOperationException eInvalidOperation)
            {
                MessageBox.Show("Error in invalid Operation Exception " + eInvalidOperation.Message);
            }
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
    }

