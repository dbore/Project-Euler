using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Poker_hands_prob54
{
    class Program
    {
       public enum Card_Value {Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace} //the order of the cards, Ace is the most valued
       public enum Card_Color {Clubs = 1, Diamonds, Hearts, Spades} // different colors of cards

        public struct Card
        {
            //card contains the value and the color
           public Card_Value value;
           public Card_Color color;
        }

        static public List<Card> side_cards = new List<Card>(); //store the side cards

        static void Main(string[] args)
        {

            string filename = "p054_poker.txt"; //test.txt"
            string player1_handstr = "";
            string player2_handstr = "";
            int winner = 0; // 0 is no one

            int player1_won_hands = 0;
            int player2_won_hands = 0;

            Stopwatch timer = new Stopwatch();
            timer.Start();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(filename))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    player1_handstr = line.Substring(0, 14);
                    player2_handstr = line.Substring(15, 14);
                  
                    //convert to hands
                    List<Card> player1_hand = getHand(player1_handstr.Split(' '));
                    List<Card> player2_hand = getHand(player2_handstr.Split(' '));
                
                    //check who have better cards
                    winner = 0;
                    //check for royal flush
                    if (winner == 0)
                    {
                        List<Card> player1_royal_flush = Royal_Flush(player1_hand);
                        List<Card> player2_royal_flush = Royal_Flush(player2_hand);

                        if (player1_royal_flush.Count() == 5)
                        {
                            winner = 1;
                        }
                        else if (player2_royal_flush.Count() == 5)
                        {
                            winner = 2;
                        }

                    }
                    //check for straight flush
                    if (winner == 0)
                    {
                        List<Card> player1_straight_flush = Straight_Flush(player1_hand);
                        List<Card> player2_straight_flush = Straight_Flush(player2_hand);

                        if (player1_straight_flush.Count() == 5 && player2_straight_flush.Count() == 0)
                        {
                            winner = 1;
                        }
                        else if (player1_straight_flush.Count() == 0 && player2_straight_flush.Count() == 5)
                        {
                            winner = 2;
                        }
                        else if (player1_straight_flush.Count() == 5 && player2_straight_flush.Count() == 5)
                        {
                            //tie, compare the highest value
                            int player1_highest = (int)player1_straight_flush[4].value;
                            int player2_highest = (int)player2_straight_flush[4].value;

                            if (player1_highest > player2_highest)
                                winner = 1;
                            else if (player1_highest < player2_highest)
                                winner = 2;

                        }

                    }

                    //check for four of a kind
                    if (winner == 0)
                    {
                        List<Card> player1_four_of_a_kind = Four_of_a_Kind(player1_hand);
                        List<Card> player2_four_of_a_kind = Four_of_a_Kind(player2_hand);

                        if (player1_four_of_a_kind.Count() == 4 && player2_four_of_a_kind.Count() == 0)
                        {
                            winner = 1;
                        }
                        else if (player1_four_of_a_kind.Count() == 0 && player2_four_of_a_kind.Count() == 4)
                        {
                            winner = 2;
                        }
                        else if (player1_four_of_a_kind.Count() == 4 && player2_four_of_a_kind.Count() == 4)
                        {
                            //tie, highest card wins
                            int player1_highest = (int)player1_four_of_a_kind[0].value;
                            int player2_highest = (int)player2_four_of_a_kind[0].value;

                            if (player1_highest > player2_highest)
                                winner = 1;
                            else if (player1_highest < player2_highest)
                                winner = 2;
                        }


                    }
                    //check for full house
                    if (winner == 0)
                    {
                        List<Card> player1_full_house = Full_House(player1_hand);
                        List<Card> player2_full_house = Full_House(player2_hand);

                        if (player1_full_house.Count() == 4 && player2_full_house.Count() == 0)
                        {
                            winner = 1;
                        }
                        else if (player1_full_house.Count() == 0 && player2_full_house.Count() == 4)
                        {
                            winner = 2;
                        }
                        else if (player1_full_house.Count() == 4 && player2_full_house.Count() == 4)
                        {
                            //tie
                            
                            int player1_highest3 = (int)player1_full_house[0].value;
                            int player2_highest3 = (int)player2_full_house[0].value;

                         
                            if (player1_highest3 > player2_highest3)
                                winner = 1;
                            else if (player1_highest3 < player2_highest3)
                                winner = 2;
                            else if (player1_highest3 == player2_highest3)
                            {
                                //compare the pair                             
                                int player1_pair = (int)player1_full_house[3].value;
                                int player2_pair = (int)player2_full_house[3].value;

                                if (player1_pair > player2_pair)
                                    winner = 1;
                                else if (player1_pair < player2_pair)
                                    winner = 2;

                            }

                        }

                    }

                    //check for flush
                    if (winner == 0)
                    {
                        List<Card> player1_flush = Flush(player1_hand);
                        List<Card> player2_flush = Flush(player2_hand);

                        if (player1_flush.Count() == 5 && player2_flush.Count() == 0)
                        {
                      
                            winner = 1;
                        }
                        else if (player1_flush.Count() == 0 && player2_flush.Count() == 5)
                        {
                        
                            winner = 2;
                        }
                        else if (player1_flush.Count() == 5 && player2_flush.Count() == 5)
                        {
                            //tie
                            for (int i = 4; i >= 0; i--)
                            {
                                int player1_highest = (int)player1_flush[i].value;
                                int player2_highest = (int)player2_flush[i].value;

                                if (player1_highest > player2_highest)
                                {
                                    winner = 1;
                                    break;
                                }
                                else if (player1_highest < player2_highest)
                                {
                                    winner = 2;
                                    break;
                                }

                            }

                        }


                    }

                    //check for straight
                    if (winner == 0)
                    {
                        List<Card> player1_streight = Straight(player1_hand);
                        List<Card> player2_streight = Straight(player2_hand);

                        if (player1_streight.Count() == 5 && player2_streight.Count() == 0)
                        {
                            winner = 1;
                        }
                        else if (player1_streight.Count() == 0 && player2_streight.Count() == 5)
                        {
                            winner = 2;
                        }
                        else if (player1_streight.Count() == 5 && player2_streight.Count() == 5)
                        {
                            //tie, get the highest value from both hands
                            int player1_highest = (int)player1_streight[4].value;
                            int player2_highest = (int)player2_streight[4].value;

                            Console.WriteLine(player1_highest);
                            Console.WriteLine(player2_highest);

                            if (player1_highest > player2_highest)
                                winner = 1;
                            else if (player1_highest < player2_highest)
                                winner = 2;

                        }



                    }

                    //check for three of a kind
                    if (winner == 0)
                    {
                        List<Card> player1_three_of_a_kind = Three_of_a_Kind(player1_hand);
                        List<Card> player1_side_cards = deepCopy(side_cards);
                        List<Card> player2_three_of_a_kind = Three_of_a_Kind(player2_hand);
                        List<Card> player2_side_cards = deepCopy(side_cards);

                        if (player1_three_of_a_kind.Count() == 3 && player2_three_of_a_kind.Count() == 0)
                        {
                            winner = 1;
                        }
                        else if (player1_three_of_a_kind.Count() == 0 && player2_three_of_a_kind.Count() == 3)
                        {
                            winner = 2;
                        }
                        else if (player1_three_of_a_kind.Count() == 3 && player2_three_of_a_kind.Count() == 3)
                        {
                            //tie,compare highest card of three_of_a_kind
                            int player1_highest = (int)player1_three_of_a_kind[0].value;
                            
                            int player2_highest = (int)player2_three_of_a_kind[0].value;
                            
                            if (player1_highest > player2_highest)
                                winner = 1;
                            else if (player1_highest < player2_highest)
                                winner = 2;
                            else if (player1_highest == player2_highest)
                            {
                                //again tie, check side cards for highest
                                //sort the cards
                                player1_side_cards = player1_side_cards.OrderBy(o => o.value).ToList();
                                player2_side_cards = player2_side_cards.OrderBy(o => o.value).ToList();
                              for(int i = 1; i >= 0; i--){
                                  int player1_highest_side_card = (int)player1_side_cards[i].value;
                                  int player2_highest_side_card = (int)player2_side_cards[i].value;

                                  if (player1_highest_side_card > player2_highest_side_card)
                                  {
                                      winner = 1;
                                      break;
                                  }
                                  else if (player1_highest_side_card < player2_highest_side_card)
                                  {

                                      winner = 2;
                                      break;
                                  }

                              }
                              
                            }


                        }
                    }

                    //check for two different pairs
                    if (winner == 0)
                    {
                        List<Card> player1_two_pairs = Two_Pairs(player1_hand);
                        List<Card> player1_side_cards = deepCopy(side_cards);
                        List<Card> player2_two_pairs = Two_Pairs(player2_hand);
                        List<Card> player2_side_cards = deepCopy(side_cards);

                        if (player1_two_pairs.Count() == 2 && player2_two_pairs.Count() == 0)
                        {
                            winner = 1;
                        }
                        else if (player1_two_pairs.Count() == 0 && player2_two_pairs.Count() == 2)
                        {
                            winner = 2;
                        }
                        else if (player1_two_pairs.Count() == 2 && player2_two_pairs.Count() == 2)
                        {
                            //tie
                            //sort the cards
                            player1_two_pairs = player1_two_pairs.OrderBy(o => o.value).ToList();
                            player2_two_pairs = player2_two_pairs.OrderBy(o => o.value).ToList();
                            //check the pairs which one is highest
                            for (int i = 1; i >= 0; i--)
                            {
                                int player1_highest_pair = (int)player1_two_pairs[i].value;
                                int player2_highest_pair = (int)player2_two_pairs[i].value;
                             
                                if (player1_highest_pair > player2_highest_pair)
                                {
                                    winner = 1;
                                    break;
                                }
                                else if (player1_highest_pair < player2_highest_pair)
                                {

                                    winner = 2;
                                    break;
                                }
                            }
                            //if still no winner found check side card
                            if (winner == 0)
                            {
                              
                                int player1_highest_side_card = (int)player1_side_cards[0].value;
                                int player2_highest_side_card = (int)player2_side_cards[0].value;

                             
                                if (player1_highest_side_card > player2_highest_side_card)
                                {
                                    winner = 1;
                                }
                                else if (player1_highest_side_card < player2_highest_side_card)
                                {
                                    winner = 2;
                                }

                            }

                        }

                    }

                    //check for one pair
                    if (winner == 0)
                    {
                        
                        Card player1_one_pair = One_Pair(player1_hand);
                        List<Card> player1_side_cards = deepCopy(side_cards);
                        Card player2_one_pair = One_Pair(player2_hand);
                        List<Card> player2_side_cards = deepCopy(side_cards);


                        if (((int)player1_one_pair.value) >= 2 && ((int)player2_one_pair.value) == 0)
                        {
                            winner = 1;
                        }
                        else if (((int)player2_one_pair.value) >= 2 && ((int)player1_one_pair.value) == 0)
                        {
                            winner = 2;
                        }
                        else if (((int)player2_one_pair.value) >= 2 && ((int)player1_one_pair.value) >= 2)
                        {
                            //tie
                      
                            //check which pair is the highest
                            if (((int)player1_one_pair.value) > ((int)player2_one_pair.value))
                            {
                                winner = 1;
                            }
                            else if (((int)player1_one_pair.value) < ((int)player2_one_pair.value))
                            {
                                winner = 2;
                            }
                            else if (((int)player1_one_pair.value) == ((int)player2_one_pair.value))
                            {
                                //pair is equal in values check side cards for highest value
                                //sort the cards
                              
                                player1_side_cards = player1_side_cards.OrderBy(o => o.value).ToList();
                                player2_side_cards = player2_side_cards.OrderBy(o => o.value).ToList();

                                for (int i = 2; i >= 0; i--)
                                {
                                    int player1_highest_side_card = (int)player1_side_cards[i].value;
                                    int player2_highest_side_card = (int)player2_side_cards[i].value;

                               

                                    if (player1_highest_side_card > player2_highest_side_card)
                                    {
                                        winner = 1;
                                        break;
                                    }
                                    else if (player1_highest_side_card < player2_highest_side_card)
                                    {
                                        winner = 2;
                                        break;
                                    }


                                }

                            }


                        }
                        
                   
                 

                    }

                   //check for highest card
                    if (winner == 0)
                    {

                        List<Card> player1_highest_cards = High_Card(player1_hand);
                        List<Card> player2_highest_cards = High_Card(player2_hand);

                        for (int i = 4; i >= 0; i--)
                        {
                            int player1_highest_card = (int)player1_highest_cards[i].value;
                            int player2_highest_card = (int)player2_highest_cards[i].value;

                            if (player1_highest_card > player2_highest_card)
                            {
                                winner = 1;
                                break;
                            }
                            else if (player1_highest_card < player2_highest_card)
                            {
                                winner = 2;
                                break;
                            }

                        }


                    }



                    if (winner == 1)
                        player1_won_hands++;
                    else if (winner == 2)
                        player2_won_hands++;



                }



            }
            timer.Stop();

            Console.WriteLine("Player 1 wins {0} hands", player1_won_hands);
            Console.WriteLine("Player 2 wins {0} hands", player2_won_hands);
            Console.WriteLine("The solution took {0} ms", timer.ElapsedMilliseconds);
            Console.ReadKey();
        }

        static List<Card> getHand(String[] cards)
        {
            List<Card> hand = new List<Card>();
            foreach (string s in cards)
            {
                //convert each string to card data type
                //get value
                char value = Convert.ToChar(s.Substring(0, 1));
                char color = Convert.ToChar(s.Substring(1, 1));
                Card c = new Card();
                switch (value)
                {
                    case '2':
                        c.value = Card_Value.Two; break;
                    case '3':
                        c.value = Card_Value.Three; break;
                    case '4':
                        c.value = Card_Value.Four; break;
                    case '5':
                        c.value = Card_Value.Five; break;
                    case '6':
                        c.value = Card_Value.Six; break;
                    case '7':
                        c.value = Card_Value.Seven; break;
                    case '8':
                        c.value = Card_Value.Eight; break;
                    case '9':
                        c.value = Card_Value.Nine; break;
                    case 'T':
                        c.value = Card_Value.Ten; break;
                    case 'J':
                        c.value = Card_Value.Jack; break;
                    case 'Q':
                        c.value = Card_Value.Queen; break;
                    case 'K':
                        c.value = Card_Value.King; break;
                    case 'A':
                        c.value = Card_Value.Ace; break;

                }

                switch (color)
                {
                    case 'C':
                        c.color = Card_Color.Clubs; break;
                    case 'D':
                        c.color = Card_Color.Diamonds; break;
                    case 'H':
                        c.color = Card_Color.Hearts; break;
                    case 'S':
                        c.color = Card_Color.Spades; break;
                }

                //add each card to hand
                hand.Add(c);

            }

            return hand;


        }

        static List<Card> High_Card(List<Card> hand)
        {
            //Highest value card
            List<Card> tmp = hand.OrderBy(o => o.value).ToList();
            return tmp;

        }

        static Card One_Pair(List<Card> hand)
        {

            //Two cards of the same value.
            Card tmp = new Card();
            side_cards.Clear();

            for (int i = 0; i < hand.Count; i++)
            {
                for (int j = i + 1; j < hand.Count(); j++)
                {
                  
                    if (hand[i].value == hand[j].value)
                    {
                        tmp = hand[i];
                    }
                }


            }

            //get the side card
            foreach (Card x in hand)
            {
                if (x.value != tmp.value)
                    {
                        side_cards.Add(x);
                     
                    }    
            }

            return tmp;

        }

        static List<Card> Two_Pairs(List<Card> hand)
        {
            List<Card> tmp = new List<Card>();
            side_cards.Clear();
            
            for (int i = 0; i < hand.Count; i++)
            {
                for (int j = i + 1; j < hand.Count(); j++)
                {

                    if (hand[i].value == hand[j].value)
                    {
                    
                        //check if list already contains this pair
                        bool contains = false;
                        foreach (Card c in tmp)
                        {
                            if (c.value == hand[i].value)
                                contains = true;
                        }

                        if(!contains)
                            tmp.Add(hand[i]);
                        
                    }
                }


            }

            //get the side card
            foreach (Card x in hand)
            {
                bool found = false;
                foreach (Card z in tmp)
                {
                    if (x.value == z.value)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    side_cards.Add(x);
                }
            }
         
            if (tmp.Count() == 2)
            {

                return tmp; //contains two pairs
            }
            else
            {
                tmp.Clear(); // do not contain two pairs, return empty array
                return tmp;

            }
      
         
        }

        static List<Card> Three_of_a_Kind(List<Card> hand)
        {
     
            
            List<Card> tmp = hand.OrderBy(o => o.value).ToList();
            List<Card> return_list = new List<Card>();
            side_cards.Clear();

            if (tmp[0].value == tmp[1].value && tmp[1].value == tmp[2].value)
            {
                //found three
                return_list.Add(tmp[0]);
                return_list.Add(tmp[1]);
                return_list.Add(tmp[2]);
                //add the side cards as last 2
               side_cards.Add(tmp[3]);
               side_cards.Add(tmp[4]);

            }
            else if (tmp[1].value == tmp[2].value && tmp[2].value == tmp[3].value)
            {
                //found three
                return_list.Add(tmp[1]);
                return_list.Add(tmp[2]);
                return_list.Add(tmp[3]);
                //add the side cards as last 2
                side_cards.Add(tmp[0]);
                side_cards.Add(tmp[4]);
            }
            else if (tmp[2].value == tmp[3].value && tmp[3].value == tmp[4].value)
            {
                //found three
                return_list.Add(tmp[2]);
                return_list.Add(tmp[3]);
                return_list.Add(tmp[4]);
                //add the side cards as last 2
                side_cards.Add(tmp[0]);
                side_cards.Add(tmp[1]);
            }



            return return_list;
        }

        static List<Card> Straight(List<Card> hand)
        {

            List<Card> SortedList = hand.OrderBy(o => o.value).ToList();
            bool straight = true;
            for(int i = 1; i < SortedList.Count(); i++)
            {
                int previous_card = (int) SortedList[i - 1].value;
                int current_card = (int)SortedList[i].value;

                if (!(previous_card + 1 == current_card))
                    straight = false;
            }

            if (straight)
            {

                return SortedList;
            }
            else
            {
                SortedList.Clear(); // return empty list;
                return SortedList;

            }


        }

        static List<Card> Flush(List<Card> hand)
        {

            List<Card> SortedList = hand.OrderBy(o => o.value).ToList();
            bool flush = true;
            for (int i = 1; i < SortedList.Count(); i++)
            {
                int previous_card = (int)SortedList[i - 1].color;
                int current_card = (int)SortedList[i].color;

                if (!(previous_card == current_card))
                   flush = false;
            }

            if (flush)
            {

                return SortedList;
            }
            else
            {
                SortedList.Clear(); // return empty list;
                return SortedList;
            }


        }

        static List<Card> Full_House(List<Card> hand)
        {

            List<Card> hand_tmp = deepCopy(hand);
            List<Card> three_of_a_kind = Three_of_a_Kind(hand_tmp);

            List<Card> return_list = new List<Card>();
            //add three of the kind to new created list
            foreach (Card c in three_of_a_kind)
                return_list.Add(c);
      
            bool full_house = true;
            //3 cards the same value
            if (three_of_a_kind.Count() == 3)
            {
                //remove the elements from tmp which are also in three_of_a_kind
                for (int i = 0; i < three_of_a_kind.Count(); i++)
                {
                    for (int j = 0; j < hand_tmp.Count(); j++)
                    {
                        if (hand_tmp[j].value == three_of_a_kind[i].value && hand_tmp[j].color == three_of_a_kind[i].color)
                        {
                            hand_tmp.RemoveAt(j);                     
                        }
                    }


                }

                //and one pair
                Card one_pair = One_Pair(hand_tmp);
                if (((int)one_pair.value) < 2)
                {
                    full_house = false;
                }
                else
                {
                    return_list.Add((one_pair));
                }

            }
            else
            {
                full_house = false;
            }

            if (full_house)
            {

                return return_list;
            }
            else
            {
                return_list.Clear(); // return empty list
                return return_list;
            }

        }

        static List<Card> Four_of_a_Kind(List<Card> hand)
        {
     
            List<Card> tmp = hand.OrderBy(o => o.value).ToList();
            List<Card> return_list = new List<Card>();
            if (tmp[0].value == tmp[1].value && tmp[1].value == tmp[2].value && tmp[2].value == tmp[3].value)
            {
                //found four
                return_list.Add(tmp[0]);
                return_list.Add(tmp[1]);
                return_list.Add(tmp[2]);
                return_list.Add(tmp[3]);
            }
            else if (tmp[1].value == tmp[2].value && tmp[2].value == tmp[3].value && tmp[3].value == tmp[4].value)
            {
                //found four
                return_list.Add(tmp[1]);
                return_list.Add(tmp[2]);
                return_list.Add(tmp[3]);
                return_list.Add(tmp[4]);
            }
          



            return return_list;
        }

        static List<Card> Straight_Flush(List<Card> hand)
        {

            List<Card> SortedList = hand.OrderBy(o => o.value).ToList();
            bool straight_flush = true;
            for (int i = 1; i < SortedList.Count(); i++)
            {
                int previous_card_value = (int)SortedList[i - 1].value;
                int current_card_value = (int)SortedList[i].value;
                int previous_card_color = (int)SortedList[i - 1].color;
                int current_card_color = (int)SortedList[i].color;

                if (!(previous_card_value + 1 == current_card_value) || previous_card_color != current_card_color)
                    straight_flush = false;
            }

            if (straight_flush)
            {

                return SortedList;
            }
            else
            {
                SortedList.Clear(); // return empty list;
                return SortedList;

            }


        }

        static List<Card> Royal_Flush(List<Card> hand)
        {

            List<Card> SortedList = hand.OrderBy(o => o.value).ToList();
            bool royal_flush = false;
            if ( (int)SortedList[0].value == 10 && (int)SortedList[1].value == 11 && (int)SortedList[2].value == 12
                && (int)SortedList[3].value == 13 && (int)SortedList[4].value == 14)
            {
                if ((int)SortedList[0].color == (int)SortedList[1].color && (int)SortedList[1].color == (int)SortedList[2].color &&
                    (int)SortedList[2].color == (int)SortedList[3].color && (int)SortedList[3].color == (int)SortedList[4].color)
                {
                    royal_flush = true;

                }
                
            }

            if (royal_flush)
            {

                return SortedList;
            }
            else
            {
                SortedList.Clear(); // return empty list
                return SortedList;
            }

        }

        static List<Card> deepCopy(List<Card> hand)
        {
            List<Card> hand_copy = new List<Card>();
            foreach (Card c in hand)
                hand_copy.Add(c);

            return hand_copy;
        }
        //------------------------
    }
}
