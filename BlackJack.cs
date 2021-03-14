using System;

namespace Black_Jack
{
    class BlackJack
    {
        static void Main(string[] args)
        {

            int gold = 300, rate = 0, score = 0, dillerScore = 0;           
            int[] cards = new int[10];
            int[] dillerCards = new int[10];
           

            Console.WriteLine($"Добро пожаловать в наше казино! Есть одно свободное место за столом Black Jack!");
            Console.ReadKey();
            
            Game:

            while (gold != 0)
            {

                BJ.ClearMassiv(cards);
                BJ.ClearMassiv(dillerCards);
                
                BJ.NewGame();
                rate = BJ.GetRate(gold);
                gold = BJ.GetGold(rate, gold);

                Console.WriteLine("Диллер сдает карты");
                Console.WriteLine("Вам раздали 2 карты");


                score = BJ.GetTwoCards(cards);

                //for (int i = 0; i < 2; i++)
                //{
                //    cards[i] = BJ.GetCard();                    
                //    score += cards[i];
                //}

                //score = BJ.CardsSum(cards);


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
                        for (int i = 0; i < cards.Length; i++)
                        {
                            if (cards[i] == 0)
                            {
                                cards[i] = BJ.GetCard();
                                score += cards[i];
                                break;
                            }
                        }

                        score = BJ.CardsSum(cards);

                        if (score > 21)
                        {
                            score = BJ.CheckAce(cards);
   
                            if (score > 21)
                            {
                                Console.WriteLine("Вы проиграли!");
                                Console.ReadKey();
                                goto Game;
                            }
                            else continue;

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

                        for (int i = 0; i < 2; i++)
                        {
                            dillerCards[i] = BJ.GetCard();
                            dillerScore += dillerCards[i];
                        }

                        dillerScore = BJ.CardsSum(dillerCards);


                        DillerGame:

                        if (dillerScore > 21)
                        {
                            dillerScore = BJ.CheckAce(dillerCards);
                            if (dillerScore > 21)
                            {
                                Console.WriteLine("У Диллера - перебор!");
                                Console.ReadKey();
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

                            for (int i = 0; i < dillerCards.Length; i++)
                            {
                                if (dillerCards[i] == 0)
                                {
                                    dillerCards[i] = BJ.GetCard();
                                    dillerScore += dillerCards[i];
                                    break;
                                }
                            }
                            dillerScore = BJ.CardsSum(dillerCards);


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


