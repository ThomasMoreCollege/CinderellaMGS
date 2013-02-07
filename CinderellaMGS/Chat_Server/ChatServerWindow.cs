using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Chat_Server
{

    /// <summary>
    /// The chatserver windows form is designed for chat client user to connect to
    /// this server to retrieve for connection. There are other chat server files that
    /// also contribute to this form as well (ChatConnection.cs and ChatServer.cs)
    /// 
    /// Precondition: Chat server monitors for any connections awaiting.
    /// 
    /// Postcondition: If chat server monitors for any connection that awaits, then the
    /// log will update as it monitors the current connection.
    /// </summary>
    public partial class ChatServerWindow : Form
    {
        private delegate void UpdateStatusCallback(string strMessage);

        private bool isListening = false;
               
        // Parse the server's IP address out of the TextBox
        IPAddress ipAddr; 
        
        // Create a new instance of the ChatServer object
        ChatServer mainServer;
        
        public ChatServerWindow()
        {
            InitializeComponent();
        }

        // Code for this method found at:
        // http://stackoverflow.com/questions/1069103/how-to-get-my-own-ip-address-in-c
        //http://www.geekpedia.com/tutorial240_Csharp-Chat-Part-2---Building-the-Chat-Client.html
        private string getMyIP()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        /// <summary>
        /// Below is where the connection button for the
        /// chat server will take place once the button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listenButton_Click(object sender, EventArgs e)
        {
            try
            {

                isListening = !isListening;

                if (isListening)
                {
                    ipAddr = IPAddress.Parse(txtIp.Text);
                    mainServer = new ChatServer(ipAddr);

                    // Hook the StatusChanged event handler to mainServer_StatusChanged
                    ChatServer.StatusChanged += new StatusChangedEventHandler(mainServer_StatusChanged);
                    
                    // Start listening for connections
                    mainServer.StartListening();

                    // Show that we started to listen for connections
                    txtIp.Enabled = true;
                    txtLog.Enabled = true;
                    txtLog.AppendText("Monitoring for connections...\n\n");     //checks for connection
                    listenButton.Text = "Stop Listening";                       //changes once the button is clicked
                }

                else if(listenButton.Text == "Stop Listening")                  //vice versa
                {
                    txtIp.Enabled = false;
                    txtLog.Enabled = false;
                    txtLog.AppendText("...No longer listening\n\n");            //signals that it is no longer connecting
                    listenButton.Text = "Start Listening";
                    ChatServerWindow.ActiveForm.Dispose();                      //closes the form
                    ChatServerWindow.ActiveForm.Close();                        //closes the form
                }

                //else if (listenButton.Text == "Start Listening")                //basically repeats the process by reconnecting.
                //{

                //    txtIp.Enabled = true;
                //    txtLog.Enabled = true;
                //    txtLog.AppendText("Monitoring for connections...\n\n");
                //    listenButton.Text = "Stop Listening";
                //}
            }
            catch (Exception error)
            {
                
            }
        }

        public void mainServer_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            // Call the method that updates the form
            this.Invoke(new UpdateStatusCallback(this.UpdateStatus), new object[] { e.EventMessage });
        }
        private void UpdateStatus(string strMessage)
        {
            // Updates the log with the message
            txtLog.AppendText(strMessage + "\r\n");
        }

    }
}
