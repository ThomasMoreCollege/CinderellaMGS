using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CinderellaQueue
/// </summary>
namespace CinderellaQueue
{
	class CinderellaNode
	{
    private int value;       // Value in a node
    private CinderellaNode next; // Pointer to the next node


       private CinderellaNode _front;  // The front of the queue
       private CinderellaNode _rear;   // The rear of the queue
       private int _numItems;      // Number of items in the queue

       // Constructor
       public CinderellaNode()
       {
           _front = null;
           _rear = null;
           _numItems = 0;
       }

       // Destructor
       public ~CinderellaNode()
       {
           clear();
       }
        
        public int getNodesLeft(){
            return _numItems;
        }

       // Queue operations
       public void enqueue(int val)
       {
           CinderellaNode newNode;

           // Create a new node and store num there.
           newNode = new CinderellaNode();
           newNode.value = val;
           newNode.next = null;

           // Adjust front and rear as necessary.
           if (isEmpty())
           {
              _front = newNode;
              _rear = newNode;
           }
           else
           {
              _rear.next = newNode;
              _rear = newNode;
           }

           // Update numItems.
           _numItems++;
       }
       public void dequeue()
       {

           if (isEmpty())
           {
               //cout << "The queue is empty.\n";
           }
           else
           {
               // Save the front node value in num.
               //val = _front.value;

               // Remove the front node and delete it.
               CinderellaNode temp;
               temp = new CinderellaNode();   
               temp = _front;
               _front = _front.next;
               temp = null;   //<------Come Back to this later 

               // Update numItems.
               _numItems--;
           }
       }
       public bool isEmpty()
       {
           bool status;

           if (_numItems > 0)
               status = false;
           else
               status = true;
           return status;
       }
       public void clear()
       { 
           while (!isEmpty())
               dequeue();
       }

	}
}