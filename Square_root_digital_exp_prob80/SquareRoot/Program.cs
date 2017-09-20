using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SquareRoot
{
    class Program
    {
        static void Main(string[] args)
        {

  
            Console.WriteLine("Square root algorithms tests:\n");

             Sqrt sqrt_obj = new Sqrt();                                                      //passed
             double a;
             double epsilon = 0.000000000001;
             double epsilon_2 = 0.0000000001;
             Stopwatch timer = new Stopwatch();

             

             Console.WriteLine("Testing method: math_sqrt");
             a = 0.05; 
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt(a));                // -ok
             a = 1.45;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt(a));                // -ok
             a = 2;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt(a));              // -ok
             a = 5;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt(a));              // -ok
             a = 10;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt(a));              // -ok
             a = 10.14;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt(a));                // -ok
             a = 105.14;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt(a));                // -ok
             a = 1089;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt(a));                // -ok
             a = 10514;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt(a));                // -ok
             a = 20449;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt(a));                // -ok
             a = 23457;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt(a));                // -ok
             a = 123456;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt(a));                // -ok
             a = 288340;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt(a));                // -ok
             a = 622521;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt(a));                // -ok


             Console.WriteLine();
             Console.WriteLine("Testing method: math_sqrt2"); // argument in format _._ produces wrong output for this method!!!
             a = 0.05;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt2(a));              // -ok
             a = 1.45;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt2(a));              // -ok
             a = 2;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt2(a));            // -ok
             a = 5;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt2(a));            // -ok
             a = 10;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt2(a));            // -ok
             a = 10.14;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt2(a));              // -ok
             a = 105.14;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt2(a));              // -ok
             a = 1089;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt2(a));              // -ok
             a = 10514;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt2(a));              // -ok
             a = 20449;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt2(a));              // -ok
             a = 23457;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt2(a));              // -ok
             a = 123456;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt2(a));              // -ok
             a = 288340;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt2(a));              // -ok
             a = 622521;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt2(a));              // -ok


             Console.WriteLine();
             Console.WriteLine("Testing method: math_sqrt3"); 
             a = 0.05;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));     // -ok
             a = 1.45;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));     // -ok
             a = 2;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));   // -ok
             a = 5;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));   // -ok
             a = 10;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));   // -ok
             a = 10.14;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));     // -ok
             a = 105.14;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));     // -ok
             a = 1089;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));     // -ok
             a = 10514;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));     // -ok
             a = 20449;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));     // -ok
             a = 23457;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));     // -ok
             a = 123456;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));     // -ok
             a = 288340;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));     // -ok
             a = 622521;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt3(a, epsilon));     // -ok 


             Console.WriteLine();
             Console.WriteLine("Testing method: math_sqrt4"); //algorithm is less accurate
             a = 0.05;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt4(a, epsilon));     // -ok
             a = 1.45;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt4(a, epsilon));     // -ok
             a = 2;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt4(a, epsilon));   // -ok
             a = 5;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt4(a, epsilon));   // -ok
             a = 10;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt4(a, epsilon));   // -ok
             a = 10.14;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt4(a, epsilon));     // -ok
             a = 105.14;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt4(a, epsilon));     // -ok
             a = 1089;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt4(a, epsilon));     // -ok
             a = 10514;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt4(a, epsilon));     // -ok
             a = 20449;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt4(a, epsilon));     // -ok
             a = 23457;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt4(a, epsilon));     // -ok
             a = 123456;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt4(a, epsilon));     // -ok
             a = 288340;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt4(a, epsilon_2));     // -this works with less precision
             a = 622521;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt4(a, epsilon_2));     // -this works with less precision


             Console.WriteLine();
             Console.WriteLine("Testing method: math_sqrt5"); // This algorithm is not accurate and NOT RECOMMENDED to use!
             a = 0.05;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt5(a));     // -failed
             a = 1.45;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt5(a));     // -not accurate
             a = 2;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt5(a));   // -not accurate
             a = 5;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt5(a));   // -not accurate
             a = 10;
             Console.WriteLine("a = " + a + "\t\t√a = " + sqrt_obj.math_sqrt5(a));   // -not accurate
             a = 10.14;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt5(a));     // -not accurate
             a = 105.14;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt5(a));     // -not accurate
             a = 1089;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt5(a));     // -not accurate
             a = 10514;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt5(a));     // -not accurate
             a = 20449;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt5(a));     // -not accurate
             a = 23457;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt5(a));     // -ok
             a = 123456;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt5(a));     // -wrong
             a = 288340;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt5(a));     // -wrong
             a = 622521;
             Console.WriteLine("a = " + a + "\t√a = " + sqrt_obj.math_sqrt5(a));     // -wrong


             Console.WriteLine();
             Console.WriteLine("Project Euler - problem 80");
             Console.WriteLine("Square root digital expansion");
             int j = 1;
             int result = 0;
             timer.Start();
             for (int i = 1; i <= 100; i++)
             {
                 
                 if (j * j == i)
                 {
                     j++;
                     continue;
                 }
                 String s = sqrt_obj.math_sqrt2_2(i, 100);
                 s = s.Remove(s.IndexOf('.'), 1);
                 s = s.Substring(0, 100);
                 result = result + s.Sum(c => c - '0');

             }
             timer.Stop();
             Console.WriteLine("The answer to this problem is: " + result);
             Console.WriteLine("Calculation time : " + timer.ElapsedMilliseconds + " ms");

            

            Console.ReadKey();
        }
    }
}
