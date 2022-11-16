namespace Pyatnashki
{
    // Обеспечивает взаимодействие с пользователем посредством консоли
    public class ConsoleUI
    {
        // Размер фишки.
        const int CELL_WIDTH = 8;
        const int CELL_HEIGHT = 5;

        ConsoleBuffer buffer = new ConsoleBuffer(4 * CELL_WIDTH, 4 * CELL_HEIGHT);

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

        // выводит игровое поле на консоль
        protected void Display(Game game)
        {
            buffer.Clear();

            int[,] field = game.GetData();

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    DrawCell(i, j, field[i, j]);
                }
            }

            buffer.Display();
        }

        void DrawCell(int row, int col, int value)
        {
            if (value == 0)
                // Это пустая ячейка, ничего не нужно отображать
                return;

            int rowCoord = row * CELL_HEIGHT;
            int colCoord = col * CELL_WIDTH;

            buffer.PutString(rowCoord + 0, colCoord, @"/======\");
            buffer.PutString(rowCoord + 1, colCoord, @"|      |");
            buffer.PutString(rowCoord + 2, colCoord, @"|      |");
            buffer.PutString(rowCoord + 3, colCoord, @"|      |");
            buffer.PutString(rowCoord + 4, colCoord, @"\======/");

            buffer.PutString(rowCoord + 2, colCoord + 3, String.Format("{0,2}", value));
        }
    }
}
