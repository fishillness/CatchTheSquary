using SFML.Window;
using SFML.System;
using SFML.Graphics;

namespace CatchTheSquary
{
    public class Game
    {
        public static int Scores;
        public static bool Islost;
        private static uint textScoreSize = 16;
        private static uint textSize = 20;

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
            scoreText.CharacterSize = textScoreSize;
            scoreText.Position = new Vector2f(10, 10);

            loseText = new Text();
            loseText.Font = Program.mainFont;
            loseText.FillColor = Color.Black;
            loseText.CharacterSize = textSize;
            loseText.DisplayedString = "Ты проиграл! \nНажми \"R\", чтобы перезапустить игру \nНажми \"S\", чтобы перейти в настройки";
            loseText.Position = new Vector2f(10, 290);

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
                    squares.SpawnPlayerSquary();
                    squares.SpawnEnemySquary();
                    break;
                case "circle":
                    circles.Reset();
                    circles.SpawnPlayerCircle();
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
                        if (squares.GetCount() == 0)
                        {
                            Reset();
                        }

                        squares.Update(win);

                        if (squares.SquareHasRemoved == true)
                        {
                            if (squares.RemovedSquare is PlayerSquare)
                            {
                                squares.SpawnPlayerSquary();
                            }
                            if (Mathf.Random.Next(0, 3) == 1)
                            {
                                squares.SpawnBonusSquary();
                            }
                        }

                        if (BonusSquare.IsGet == true)
                        {
                            squares.ReturnDefaultSizeEnemySquare();
                            BonusSquare.IsGet = false;
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

                            if (Mathf.Random.Next(0, 2) == 1)
                            {
                                circles.SpawnBonusSquary();
                            }
                        }


                        if (BonusCircle.IsGet == true)
                        {
                            circles.ReturnDefaultSizeEnemyCircle();
                            BonusCircle.IsGet = false;
                        }
                        break;
                }
            }

            scoreText.DisplayedString = $"Score: {Scores.ToString()} \nMax: {MaxScores.ToString()}";
            win.Draw(scoreText);
        }
    }
}