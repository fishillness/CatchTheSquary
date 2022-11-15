using SFML.Graphics;
using SFML.System;

namespace CatchTheSquary
{
    class EnemySprite : SpriteF
    {
        private static float MovementStep = 0.05f;
        private static float MaxSize = 128;
        private static float MaxMovementSpeed = 3;
        public static int DefaultSize = 32;
        public EnemySprite(Vector2f position, float movementSpeed, IntRect movementBounds) :
               base(position, movementSpeed, movementBounds)
        {
            shape.Texture = enemyBall32;
            size = DefaultSize;
        }

        protected override void OnClick()
        {
            Game.Islost = true;
        }
        protected override void OnReachedTarget()
        {
            if (movementSpeed < MaxMovementSpeed)
                movementSpeed += MovementStep;
            if (size < MaxSize)
                size *= 2;
            switch (size)
            {
                case 128:
                    shape.Texture = enemyBall128;
                    break;
                case 64:
                    shape.Texture = enemyBall64;
                    break;
                case 32:
                    shape.Texture = enemyBall32;
                    break;
            }
        }
    }
}
