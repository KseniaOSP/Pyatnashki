namespace Pyatnashki
{
   // Буфер для вывода символов на консоль.
   // Позволяет сформировать содержимое консоли до вывода на консоль.
    public class ConsoleBuffer
    {
        readonly int width;
        readonly int height;

        readonly char[,] buffer;

        public ConsoleBuffer(int width, int height)
        {
            this.width = width;
            this.height = height;
            buffer = new char[height, width];
        }

        // Очищает буфер (заполняет пробелами).
        public void Clear()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    buffer[i, j] = ' ';
                }
            }
        }

        // Записывает строку в буфер, начиная с указанных координат.
        public void PutString(int row, int col, string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                buffer[row, col + i] = str[i];
            }
        }

        // Выводит содержимое буфера на консоль.
        public void Display()
        {
            Console.Clear();

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(buffer[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}