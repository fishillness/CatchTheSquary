using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquary
{
    class Program
    {
        public static Random Random = new Random();
        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Game");
            window.Closed += Window_Closed;
            window.SetFramerateLimit(60);

            List<Square> squares = new List<Square>();
            squares.Add( new PlayerSquare(new Vector2f(100, 100), 10, new IntRect(0, 0, 800, 600 )) );
            squares.Add(new PlayerSquare(new Vector2f(100, 100), 10, new IntRect(0, 0, 800, 600)));
            squares.Add(new PlayerSquare(new Vector2f(100, 100), 10, new IntRect(0, 0, 800, 600)));
            squares.Add(new EnemySquare(new Vector2f(200, 100), 10, new IntRect(0, 0, 800, 600)));


            while (window.IsOpen == true)
            {
                window.Clear(new Color(230, 230, 230));
                
                window.DispatchEvents();

                if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
                {
                    for (int i = 0; i < squares.Count; i++)
                    {
                        squares[i].CheckMousePosition(Mouse.GetPosition(window));
                    }
                }

                for (int i = 0; i < squares.Count; i++)
                {
                    squares[i].Move();
                    squares[i].Draw(window);
                }

                window.Display();
            }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}