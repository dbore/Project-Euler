using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace XOR_decryption3
{
    class Program
    {

            //devide message into 3 piles (3 letter password)
           static List<int> first_pile = new List<int>(); 
           static List<int> second_pile = new List<int>();
           static List<int> third_pile = new List<int>();

            //used for counting number of occurances
            static Dictionary<int, int> myMap_1 = new Dictionary<int, int>();
            static Dictionary<int, int> myMap_2 = new Dictionary<int, int>();
            static Dictionary<int, int> myMap_3 = new Dictionary<int, int>();

           static int sumofASCII = 0;

        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            //read the file
            int[] message = File.ReadAllText("p059_cipher.txt").Split(',').Select(int.Parse).ToArray();

            //devide message into philes
            for (int i = 0; i < message.Length; i++)
            {
                if (i % 3 == 0)
                     first_pile.Add(message[i]);
                else if (i % 3 == 1)
                    second_pile.Add(message[i]);
                else if (i % 3 == 2)
                     third_pile.Add(message[i]);
            }

             int[] key = analyse();
             string decoded_message = encode(key, message);
             timer.Stop();

             Console.WriteLine(decoded_message + "\r\n");
             Console.WriteLine("answer is: " + sumofASCII);
             Console.WriteLine("calculated in (ms): " + timer.ElapsedMilliseconds);
             Console.WriteLine("finish...");
             Console.ReadKey();




        }
        static int[] analyse(){

               //count occurances in each phile
               countOccurances(first_pile, myMap_1);
               countOccurances(second_pile, myMap_2);
               countOccurances(third_pile, myMap_3);

             //look for each most common character in each pile
            int most_common_first_phile = myMap_1.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            int most_common_second_phile = myMap_2.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
            int most_common_third_phile = myMap_3.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

            //get the key ('god')
            int ASCIIspace = 32; //space character is the most common english word
            int[] key = new int[3];
            key[0] = most_common_first_phile ^ ASCIIspace;
            key[1] = most_common_second_phile ^ ASCIIspace;
            key[2] = most_common_third_phile ^ ASCIIspace;

            return key;

        }

        static string encode(int[] key, int[] cipher)
        {

            int i = 0;
            string msg = "";
            foreach (int k in cipher)
            {

                char encoded = Convert.ToChar(key[i % 3] ^ k); // XOR encode
                msg = msg + encoded.ToString();
                sumofASCII = sumofASCII + ((int)encoded);
                    i++;

            }

            return msg;
        }

        static void countOccurances(List<int> phile, Dictionary<int, int> dictionary)
        {
            // the keys and occurances count is stored in dictionary

            for (int k = 0; k < phile.Count; k++)
            {
                if (dictionary.ContainsKey(phile[k]))
                {
                    int value = 0;
                    dictionary.TryGetValue(phile[k], out value);
                    value++;
                    dictionary[phile[k]] = value;
                }
                else
                {
                    dictionary.Add(phile[k], 1);

                }


            }
        }
    }
}
