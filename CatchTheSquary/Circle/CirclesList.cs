using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace CatchTheSquary
{
    class CirclesList
    {
        private static int MovementSpeed = 5;
        private static int windowWidth = 800;
        private static int windowHeight = 600;

        private List<Circle> circles;
        public bool CircleHasRemoved;
        public Circle RemovedCircle;

        public CirclesList()
        {
            circles = new List<Circle>();
        }
        public void Reset()
        {
            CircleHasRemoved = false;
            RemovedCircle = null;
            circles.Clear();
        }

        public void Update(RenderWindow win)
        {
            CircleHasRemoved = false;
            RemovedCircle = null;

            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
            {
                for (int i = 0; i < circles.Count; i++)
                {
                    circles[i].CheckMousePosition(Mouse.GetPosition(win));
                }
            }

            for (int i = 0; i < circles.Count; i++)
            {
                circles[i].Move();
                circles[i].Draw(win);

                if (circles[i].isActive == false)
                {
                    RemovedCircle = circles[i];
                    circles.Remove(circles[i]);
                    CircleHasRemoved = true;
                }

            }
        }

        public void SpawnPlayerCircle()
        {
            circles.Add(new PlayerCircle(new Vector2f(Mathf.Random.Next(0, windowWidth), Mathf.Random.Next(0, windowHeight)), 
                MovementSpeed, new IntRect(0, 0, windowWidth, windowHeight)));
        }
        public void SpawnEnemyCircle()
        {
            circles.Add(new EnemyCircle(new Vector2f(Mathf.Random.Next(0, windowWidth), Mathf.Random.Next(0, windowHeight)), 
                MovementSpeed, new IntRect(0, 0, windowWidth, windowHeight)));
        }
        public void SpawnBonusSquary()
        {
            circles.Add(new BonusCircle(new Vector2f(Mathf.Random.Next(0, windowWidth), Mathf.Random.Next(0, windowHeight)), 
                MovementSpeed, new IntRect(0, 0, windowWidth, windowHeight)));
        }
        public int GetCount()
        {
            return circles.Count;
        }

        public void ReturnDefaultSizeEnemyCircle()
        {
            for (int i = 0; i < circles.Count; i++)
            {

                if (circles[i] is EnemyCircle)
                {
                    circles[i].ReturnDefaultSize();
                }

            }
        }
    }
}
