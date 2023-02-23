using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adachi_ChatGPT_testing
{
    public partial class Form1 : Form
    {
        //git ignore
        Credentials credentials = new Credentials();

        public Form1()
        {
            InitializeComponent();
        }

        private void convertBytestream(string stream)
        {
            byte[] buffer;

            var a = stream.Split(',');
            int ArrayLen = a.Length - 1;
            richTextBox1.AppendText(string.Format("Length of array is {0}\n", ArrayLen));
            buffer = new byte[ArrayLen];
            string[] b = new string[ArrayLen];

            for (int i = 0; i < a.Length - 1; i++)
            {
                //var tt = Convert.ToInt16(a[i]).ToString("X");
                var tt = Convert.ToInt16(a[i]);
                richTextBox1.AppendText(tt + "\r\n");
                //buffer[i] = Convert.ToByte(tt);
                //buffer[i] = Convert.ToInt32(a[i].ToString("X"));
                //b[i] = a[i];
            }

            var adsf = "aaaaaaaaaaa";

            //richTextBox1.AppendText(string.Format("\n\n :: {0} :: \n\n", Encoding.UTF8.GetString(buffer,0,buffer.Length)));
            Console.WriteLine("\n\n :: {0} :: \n\n", Encoding.UTF8.GetString(buffer, 0, buffer.Length));
            Console.WriteLine("\n\n :: {0} :: \n\n", Encoding.Default.GetString(buffer, 0, buffer.Length));

            //byte[] test = BitConverter.GetBytes()
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            RemoteAPI ClientAPI = new RemoteAPI(new Uri("https://adachi.wiki/api69/"), credentials.username, credentials.password);

            try {
                string res = await ClientAPI.SendPayload("Apples are good!|Halp");
                //MessageBox.Show(res, "Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
                richTextBox1.AppendText(res + "\r\n");
                //convertBytestream(res);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //it responded kuh it's working
        }
    }
}
