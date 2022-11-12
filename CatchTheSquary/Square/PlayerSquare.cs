using SFML.System;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquary
{
    public class PlayerSquare : Square
    {
        private static Color Color = new Color(50, 50, 50);
        private static float SizeStep = 10;
        private static float MaxSize = 30;
        public PlayerSquare(Vector2f position, float movementSpeed, IntRect movementBounds) : 
            base(position, movementSpeed, movementBounds) 
        {
            shape.FillColor = Color;
        }

        protected override void OnClick()
        {
            shape.Size -= new Vector2f(SizeStep, SizeStep);

            if (shape.Size.X < MaxSize)
            {
                isActive = false;
                return;
            }

            UpdateMovementTarget();
            shape.Position = movementTarget;
        }
    }
}
