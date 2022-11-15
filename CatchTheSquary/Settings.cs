using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquary
{
    public class Settings
    {
        private static uint textSize = 16;

        private Text nameWindow;

        private Text squareType;
        private Text circleType;
        private Text spriteType;

        public Settings()
        {

            nameWindow = new Text();
            nameWindow.Font = Program.mainFont;
            nameWindow.FillColor = Color.Black;
            nameWindow.CharacterSize = textSize;
            nameWindow.DisplayedString = "Настройки";
            nameWindow.Position = new Vector2f(10, 10);

            squareType = new Text();
            squareType.Font = Program.mainFont;
            squareType.FillColor = Color.Red;
            squareType.CharacterSize = textSize;
            squareType.DisplayedString = "Квадрат Q";
            squareType.Position = new Vector2f(10, 30);

            circleType = new Text();
            circleType.Font = Program.mainFont;
            circleType.FillColor = Color.Black;
            circleType.CharacterSize = textSize;
            circleType.DisplayedString = "Круг W";
            circleType.Position = new Vector2f(10, 50);

            spriteType = new Text();
            spriteType.Font = Program.mainFont;
            spriteType.FillColor = Color.Black;
            spriteType.CharacterSize = textSize;
            spriteType.DisplayedString = "Спрайт E";
            spriteType.Position = new Vector2f(10, 70);
        }
        public void Update(RenderWindow win)
        {
            win.Draw(nameWindow);
            win.Draw(squareType);
            win.Draw(circleType);
            win.Draw(spriteType);

            if (Keyboard.IsKeyPressed(Keyboard.Key.G) == true)
            {
                Program.typeWindow = "game";
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Q) == true)
            {
                squareType.FillColor = Color.Red;
                circleType.FillColor = Color.Black;
                spriteType.FillColor = Color.Black;

                Program.TypeFigure = "square";
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W) == true)
            {
                squareType.FillColor = Color.Black;
                circleType.FillColor = Color.Red;
                spriteType.FillColor = Color.Black;

                Program.TypeFigure = "circle";
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.E) == true)
            {
                squareType.FillColor = Color.Black;
                circleType.FillColor = Color.Black;
                spriteType.FillColor = Color.Red;

                Program.TypeFigure = "sprite";
            }
        }
    }
}
