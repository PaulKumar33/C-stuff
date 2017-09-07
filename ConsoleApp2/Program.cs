using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class delegatePract
    {
        

        public void myFunction(int a, int b, Action<bool, string> callback)
        {
            if (a == b)
                callback(true, "The numbers are the same");
            if (a > b)
            {
                string res = System.String.Format("{0} is greater than {1}", a, b);
                callback(true, res);
            }

            if (a < b)
            {
                string res = System.String.Format("{0} is less than than {1}", a, b);
                callback(false, res);
            }
        }
    }

        class Program
        {

        
        public static void delCall(int a, int b, Action<bool, string> callback)
        {
            delegatePract myDel = new delegatePract();
            myDel.myFunction(1, 1, callback);
        }

        public void callback(bool b, string s)
        {
            Console.WriteLine(b);
            Console.WriteLine(s);
        }
            static void Main(string[] args)
            {
            Program mycallback = new Program();

            delCall(1, 1, mycallback.callback);
            Console.ReadLine();
            
            }
        }
    
}
