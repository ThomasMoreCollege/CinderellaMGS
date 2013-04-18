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
    /// Precondition: The connection is running properly.
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
            tcpClient = tcpCon; // This thread accepts the client and waits for messages. 

            thrSender = new Thread(AcceptClient); // This thread calls the AcceptClient() method.

            thrSender.Start(); // When this thread starts, it will begin sending information to the client. 
        }

        public void CloseConnection() //Closes the Connection Objects below. 
        {
            
            tcpClient.Close();      //Closes tcpClient.
            srReceiver.Close();     //Closes srReceiver.
            swSender.Close();       //Closes swSender. 
        }

        
        private void AcceptClient()   //The "private void AQcceptClient() occurs when a new client is accepted. 
        {
            srReceiver = new System.IO.StreamReader(tcpClient.GetStream());     //Gets and reads the network stream for tcpClient.
            swSender = new System.IO.StreamWriter(tcpClient.GetStream());       //Gets and writes the network stream for tcpClient.    


            currUser = srReceiver.ReadLine();           //This reads the account information from the client. 

            
            if (currUser != "") //This line states that we have gotten a response from the client. 
            {

                //This stores a user name in the hash table.
                if (ChatServer.htUsers.Contains(currUser) == true) 
                {
                    // '0' indicates that we are not connected to Chat. 
                    swSender.WriteLine("0|This username already exists."); //Message that is thrown to the user if a particular username already exists. 
                    swSender.Flush(); //Flushes the above information as long as that username does not already exist. 
                    CloseConnection();  //Closes the current connection. 
                    return;
                }
                else if (currUser == "Administrator")
                {
                    // '0' indicates that we are not connected to Chat. 
                    swSender.WriteLine("0|This username is reserved.");
                    swSender.Flush();
                    CloseConnection();
                    return;
                }
                else
                {
                    // '1' indicates that we have been successfully connected to Chat. 
                    swSender.WriteLine("1"); //Writes the line that states we have been successfully connected to Chat. 
                    swSender.Flush(); //Flushes the above information. 

                  
                    ChatServer.AddUser(tcpClient, currUser);  // Adds the user to the hash tables and begins listening for messages from that user.     
                }
            }
            else
            {
                CloseConnection(); //Closes the connection. 
                return;
            }

            try
            {
               
                while ((strResponse = srReceiver.ReadLine()) != "")  // Continues waiting for messages from the user. 
                {

                    if (strResponse == null) // If the strResponse is invalid, remove the user.
                    {
                        ChatServer.RemoveUser(tcpClient); //This line tells the Chat Server to remove the user from the tcpClient. 
                    }
                    else // Otherwise send the message to all of the other current users.
                    {
                        
                        ChatServer.SendMessage(currUser, strResponse); //Sends the message to all of the other current users. 
                    }
                }
            }
            catch
            {
                // If any errors of any kind occurred with this user, disconnect him/her from the tcpClient. 
                ChatServer.RemoveUser(tcpClient);
            }
        }
    }

}
