using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CinderellaQueue
/// </summary>
namespace CinderellaQueue
{
	public class CinderellaNode
	{
        private int _number;       // Value in a node
        private CinderellaNode _next; // Pointer to the next node

       // Constructor
       public CinderellaNode()
       {
           _number = 0;
           _next = null;
       }
       public int Number
       {
           get { return _number; }
           set { _number = value; }
       }
       public CinderellaNode Next
       {
           get { return _next; }
           set { _next = value; }
       }

	}
}