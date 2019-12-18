using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1st
{

    class Program 
    {
        static void Main(string[] args)
        {
            try
            {
                string answer = "";
                do
                {
                    Function.InitiliazeScreen();
                    answer = Function.TakeAction(answer);
                } while (answer != "Q");
                Console.WriteLine("The Program will close!");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }   
    }
}
