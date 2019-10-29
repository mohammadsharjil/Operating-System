using System.Timers;
//using System.Drawing;
using System;
using System.Data;
using System.Windows.Forms;

namespace MyTaskManager
{
    partial class MainClass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainClass));
            this.lv = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.killListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exceptListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.secToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.TollBox = new System.Windows.Forms.ToolStripTextBox();
            this.Kill_list_Process = new System.Windows.Forms.Button();
            this.Run = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv
            // 
            this.lv.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.lv.FullRowSelect = true;
            this.lv.GridLines = true;
            this.lv.Location = new System.Drawing.Point(24, 59);
            this.lv.Name = "lv";
            this.lv.Size = new System.Drawing.Size(331, 394);
            this.lv.TabIndex = 0;
            this.lv.UseCompatibleStateImageBehavior = false;
            this.lv.View = System.Windows.Forms.View.Details;
            this.lv.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RowSelect);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Process Name";
            this.columnHeader1.Width = 112;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ram";
            this.columnHeader2.Width = 76;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem6,
            this.menuItem5,
            this.menuItem3,
            this.menuItem4});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Open Containg folder";
            this.menuItem1.Click += new System.EventHandler(this.OpenContainingFolder);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "Kill select process";
            this.menuItem2.Click += new System.EventHandler(this.Kill_Selected_Process);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 2;
            this.menuItem6.Text = "Add to Except";
            this.menuItem6.Click += new System.EventHandler(this.Add_ExceptList_Clicked);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.Text = "Add to kill list";
            this.menuItem5.Click += new System.EventHandler(this.Add_Kill_List_Clicked);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            this.menuItem3.Text = "Kill list";
            this.menuItem3.Click += new System.EventHandler(this.Ml_Kill_List_Clicked);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 5;
            this.menuItem4.Text = "Except list";
            this.menuItem4.Click += new System.EventHandler(this.Ml_Except_List_Clicked);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(24, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "View Kill List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.KillListButton_Clicked);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(105, 479);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "View Except List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Except_btn_Clicked);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.refreshRateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(379, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.killListToolStripMenuItem,
            this.exceptListToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // killListToolStripMenuItem
            // 
            this.killListToolStripMenuItem.Name = "killListToolStripMenuItem";
            this.killListToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.killListToolStripMenuItem.Text = "Kill List";
            this.killListToolStripMenuItem.Click += new System.EventHandler(this.MS_Kill_List_Clicked);
            // 
            // exceptListToolStripMenuItem
            // 
            this.exceptListToolStripMenuItem.Name = "exceptListToolStripMenuItem";
            this.exceptListToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exceptListToolStripMenuItem.Text = "Except List";
            this.exceptListToolStripMenuItem.Click += new System.EventHandler(this.exceptListToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // refreshRateToolStripMenuItem
            // 
            this.refreshRateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.secToolStripMenuItem,
            this.secToolStripMenuItem1,
            this.secToolStripMenuItem2,
            this.secToolStripMenuItem3,
            this.TollBox});
            this.refreshRateToolStripMenuItem.Name = "refreshRateToolStripMenuItem";
            this.refreshRateToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.refreshRateToolStripMenuItem.Text = "Refresh Rate";
            // 
            // secToolStripMenuItem
            // 
            this.secToolStripMenuItem.Name = "secToolStripMenuItem";
            this.secToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.secToolStripMenuItem.Text = "1 Sec";
            this.secToolStripMenuItem.Click += new System.EventHandler(this.OneSecCliceked);
            // 
            // secToolStripMenuItem1
            // 
            this.secToolStripMenuItem1.Name = "secToolStripMenuItem1";
            this.secToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.secToolStripMenuItem1.Text = "2 Sec";
            this.secToolStripMenuItem1.Click += new System.EventHandler(this.secToolStripMenuItem1_Click);
            // 
            // secToolStripMenuItem2
            // 
            this.secToolStripMenuItem2.Name = "secToolStripMenuItem2";
            this.secToolStripMenuItem2.Size = new System.Drawing.Size(160, 22);
            this.secToolStripMenuItem2.Text = "4 Sec";
            this.secToolStripMenuItem2.Click += new System.EventHandler(this.secToolStripMenuItem2_Click);
            // 
            // secToolStripMenuItem3
            // 
            this.secToolStripMenuItem3.Name = "secToolStripMenuItem3";
            this.secToolStripMenuItem3.Size = new System.Drawing.Size(160, 22);
            this.secToolStripMenuItem3.Text = "8 Sec";
            this.secToolStripMenuItem3.Click += new System.EventHandler(this.secToolStripMenuItem3_Click);
            // 
            // TollBox
            // 
            this.TollBox.Name = "TollBox";
            this.TollBox.Size = new System.Drawing.Size(100, 20);
            this.TollBox.Text = "1";
            this.TollBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ForEnter);
            this.TollBox.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // Kill_list_Process
            // 
            this.Kill_list_Process.ForeColor = System.Drawing.Color.Red;
            this.Kill_list_Process.Location = new System.Drawing.Point(243, 30);
            this.Kill_list_Process.Name = "Kill_list_Process";
            this.Kill_list_Process.Size = new System.Drawing.Size(95, 23);
            this.Kill_list_Process.TabIndex = 3;
            this.Kill_list_Process.Text = "Kill list Process";
            this.Kill_list_Process.UseVisualStyleBackColor = true;
            this.Kill_list_Process.Click += new System.EventHandler(this.Kill_list_Process_Click);
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(281, 479);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(67, 23);
            this.Run.TabIndex = 4;
            this.Run.Text = "New Task";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // MainClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 514);
            this.ContextMenu = this.contextMenu1;
            this.Controls.Add(this.Run);
            this.Controls.Add(this.Kill_list_Process);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lv);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainClass";
            this.Text = "MyTaskManager";
            this.Load += new System.EventHandler(this.MainClass_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void AddTimer()
        {
            this.timer.Enabled = true;
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(TimerElapsed);

        }

        private void MyInitializetion()
        {

            ColumnHeader columnHeader1 = new ColumnHeader();
            columnHeader1.Text = " Process";
            columnHeader1.TextAlign = HorizontalAlignment.Left;
            columnHeader1.Width = 146;

            ColumnHeader columnHeader2 = new ColumnHeader();
            columnHeader2.Text = "Memory";
            columnHeader2.TextAlign = HorizontalAlignment.Left;
            columnHeader2.Width = 142;

            this.lv.Columns.Add(columnHeader1);
            this.lv.Columns.Add(columnHeader2);
           
        }
       
        #endregion

        public System.Windows.Forms.ListView lv;
        public System.Timers.Timer timer = new System.Timers.Timer(4000);
        private ContextMenu contextMenu1;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private Button button1;
        private Button button2;
        private MenuItem menuItem5;
        private MenuItem menuItem6;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem killListToolStripMenuItem;
        private ToolStripMenuItem exceptListToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem refreshRateToolStripMenuItem;
        private ToolStripMenuItem secToolStripMenuItem;
        private ToolStripMenuItem secToolStripMenuItem1;
        private ToolStripMenuItem secToolStripMenuItem2;
        private ToolStripMenuItem secToolStripMenuItem3;
        private ToolStripTextBox TollBox;
        private Button Kill_list_Process;
        private Button Run;
        
    }
}

