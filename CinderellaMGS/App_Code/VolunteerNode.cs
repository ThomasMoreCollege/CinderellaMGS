using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CinderellaQueue
/// </summary>
namespace VolunteerQueue
{
	public class VolunteerNode
	{
        private VolunteerClass _volunteer;  // Current Volunteer in node
        private VolunteerNode _next; // Pointer to the next node

       // Constructor
        public VolunteerNode()
       {
           _volunteer = null;
           _next = null;
       }
        //Volunteer property
        public VolunteerClass Volunteer
       {
           get { return _volunteer; }
           set { _volunteer = value; }
       }
       //Next Property
       public VolunteerNode Next
       {
           get { return _next; }
           set { _next = value; }
       }

	}
}