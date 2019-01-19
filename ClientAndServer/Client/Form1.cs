using SimpleTCP;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SimpleTcpClient client;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Click to connect button and this button will be enable.
            btnConnect.Enabled = false;
            //We take host and port.We connected with Connect() method.
            client.Connect(txtHost.Text, Convert.ToInt32(txtPort.Text));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //We must always description to  new TcpClient because we will call its object below.
            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8; //Unicode Transformation Format..We encode the received data
            client.DataReceived += Client_DataReceived; //And we send the received data DataReceived object.
        }

        private void Client_DataReceived(object sender, SimpleTCP.Message e)
        {
            // A delegate is a reference type variable that holds the reference to a method. The reference can be changed at runtime.
           //Delegates are especially used for implementing events and the call - back methods.
           //And delegate can use invoke.
                        txtStatus.Invoke((MethodInvoker)delegate(){
                txtStatus.Text += e.MessageString;

            });
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ///Write recieved reply from server to console.(WriteLine)
            ///As long as the console is open, every message you type will be sent to the server.(WriteLineAndGetReply)
            client.WriteLineAndGetReply(txtMessage.Text, TimeSpan.FromSeconds(3));
          

        }
    }
}
