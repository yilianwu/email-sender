using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;

namespace emailsender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog filelog = new OpenFileDialog();
            if (filelog.ShowDialog() == DialogResult.OK)
            {
                atttxt.Text = filelog.FileName.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Sending sender1 = new Sending();
                sender1.info(svrtxt.Text, portxt.Text, usertxt.Text, pwdtxt.Text, fromtxt.Text, totxt.Text, subtxt.Text, cnttxt.Text, atttxt.Text);
                MessageBox.Show("Message sent!");
            }
            catch (Exception)
            {
                MessageBox.Show("填寫不完整或帳號密碼不正確!");
            }         
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex==0)
            {
                svrtxt.ReadOnly = true;
                portxt.ReadOnly = true;
                svrtxt.Text = "smtp.gmail.com";
                portxt.Text= "587";
                svrtxt.Visible = false;
                label4.Visible = false;
                portxt.Visible = false;
            }
            if (listBox1.SelectedIndex == 1)
            {
                svrtxt.ReadOnly = true;
                portxt.ReadOnly = true;
                svrtxt.Text= "smtp.live.com";
                portxt.Text = "587";
                svrtxt.Visible = false;
                label4.Visible = false;
                portxt.Visible = false;
            }
            if (listBox1.SelectedIndex == 2)
            {
                svrtxt.ReadOnly = true;
                portxt.ReadOnly = true;
                svrtxt.Text = "smtp.mail.yahoo.com";
                portxt.Text = "587";
                svrtxt.Visible = false;
                label4.Visible = false;
                portxt.Visible = false;
            }
            if (listBox1.SelectedIndex == 3)
            {
                svrtxt.ReadOnly = false;
                portxt.ReadOnly = false;
                svrtxt.Text="";
                portxt.Text = "";
                svrtxt.Visible = true;
                label4.Visible = true;
                portxt.Visible = true;

            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = label1.Font;
            if(fontDialog1.ShowDialog() !=DialogResult.Cancel)
            {
                label1.Font = fontDialog1.Font;
                label2.Font = fontDialog1.Font;
                label3.Font = fontDialog1.Font;
                label4.Font = fontDialog1.Font;
                label8.Font = fontDialog1.Font;
                groupBox1.Font = fontDialog1.Font;
                listBox1.Font = fontDialog1.Font;
                label5.Font = fontDialog1.Font;
                label6.Font = fontDialog1.Font;
                label7.Font = fontDialog1.Font;
                label8.Font = fontDialog1.Font;
                cnttxt.Font = fontDialog1.Font;
                button1.Font = fontDialog1.Font;
                button2.Font = fontDialog1.Font;
                checkBox1.Font = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = this.BackColor;
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                this.BackColor = colorDialog1.Color;
            }
        }

        private void outputTotxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog filelog1 = new SaveFileDialog();
            filelog1.ShowDialog();
            
            if (filelog1.FileName!="")
            {
                (filelog1.FileName).ToString();
                Saving saver = new Saving();
                FileStream draft = new FileStream((filelog1.FileName).ToString()+".txt", FileMode.CreateNew);
                BinaryWriter writer = new BinaryWriter(draft);
                writer.Write(saver.Saving1(fromtxt.Text, totxt.Text, subtxt.Text, cnttxt.Text));
                writer.Close();
                draft.Close();
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                fromtxt.Text = usertxt.Text;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developer : 吳羿璉\nVersion 1.0.1\n2017-2027 Copyright © All Rights Reserved");
        }
    }
}
