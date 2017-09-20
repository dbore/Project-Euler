using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace Diophantine_equation_prob66
{
    class Program
    {
        //https://www.researchgate.net/profile/Andrzej_Nowicki3/publication/271272583_Pell's_Equation/links/54c412000cf256ed5a9334da.pdf 
        //the above paper was used to help to solve this problem
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            int limit = 1000;
            BigInteger largest_x = 0;
            int largest_d = 0;
            
            timer.Start();
            for (int d = 2; d <= limit; d++)
            {
                //check if d is square
                double result = Math.Sqrt(d);
                bool isSquare = result % 1 == 0;

                if(isSquare) // this do not work with square numbers
                    continue;

                int n = d;
                List<BigInteger> x_y = continued_fraction_of_a_square_root(n);
                //Console.WriteLine("x = {0}, y = {1}", x_y[0], x_y[1]);

                if (x_y[0] > largest_x)
                {
                    largest_x = x_y[0];
                    largest_d = n;
                }

            }
            timer.Stop();


            Console.WriteLine("The largest value of x is when x = {0} and d = {1}",largest_x, largest_d);
            Console.WriteLine("The solution took " + timer.ElapsedMilliseconds + " ms");
            Console.ReadKey();
            
       }

        static List<BigInteger> continued_fraction_of_a_square_root(int n)
        {
               List<BigInteger> x_y = new List<BigInteger>();
               List<BigInteger> q_arr = new List<BigInteger>();
               List<BigInteger> p_arr = new List<BigInteger>();
               List<BigInteger> a_arr = new List<BigInteger>();
                int k = 0;
                BigInteger m = 0;
                BigInteger d = 1;
                int a0;
               
                a0 = (int)Math.Sqrt(n);
                BigInteger a = a0;
                a_arr.Add(a);
               
                BigInteger p = a;
                p_arr.Add(p);
                BigInteger q = 1;
               q_arr.Add(q);

              x_y.Add(p);
              x_y.Add(q);
              BigInteger result = (x_y[0] * x_y[0]) - n * (x_y[1] * x_y[1]);

              if (result == 1)
                  return x_y;

                while (true)
                {
                    m = d * a - m;
                    d = (n - m * m) / d;
                    a = (a0 + m) / d;
                    a_arr.Add(a);

                    if (k == 0)
                    {
                        p = a_arr[1] * a_arr[0] + 1;
                        q = a_arr[1];
                        p_arr.Add(p);
                        q_arr.Add(q);
                    }
                    else
                    {

                        p = a * p + p_arr[k - 1];
                        q = a * q + q_arr[k - 1];
                        p_arr.Add(p);
                        q_arr.Add(q);

                    }

                    //update list
                    x_y[0] = p;
                    x_y[1] = q;
                    result = (x_y[0] * x_y[0]) - n * (x_y[1] * x_y[1]);

                    if (result == 1)
                        break;

                    k++;
                }
   
            return x_y;
                
            }



        }

            
    }


