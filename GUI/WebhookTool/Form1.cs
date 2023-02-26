using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace WebhookTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (this.checkBox1.Checked)
            {
                this.webhookurl.PasswordChar = '*';
            }
            else
            {
                this.webhookurl.PasswordChar = default(char);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.webhookurl.PasswordChar = '*';
            } else
            {
                this.webhookurl.PasswordChar = default(char);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string url = this.webhookurl.Text.Replace(" ", "");
            try
            {
                HttpResponseMessage response = await new HttpClient().DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    this.textBox1.AppendText("delete succeed!" + Environment.NewLine);
                }
                else
                {
                    this.textBox1.AppendText("delete failed!" + Environment.NewLine);
                }
            }
            catch
            {
                this.textBox1.AppendText("delete failed!" + Environment.NewLine);
            }
        }
    }
}
