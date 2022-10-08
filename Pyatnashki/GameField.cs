using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    public class GameField
    {
        int[,] field = new int[4,4];
        int emptyCellRow;
        int emptyCellCol;

        public int[,] GetData()
        {
            return field;  
        }

        
        // метод, который выводит поле, в котором только нужный нам параметр беспорядка
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

        // метод, который формирует рандомное поле
        private void RandomField()
        {
            Random random = new Random();

            List<int> list = Enumerable.Range(0,field.Length).OrderBy(x => random.Next()).ToList();

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = list[i*field.GetLength(1)+j];
                }
            }

            UpdateEmptyCell();
        }

        // метод, который обновляет координаты пустой клетки
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

        // Методы, которые определяют куда пойдет пустая клетка при движении влево/вправо/вниз/вверх
        public void MoveLeft()
        {
            
            if (emptyCellCol != field.GetLength(1)-1)
            { 
                field[emptyCellRow, emptyCellCol]=field[emptyCellRow, emptyCellCol+1];
                field[emptyCellRow, emptyCellCol + 1] = 0;
                emptyCellCol = emptyCellCol + 1;
            }
            
        }
        public void MoveRight()
        {
            if (emptyCellCol != 0)
            {
                field[emptyCellRow, emptyCellCol] = field[emptyCellRow, emptyCellCol - 1];
                field[emptyCellRow, emptyCellCol - 1] = 0;
                emptyCellCol = emptyCellCol - 1;
            }
        }
        public void MoveUp()
        {
            if (emptyCellRow != field.GetLength(0) - 1)
            {
                field[emptyCellRow, emptyCellCol] = field[emptyCellRow + 1, emptyCellCol];
                field[emptyCellRow + 1, emptyCellCol] = 0;
                emptyCellRow = emptyCellRow + 1;
            }
        }
        public void MoveDown()
        {
            if (emptyCellRow != 0)
            {
                field[emptyCellRow, emptyCellCol] = field[emptyCellRow - 1, emptyCellCol];
                field[emptyCellRow - 1, emptyCellCol] = 0;
                emptyCellRow = emptyCellRow - 1;
            }
        }

        // метод, который находит параметр беспорядка
        private int FindDisorder(int [,] field) 
        {
            // создаем одномерный массив, в который развернется наш двумерный массив (наше поле)
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
                    // если первая цифра больше, чем последующая, и последующая не равна нулю,
                    // увеличиваем значение счетчика на 1
                    if (fieldDisorder[i] > fieldDisorder[j] && fieldDisorder[j] != 0)
                        count++;
                }
            }
            // возвращаем счетчик + индекс ряда, в котором находится пустая клетка + 1
            return count+emptyCellRow+1;
        }

        // метод, который сравнивает победное поле с текущим полем
        public bool IsWinField()
        {
            int[,] winField = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };

            var winFieldCast = winField.Cast<int>();
            var gameFieldCast = field.Cast<int>();
            return winFieldCast.SequenceEqual(gameFieldCast);
        }

        public void SetField(int[,] newfield)
        {
            field = (int [,])newfield.Clone(); // защитная копия, чтобы убедиться, что снаружи никто менять не будет
            UpdateEmptyCell();
        }
    }

}
