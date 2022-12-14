using SFML.Graphics;
using SFML.System;

namespace CatchTheSquary
{
    public class Circle
    {
        public static int DefaultSize = 50;

        public bool isActive = true;
        protected CircleShape shape;
        protected float movementSpeed;
        protected Vector2f movementTarget;
        protected IntRect movementBounds;

        public Circle(Vector2f position, float movementSpeed, IntRect movementBounds)
        {
            shape = new CircleShape(DefaultSize);
            shape.Position = position;

            this.movementSpeed = movementSpeed;
            this.movementBounds = movementBounds;

            UpdateMovementTarget();
        }

        public void Move()
        {
            shape.Position = Mathf.MoveTowards(shape.Position, movementTarget, movementSpeed);

            if (shape.Position == movementTarget)
            {
                OnReachedTarget();
                UpdateMovementTarget();
            }
        }
        public void CheckMousePosition(Vector2i mousePos)
        {
            if (isActive == false) return;

            if (mousePos.X > shape.Position.X - shape.Radius && mousePos.X < shape.Position.X + shape.Radius &&
                mousePos.Y > shape.Position.Y - shape.Radius && mousePos.Y < shape.Position.Y + shape.Radius)
                OnClick();
        }
        public void Draw(RenderWindow win)
        {
            if (isActive == false) return;

            win.Draw(shape);
        }
        protected void UpdateMovementTarget()
        {
            movementTarget.X = Mathf.Random.Next(movementBounds.Left, movementBounds.Left + movementBounds.Width);
            movementTarget.Y = Mathf.Random.Next(movementBounds.Top, movementBounds.Top + movementBounds.Height);
        }

        public void ReturnDefaultSize()
        {
            shape.Radius = DefaultSize;
        }

        protected virtual void OnClick() { }
        protected virtual void OnReachedTarget() { }
    }
}
