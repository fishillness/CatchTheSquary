using System;
using SFML.Graphics;
using SFML.Window;

namespace CatchTheSquary
{
    class Program
    {
        public static string TypeFigure;
        public static Font mainFont;
        public static string typeWindow;
        private static Color Color = new Color(230, 230, 230);

        static void Main(string[] args)
        {
            RenderWindow window = new RenderWindow(new VideoMode(800, 600), "Game");
            window.Closed += Window_Closed;
            window.SetFramerateLimit(60);
            mainFont = new Font("comic.ttf");


            TypeFigure = "square";

            Game game = new Game();
            Settings settings = new Settings();
            typeWindow = "settings";
            
            while (window.IsOpen == true)
            {
                window.Clear(Color);
                
                window.DispatchEvents();
                if (typeWindow == "settings")
                    settings.Update(window);
                if (typeWindow == "game")
                    game.Update(window);

                window.Display();
            }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}