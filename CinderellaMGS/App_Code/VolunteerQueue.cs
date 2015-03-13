using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CinderellaQueue
/// </summary>
/// 
namespace VolunteerQueue
{
    public class VolunteerQueue
    {
        VolunteerNode front;
        VolunteerNode rear;
        int numItems;

        public VolunteerQueue()
        {
            front = null;
            rear = null;
            numItems = 0;
        }
        ~VolunteerQueue()
        {
            clear();
        }

        public int getValofLastNode()
        {
            return rear.Volunteer;
        }

        public int getNumItems()
        {
            return numItems;
        }

        // Queue operations
        public void enqueue(VolunteerNode val)
        {
            VolunteerNode newNode;

            // Create a new node and store num there.
            newNode = new VolunteerNode();
            newNode.Volunteer = val;
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
                VolunteerNode temp;
                temp = new VolunteerNode();
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