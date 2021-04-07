using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D pixel;

        Rectangle ball = new Rectangle(100, 100, 20, 20);
        Rectangle left_paddle = new Rectangle(10, 150, 20, 150);
        Rectangle right_paddle = new Rectangle(700, 150, 20, 150);

        int x_speed = 2;
        int y_speed = 2;
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
            pixel = Content.Load<Texture2D>("pixel");
        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                right_paddle.Y -= 5;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                right_paddle.Y += 5;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                left_paddle.Y -= 5;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                left_paddle.Y += 5;

            if (left_paddle.Y < 0)
                left_paddle.Y = 0;
            if (left_paddle.Y > Window.ClientBounds.Height - left_paddle.Height)
                left_paddle.Y = Window.ClientBounds.Height - left_paddle.Height;

            if (right_paddle.Y < 0)
                right_paddle.Y = 0;
            if (right_paddle.Y > Window.ClientBounds.Height - right_paddle.Height)
                right_paddle.Y = Window.ClientBounds.Height - right_paddle.Height;

            ball.X += x_speed;
            ball.Y += y_speed;

            if (ball.Y < 0 || ball.Y > Window.ClientBounds.Height - ball.Height)
                y_speed *= -1;

            if (ball.Intersects(left_paddle) || ball.Intersects(right_paddle))
                x_speed *= -1;

            if (ball.X < 0 || ball.X > Window.ClientBounds.Width - ball.Width)
                Exit();

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spriteBatch.Draw(pixel, ball, Color.Green);
            spriteBatch.Draw(pixel, left_paddle, Color.Green);
            spriteBatch.Draw(pixel, right_paddle, Color.Green);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
