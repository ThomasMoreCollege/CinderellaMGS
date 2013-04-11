using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;

// Code for this method found at:
//http://www.geekpedia.com/tutorial240_Csharp-Chat-Part-2---Building-the-Chat-Client.html
namespace Chat_Server
{
    /// <summary>
    /// This controls the chat connection, when users are attempting to chat on the form. It also ensures that
    /// the connections is running properly.
    /// Precondition: Connection is running property
    /// Postcondition: None.
    /// </summary>
    class ChatConnection                    // class declaration for ChatConnection
    {
        TcpClient tcpClient; // Provides client connections for TCP network services. This is the thread that is used to connect the client/user to the Chat Server.
        
        private Thread thrSender;            //This is the thread that will send information to the client/user. 
        private StreamReader srReceiver;     //This is the thread that listens for attempted connections to the Chat Server.
        private StreamWriter swSender;       //This takes the network stream as a constructor parameter and let's users know whether or not they have been successfully connected to the server. 
        private string currUser;             //Shows the Current User/Users that are connected to the Chat Server.
        private string strResponse;          //Parses the responses and splits the parts into headers and body.

        public ChatConnection(TcpClient tcpCon)
        {
            tcpClient = tcpCon;
            // The thread that accepts the client and awaits messages
            thrSender = new Thread(AcceptClient);
            // The thread calls the AcceptClient() method
            thrSender.Start();
        }

        private void CloseConnection()
        {
            // Close the currently open objects
            tcpClient.Close();
            srReceiver.Close();
            swSender.Close();
        }

        // Occures when a new client is accepted
        private void AcceptClient()
        {
            srReceiver = new System.IO.StreamReader(tcpClient.GetStream());
            swSender = new System.IO.StreamWriter(tcpClient.GetStream());

            // Read the account information from the client
            currUser = srReceiver.ReadLine();

            // We got a response from the client
            if (currUser != "")
            {
                // Store the user name in the hash table
                if (ChatServer.htUsers.Contains(currUser) == true)
                {
                    // 0 means not connected
                    swSender.WriteLine("0|This username already exists.");
                    swSender.Flush();
                    CloseConnection();
                    return;
                }
                else if (currUser == "Administrator")
                {
                    // 0 means not connected
                    swSender.WriteLine("0|This username is reserved.");
                    swSender.Flush();
                    CloseConnection();
                    return;
                }
                else
                {
                    // 1 means connected successfully
                    swSender.WriteLine("1");
                    swSender.Flush();

                    // Add the user to the hash tables and start listening for messages from him
                    ChatServer.AddUser(tcpClient, currUser);
                }
            }
            else
            {
                CloseConnection();
                return;
            }

            try
            {
                // Keep waiting for a message from the user
                while ((strResponse = srReceiver.ReadLine()) != "")
                {
                    // If it's invalid, remove the user
                    if (strResponse == null)
                    {
                        ChatServer.RemoveUser(tcpClient);
                    }
                    else
                    {
                        // Otherwise send the message to all the other users
                        ChatServer.SendMessage(currUser, strResponse);
                    }
                }
            }
            catch
            {
                // If anything went wrong with this user, disconnect him
                ChatServer.RemoveUser(tcpClient);
            }
        }
    }

}
