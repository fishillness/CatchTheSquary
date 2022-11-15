using SFML.System;
using SFML.Graphics;

namespace CatchTheSquary
{
    class PlayerSprite : SpriteF
    {
        private static float MaxSize = 12;
        public static int DefaultSize = 128;

        public PlayerSprite(Vector2f position, float movementSpeed, IntRect movementBounds) :
            base(position, movementSpeed, movementBounds)
        {
            shape.Texture = playerBall128;
            size = DefaultSize;
        }

        protected override void OnClick()
        {
            Game.Scores++;
            size /= 2;
            switch (size)
            {
                case 128:
                    shape.Texture = playerBall128;
                    break;
                case 64:
                    shape.Texture = playerBall64;
                    break;
                case 32:
                    shape.Texture = playerBall32;
                    break;
                case 24:
                    shape.Texture = playerBall24;
                    break;
            }

            if (size <= MaxSize)
            {
                isActive = false;
                return;
            }

            UpdateMovementTarget();
            shape.Position = movementTarget;
        }
    }
}
