using SFML.System;
using SFML.Graphics;


namespace CatchTheSquary
{
    class BonusSprite : SpriteF
    {
        public static bool IsGet = false;
        public BonusSprite(Vector2f position, float movementSpeed, IntRect movementBounds) :
            base(position, movementSpeed, movementBounds)
        {
            shape.Texture = bonusBall;
        }

        protected override void OnClick()
        {
            Game.Scores++;

            IsGet = true;
            isActive = false;
        }
    }

}
