using Grpc.Net.Client;
using gRPC_Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace gRPC_Client
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7002");

            var client = new Calculator.CalculatorClient(channel);
            var request = new MultiplyRequest
            {
                Number1 = (int)numericUpDown1.Value,
                Number2 = (int)numericUpDown2.Value
            };

            var response = client.Multiply(request);

            label1.Text = response.Result.ToString();

        }
    }
}
