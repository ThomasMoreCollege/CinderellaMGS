using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BusinessLogic;
namespace CinderellaLauncher
{
    
    class Program
    {
        
        static void Main(string[] args)
        {
            /*
            ApointmentListIO test = new ApointmentListIO();
            Console.WriteLine(test.readFromExcel());
            Thread MatchMaking = new Thread(() => Application.Run(new MatchMaking()));
            //MatchMaking.Start();

                     
            //MatchMaking.Start();*/

            //Queries testQuery = new Queries();   //use for testing purposes
            

            /*Thread Login = new Thread(() => Application.Run(new Login()));
            Login.Start();*/
            Application.Run(new Login());
           // ApointmentListIO myTest = new ApointmentListIO();
           
                
            
           // Thread MainMenu = new Thread(() => Application.Run(new MainMenu()));
        //    MainMenu.Start();
            /*
            Application.Run(new Login());
            Application.Run(new MainMenu());*/
        }
    }
}
