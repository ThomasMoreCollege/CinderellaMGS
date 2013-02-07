using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinderellaLauncher;

//Add the following using statement that will correspond to networking
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using System.Runtime.InteropServices;

//cite references
// http://www.geekpedia.com/tutorial239_Csharp-Chat-Part-1---Building-the-Chat-Client.html
// http://social.msdn.microsoft.com/Forums/en-US/csharpgeneral/thread/8fb6504a-f9fc-4ace-b813-a85712928422/

namespace CinderellaLauncher
{
    public partial class ClientApp : Form
    {
        /// <summary>
        /// Prior to the actual chat function and its implementation 
        /// (which starts with the private string variable),
        /// the chat form is minimized when it is first prompted as a thread.
        /// The 'ClientApp_Resize' method manages the form when it resize, which
        /// implements the 'Flash' method as it executes.
        ///  
        /// Precondition: None
        /// Postcondition: The chat form flashes when it is minimized 
        /// </summary>
        /// <param name="pwfi"></param>
        /// <returns></returns>

        [DllImport("user32.dll")]
        static extern Int32 FlashWindowEx(ref FLASHWINFO pwfi);
        [StructLayout(LayoutKind.Sequential)]

        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public Int32 dwFlags;
            public UInt32 unCount;
            public Int32 dwTimeout;
        }

        //stop flashing
        const int flashStop = 0;

        //flash the window title
        const int flashCaption = 1;

        //flash taskbar button
        const int flashTray = 2;

        //flash all
        const int flashAll = 3;

        //flash continuously
        const int flashTimer = 4;

        //flash untill windows comes to the foreground
        const int flashForeground = 12;

        public ClientApp()
        {
            //on application exit, don't forget to disconnect first
            Application.ApplicationExit += new EventHandler(onAppExit);
            InitializeComponent();
        }

        private void ClientApp_Resize(object sender, EventArgs e)
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

        private void Flash(bool stop)
        {
            FLASHWINFO fw = new FLASHWINFO();
            fw.cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(FLASHWINFO)));
            fw.hwnd = Handle;
            if (!stop)
                fw.dwFlags = 2;
            else
                fw.dwFlags = 0;
            fw.unCount = UInt32.MaxValue;

            FlashWindowEx(ref fw);

        }

        //add the private objects that will be used in the class
        private string chatName = "unknown";
        private StreamWriter write;
        private StreamReader read;
        private TcpClient tcpServer;

        //update the form with message from another thread
        private delegate void UpdateLogCallback(string strMessage);

        //set the form to a disconnected state from another thread
        private delegate void closeConnectionCallback(string reason);

        //create private thread
        private Thread threadMessage;

        //create private IP address
        private IPAddress ipAddress;

        //ensure that it is connected
        private bool connect;

        //now since they are declare, they are now ready for use
        //start with the connect button from the form
        private void connectButton_Click(object sender, EventArgs e)
        {
            //if the connection is false, initialize the connection
            //otherwise, close the connection
            if (connect == false)
            {
                if (txtChatName.Text != "")
                {
                    //initialize the connection
                    InitializeConnection();
                }
                else
                {
                    MessageBox.Show("Enter your chat name");
                }

            }
            else
            {
                //shut the connection down after being connected
                closeConnection("User has disconnected");
            }
        }

        //create the initialized connection as a method
        private void InitializeConnection()
        {
            //implement the try-catch block to grab any exception
            try
            {
                //parse IP address from the text box into an IP address object
                ipAddress = IPAddress.Parse(txtIP.Text);

                //start new TCP connection to the server
                tcpServer = new TcpClient();
                tcpServer.Connect(ipAddress, 1986);

                //track whether or not it is connected
                connect = true;

                //prepare the form
                chatName = txtChatName.Text;

                //disable and enable the appropiate fields
                txtIP.Enabled = false;
                txtChatName.Enabled = false;
                txtMessage.Enabled = true;
                sendButton.Enabled = true;
                connectButton.Text = "Disconnect";

                //send username to server
                write = new StreamWriter(tcpServer.GetStream());
                write.WriteLine(txtChatName.Text);
                write.Flush();

                //begin a thread that will recieve message and to start a conversation
                threadMessage = new Thread(new ThreadStart(recieveMessage));
                threadMessage.Start();
            }
            catch (SocketException error)
            {
                MessageBox.Show("Unable to connect. Check the IP address", "Cannot Connect");
            }
        }

        /// <summary>
        ///Create the recieveMessage method. This method is implemented for 
        ///the chat user to recieve messages.
        /// </summary>
        private void recieveMessage()
        {
            read = new StreamReader(tcpServer.GetStream());

            //if the first character has occured, connection is successful
            string response = read.ReadLine();

            if (read.ReadLine() == null)
            {
                //add try-catch block, searching for any error exception
                try
                {
                    Thread.CurrentThread.Abort();
                    MessageBox.Show(Thread.CurrentThread.ToString());
                    ClientApp.ActiveForm.Close(); 
                }
                catch (InvalidOperationException except)
                {
                    MessageBox.Show(except.ToString());
                }
                catch (ThreadAbortException abort)
                {
                    MessageBox.Show(abort.ToString());
                }
            }

            //if character is 1, connection is successful
            if (response[0] == '1')
            {
                try
                {
                    //update the form to inform the log that it is connected
                    this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "Connection Success!" });
                }
                catch (ObjectDisposedException disposeException)
                {
                    MessageBox.Show(disposeException.ToString());
                }
            }
            else
            {
                //connection fails
                string reason = "Connection Failed!";

                //extract the reason out of the response message
                reason += response.Substring(2, response.Length - 2);

                //update the form with the reason why it's not connected
                this.Invoke(new closeConnectionCallback(this.closeConnection), new object[] { reason });
                return;
            }

            try
            {
                //while the connection is valid
                while (connect && threadMessage != null)
                {
                    //show message in log text box
                    this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { read.ReadLine() });
                }
            }
            catch (Exception error)
            {
                closeConnection("Closing");
            }


        }

        //create the UpdateLog method
        private void UpdateLog(string message)
        {
            //append text so that it scrolls the textbox to the bottom
            txtLog.AppendText(message + "\r\n");
        }

        //switch to the send button and its method
        private void sendButton_Click(object sender, EventArgs e)
        {
            sendMessage();  //this will be the sending message method will execute
            txtMessage.Focus();
        }

        //send the message after pressing the enter key
        private void txtMessage_KeyPress(object sender, KeyPressEventArgs pressEnter)
        {
            if (pressEnter.KeyChar == (char)13)
            {
                sendMessage();
                txtMessage.Focus();
            }
        }

        //create the sendMessage
        private void sendMessage()
        {
            if (txtMessage.Lines.Length >= 1)
            {
                write.WriteLine(txtMessage.Text);
                write.Flush();
                txtMessage.Lines = null;
            }

            txtMessage.Text = "";
        }

        //create the close connection method
        private void closeConnection(string reason)
        {
            //show the implementation on reason that the connection is ending
            txtLog.Text = "Disconnected.\r\n";

            //enable and disable the proper controls
            txtIP.Enabled = true;
            txtChatName.Enabled = true;
            txtMessage.Enabled = false;
            sendButton.Enabled = false;
            connectButton.Text = "Connect";
            connect = false;
            write.Close();
            read.Close();
            tcpServer.Close();
        }

        public void onAppExit(object sender, EventArgs e)
        {
            if (connect == true)
            {
                //close all connections
                connect = false;
                write.Close();
                read.Close();
                tcpServer.Close();
            }
        }

        /// <summary>
        /// The method below indicates that the form close.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientApp_FormClosing(object sender, FormClosedEventArgs e)
        {
            Thread.CurrentThread.Abort();
            ClientApp.ActiveForm.Dispose();
            ClientApp.ActiveForm.Close();
        }

        //this focus on the chat name text box once the chat is launched.
        private void ClientApp_Load(object sender, EventArgs e)
        {
            txtChatName.Focus();
        }
        //This will close the connection on form close
        private void ClientApp_FormClosing(Object sender, FormClosingEventArgs e)
        {
            closeConnection("");
        }
    }
  }

