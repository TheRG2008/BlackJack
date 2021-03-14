using System;
using System.Collections.Generic;
using System.Text;

namespace Black_Jack
{
    class BJ
    {
        /// <summary>
        /// Рандомное число для генерации карты
        /// </summary>
        /// <returns>Возвращает случайное число от 2 до 14 </returns>
        public static int RandomNumber()
        {
            var r1 = new Random();
            int random = r1.Next(1, 14);
            return random;
        }
        /// <summary>
        /// Генерирует название карты
        /// </summary>
        /// <param name="random"></param>
        /// <returns>Возвращает название карты</returns>
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
        /// <summary>
        /// Присваивает значение для сгенерированной карты
        /// </summary>
        /// <param name="random"></param>
        /// <returns>Возвращает значение карты</returns>
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
        /// <summary>
        /// Продолжаем играть или нет
        /// </summary>
        public static void NewGame()
        {

            Console.WriteLine($"Желаете сыграть? - Y/N");
            char newGame = Console.ReadKey(true).KeyChar;
            if (newGame != 'y')
            {
                Console.WriteLine("До свиданья!");
                EndGame();

            } 

        }
        /// <summary>
        /// Определяет ставку Игрока
        /// </summary>
        /// <param name="gold"></param>
        /// <returns></returns>
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
            else
            {
                gold -= rate;
                Console.WriteLine($"Ставка {rate} принята. У вас осталось - {gold}$ ");
                Console.ReadLine();
            }
            return rate;
            
        }
        /// <summary>
        /// Определяет сколько осталось денег
        /// </summary>
        /// <param name="rate"></param>
        /// <param name="gold"></param>
        /// <returns></returns>
        public static int GetGold(int rate, int gold)
        {
            gold -= rate;
            return gold;
        }
        /// <summary>
        /// Выход из игры
        /// </summary>
        public static void EndGame()
        {
            Environment.Exit(0);
        }
        /// <summary>
        /// Генерирует случайную карту
        /// </summary>
        /// <returns>Возвращает значение этой карты</returns>
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
        /// <summary>
        /// Проверяет наличие Туза, если перебор
        /// </summary>
        /// <param name="card1"></param>
        /// <param name="card2"></param>
        /// <param name="card"></param>
        /// <returns>Возвращает итоговую сумму значений карт</returns>
        public static int CheckAce(ref int card1,  ref int card2, ref int card)
        {
            int score = 0;
            if (card1 == 11) 
            {
                card1 = 1;
                return score  = card1 + card2 + card; 
            } 
            else if (card2 == 11)
            {
                card2 = 1;
                return score = card2 + card1 + card;
            }
            else if (card == 11)
            {
                card = 1; 
                return score = card + card1 + card2;
            }
            else return score = card + card1 + card2;
        }
        /// <summary>
        /// Победа игрока
        /// </summary>
        /// <param name="gold"></param>
        /// <param name="rate"></param>
        /// <returns>Возвращает кол-во денег у игрока</returns>
        public static int PlayerWin(int gold, int rate)
        {
            Console.WriteLine("Вы победили!");
            Console.ReadKey();
            gold += rate * 2;
            return gold;
        }































    }
}
