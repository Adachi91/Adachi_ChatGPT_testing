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

        private async void button1_Click(object sender, EventArgs e)
        {
            RemoteAPI ClientAPI = new RemoteAPI(new Uri("https://adachi.wiki/api69/"), credentials.username, credentials.password);

            try {
                string res = await ClientAPI.SendPayload("c_0_9_1");
                MessageBox.Show(res, "Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //it responded kuh it's working
        }
    }
}
