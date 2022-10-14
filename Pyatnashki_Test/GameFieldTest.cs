using Pyatnashki;

namespace Pyatnashki_Test

{
    public class GameFieldTest

    {
        [Fact]
        public void DetectsWinField()
        {
            Game gameField = new Game();
            int[,] winField = new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 } };
            gameField.SetField(winField);

            Assert.True(gameField.IsWinField());
        }
        
        [Fact]
        public void RejectsWinField()
        {
            Game gameField = new Game();
            int[,] anyField = new int[4, 4] { 
                { 1, 2, 4, 3 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 } };
            gameField.SetField(anyField);

            Assert.False(gameField.IsWinField());
        }
       
        [Fact]
        public void MovesLeftIfPossible()
        {
            Game gameField = new Game();
            gameField.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 0, 15 }
            });

            gameField.MoveLeft();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 }
            }, gameField.GetData());
        }
       
        [Fact]
        public void DoesNotMoveLeftIfImpossible()
        {
            Game gameField = new Game();
            gameField.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 }
            });

            gameField.MoveLeft();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 }
            }, gameField.GetData());
        }

        [Fact]
        public void MovesRightIfPossible()
        {
            Game gameField = new Game();
            gameField.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 0, 15 }
            });

            gameField.MoveRight();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 0, 14, 15 }
            }, gameField.GetData());
        }
        [Fact]
        public void DoesNotMoveIfImpossible()
        {
            Game gameField = new Game();
            gameField.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 0, 13, 14, 15 }
            });

            gameField.MoveRight();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 0, 13, 14, 15 }
            }, gameField.GetData());
        }
        [Fact]
        public void MovesUpIfPossible()
        {
            Game gameField = new Game();
            gameField.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 0, 11, 12 },
                { 13, 14, 10, 15 }
            });

            gameField.MoveUp();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 14, 11, 12 },
                { 13, 0, 10, 15 }
            }, gameField.GetData());
        }
        [Fact]
        public void DoesNotMoveUpIfImpossible()
        {
            Game gameField = new Game();
            gameField.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 0, 13, 14, 15 }
            });

            gameField.MoveUp();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 0, 13, 14, 15 }
            }, gameField.GetData());
        }

        [Fact]
        public void MovesDownIfPossible()
        {
            Game gameField = new Game();
            gameField.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 0, 11, 12 },
                { 13, 14, 10, 15 }
            });

            gameField.MoveDown();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 0, 7, 8 },
                { 9, 6, 11, 12 },
                { 13, 14, 10, 15 }
            }, gameField.GetData());
        }
        [Fact]
        public void DoesNotMoveDownIfImpossible()
        {
            Game gameField = new Game();
            gameField.SetField(new int[4, 4] {
                { 0, 2, 3, 4 },
                { 1, 6, 7, 8 },
                { 5, 10, 11, 12 },
                { 9, 13, 14, 15 }
            });

            gameField.MoveDown();

            Assert.Equal(new int[4, 4] {
                { 0, 2, 3, 4 },
                { 1, 6, 7, 8 },
                { 5, 10, 11, 12 },
                { 9, 13, 14, 15 }
            }, gameField.GetData());
        }
        [Fact]
        public void RandomFieldContainsAllNumbers()
        {
            Game gameField = new Game();
            
            gameField.ValidRandomField();

            int[,] field = gameField.GetData();

            var actualSet = new HashSet<int>(field.Cast<int>());
            var expectedSet = new HashSet<int>(Enumerable.Range(0,16));
            Assert.Equal(expectedSet, actualSet);   
        }
    }
}