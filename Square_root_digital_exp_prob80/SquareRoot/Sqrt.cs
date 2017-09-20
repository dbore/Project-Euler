using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SquareRoot
{
    class Sqrt
    {
        public Sqrt() { }

        //methods
        public double math_sqrt(double number){
            return Math.Sqrt(number);
        }

        public double math_sqrt2(double number)
        {
            //devide number into groups
            int precision = 14;
            string result_out = "";
            string product = "";
            List<string> groups = new List<string>();
            string num_str = Convert.ToString(number);
            int comma_pos = 0;      
            if (num_str.Contains("."))
            {
                comma_pos = num_str.IndexOf(".");
                num_str = num_str.Remove(comma_pos, 1);
            }
            if (num_str.Length % 2 == 0)
            {
                //devides into groups equaly
              for (int i = 0; i < num_str.Length; i += 2)
                        groups.Add(num_str.Substring(i, 2));
          
            }
            else
            {
                //devides into groups not equaly
                groups.Add(num_str.Substring(0, 1));
                for (int i = 1; i < num_str.Length; i += 2)
                    groups.Add(num_str.Substring(i, 2));
            }
            for(int i = 0; i< precision; i++)
                groups.Add("00");
 
            int group_pos = 0;
            int group_digit = int.Parse(groups[group_pos]);
            //look for number which power of 2 is less than the group_digit
            int power = 0;
            for (int i = 0; i <= group_digit; i++)
                if (i * i <= group_digit)
                    power = i;
            Int64 r = group_digit - (power * power);
            result_out = power.ToString();
            product = product + power.ToString();

        
            while (true)
            {
                //insert comma in right place
                if ((result_out.Length == comma_pos - 1 || result_out.Length == comma_pos)  && !result_out.Contains("."))
                    result_out = result_out + ".";

                group_pos++;
                if (group_pos < groups.Count)
                {
                    if (groups[group_pos].Equals("00"))
                    {
                        if (!result_out.Contains("."))
                            result_out = result_out + ".";
                      
                        r = Int64.Parse(Convert.ToString(r) + Convert.ToString(groups[group_pos]));
               
                    }
                    else
                    {
                        r = Int64.Parse(Convert.ToString(r) + Convert.ToString(groups[group_pos]));
                    }

                }
                else
                {
                    break;
                }

                         
                Int64 k = 2 * Int64.Parse(product);
                Int64 num_g = 0;
                Int64 num_r = 0;
                int i;
                for (i = 9; i >= 0; i--)
                {
                    num_g = Int64.Parse(Convert.ToString(k) + Convert.ToString(i));
                    if (num_g * i <= r)
                    {
                        result_out = result_out + i.ToString();
                        product = product + i.ToString();
                        num_r = num_g * i;
                        break;
                    }
                }

             
                r = r - num_r;
        
            
            }
       
           
            return double.Parse(result_out);
        }

        public string math_sqrt2_2(double number, int precision)
        {
            //method to calculate square roots with greater percision, for example 100 decimal places
            //devide number into groups
            string result_out = "";
            string product = "";
            List<string> groups = new List<string>();
            string num_str = Convert.ToString(number);
            int comma_pos = 0;
            if (num_str.Contains("."))
            {
                comma_pos = num_str.IndexOf(".");
                num_str = num_str.Remove(comma_pos, 1);
            }
            if (num_str.Length % 2 == 0)
            {
                //devides into groups equaly
                for (int i = 0; i < num_str.Length; i += 2)
                    groups.Add(num_str.Substring(i, 2));

            }
            else
            {
                //devides into groups not equaly
                groups.Add(num_str.Substring(0, 1));
                for (int i = 1; i < num_str.Length; i += 2)
                    groups.Add(num_str.Substring(i, 2));
            }
            for (int i = 0; i < precision; i++)
                groups.Add("00");

            int group_pos = 0;
            int group_digit = int.Parse(groups[group_pos]);
            //look for number which power of 2 is less than the group_digit
            int power = 0;
            for (int i = 0; i <= group_digit; i++)
                if (i * i <= group_digit)
                    power = i;
           BigInteger r = group_digit - (power * power);
            result_out = power.ToString();
            product = product + power.ToString();


            while (true)
            {
                //insert comma in right place
                if ((result_out.Length == comma_pos - 1 || result_out.Length == comma_pos) && !result_out.Contains("."))
                    result_out = result_out + ".";

                group_pos++;
                if (group_pos < groups.Count)
                {
                    if (groups[group_pos].Equals("00"))
                    {
                        if (!result_out.Contains("."))
                            result_out = result_out + ".";

                        r = BigInteger.Parse(Convert.ToString(r) + Convert.ToString(groups[group_pos]));

                    }
                    else
                    {
                        r = BigInteger.Parse(Convert.ToString(r) + Convert.ToString(groups[group_pos]));
                    }

                }
                else
                {
                    break;
                }


                BigInteger k = 2 * BigInteger.Parse(product);
                BigInteger num_g = 0;
                BigInteger num_r = 0;
                int i;
                for (i = 9; i >= 0; i--)
                {
                    num_g = BigInteger.Parse(Convert.ToString(k) + Convert.ToString(i));
                    if (num_g * i <= r)
                    {
                        result_out = result_out + i.ToString();
                        product = product + i.ToString();
                        num_r = num_g * i;
                        break;
                    }
                }

                r = r - num_r;

            }


            return result_out;
        }

        public double math_sqrt3(double number, double epsilon)
        {
          //square root algorithm: Newton-Raphson
         
            double a = number / 2;

            while (Math.Abs(number / a - a) > epsilon)
            {
                a = (number / a + a) / 2;
            }

            return a;

        }

        public double math_sqrt4(double number, double epsilon)
        {
            //Bisection method

            double max = number + 1;
            double min = 0;
            int i, j;

            //get max
            for (i = 0; i < number; i++)
              if (i * i > number)
                {
                    max = i;
                    break;
                }

            //get min
             for (j = i; j > 0; j--)
                if (j * j < number)
                {
                    min = j;
                    break;
                }


            double a = ((max + min) / 2) * ((max + min) / 2);
            while (Math.Abs(a - number) > epsilon)
            {
                 a = ((max + min) / 2) * ((max + min) / 2);
                
                if (a < number)
                    min = ((max + min) / 2);
                else
                    max = ((max + min) / 2);
              
            }
            return ((max + min) / 2);

     
        }

        public double math_sqrt5(double number)
        {
            //Bakhshali approximation
            int n;
            double d;
            double P;
            double A;

            for (n = (int) number; n > 0; n--)
                if (n * n < number)
                    break;

            d = number - (n * n);
            P = d / (2 * n);
            A = n + P;

            double S = A - ((P * P) / (2 * A));

            return S; // S ≈ sqrt(number)
        }

    }



}
