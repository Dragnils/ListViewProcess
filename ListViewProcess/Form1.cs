using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            Process[] processList = Process.GetProcesses();
            listView1.Items.Clear();
            foreach (var process in processList)
            {
                var item = new string[] { process.Id.ToString(), process.ProcessName, process.Threads.Count.ToString(), process.HandleCount.ToString() };
                ListViewItem row = new ListViewItem(item);             
                row.Tag = process;
                listView1.Items.Add(row);               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.ShowDialog();

                string fister = save.FileName;

                StreamWriter sw = new StreamWriter(fister);

                foreach (ListViewItem item in listView1.Items)
                {
                    for(int i=0; i < item.SubItems.Count; i++)
                    {
                        sw.Write(item.SubItems[i].Text);
                        if (i != item.SubItems.Count - 1)
                        {
                            sw.Write(",");
                        }
                                                   
                    }
                    sw.WriteLine();
                }
                sw.Close();
                MessageBox.Show("File save to: " + fister);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

             
        }
    }
}
