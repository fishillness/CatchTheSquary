using SFML.System;
using SFML.Graphics;

namespace CatchTheSquary
{
    class PlayerCircle : Circle
    {
        private static Color Color = new Color(50, 50, 50);
        private static float SizeStep = 10;
        private static float MaxSize = 20;
        public PlayerCircle(Vector2f position, float movementSpeed, IntRect movementBounds) :
            base(position, movementSpeed, movementBounds)
        {
            shape.FillColor = Color;
        }

        protected override void OnClick()
        {
            Game.Scores++;

            shape.Radius -= SizeStep;
            
            if (shape.Radius < MaxSize)
            {
                isActive = false;
                return;
            }

            UpdateMovementTarget();
            shape.Position = movementTarget;
        }
    }
}
