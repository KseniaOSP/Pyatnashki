using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    public class ConsoleUI
    {
        internal void Start() 
        {
            // выводим на консоль сообщение: "Игра началась"
            Console.WriteLine("Игра началась");
            // создаем объект класса GameField
            GameField gameField = new GameField();
            // вызываем метод ValidRandomField, который перебирает создаваемые в м-де RandomField рандомные поля до тех пор,
            // пока не найдет поле с четным параметром беспорядка и не выведет необходимое нам поле
            gameField.ValidRandomField();

            // пока поле не победное, осуществляем действия ниже
            while (!gameField.IsWinField()) 
            {
                // отображаем игровое поле
                Display(gameField);
                // читаем нажимаемую клавишу
                ConsoleKey key = ReadKey();
                // обрабатываем введенную клавишу, т.е. по сути команду пользователя
                ProcessKey(gameField, key); 
            }

            // отображаем победное поле
            Display(gameField);
            // выводим на консоль сообщение: "Вы победили!"
            Console.WriteLine("Вы победили!");
        }

        // Обработка введенных клавиш 
        private void ProcessKey(GameField gameField, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    gameField.MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    gameField.MoveRight();
                    break;
                case ConsoleKey.UpArrow:
                    gameField.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    gameField.MoveDown();
                    break;
            }
        }

        // получаем и вовращаем нажатую пользователем клавишу
        private ConsoleKey ReadKey()
        {
            return Console.ReadKey().Key;
        }

        // метод, отображающий игровое поле
        private void Display(GameField gameField) 
        {   
            Console.Clear();

            // в переменную data (тип данных - двумерный массив) помещаем двумерный массив:
            // у объекта класса GameField вызываем м-д Get Data, который возвращает рандомное выигрышное поле 4 на 4
            int[,] data = gameField.GetData();

            // перебираем элементы массива и находим там элемент с нулем (заменяем на три пробела),
            // затем выводим поле в соответствие с форматом
            for (int i = 0; i < data.GetLength(0); i++)  
            {
                for (int j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] == 0)
                    {
                        Console.Write("   ");
                    }
                    else Console.Write(String.Format("{0,3}",data[i, j]));

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
