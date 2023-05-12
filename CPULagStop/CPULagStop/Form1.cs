using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPULagStop
{
    public partial class Form1 : Form
    {
        public string title;
        public string shortcutName;
        public string path;
        public string processName;
        public int CPUvalue;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //title
            title = (textBox1.Text);
            //shortcutName
            shortcutName = (textBox2.Text);
            //path
            path = (textBox3.Text);
            //processName
            processName = (textBox4.Text);

            //CPU cores
            CPUvalue = 0; //used to reset the values
            if (checkBox1.Checked)
            {
                CPUvalue = CPUvalue + 1;
            }

            if (checkBox2.Checked)
            {
                CPUvalue = CPUvalue + 2;
            }

            if (checkBox3.Checked)
            {
                CPUvalue = CPUvalue + 4;
            }

            if (checkBox4.Checked)
            {
                CPUvalue = CPUvalue + 8;
            }

            if (checkBox5.Checked)
            {
                CPUvalue = CPUvalue + 16;
            }

            if (checkBox6.Checked)
            {
                CPUvalue = CPUvalue + 32;
            }

            if (checkBox7.Checked)
            {
                CPUvalue = CPUvalue + 64;
            }

            if (checkBox8.Checked)
            {
                CPUvalue = CPUvalue + 128;
            }

            textBox5.Text = ( "@echo off\r\ntitle " + title + "\r\nstart \"" + shortcutName + "\" \"" + path + "\"\r\ntimeout /t 20 /nobreak \r\nPowerShell \"Get-Process " + processName + " | Select-Object ProcessorAffintiy\"\r\nPowerShell \"$Process = Get-Process " + processName + "; $Process.ProcessAffinity= " + Convert.ToString(CPUvalue)) + "\"";
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ".lnk (*.lnk)| *.lnk";
            ofd.FilterIndex = 1;
            ofd.Multiselect = false;
            
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = ofd.FileName;
                textBox2.Text = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
            }
        }
    }
}
