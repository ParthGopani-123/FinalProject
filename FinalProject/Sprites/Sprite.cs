using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Sprites
{
    class Sprite
    {
        ///protected KeyboardState currentKey;

        //protected KeyboardState previousKey;

        public Vector2 position;
       

        public Vector2 origin;

        public Color colour = Color.White;

        public float speed = 0f;

        //public float LifeSpan;

        public bool IsRemoved = false;

        protected Texture2D Texture;
        public Sprite(Texture2D texture)
        {
            Texture = texture;
        }

        public Rectangle Rectangle
        {
            get
            {
                if (Texture != null)
                {
                    return new Rectangle((int)position.X-(int)origin.X, (int)position.Y - (int)origin.Y, Texture.Width, Texture.Height);
                }
                throw new Exception("******");
            }
        }
        
        public virtual void Update(GameTime gameTime, List<Sprite> sprite)
        {
            Move();
        }

        public void Move()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                position.Y -= 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                position.Y += 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position.X -= 5;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position.X += 5;
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, position, Color.White);
        }

       
    }
}
