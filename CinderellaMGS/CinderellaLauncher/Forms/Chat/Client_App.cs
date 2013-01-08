using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinderellaLauncher;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Runtime.InteropServices;

// http://www.geekpedia.com/tutorial239_Csharp-Chat-Part-1---Building-the-Chat-Client.html

namespace CinderellaLauncher
{
    public partial class Client_App : Form
    {

        [DllImport("user32.dll")]
        static extern Int32 FlashWindowEx(ref FLASHWINFO pwfi);
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public Int32 dwFlags;
            public UInt32 uCount;
            public Int32 dwTimeout;
        }

        // stop flashing

        const int FLASHW_STOP = 0;



        // flash the window title 

        const int FLASHW_CAPTION = 1;



        // flash the taskbar button

        const int FLASHW_TRAY = 2;



        // 1 | 2

        const int FLASHW_ALL = 3;



        // flash continuously 

        const int FLASHW_TIMER = 4;



        // flash until the window comes to the foreground 

        const int FLASHW_TIMERNOFG = 12;



        // Will hold the user name
        private string UserName = "Unknown";
        private StreamWriter swSender;
        private StreamReader srReceiver;
        private TcpClient tcpServer;
        
        // Needed to update the form with messages from another thread
        private delegate void UpdateLogCallback(string strMessage);

        // Needed to set the form to a "disconnected" state from another thread
        private delegate void CloseConnectionCallback(string strReason);
        private Thread thrMessaging;
        private IPAddress ipAddr;
        private bool Connected;

        private void connectButton_Click(object sender, EventArgs e)
        {
            // If we are not currently connected but awaiting to connect
            if (Connected == false)
            {
                if (txtUsername.Text != "")
                    // Initialize the connection
                    InitializeConnection();
                else
                    MessageBox.Show("Enter a username");
            }
            else 
            {
                // We are connected, thus disconnect
                CloseConnection("Disconnected at user's request.");
            }
        }

        private void InitializeConnection()
        {

            try
            {
                // Parse the IP address from the TextBox into an IPAddress object
                ipAddr = IPAddress.Parse(txtIP.Text);

                // Start a new TCP connections to the chat server
                tcpServer = new TcpClient();
                tcpServer.Connect(ipAddr, 1986);

                // Helps us track whether we're connected or not
                Connected = true;

                // Prepare the form
                UserName = txtUsername.Text;

                // Disable and enable the appropriate fields
                txtIP.Enabled = false;
                txtUsername.Enabled = false;
                txtMessage.Enabled = true;
                sendButton.Enabled = true;
                connectButton.Text = "Disconnect";

                // Send the desired username to the server
                swSender = new StreamWriter(tcpServer.GetStream());
                swSender.WriteLine(txtUsername.Text);
                swSender.Flush();

                // Start the thread for receiving messages and further communication
                thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
                thrMessaging.Start();
            }
            catch(SocketException error)
            {
                MessageBox.Show("Unable to connect. Check the IP address.", "Cannot Connect");
            }
        }

        private void ReceiveMessages()
        {
           
             // Receive the response from the server
            srReceiver = new StreamReader(tcpServer.GetStream());
           
                // If the first character of the response is 1, connection was successful
           
            
               string ConResponse = srReceiver.ReadLine();
               if (srReceiver.ReadLine() == null)
               {
                   try
                   {
                       Thread.CurrentThread.Abort();
                       MessageBox.Show(Thread.CurrentThread.ToString());
                       Client_App.ActiveForm.Dispose();
                       // this.Close();
                       Client_App.ActiveForm.Close();
                   }
                   catch (InvalidOperationException tmc)
                   {
                       MessageBox.Show(tmc.ToString());
                   }
                   catch (ThreadAbortException haha)
                   {
                       MessageBox.Show(haha.ToString());
                       
                   }
               }
          
            
      
            // If the first character is a 1, connection was successful
            if (ConResponse[0] == '1')
            {
                try
                {
                    // Update the form to tell it we are now connected
                    this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "Connected Successfully!" });
                }
                catch (ObjectDisposedException nope)
                {
                }
            }
            else
            {
                // If the first character is not a 1 (probably a 0), the connection was unsuccessful
                string Reason = "Not Connected: ";

                // Extract the reason out of the response message. The reason starts at the 3rd character
                Reason += ConResponse.Substring(2, ConResponse.Length - 2);

                // Update the form with the reason why we couldn't connect
                this.Invoke(new CloseConnectionCallback(this.CloseConnection), new object[] { Reason });
                
                // Exit the method
                return;
            }

            try
            {
                // While we are successfully connected, read incoming lines from the server
                while (Connected && thrMessaging != null)
                {
                    // Show the messages in the log TextBox
                    this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { srReceiver.ReadLine() });
                }
            }
            catch(Exception error)
            {
             //   CloseConnection("Closing");
            }
        }

        private void UpdateLog(string strMessage)
        {
            // Append text also scrolls the TextBox to the bottom each time
            txtLog.AppendText(strMessage + "\r\n");
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            SendMessage();          //use when the button is clicked to send message
            txtMessage.Focus();
        }

        // But we also want to send the message once Enter is pressed
        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the key is entered to send message
            if (e.KeyChar == (char)13)
            {
                SendMessage();
            }
        }

        // Sends the message typed in to the server
        private void SendMessage()
        {
            if (txtMessage.Lines.Length >= 1)
            {
                swSender.WriteLine(txtMessage.Text);
                swSender.Flush();
                txtMessage.Lines = null;
            }

            txtMessage.Text = "";
        }

        // Closes a current connection

        private void CloseConnection(string Reason)
        {
            // Show the reason why the connection is ending
            //txtLog.AppendText(Reason + "\r\n");
            txtLog.Text = "Disconnected.\r\n";
            // Enable and disable the appropriate controls on the form
            txtIP.Enabled = true;
            txtUsername.Enabled = true;
            txtMessage.Enabled = false;
            sendButton.Enabled = false;
            connectButton.Text = "Connect";

            // Close the objects
            Connected = false;
            swSender.Close();
            srReceiver.Close();
            tcpServer.Close();
        }

        public Client_App()
        {
            //remember to disconnect first
            //Application.ApplicationExit += new EventHandler(OnApplicationExit);
            InitializeComponent();
        }

        // The event handler for application exit
        public void OnApplicationExit(object sender, EventArgs e)
        {
            if (Connected == true)
            {
                // Closes the connections, streams, etc.
                Connected = false;
                swSender.Close();
                srReceiver.Close();
                tcpServer.Close();
            }

        }

        private void txtIP_TextChanged(object sender, EventArgs e)
        {

        }

        private void Client_App_FormClosing(object sender, FormClosingEventArgs e)
        {
            Thread.CurrentThread.Abort();
           // MessageBox.Show(Thread.CurrentThread.ToString());
            Client_App.ActiveForm.Dispose();
            // this.Close();
            Client_App.ActiveForm.Close();
           
            if (Connected == false && txtUsername.Equals(""))
            {
                txtUsername.Text = "administrator";
                InitializeConnection();
                string theReason = "user forcibly quit";
                CloseConnection(theReason);

            }
           else if (Connected == false)
            {
                InitializeConnection();
                string myOtherReason = "Disconnecting";
                CloseConnection(myOtherReason);
            }
            else
            {
                string myReason = "Disconnecting";
                CloseConnection(myReason);
            }
          //  thrMessaging.Abort();
           // connectButton.PerformClick();
          
        //    this.Close();*/
        }

        private void Client_App_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void Client_App_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Flash(false);
            }
            else
            {
                Flash(true);
            }
        }

        private void Flash(bool stoppingCondition)
        {
            FLASHWINFO flashy = new FLASHWINFO();

            flashy.cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(FLASHWINFO)));
            flashy.hwnd = Handle;

            if (!stoppingCondition)
            {
                flashy.dwFlags = 2;
            }
            else
            {
                flashy.dwFlags = 0;
            }
            flashy.uCount = UInt32.MaxValue;

            FlashWindowEx(ref flashy);
        }

       
    }
}
