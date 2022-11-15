using SFML.System;
using SFML.Graphics;

namespace CatchTheSquary
{
    class BonusSquare : Square
    {
        private static Color Color = new Color(255, 242, 0);
        public static bool IsGet = false;
        public BonusSquare(Vector2f position, float movementSpeed, IntRect movementBounds) :
            base(position, movementSpeed, movementBounds)
        {
            shape.FillColor = Color;
        }

        protected override void OnClick()
        {
            Game.Scores++;

            IsGet = true;
            isActive = false;
        }
    }
}
