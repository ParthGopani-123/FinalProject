using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FinalProject.Sprites
{
    class Player : Sprite
    {
        public bool HasDied = false;

        public Player(Texture2D texture) : base(texture)
        {
            position = new Vector2(30, 40);
            speed = 5f;
        }

        public override void Update(GameTime gametime, List<Sprite> sprite)
        {
            Move();
        }

        //public void Move()
        //{
        //    if (Keyboard.GetState().IsKeyDown(Keys.Up))
        //    {
        //        position.Y -= 5;
        //    }

        //    if (Keyboard.GetState().IsKeyDown(Keys.Down))
        //    {
        //        position.Y += 5;
        //    }

        //    if (Keyboard.GetState().IsKeyDown(Keys.Left))
        //    {
        //        position.X -= 5;
        //    }

        //    if (Keyboard.GetState().IsKeyDown(Keys.Right))
        //    {
        //        position.X += 5;
        //    }
       // }
    }
}
