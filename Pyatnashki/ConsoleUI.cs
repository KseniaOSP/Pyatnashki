namespace Pyatnashki
{
    // обеспечивает взаимодействие с пользователем посредством консоли
    public class ConsoleUI
    {
        // начинает игровую сессию
        internal void Play() 
        {
            Game game = new Game();
            game.ValidRandomField();

            while (!game.IsWinField()) 
            {
                Display(game);
                ConsoleKey key = ReadKey();
                ProcessKey(game, key); 
            }

            // отображаем победное поле
            Display(game);
            Console.WriteLine("Вы победили!");
            Console.ReadLine();
        }

        // обрабатывает нажатую клавишу 
        private void ProcessKey(Game game, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    game.MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    game.MoveRight();
                    break;
                case ConsoleKey.UpArrow:
                    game.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                    game.MoveDown();
                    break;
            }
        }

        // получает и вовращает нажатую пользователем клавишу
        private ConsoleKey ReadKey()
        {
            return Console.ReadKey().Key;
        }

        // выводит игровое поле на консоли
        private void Display(Game game) 
        {   
            Console.Clear();

            int[,] data = game.GetData();
            
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
