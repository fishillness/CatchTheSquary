using SFML.Graphics;
using SFML.System;

namespace CatchTheSquary
{
    class SpriteF
    {

        protected static Texture playerBall128 = new Texture("ball-128.png");
        protected static Texture playerBall64 = new Texture("ball-64.png");
        protected static Texture playerBall32 = new Texture("ball-32.png");
        protected static Texture playerBall24 = new Texture("ball-24.png");

        protected static Texture enemyBall128 = new Texture("enemyBall-128.png");
        protected static Texture enemyBall64 = new Texture("enemyBall-64.png");
        protected static Texture enemyBall32= new Texture("enemyBall-32.png");

        protected static Texture bonusBall = new Texture("bonusBall.png");


        public bool isActive = true;
        protected Sprite shape;
        protected int size;

        protected float movementSpeed;
        protected Vector2f movementTarget;
        protected IntRect movementBounds;

        public SpriteF(Vector2f position, float movementSpeed, IntRect movementBounds)
        {
            shape = new Sprite(playerBall128);
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

            if (mousePos.X > shape.Position.X && mousePos.X < shape.Position.X + shape.TextureRect.Width &&
                mousePos.Y > shape.Position.Y && mousePos.Y < shape.Position.Y + shape.TextureRect.Height)
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
            size = EnemySprite.DefaultSize;
        }

        protected virtual void OnClick() { }
        protected virtual void OnReachedTarget() { }
    }
}
