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

        public VolunteerClass getValofLastNode()
        {
            return rear.Volunteer;
        }

        public VolunteerClass getValofFrontNode()
        {
            return front.Volunteer;
        }

        public int getNumItems()
        {
            return numItems;
        }

        // Queue operations
        public void enqueue(VolunteerClass val)
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

        public void enqueueToFront(VolunteerClass vol)
        {

            if (isEmpty())
            {
                enqueue(vol);
            }
            else
            {
                VolunteerNode newFront;
                newFront = new VolunteerNode();
                newFront.Volunteer = vol;
                newFront.Next = front;
                front = newFront;

                numItems++;
            }
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
        public bool selectiveDequeue(int VolID)
        {
            if (isEmpty())
            {
                return false;
            }
            else
            {
                // Cursor node to point to node with target ID
                VolunteerNode cursor = new VolunteerNode();

                cursor = front;

                // Cursor node to points to node in front of the cursor
                VolunteerNode previousCursor = new VolunteerNode();

                previousCursor = null;

                //Search for a cinderella with the same ID 
                while (cursor.Volunteer.VolunteerID != VolID)
                {
                    if (cursor == rear)
                    {
                        break;
                    }
                    previousCursor = cursor;
                    cursor = cursor.Next;
                }

                //If id is match remove the cinderella from the queue and reasign pointers accordingly
                if (cursor.Volunteer.VolunteerID == VolID)
                {
                    //If front cinderella matches ID just call dequeue
                    if (cursor == front)
                    {
                        dequeue();
                    }

                    else
                    {
                        //If matching cinderella is the last one in the queue reassign the rear pointer
                        if (cursor == rear)
                        {
                            rear = previousCursor;
                            previousCursor.Next = null;
                        }
                        //Otherwise rearrange the pointer of the previous cinderella to the next possible cinderella
                        else
                        {
                            previousCursor.Next = cursor.Next;
                        }

                        //Remove cinderella from queue
                        cursor = null;

                        // Update numItems.
                        numItems--;
                    }
                    return true;
                }
                else
                {
                    return false;
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