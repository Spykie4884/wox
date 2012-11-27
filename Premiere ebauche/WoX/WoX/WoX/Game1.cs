using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace WoX
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D sol, perso;
        Rectangle psol, pperso;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            sol = Content.Load<Texture2D>("sol");
            perso = Content.Load<Texture2D>("perso");
            psol = new Rectangle(0, 350, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            pperso = new Rectangle(0, 0, perso.Width, perso.Height);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if ( (Keyboard.GetState().IsKeyDown(Keys.Right)) && ((pperso.X + perso.Width) < GraphicsDevice.Viewport.Width))
            {
                pperso.X += 10;
            }

            if ( (Keyboard.GetState().IsKeyDown(Keys.Left)) && (pperso.X > 0))
            {
                pperso.X -= 10;

            }

            if ( (Keyboard.GetState().IsKeyDown(Keys.Up)) && pperso.Y > 0)
            {
                pperso.Y -= 10;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {

                pperso.Y += 10;

                if (pperso.Intersects(psol))
                {
                    pperso.Y -= 10;
                }

            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(sol, psol, Color.White);
            spriteBatch.Draw(perso, pperso, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
