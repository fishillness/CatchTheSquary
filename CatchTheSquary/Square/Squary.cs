using System;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquary
{
    public class Squary
    {
        public bool isActive = true;
        private RectangleShape shape;
        private float movementSpeed;
        private Vector2f movementTarget;
        private IntRect movementBounds;

        public Squary(Vector2f position, float movementSpeed, IntRect movementBounds)
        {
            shape = new RectangleShape(new Vector2f(100, 100));
            shape.Position = position;

            this.movementSpeed = movementSpeed;
            this.movementBounds = movementBounds;

            UpdateMovementTarget();
        }

        public void Move()
        {
            Vector2f dir = movementTarget - shape.Position;
            float magnitude = (float)Math.Sqrt(dir.X * dir.X + dir.Y * dir.Y);

            if (magnitude <= movementSpeed)
            {
                shape.Position = movementTarget;
            }
            else
            {
                shape.Position += dir / magnitude * movementSpeed;
            }

            if (shape.Position == movementTarget)
            {
                UpdateMovementTarget();
            }
        }
        public void Draw(RenderWindow win)
        {
            if (isActive == false) return;

            win.Draw(shape);
        }
        private void UpdateMovementTarget()
        {
            Random rnd = new Random();
            movementTarget.X = rnd.Next(movementBounds.Left, movementBounds.Left + movementBounds.Width);
            movementTarget.Y = rnd.Next(movementBounds.Top, movementBounds.Top + movementBounds.Height);
        }

    }
}
