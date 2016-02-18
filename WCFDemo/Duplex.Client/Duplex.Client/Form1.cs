using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Duplex.Client
{
    public partial class Form1 : Form, ReportService.IReportServiceCallback
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InstanceContext instanceContext = new InstanceContext(this);
            ReportService.ReportServiceClient client =
                new ReportService.ReportServiceClient(instanceContext);

            client.ProcessReport();
        }
        public void Progress(int percentageComplete)
        {
            textBox1.Text = percentageComplete.ToString() + " % completed";
        }
    }
}
