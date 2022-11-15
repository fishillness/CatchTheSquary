using SFML.Window;
using SFML.System;
using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatchTheSquary
{
    public class Game
    {
        public static int Scores;
        public static bool Islost;

        private Text scoreText;
        private Text loseText;

        private SquaresList squares;
        private CirclesList circles;
        private int MaxScores;
        public Game()
        {
            squares = new SquaresList();
            circles = new CirclesList();

            scoreText = new Text();
            scoreText.Font = Program.mainFont;
            scoreText.FillColor = Color.Black;
            scoreText.CharacterSize = 16;
            scoreText.Position = new Vector2f(10, 10);

            loseText = new Text();
            loseText.Font = Program.mainFont;
            loseText.FillColor = Color.Black;
            loseText.DisplayedString = "Ты проиграл! Нажми R, чтобы перезапустить игру!";
            loseText.Position = new Vector2f(20, 290);

            Reset();
        }
        private void Reset()
        {
            Scores = 0;
            Islost = false;
            switch (Program.TypeFigure)
            {
                case "square":
                    squares.Reset();
                    squares.SpawnPlayerSquary();
                    squares.SpawnEnemySquary();
                    break;
                case "circle":
                    circles.Reset();
                    circles.SpawnPlayerCircle();
                    circles.SpawnEnemyCircle();
                    break;
            }

        }
        public void Update(RenderWindow win)
        {
            if (Islost == true)
            {
                win.Draw(loseText);
                if (Scores > MaxScores)
                    MaxScores = Scores;

                if (Keyboard.IsKeyPressed(Keyboard.Key.R) == true)
                {
                    Reset();
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.S) == true)
                {
                    Program.typeWindow = "settings";
                    Reset();
                }
            }
            if (Islost == false)
            {
                switch (Program.TypeFigure)
                {
                    case "square":


                        squares.Update(win);

                        if (squares.SquareHasRemoved == true)
                        {
                            if (squares.RemovedSquare is PlayerSquare)
                            {
                                squares.SpawnPlayerSquary();
                            }
                            /*if (squares.RemovedSquare is EnemySquare)
                             {
                                squares.SpawnEnemySquary();
                            }*/
                        }
                        break;
                    case "circle":
                        if (circles.GetCount() == 0)
                        {
                            Reset();
                        }

                        circles.Update(win);

                        if (circles.CircleHasRemoved == true)
                        {
                            if (circles.RemovedCircle is PlayerCircle)
                            {
                                circles.SpawnPlayerCircle();
                            }
                        }
                        break;
                }
            }

            scoreText.DisplayedString = $"Score: {Scores.ToString()} \nMax: {MaxScores.ToString()}";
            win.Draw(scoreText);
        }


    }
}


/*
  switch (Settings.TypeFigure)
            {
                case "square":

                    break;
                case "circle":

                    break;
            }

*/