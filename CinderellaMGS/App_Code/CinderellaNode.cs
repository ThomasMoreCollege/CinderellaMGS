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
        private CinderellaClass _cinderella;       // Value in a node
        private CinderellaNode _next; // Pointer to the next node

       // Constructor
       public CinderellaNode()
       {
           _cinderella = null;
           _next = null;
       }
       public CinderellaClass Cinderella
       {
           get { return _cinderella; }
           set { _cinderella = value; }
       }
       public CinderellaNode Next
       {
           get { return _next; }
           set { _next = value; }
       }

	}
}