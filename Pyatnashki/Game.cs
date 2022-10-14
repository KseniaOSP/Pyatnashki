namespace Pyatnashki
{
    // представляет экземпляр игры "Пятнашки"
    public class Game
    {
        // игровое поле с числами от 0 до 15, где 0 - пустая клетка, а остальные - фишки
        int[,] field = new int[4,4];
        // индекс строки, в которой находится пустая клетка
        // (соответствует нулевой клетке в field)
        int emptyCellRow;
        // индекс столбца, в котором находится пустая клетка
        // (соответствует нулевой клетке в field)
        int emptyCellCol;

        // возвращает игровое поле с числами от 0 до 15, где 0 - пустая клетка, а остальные - фишки
        public int[,] GetData()
        {
            return field;  
        }
                
        // инициализирует поле случайным образом, но так, чтобы его можно было решить
        public void ValidRandomField()
        {
            int disorder;
            do 
            {
                RandomField();
                disorder = FindDisorder(field);
            }
            while (disorder % 2 != 0);
        }

        // инициализирует поле случайным образом
        private void RandomField()
        {
            Random random = new Random();

            List<int> list = Enumerable.Range(0,field.Length).OrderBy(x => random.Next()).ToList();

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = list[i * field.GetLength(1) + j];
                }
            }

            UpdateEmptyCell();
        }

        // обновляет координаты пустой клетки так, чтобы они соответствовали содержимому field
        private void UpdateEmptyCell()  
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {

                    if (field[i, j] == 0)
                    {
                        emptyCellRow = i;
                        emptyCellCol = j;
                    }
                }
            }
        }

        // осуществляет ход влево, если он возможен
        public void MoveLeft()
        {
            if (emptyCellCol != field.GetLength(1) - 1)
            { 
                field[emptyCellRow, emptyCellCol] = field[emptyCellRow, emptyCellCol + 1];
                field[emptyCellRow, emptyCellCol + 1] = 0;
                emptyCellCol++;
            }
        }
        
        // осуществляет ход вправо, если он возможен
        public void MoveRight()
        {
            if (emptyCellCol != 0)
            {
                field[emptyCellRow, emptyCellCol] = field[emptyCellRow, emptyCellCol - 1];
                field[emptyCellRow, emptyCellCol - 1] = 0;
                emptyCellCol--;
            }
        }
        
        // осуществляет ход вверх, если он возможен
        public void MoveUp()
        {
            if (emptyCellRow != field.GetLength(0) - 1)
            {
                field[emptyCellRow, emptyCellCol] = field[emptyCellRow + 1, emptyCellCol];
                field[emptyCellRow + 1, emptyCellCol] = 0;
                emptyCellRow++;
            }
        }
        
        // осуществляет ход вниз, если он возможен
        public void MoveDown()
        {
            if (emptyCellRow != 0)
            {
                field[emptyCellRow, emptyCellCol] = field[emptyCellRow - 1, emptyCellCol];
                field[emptyCellRow - 1, emptyCellCol] = 0;
                emptyCellRow--;
            }
        }

        // находит параметр беспорядка
        private int FindDisorder(int [,] field) 
        {
            // разворачиваем поле в одномерный массив
            int[] fieldDisorder = new int[field.Length]; 
            int z = 0;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    fieldDisorder[z] = field[i, j];
                    z++;
                }
            }

            // создаем счетчик count, куда будут складываться "беспорядки" (кол-во пар цифр, расположенных неправильно,
            // когда цифра расположенная впереди больше, чем те цифры, которые идут за ней)) 
            int count = 0;

            for (int i = 0; i < fieldDisorder.Length; i++)
            {
                for (int j = i + 1; j < fieldDisorder.Length; j++)
                {
                    if (fieldDisorder[i] > fieldDisorder[j] && fieldDisorder[j] != 0)
                        count++;
                }
            }
            return count + emptyCellRow + 1;
        }

        // определяет, является ли текущее поле победным
        public bool IsWinField()
        {
            int[,] winField = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };

            var winFieldCast = winField.Cast<int>();
            var gameFieldCast = field.Cast<int>();
            return winFieldCast.SequenceEqual(gameFieldCast);
        }

        // устанавливает заданное поле (используется только тестами)
        public void SetField(int[,] newfield)
        {
            // защитная копия, чтобы убедиться, что снаружи никто менять не будет
            field = (int [,])newfield.Clone(); 
            UpdateEmptyCell();
        }
    }

}
