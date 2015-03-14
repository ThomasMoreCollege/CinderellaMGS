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

        public void enqueueToFront(CinderellaClass cind)
        {
            cind.Priority = 1;

            if (isEmpty())
            {
                priorityEnqueue(cind);
            }
            else
            {
                CinderellaNode newFront;
                newFront = new CinderellaNode();
                newFront.Cinderella = cind;
                newFront.Next = front;
                front = newFront;

                numItems++;
            }
        }

        // Queue operations
        public void priorityEnqueue(CinderellaClass val)
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
                            
                        }
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
                
            }
            else
            {

                // Remove the front node.
                CinderellaNode temp;
                temp = new CinderellaNode();
                temp = front;
                front = front.Next;
                temp = null;   //<------Come Back to this later 

                // Update numItems.
                numItems--;

                if (numItems == 0)
                {
                    front = null;
                    rear = null;
                }
            }
        }
        public bool selectiveDequeue(int CindID)
        {
            if (isEmpty())
            {
                return false;
            }
            else
            {
                // Cursor node to point to node with target ID
                CinderellaNode cursor = new CinderellaNode();

                cursor = front;

                // Cursor node to points to node in front of the cursor
                CinderellaNode previousCursor = new CinderellaNode();

                previousCursor = null;

                //Search for a cinderella with the same ID 
                while (cursor.Cinderella.CinderellaID != CindID)
                {
                    if (cursor == rear)
                    {
                        break;
                    }
                    previousCursor = cursor;
                    cursor = cursor.Next;
                }

                //If id is match remove the cinderella from the queue and reasign pointers accordingly
                if (cursor.Cinderella.CinderellaID == CindID)
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

        public void recalibratePriority()
        {
            if (isEmpty())
            {
                //Do Nothing 
            }
            else
            {
                // Cursor node to point to node with target ID
                CinderellaNode cursor = new CinderellaNode();

                cursor = front;

                for (int i = 0; i < numItems; i++)
                {
                    //Temp used to check priority
                    CinderellaNode temp;
                    temp = new CinderellaNode();
                    temp = cursor;

                    if (cursor != rear)
                    {
                        cursor = cursor.Next;
                    }

                    //If cinderella is earlly...
                    if (temp.Cinderella.Priority == 2)
                    {
                        //Time window is subject change
                        double maxTimeWindow = 15.0;

                        //If the cinderella is now within her time window...
                        if (temp.Cinderella.InScheduledTimeWindow(maxTimeWindow))
                        {
                            //Store the cinderellas' ID before removing them from the queue
                            int targetCinderellaID = temp.Cinderella.CinderellaID;

                            //Selectively dequeue them
                            selectiveDequeue(targetCinderellaID);

                            //Recreate instance of the cinderella that has been removed from the queue
                            CinderellaClass targetedCinderella = new CinderellaClass(targetCinderellaID);

                            //Set the cinderellas' priority to 1
                            targetedCinderella.Priority = 1;

                            //Insert the cinderella back into the queue
                            priorityEnqueue(targetedCinderella);
                        }
                    }
                    else if (temp.Cinderella.Priority == 3)
                    {
                        double maxWaitTime = 30.0;

                        if (temp.Cinderella.WaitingForXTime(maxWaitTime))
                        {
                            //Store the cinderellas' ID before removing them from the queue
                            int targetCinderellaID = temp.Cinderella.CinderellaID;

                            //Selectively dequeue them
                            selectiveDequeue(targetCinderellaID);

                            //Recreate instance of the cinderella that has been removed from the queue
                            CinderellaClass targetedCinderella = new CinderellaClass(targetCinderellaID);

                            //Set the cinderellas' priority to 1
                            targetedCinderella.Priority = 1;

                            //Insert the cinderella back into the queue
                            priorityEnqueue(targetedCinderella);
                        }
                    }
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