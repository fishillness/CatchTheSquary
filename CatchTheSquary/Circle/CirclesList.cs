using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquary
{
    class CirclesList
    {
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
            circles.Add(new PlayerCircle(new Vector2f(Mathf.Random.Next(0, 800), Mathf.Random.Next(0, 600)), 5, new IntRect(0, 0, 800, 600)));
        }
        public void SpawnEnemyCircle()
        {
            circles.Add(new EnemyCircle(new Vector2f(Mathf.Random.Next(0, 800), Mathf.Random.Next(0, 600)), 5, new IntRect(0, 0, 800, 600)));
        }

        public int GetCount()
        {
            return circles.Count;
        }
    }
}
