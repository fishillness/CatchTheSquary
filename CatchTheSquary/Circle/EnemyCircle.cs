using SFML.Graphics;
using SFML.System;

namespace CatchTheSquary
{
    class EnemyCircle : Circle
    {
        private static Color Color = new Color(230, 50, 50);
        private static float MovementStep = 0.05f;
        private static float SizeStep = 10;
        private static float MaxSize = 100;
        private static float MaxMovementSpeed = 3;
        public EnemyCircle(Vector2f position, float movementSpeed, IntRect movementBounds) :
               base(position, movementSpeed, movementBounds)
        {
            shape.FillColor = Color;
        }

        protected override void OnClick()
        {
            Game.Islost = true;
        }
        protected override void OnReachedTarget()
        {
            if (movementSpeed < MaxMovementSpeed)
                movementSpeed += MovementStep;
            if (shape.Radius < MaxSize)
                shape.Radius += SizeStep;
        }
    }
}
