﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Jack
{
    class BJ
    {
        
        public static int RandomNumber()
        {
            var r1 = new Random();
            int random = r1.Next(1, 14);
            return random;
        }


       
        public static string GetCardName(int random)
        {
            string cardName = " ";
            switch (random)
            {
                case 1: cardName = "ДВОЙКА"; break;
                case 2: cardName = "ТРОЙКА"; break;
                case 3: cardName = "ЧЕТВЕРКА"; break;
                case 4: cardName = "ПЯТЕРКА"; break;
                case 5: cardName = "ШЕСТЕРКА"; break;
                case 6: cardName = "СЕМЕРКА"; break;
                case 7: cardName = "ВОСЬМЕРКА"; break;
                case 8: cardName = "ДЕВЯТКА"; break;
                case 9: cardName = "ДЕСЯТКА"; break;
                case 10: cardName = "ВАЛЕТ"; break;
                case 11: cardName = "ДАМА"; break;
                case 12: cardName = "КОРОЛЬ"; break;
                case 13: cardName = "ТУЗ"; break;
            }
            return cardName;
        }



      
        public static int GetCardValue(int random)
        {
            int cardValue = 0;
            switch (random)
            {
                case 1: cardValue = 2; break;
                case 2: cardValue = 3; break;
                case 3: cardValue = 4; break;
                case 4: cardValue = 5; break;
                case 5: cardValue = 6; break;
                case 6: cardValue = 7; break;
                case 7: cardValue = 8; break;
                case 8: cardValue = 9; break;
                case 9: cardValue = 10; break;
                case 10: cardValue = 10; break;
                case 11: cardValue = 10; break;
                case 12: cardValue = 10; break;
                case 13: cardValue = 11; break;
            }
            return cardValue;
        }



        public static void NewGame()
        {
            Console.Clear();
            Console.WriteLine($"Желаете сыграть? - Y/N");
            char newGame = Console.ReadKey(true).KeyChar;
            if (newGame != 'y')
            {
                Console.WriteLine("До свиданья!");
                EndGame();

            } 

        }



     
        public static int GetRate(int gold)
        {
            int rate;
            Rate:
            do
            {
                Console.WriteLine($"У ваc {gold}$ Делайте вашу ставку:");
            } while (!int.TryParse(Console.ReadLine(), out rate));

           
            if (rate > gold)
            {
                Console.WriteLine("У вас недостаточно денег, сделайте другую ставку!");
                goto Rate;
            }
            else if (rate < 50)
            {
                Console.WriteLine("Минимальная ставка - 50$");
                goto Rate;
            }
            else
            {
                gold -= rate;
                Console.WriteLine($"Ставка {rate} принята. У вас осталось - {gold}$ ");
                Console.ReadLine();
            }
            return rate;
            
        }




      
        public static int GetGold(int rate, int gold)
        {
            gold -= rate;
            return gold;
        }



       
        public static void EndGame()
        {
            Environment.Exit(0);
        }



      
        public static int GetCard()
        {

            int r = RandomNumber();
            string cardName = GetCardName(r);
            int cardValue = GetCardValue(r);

            Console.WriteLine($"{cardName} - {cardValue} очков");
            Console.ReadKey();

            int value = cardValue;
            return value;

        }      




    
        public static int PlayerWin(int gold, int rate)
        {
            Console.WriteLine("Вы победили!");
            Console.ReadKey();
            gold += rate * 2;
            return gold;
        }

        public static int CardsSum(int[] sum)
        {
            int sumAll = 0;
            for (int i = 0; i < sum.Length; i++)
            {
                sumAll += sum[i];               
            }
            Console.WriteLine($"Всего очков {sumAll}");
            Console.ReadKey();
            return sumAll;
        }

        public static int CheckAce(int[] ace)
        {
            int result = 0;
            for (int i = 0; i < ace.Length; i++)
            {
                if (ace[i] == 11)
                {
                    ace[i] = 1;
                    break;
                }

            }
            result = CardsSum(ace);
            return result;

        }

        public static void ClearMassiv(int[] ace)
        {
            
            for (int i = 0; i < ace.Length; i++)
            {
                ace[i] = 0;                            

            }

        }



        public static int GetTwoCards(int[] cards)
        {
            int score = 0;
            for (int i = 0; i < 2; i++)
            {
                cards[i] = BJ.GetCard();
                score += cards[i];
            }

            return score;

        }

        public static int GetOneCards(int[] cards)
        {
            int score = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i] == 0)
                {
                    cards[i] = BJ.GetCard();
                    score += cards[i];
                    break;
                }
            }
            score = CardsSum(cards);

            return score;

        }

        public static void Print (string text)
        {
            Console.WriteLine(text);
            Console.ReadKey();
        }

























    }
}
