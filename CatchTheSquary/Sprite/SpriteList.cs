using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace CatchTheSquary
{
    class SpriteList
    {
        private static int MovementSpeed = 5;
        private static int windowWidth = 800;
        private static int windowHeight = 600;

        private List<SpriteF> sprites;
        public bool SpriteHasRemoved;
        public SpriteF RemovedSprite;

        public SpriteList()
        {
            sprites = new List<SpriteF>();
        }
        public void Reset()
        {
            SpriteHasRemoved = false;
            RemovedSprite = null;
            sprites.Clear();
        }

        public void Update(RenderWindow win)
        {
            SpriteHasRemoved = false;
            RemovedSprite = null;

            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
            {
                for (int i = 0; i < sprites.Count; i++)
                {
                    sprites[i].CheckMousePosition(Mouse.GetPosition(win));
                }
            }

            for (int i = 0; i < sprites.Count; i++)
            {
                sprites[i].Move();
                sprites[i].Draw(win);

                if (sprites[i].isActive == false)
                {
                    RemovedSprite = sprites[i];
                    sprites.Remove(sprites[i]);
                    SpriteHasRemoved = true;
                }

            }
        }

        public void SpawnPlayerSprite()
        {
            sprites.Add(new PlayerSprite(new Vector2f(Mathf.Random.Next(0, windowWidth), Mathf.Random.Next(0, windowHeight)),
                MovementSpeed, new IntRect(0, 0, windowWidth, windowHeight)));
        }
        public void SpawnEnemySprite()
        {
            sprites.Add(new EnemySprite(new Vector2f(Mathf.Random.Next(0, windowWidth), Mathf.Random.Next(0, windowHeight)),
                MovementSpeed, new IntRect(0, 0, windowWidth, windowHeight)));
        }
        public void SpawnBonusSprite()
        {
            sprites.Add(new BonusSprite(new Vector2f(Mathf.Random.Next(0, windowWidth), Mathf.Random.Next(0, windowHeight)),
                MovementSpeed, new IntRect(0, 0, windowWidth, windowHeight)));
        }
        public int GetCount()
        {
            return sprites.Count;
        }

        public void ReturnDefaultSizeEnemySprite()
        {
            for (int i = 0; i < sprites.Count; i++)
            {

                if (sprites[i] is EnemySprite)
                {
                    sprites[i].ReturnDefaultSize();
                }

            }
        }
    }
}
