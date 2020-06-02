using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rest_WebService_Consumer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region UI Event Handler
        private void btnExecute_Click(object sender, EventArgs e)
        {
            RestConsumer client = new RestConsumer();
            client.endPoint = txtRestURL.Text;

            string strResponse = client.executeRequest();

            txtResponse.Text = strResponse;
        }
        #endregion
    }
}
