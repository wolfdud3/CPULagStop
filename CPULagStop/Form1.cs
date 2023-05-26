using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        //Message Box and Errors and whatnot
        public bool errorFlag;
        public string errorMsg;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //resetting values
            CPUvalue = 0;
            errorMsg = "We got a small issue:"; //or maybe "Following values are missing"?
            if (errorFlag == true)
            {
                errorFlag = false;
                label2.ForeColor = SystemColors.ControlText;
                label3.ForeColor = SystemColors.ControlText;
                label4.ForeColor = SystemColors.ControlText;
                label5.ForeColor = SystemColors.ControlText;
            }

            //assinging values from textBox to variablem
            title = (textBox1.Text);
            shortcutName = (textBox2.Text);
            path = (textBox3.Text);
            processName = (textBox4.Text);

            cpuCheck(); //check selected CPUs
            boxCheck(); //check entries of textBoxes

            if (errorFlag == true)
            {
                var MsgBox = MessageBox.Show(errorMsg + "", "Missing Values", MessageBoxButtons.OK);
            }
            else if (File.Exists(path) == false && !checkBox9.Checked)
            {
                var MsgBox = MessageBox.Show("File \"" + path + "\" not found","Error", MessageBoxButtons.OK);
            }
            else
            {
                textBox5.Text = ("@echo off\r\ntitle " + title + "\r\nstart \"" + shortcutName + "\" \"" + path + "\"\r\ntimeout /t 20 /nobreak \r\nPowerShell \"Get-Process " + processName + " | Select-Object ProcessorAffintiy\"\r\nPowerShell \"$Process = Get-Process " + processName + "; $Process.ProcessAffinity= " + Convert.ToString(CPUvalue)) + "\"";
            }
        }

        //Browse Through Files in File Explorer
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
                checkBox9.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //open save location + create file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = ".bat (*.bat) | *.bat";
            sfd.FilterIndex = 2;
            sfd.FileName = title;
            
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                //insert all Text from textBox5
                File.WriteAllText(sfd.FileName, textBox5.Text);
            }
            
        }
        public void cpuCheck()
        {
            //CPU cores
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
        }

        public void boxCheck()
        {
            //check if textBoxes are empty, if not, continue with creating script  
            if (textBox1.Text.Length == 0)
            {
                label2.ForeColor = Color.Red;
                errorFlag = true;
                errorMsg = errorMsg + "\r\nNo title entered.";
            }
            if (textBox2.Text.Length == 0)
            {
                label3.ForeColor = Color.Red;
                errorFlag = true;
                errorMsg = errorMsg + "\r\nNo shortcut name";
            }
            if (textBox3.Text.Length == 0)
            {
                label4.ForeColor = Color.Red;
                errorFlag = true;
                errorMsg = errorMsg + "\r\nNo shortcut selected";
            }
            if (textBox4.Text.Length == 0)
            {
                label5.ForeColor = Color.Red;
                errorFlag = true;
                errorMsg = errorMsg + "\r\nNo process name entered";
            }
        }

    }
}
