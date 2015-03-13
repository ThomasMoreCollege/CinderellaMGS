using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CinderellaQueue
/// </summary>
/// 
namespace CinderellaQueue
{
    public class CinderellaQueue
    {
        CinderellaNode front;
        CinderellaNode rear;
        int numItems;

        public CinderellaQueue()
        {
            front = null;
            rear = null;
            numItems = 0;
        }
        ~CinderellaQueue()
        {
           clear();
        }

        public int getValofLastNode()
        {
            return rear.Cinderella;
        }

        public int getNumItems()
        {
            return numItems;
        }

        // Queue operations
        public void enqueue(int val)
        {
            CinderellaNode newNode;

            // Create a new node and store num there.
            newNode = new CinderellaNode();
            newNode.Cinderella = val;
            newNode.Next = null;

            // Adjust front and rear as necessary.
            if (isEmpty())
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }

            // Update numItems.
            numItems++;
        }
        public void dequeue()
        {

            if (isEmpty())
            {
                //cout << "The queue is empty.\n";
            }
            else
            {

                // Remove the front node and delete it.
                CinderellaNode temp;
                temp = new CinderellaNode();
                temp = front;
                front = front.Next;
                temp = null;   //<------Come Back to this later 

                // Update numItems.
                numItems--;

                if (numItems == 0)
                {
                    rear = null;
                }
            }
        }
        public bool isEmpty()
        {
            bool status;

            if (numItems > 0)
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