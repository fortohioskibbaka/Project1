using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project1

{
    enum Screen
    {
        intro, main, end



    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D introtexture;
        Texture2D mainback;
        Texture2D pt;
        Rectangle ptrect;
        Vector2 ptspeed;
        Texture2D endbacktexture;
        Rectangle window;
        SoundEffect introsound;
        SoundEffectInstance introsoundInstance;
        float seconds;
        Texture2D dino;
        Rectangle dinoRect;
        Vector2 dinoSpeed;
        SpriteFont textfont;
        Texture2D per;
        Rectangle perRect;
        Vector2 perSpeed;
        Screen Screen;

        MouseState mouseState;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            dinoRect = new Rectangle(500, 200, 300, 400);
            dinoSpeed = new Vector2(2, 0);

            perRect = new Rectangle(300, 500, 100, 100);
            perSpeed = new Vector2(2, 0);

            ptrect = new Rectangle(300, 200, 300, 100);
            ptspeed = new Vector2(2, 0);

            _graphics.ApplyChanges();
            seconds = 10;

            Screen = Screen.intro;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            introsound = Content.Load<SoundEffect>("soundd");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            introtexture = Content.Load<Texture2D>("ark");
            textfont = Content.Load<SpriteFont>("TextFont");
            mainback = Content.Load<Texture2D>("pix");
            dino = Content.Load<Texture2D>("dino (2)");
            per = Content.Load<Texture2D>("person");
            pt = Content.Load<Texture2D>("pt");

            endbacktexture = Content.Load<Texture2D>("blood");
            introsoundInstance = introsound.CreateInstance();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            seconds -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            if (Screen == Screen.intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    Screen = Screen.main;

               
                    
                

                
            }
            else if (Screen == Screen.main)
            {
                if(dinoRect.X >= 0)
                    introsoundInstance.Play();

                dinoRect.X += (int)dinoSpeed. X;
                dinoRect.Y += (int)dinoSpeed.Y;
                if (dinoRect.Right > window.Width )
                {
                    dinoSpeed.X *= -1;

                    

                }
                perRect.X += (int)perSpeed.X;
                perRect.Y += (int)perSpeed.Y;
                if (perRect.Right > 400)
                {
                    perSpeed.X *= -1;



                }
                ptrect.X = (int)ptspeed.X;
                ptrect.Y = (int)ptspeed.Y;
                if (ptrect.Right > window.Width)
                {
                    perSpeed.X *= -1;



                }
                if (introsoundInstance.State == SoundState.Stopped)
                {
                    Screen = Screen.end;
                }



            }

                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            if (Screen == Screen.intro)
            {
                _spriteBatch.Draw(introtexture, window, Color.White);
                _spriteBatch.DrawString(textfont, "click to continune", new Vector2(280, 500), Color.Red);
               




            }
            else if (Screen == Screen.main)
            {

                _spriteBatch.Draw(mainback, window, Color.White);
                _spriteBatch.Draw(dino,dinoRect,  Color.White);
                _spriteBatch.Draw(per, perRect, Color.White);
                _spriteBatch.Draw(pt, ptrect, Color.White);
                


            }
            else if (Screen == Screen.end)
            {
                _spriteBatch.Draw(endbacktexture, window, Color.White);

                _spriteBatch.DrawString(textfont, "press enter to end", new Vector2(280, 500), Color.Red);
                _spriteBatch.DrawString(textfont, "you died ", new Vector2(350, 300), Color.Red);
                if (mouseState.LeftButton == ButtonState.Pressed)

                {

                    Exit();

                }


            }
                _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
