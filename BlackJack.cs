using System;

namespace Black_Jack
{
    class BlackJack
    {
        static void Main(string[] args)
        {

            int gold = 300;
            int rate = 0;            
            int card = 0;
            int card1 = 0;
            int card2 = 0;
            int score = 0;
            int dillerCard = 0;
            int dillerCard1 = 0;
            int dillerCard2 = 0;
            int dillerScore = 0;
            int[] cards = new int[10];
           

            Console.WriteLine($"Добро пожаловать в наше казино! Есть одно свободное место за столом Black Jack!");
            
            Game:

            while (gold != 0)
            {
                Console.Clear();
                BJ.NewGame();
                rate = BJ.GetRate(gold);
                gold = BJ.GetGold(rate, gold);
                Console.WriteLine("Диллер сдает карты");
                Console.WriteLine("Вам раздали 2 карты");

                for (int i = 0; i < 2; i++)
                {
                    cards[i] = BJ.GetCard();
                    Console.WriteLine($"{cards[i]}");
                    score += cards[i];
                }

                Console.WriteLine($"Всего очков: {score}");
                Console.ReadKey();

                card1 =  BJ.GetCard();                
                card2 = BJ.GetCard();                
                score = card1 + card2;
                Console.WriteLine($"Всего очков: {score}");
                Console.ReadKey();

               
                if (score == 21)
                {
                    gold = BJ.PlayerWin(gold, rate);                 
                    goto Game;
                }
               
                while (score <= 21)
                {
                    Console.WriteLine("ЕЩЕ? - Y/N");
                    char next = Console.ReadKey(true).KeyChar;
                    if (next == 'y')
                    {
                        card = BJ.GetCard();                       
                        score += card;

                        Console.WriteLine($"Всего очков {score}");
                        Console.ReadKey();

                        if (score > 21)
                        {
                            if (card1 == 11 || card2 == 11 || card == 11)
                            {
                                score = BJ.CheckAce(ref card1, ref card2, ref card);
                                Console.WriteLine($"Всего очков {score}");
                                Console.ReadKey();
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Вы проиграли!");
                                Console.ReadKey();
                                goto Game;
                            }
     
                        }
                        else if (score == 21)
                        {
                            gold = BJ.PlayerWin(gold, rate);
                            goto Game;
                        }
                        else continue;
                    }
                    else
                    {
                        Console.WriteLine("Играет диллер");
                        dillerCard1 = BJ.GetCard();                        
                        dillerCard2 = BJ.GetCard();
                        dillerScore = dillerCard1 + dillerCard2;

                        DillerGame:

                        if (dillerScore > 21)
                        {
                            if (dillerCard1 == 11 || dillerCard2 == 11 || dillerCard == 11)
                            {
                                dillerScore = BJ.CheckAce(ref dillerCard1, ref dillerCard2, ref dillerCard);
                                Console.WriteLine($"Диллер набрал {dillerScore} очков");
                                Console.ReadKey();
                                goto DillerGame;
                            }
                            else
                            {
                                Console.WriteLine("У Диллера - перебор");
                                gold = BJ.PlayerWin(gold, rate);
                                goto Game;
                            }                               
    
                        }
                        else if (dillerScore >= 16 && dillerScore <=21)
                        {
                            Console.WriteLine($"Диллер набрал {dillerScore} очков");
                            if (dillerScore > score)
                            {
                                Console.WriteLine("Вы проиграли!");
                                goto Game;
                            }
                            else if (dillerScore < score)
                            {
                                Console.WriteLine($"Диллер набрал {dillerScore} очков");
                                gold = BJ.PlayerWin(gold, rate);
                                goto Game;
                            }
                            else if (dillerScore == score)
                            {
                                Console.WriteLine($"Диллер набрал {dillerScore} очков");
                                Console.WriteLine("Ничья");
                                Console.ReadKey();
                                gold += rate;
                                goto Game;
                            }
                        }
                        else if (dillerScore < 16)
                        {
                            Console.WriteLine($"Диллер берет еще карту");
                            dillerCard = BJ.GetCard();
                            dillerScore += dillerCard;
                            Console.WriteLine($"Диллер набрал {dillerScore} очков");
                            goto DillerGame;
                        }
                        Console.ReadKey();

                    }

                }
            }

            Console.WriteLine("Вы проиграли все деньги, покиньте наше казино");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("псс.... что все денежки тю тю.. могу помочь");
            Console.ReadKey();
            Console.WriteLine("Могу купить у тебя что нибудь!");
            Console.ReadKey();

            Console.WriteLine("Вещи на продажу:\n 1.Часы - 100$\n 2.Пиджак - 50$\n 3.Цепочка - 80$\n 4.Трусы - 20$");
            int sale = int.Parse(Console.ReadLine());

            switch (sale)
            {
                case 1: gold += 100; break;
                case 2: gold += 50; break;
                case 3: gold += 80; break;
                case 4: gold += 20; break;
                        
            }

            Console.WriteLine($"Хотите вернуться в казино? - Y/N");
            char newGame = Console.ReadKey(true).KeyChar;
            if (newGame != 'y')
            {
                Console.WriteLine("До свиданья!");
                BJ.EndGame();
            }
            else
            {
                Console.WriteLine($"И снова здравствуйте! Ваше место еще свободно - проходите! ");
                goto Game;
            }


        }
    }
}


