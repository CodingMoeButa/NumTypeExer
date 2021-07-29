using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumTypeExerG
{
    public partial class MainForm : Form
    {
        public static long used_time;
        public static int sum;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void newNum()
        {
            Random ran = new Random();
            label3.Text = "";
            textBox1.Text = "";
            for (int i = 1; i <= Convert.ToInt32(numericUpDown1.Value); i++)
            {
                label3.Text = label3.Text + Convert.ToString(ran.Next(0, 9));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = Convert.ToInt32(numericUpDown1.Value);
            button1.Enabled = false;
            button2.Enabled = true;
            numericUpDown1.Enabled = false;
            used_time = 0;
            sum = 0;
            label3.Width = Convert.ToInt32(Convert.ToDouble(numericUpDown1.Value) * 1.514);
            newNum();
            progressBar1.Width = label3.Width - 10;
            textBox1.Width = label3.Width - 10;
            int windowWidth = label3.Location.X + label3.Width + 20;
            if(windowWidth <= 815)
            {
                this.Width = 815;
            }
            else
            {
                this.Width = windowWidth;
            }
            label2.Text = "已用时长：0秒  已经完成：0组  平均速度：0.0组/分钟";
            timer1.Enabled = true;
            textBox1.Enabled = true;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            numericUpDown1.Enabled = true;
            timer1.Enabled = false;
            textBox1.Enabled = false;
            numericUpDown1.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            used_time++;
            label2.Text = "已用时长：" + used_time.ToString() + "秒  已经完成：" + sum.ToString() + "组  平均速度：" + (Convert.ToDouble(sum) / (Convert.ToDouble(used_time)/60)).ToString("0.0") + "组/分钟";
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void numericUpDown1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    button1.PerformClick();
                    break;
                case Keys.F2:
                    button2.PerformClick();
                    break;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    button1.PerformClick();
                    break;
                case Keys.F2:
                    button2.PerformClick();
                    break;
            }
        }

        public int getSameLen(string s1, string s2)
        {
            int min_len = s1.Length > s2.Length ? s2.Length : s1.Length;
            int same_len = 0;
            for(int i = 0; i < min_len; i++)
            {
                if(s1[i] == s2[i])
                {
                    same_len++;
                }
                else
                {
                    break;
                }
            }
            return same_len;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            progressBar1.Value = getSameLen(label3.Text, textBox1.Text);
            if(progressBar1.Maximum == progressBar1.Value)
            {
                newNum();
                sum++;
            }
        }
    }
}
