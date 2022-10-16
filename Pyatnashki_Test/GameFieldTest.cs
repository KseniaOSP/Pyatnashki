using Pyatnashki;

namespace Pyatnashki_Test
{
    public class GameFieldTest
    {
        [Fact]
        public void DetectsWinField()
        {
            Game game = new Game();
            int[,] winField = new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 } };
            game.SetField(winField);

            Assert.True(game.IsWinField());
        }
        
        [Fact]
        public void RejectsWinField()
        {
            Game game = new Game();
            int[,] anyField = new int[4, 4] { 
                { 1, 2, 4, 3 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 } };
            game.SetField(anyField);

            Assert.False(game.IsWinField());
        }
       
        [Fact]
        public void MovesLeftIfPossible()
        {
            Game game = new Game();
            game.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 0, 15 }
            });

            game.MoveLeft();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 }
            }, game.GetData());
        }
       
        [Fact]
        public void DoesNotMoveLeftIfImpossible()
        {
            Game game = new Game();
            game.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 }
            });

            game.MoveLeft();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 0 }
            }, game.GetData());
        }

        [Fact]
        public void MovesRightIfPossible()
        {
            Game game = new Game();
            game.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 0, 15 }
            });

            game.MoveRight();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 0, 14, 15 }
            }, game.GetData());
        }
        
        [Fact]
        public void DoesNotMoveIfImpossible()
        {
            Game game = new Game();
            game.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 0, 13, 14, 15 }
            });

            game.MoveRight();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 0, 13, 14, 15 }
            }, game.GetData());
        }
        
        [Fact]
        public void MovesUpIfPossible()
        {
            Game game = new Game();
            game.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 0, 11, 12 },
                { 13, 14, 10, 15 }
            });

            game.MoveUp();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 14, 11, 12 },
                { 13, 0, 10, 15 }
            }, game.GetData());
        }
        
        [Fact]
        public void DoesNotMoveUpIfImpossible()
        {
            Game game = new Game();
            game.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 0, 13, 14, 15 }
            });

            game.MoveUp();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 0, 13, 14, 15 }
            }, game.GetData());
        }

        [Fact]
        public void MovesDownIfPossible()
        {
            Game game = new Game();
            game.SetField(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 0, 11, 12 },
                { 13, 14, 10, 15 }
            });

            game.MoveDown();

            Assert.Equal(new int[4, 4] {
                { 1, 2, 3, 4 },
                { 5, 0, 7, 8 },
                { 9, 6, 11, 12 },
                { 13, 14, 10, 15 }
            }, game.GetData());
        }
        
        [Fact]
        public void DoesNotMoveDownIfImpossible()
        {
            Game game = new Game();
            game.SetField(new int[4, 4] {
                { 0, 2, 3, 4 },
                { 1, 6, 7, 8 },
                { 5, 10, 11, 12 },
                { 9, 13, 14, 15 }
            });

            game.MoveDown();

            Assert.Equal(new int[4, 4] {
                { 0, 2, 3, 4 },
                { 1, 6, 7, 8 },
                { 5, 10, 11, 12 },
                { 9, 13, 14, 15 }
            }, game.GetData());
        }
        
        [Fact]
        public void RandomFieldContainsAllNumbers()
        {
            Game game = new Game();
            
            game.ValidRandomField();

            int[,] field = game.GetData();

            var actualSet = new HashSet<int>(field.Cast<int>());
            var expectedSet = new HashSet<int>(Enumerable.Range(0,16));
            Assert.Equal(expectedSet, actualSet);   
        }
        
        [Fact]
        public void ReturnsData()
        {
            Game game = new Game();

            game.SetField(new int[4, 4] {
                { 0, 2, 3, 4 },
                { 1, 6, 7, 8 },
                { 5, 10, 11, 12 },
                { 9, 13, 14, 15 } 
            });

            int[,] field = game.GetData();

            Assert.Equal(new int[4, 4] {
                { 0, 2, 3, 4 },
                { 1, 6, 7, 8 },
                { 5, 10, 11, 12 },
                { 9, 13, 14, 15 }
            }, field);
        }
    }
}