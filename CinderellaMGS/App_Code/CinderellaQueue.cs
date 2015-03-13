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

        public CinderellaClass getValofLastNode()
        {
            return rear.Cinderella;
        }

        public CinderellaClass getValofFrontNode()
        {
            return front.Cinderella;
        }

        public int getNumItems()
        {
            return numItems;
        }

        // Queue operations
        public void enqueue(CinderellaClass val)
        {
            CinderellaNode newNode;

            // Create a new node and store num there.
            newNode = new CinderellaNode();
            newNode.Cinderella = val;
            newNode.Next = null;

            // Setting newNode as front and rear if no nodes are in queue
            if (isEmpty())
            {
                front = newNode;
                rear = newNode;
            }
            else
            {
                // Cursor node to point to node in front of target position
                CinderellaNode cursor = new CinderellaNode();

                cursor = front;

                // Checking if the new Node should be front
                if (cursor.Cinderella.Priority > newNode.Cinderella.Priority)
                {
                    newNode.Next = cursor;
                    front = newNode;
                }
                else
                {
                    // Setting newNode as the rear if cursor was the last node
                    if (cursor == rear)
                    {
                    }
                    else
                    {

                        while (cursor.Next.Cinderella.Priority <= newNode.Cinderella.Priority)
                        {
                            cursor = cursor.Next;

                            // Setting the cursor to its NEXT node or breaking if cursor is rear
                            if (cursor == rear)
                            {
                                break;
                            }
                            
                        };
                    }

                    // Setting newNode as the cursor's next, and newNode's next as cursor's previous next
                    CinderellaNode temp = new CinderellaNode();
                    temp = cursor.Next;
                    cursor.Next = newNode;
                    newNode.Next = temp;

                    // Setting newNode as the rear if cursor was the last node
                    if (cursor == rear)
                    {
                        rear = newNode;
                    }
                    
                }
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