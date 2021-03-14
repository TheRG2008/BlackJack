using System;

namespace Black_Jack
{
    class BlackJack
    {
        static void Main(string[] args)
        {

        //    int gold = 300, rate = 0, score = 0, dillerScore = 0;
        //    int[] playerCards = new int[10];
        //    int[] dillerCards = new int[10];

        //    BJ.Print($"Добро пожаловать в наше казино! Есть одно свободное место за столом Black Jack!");

        //Game:

        //    while (gold != 0)
        //    {

        //        BJ.ClearMassiv(playerCards);
        //        BJ.ClearMassiv(dillerCards);

        //        BJ.NewGame();
        //        rate = BJ.GetRate(gold);
        //        gold = BJ.GetGold(rate, gold);

        //        BJ.Print("Диллер сдает карты");
        //        BJ.Print("Вам раздали 2 карты");


        //        score = BJ.GetTwoCards(playerCards);

        //        if (score == 21)
        //        {
        //            gold = BJ.PlayerWin(gold, rate);
        //            goto Game;
        //        }

        //        while (score <= 21)
        //        {
        //            Console.WriteLine("ЕЩЕ? - Y/N");
        //            char next = Console.ReadKey(true).KeyChar;
        //            if (next == 'y')
        //            {
        //                score = BJ.GetOneCards(playerCards);

        //                if (score > 21)
        //                {
        //                    score = BJ.CheckAce(playerCards);

        //                    if (score > 21)
        //                    {
        //                        BJ.Print("Вы проиграли!");
        //                        goto Game;
        //                    }
        //                    else continue;

        //                }
        //                else if (score == 21)
        //                {
        //                    gold = BJ.PlayerWin(gold, rate);
        //                    goto Game;
        //                }
        //                else continue;
        //            }
        //            else
        //            {
        //                BJ.Print("Играет диллер");

        //                dillerScore = BJ.GetTwoCards(dillerCards);


        //            DillerGame:

        //                if (dillerScore > 21)
        //                {
        //                    dillerScore = BJ.CheckAce(dillerCards);

        //                    if (dillerScore > 21)
        //                    {
        //                        BJ.Print("У Диллера - перебор!");
        //                        gold = BJ.PlayerWin(gold, rate);
        //                        goto Game;
        //                    }

        //                }
        //                else if (dillerScore >= 16 && dillerScore <= 21)
        //                {
        //                    BJ.Print($"Диллер набрал {dillerScore} очков");
        //                    if (dillerScore > score)
        //                    {
        //                        BJ.Print("Вы проиграли!");
        //                        goto Game;
        //                    }
        //                    else if (dillerScore < score)
        //                    {
        //                        BJ.Print($"Диллер набрал {dillerScore} очков");
        //                        gold = BJ.PlayerWin(gold, rate);
        //                        goto Game;
        //                    }
        //                    else if (dillerScore == score)
        //                    {
        //                        BJ.Print($"Диллер набрал {dillerScore} очков");
        //                        BJ.Print("Ничья");
        //                        gold += rate;
        //                        goto Game;
        //                    }
        //                }
        //                else if (dillerScore < 16)
        //                {
        //                    BJ.Print($"Диллер берет еще карту");

        //                    dillerScore = BJ.GetOneCards(dillerCards);

        //                    BJ.Print($"Диллер набрал {dillerScore} очков");
        //                    goto DillerGame;
        //                }
        //                Console.ReadKey();

        //            }

        //        }
        //    }






        //    BJ.Print("Вы проиграли все деньги, покиньте наше казино");
        //    Console.Clear();
        //    BJ.Print("псс.... что все денежки тю тю.. могу помочь");
        //    BJ.Print("Могу купить у тебя что нибудь!");

        //    Console.WriteLine("Вещи на продажу:\n 1.Часы - 100$\n 2.Пиджак - 50$\n 3.Цепочка - 80$\n 4.Трусы - 20$");
        //    int sale = int.Parse(Console.ReadLine());

        //    switch (sale)
        //    {
        //        case 1: gold += 100; break;
        //        case 2: gold += 50; break;
        //        case 3: gold += 80; break;
        //        case 4: gold += 20; break;

        //    }

        //    Console.WriteLine($"Хотите вернуться в казино? - Y/N");
        //    char newGame = Console.ReadKey(true).KeyChar;
        //    if (newGame != 'y')
        //    {
        //        Console.WriteLine("До свиданья!");
        //        BJ.EndGame();
        //    }
        //    else
        //    {
        //        Console.WriteLine($"И снова здравствуйте! Ваше место еще свободно - проходите! ");
        //        goto Game;
        //    }

            Inventory jacket = new Inventory() { price = 100, name = "Пиджак" };
            Inventory Pants = new Inventory() { price = 70, name = "Штаны" };
            Inventory Shirt = new Inventory() { price = 50, name = "Рубашка" };
            Inventory Clock = new Inventory() { price = 200, name = "Часы" };
            Inventory Chain = new Inventory() { price = 150, name = "Цепочка" };
            Inventory Underpants = new Inventory() { price = 20, name = "Трусы" };

            string[,] things = {
                { jacket.name, Convert.ToString(jacket.price) },
                { Pants.name, Convert.ToString(Pants.price) }, 
                { Shirt.name, Convert.ToString(Shirt.price) },
                { Clock.name, Convert.ToString(Clock.price) }, 
                { Chain.name, Convert.ToString(Chain.price) }, 
                { Underpants.name, Convert.ToString(Underpants.price) } 

            };


            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"{things[i, j]} ");
                }
                Console.WriteLine("\n");
                
            }
            Console.ReadKey();




        }
    }
}


