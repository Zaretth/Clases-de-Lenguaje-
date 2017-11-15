using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RectaPendiente
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D lucario;
        Vector2 positionLucario;
        Vector2 positionInicial;
        Vector2 posFinal;
        float movementX;
        float movementY;
        float m;
        float y;
        bool diagonalMove1;
        bool diagonalMove2;
        bool verticalMove;
        bool verticalMoveReverse;
        bool diagonalMoveReverse1;
        bool diagonalMoveReverse2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            lucario = Content.Load<Texture2D>(assetName: "lucario");
            positionLucario = new Vector2(x: 0, y: 0);
            positionInicial = new Vector2(x: 0, y: 0);
            posFinal = new Vector2(x: 800, y: 400);
            m = (posFinal.Y - positionInicial.Y) / (posFinal.X - positionInicial.Y);
            movementX = 5;
            movementY = 5;
            y = (m * movementX);

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

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (positionLucario.X <= 0 && positionLucario.Y <= 100)
            {
                diagonalMove1 = true;
            }
            if (positionLucario.X >= 700 && positionLucario.Y >= 350)
            {
                verticalMove = true;
                diagonalMove1 = false;
            }
            if(positionLucario.X >=700 && positionLucario.Y <= 0)
            {
                diagonalMove2 = true;
                verticalMove = false;
            }
            if(positionLucario.X <= 0 && positionLucario.Y >= 330)
            {
                diagonalMoveReverse1 = true;
                diagonalMove2 = false;
            }
            if(diagonalMove2 == true && diagonalMoveReverse1== true)
            {
                verticalMoveReverse = true;
                diagonalMove2 = false;
                diagonalMoveReverse1 = false;                    
            }
            if(verticalMove == true && verticalMoveReverse == true)
            {
                diagonalMoveReverse2 = true;
                verticalMove = false;
                verticalMoveReverse = false;
            }
            if(diagonalMoveReverse2 == true && diagonalMove1 == true)
            {
                diagonalMoveReverse2 = false;
            }
            if (diagonalMove1 == true)
            {
                positionLucario += new Vector2(movementX, y);
            }
            if (verticalMove == true)
            {
                positionLucario += new Vector2(0, movementY* -1);
            }
            if (diagonalMove2 == true)
            {
                positionLucario -= new Vector2(movementX, y *-1);
            }
            if(diagonalMoveReverse1 == true)
            {
                positionLucario += new Vector2(movementX, y * -1);
            }
            if(verticalMoveReverse == true)
            {
                positionLucario += new Vector2(0, movementY);        
            }
            if(diagonalMoveReverse2 == true)
            {
                positionLucario -= new Vector2(movementX, y);
            }
            


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            spriteBatch.Begin();
            spriteBatch.Draw(lucario, positionLucario);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
