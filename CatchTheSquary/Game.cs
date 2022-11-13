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

        private Font mainFont;
        private Text scoreText;
        private Text loseText;

        private SquaresList squares;
        private int MaxScores;
        public Game()
        {
            mainFont = new Font("comic.ttf");
            squares = new SquaresList();

            scoreText = new Text();
            scoreText.Font = mainFont;
            scoreText.FillColor = Color.Black;
            scoreText.CharacterSize = 16;
            scoreText.Position = new Vector2f(10, 10);

            loseText = new Text();
            loseText.Font = mainFont;
            loseText.FillColor = Color.Black;
            loseText.DisplayedString = "Ты проиграл! Нажми R, чтобы перезапустить игру!";
            loseText.Position = new Vector2f(20, 290);

            Reset();
        }
        private void Reset()
        {
            squares.Reset();
            Scores = 0;
            Islost = false;

            squares.SpawnPlayerSquary();
            squares.SpawnEnemySquary();
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
            }
            if (Islost == false)
            {
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
            }

            scoreText.DisplayedString = $"Score: {Scores.ToString()} \nMax: {MaxScores.ToString()}";
            win.Draw(scoreText);
        }


    }
}
