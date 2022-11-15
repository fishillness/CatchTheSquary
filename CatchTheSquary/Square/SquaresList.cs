using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace CatchTheSquary
{
    public class SquaresList
    {
        private static int MovementSpeed = 5;
        private static int windowWidth = 800;
        private static int windowHeight = 600;

        private List<Square> squares;
        public bool SquareHasRemoved;
        public Square RemovedSquare;

        public SquaresList()
        {
            squares = new List<Square>();
        }
        public void Reset()
        {
            SquareHasRemoved = false;
            RemovedSquare = null;
            squares.Clear();
        }

        public void Update(RenderWindow win)
        {
            SquareHasRemoved = false;
            RemovedSquare = null;

            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
            {
                for (int i = 0; i < squares.Count; i++)
                {
                    squares[i].CheckMousePosition(Mouse.GetPosition(win));
                }
            }

            for (int i = 0; i < squares.Count; i++)
            {
                squares[i].Move();
                squares[i].Draw(win);

                if (squares[i].isActive == false)
                {
                    RemovedSquare = squares[i];
                    squares.Remove(squares[i]);
                    SquareHasRemoved = true;
                }

            }
        }

        public void SpawnPlayerSquary()
        {
            squares.Add(new PlayerSquare(new Vector2f(Mathf.Random.Next(0, windowWidth), Mathf.Random.Next(0, windowHeight)), 
                MovementSpeed, new IntRect(0, 0, windowWidth, windowHeight)));
        }
        public void SpawnEnemySquary()
        {
            squares.Add(new EnemySquare(new Vector2f(Mathf.Random.Next(0, windowWidth), Mathf.Random.Next(0, windowHeight)), 
                MovementSpeed, new IntRect(0, 0, windowWidth, windowHeight)));
        }
        public void SpawnBonusSquary()
        {
            squares.Add(new BonusSquare(new Vector2f(Mathf.Random.Next(0, windowWidth), Mathf.Random.Next(0, windowHeight)), 
                MovementSpeed, new IntRect(0, 0, windowWidth, windowHeight)));
        }
        public int GetCount()
        {
            return squares.Count;
        }

        public void ReturnDefaultSizeEnemySquare()
        {
            for (int i = 0; i < squares.Count; i++)
            {
                
                if (squares[i] is EnemySquare)
                {
                    squares[i].ReturnDefaultSize();
                }

            }
        }
    }
}
