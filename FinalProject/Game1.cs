using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using FinalProject.Sprites;


namespace FinalProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        protected KeyboardState currentKey;
        protected KeyboardState previousKey;

        public Texture2D texture;

        public Vector2 position;
        public Vector2 velocity;
        public Vector2 origin;
        public Vector2 direction;

        public float rotationVelocity = 2f;
        public float LinearVelocity = 5f;
        private float rotation;

        public float speed;

        //public static int ScreenWidth = 1900;
        //public static int ScreenHeight = 980;

        //public float Rotation
        //{
        //    get
        //    {
        //        return rotation;
        //    }
        //    set
        //    {
        //        rotation = value;
        //    }
        //}

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
            //graphics.PreferredBackBufferWidth = ScreenWidth;
            //graphics.PreferredBackBufferHeight=ScreenHeight;
            graphics.IsFullScreen = true;
            //graphics.ToggleFullScreen();
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            texture = Content.Load<Texture2D>("car_right");
            position = new Vector2(100, 100);
            origin = new Vector2(texture.Width/2, texture.Height/2);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        

        //public Matrix Transform
        //{
        //    get
        //    {
        //        return Matrix.CreateTranslation(new Vector3(-origin, 0)) * Matrix.CreateRotationZ(rotation) * Matrix.CreateTranslation(new Vector3(position, 0));
        //    }
        //}


        public Rectangle Rectangle
        {
            get
            {
                if (texture != null)
                {
                    return new Rectangle((int)position.X - (int)origin.X, (int)position.Y - (int)origin.Y, texture.Width, texture.Height);
                }
                throw new Exception("******");
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            previousKey = currentKey;
            currentKey = Keyboard.GetState();

            if(Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                rotation -= MathHelper.ToRadians(rotationVelocity);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                rotation += MathHelper.ToRadians(rotationVelocity);
            }

            direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                position += direction * LinearVelocity;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                position -= direction * LinearVelocity;
            }

            //position = Vector2.Clamp(position, new Vector2(0, 0), new Vector2(ScreenWidth - Rectangle.Width, ScreenHeight - Rectangle.Height));

            position.X = MathHelper.Clamp(position.X, 0, GraphicsDevice.Viewport.Width - texture.Width);
            position.Y = MathHelper.Clamp(position.Y, 0, GraphicsDevice.Viewport.Height - texture.Height);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    position.Y -= 5;
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Down))
            //{
            //    position.Y += 5;
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Left))
            //{
            //    position.X -= 5;
            //}

            //if (Keyboard.GetState().IsKeyDown(Keys.Right))
            //{
            //    position.X += 5;
            //}


            //foreach (var sprite1 in spriteList)
            // {
            //      sprite1.Update(gameTime, spriteList);
            // }

            base.Update(gameTime);

        }

        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SlateGray);

            spriteBatch.Begin();
            //spriteBatch.Draw(texture, position, Color.White);
            //foreach(var sprite1 in spriteList)
            //{
            //    sprite1.Draw(spriteBatch);
            //}
            spriteBatch.Draw(texture, position, null, Color.White, rotation, origin, 1, SpriteEffects.None, 0);
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
