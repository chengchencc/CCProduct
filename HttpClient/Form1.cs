using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BlackMamba.Framework.Core;
using CC.Product.Core;

namespace HttpClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // var url = textBoxUrl.Text;
           // RestfulClient restClient = new RestfulClient();
           // var paras = new Dictionary<string,string>();
           // paras.Add("userId", "test01");
           // paras.Add("password", "password");
           // var result = restClient.Post(url, paras, EncodingNames.UTF8);
           //textBoxResult.Text = result;

           WebReference.OAWebService wc = new WebReference.OAWebService();
           var a = wc.getNoticeList("qinqiao", "qinqiao");
           textBoxResult.Text = a;
           textBoxResult.Text += "\t\r\n------------------------------------------------";
           var b = wc.getTaskList("qinqiao","qinqiao");
           textBoxResult.Text += b;
        }
    }
}
