using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ClaseDeMonogame
{
    public class Game1 : Game
    {
        // Valores básicos
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Valores para LujoBall
        Texture2D lujoBall;
        Rectangle positionLujoBall;
        int speedBaseLujoBall;
        string ultimateKeyForX;
        string ultimateKeyForY;
        bool colissionNow;
        bool changeScene;

        // Valores para los muros
        Texture2D wall;
        Rectangle[] allPositionsWallLevel1;
        Rectangle[] allPositionsWallLevel2;

        // escenas 
        int scene;
        Rectangle newScene;


        // Mi método: Movimiento de lujoball.
        private void MovementLujoBall(GameTime gameTime)
        {
            // Cálculo de la velocidad
            int RealSpeedLujoBall = (int)(speedBaseLujoBall * gameTime.ElapsedGameTime.TotalSeconds);

            // Movimiento por -Y
            if ((Keyboard.GetState().IsKeyDown(Keys.S)) && (colissionNow == false))
            {
                positionLujoBall.Y += RealSpeedLujoBall;
                ultimateKeyForY = "S";
            }

            // Movimiento por +Y
            else if ((Keyboard.GetState().IsKeyDown(Keys.W)) && (colissionNow == false))
            {
                positionLujoBall.Y -= RealSpeedLujoBall;
                ultimateKeyForY = "W";
            }

            // Movimiento por +X
            if ((Keyboard.GetState().IsKeyDown(Keys.D)) && (colissionNow == false))
            {
                positionLujoBall.X += RealSpeedLujoBall;
                ultimateKeyForX = "D";
            }

            // Movimiento por -X
            else if ((Keyboard.GetState().IsKeyDown(Keys.A)) && (colissionNow == false))
            {
                positionLujoBall.X -= RealSpeedLujoBall;
                ultimateKeyForX = "A";
            }

            Rectangle collissionObject = CheckCollision();

            if (positionLujoBall.Intersects(collissionObject))
            {
                // Movimiento por -Y
                if (ultimateKeyForY == "S")
                    positionLujoBall.Y -= RealSpeedLujoBall;

                // Movimiento por +Y
                else if (ultimateKeyForY == "W")
                    positionLujoBall.Y += RealSpeedLujoBall;

                // Movimiento por +X
                if (ultimateKeyForX == "D")
                    positionLujoBall.X -= RealSpeedLujoBall;

                // Movimiento por -X
                else if (ultimateKeyForX == "A")
                    positionLujoBall.X += RealSpeedLujoBall;

                colissionNow = true;
            }

            else
            {
                colissionNow = false;
                ultimateKeyForX = null;
                ultimateKeyForY = null;
            }
        }

        // cambio de escena.
        void SceneManager()
        {
            if (positionLujoBall.Intersects(newScene))
            {
                scene++;
                changeScene = true;
            }

            if ((scene == 1) && (changeScene == true))
            {
                positionLujoBall = new Rectangle(10, 10, 20, 20);
                changeScene = false;
            }
            else if ((scene == 2) && (changeScene == true))
            {
                positionLujoBall = new Rectangle(4, 244, 20, 20);
                changeScene = false;
            }
        }
        // posicion para newScene.
        void NewNewScene()
        {
            if (scene == 1)
            {
                newScene = new Rectangle(x: 790, y: 450, width: 30, height: 50);
            }
            else if (scene == 2)
            {
                newScene = new Rectangle(790, 10, 10, 200);
            }
        }

        // seleccion de nivel
        void Selection()
        {
            if (scene == 0)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    scene++;
                }
                if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.NumPad1)) || (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D1)))
                {
                    scene = 1;
                }
                if ((GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.NumPad2)) || (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D2)))
                {
                    scene = 2;
                }
            }
        }

        // Juego base.
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        // Método Initialize: Inicializa todos los valores globales.
        protected override void Initialize()
        {
            changeScene = true;
            // Inicializando los valores la LujoBall.
            positionLujoBall = new Rectangle(10, 10, 20, 20);
            speedBaseLujoBall = 400;

            // Inicializando los valores para los muros del nivel 1.
            allPositionsWallLevel1 = new Rectangle[]
            {
                // Margenes
                new Rectangle(x: 000, y:-001, width: 800, height: 001),
                new Rectangle(x: 000, y: 480, width: 800, height: 001),
                new Rectangle(x:-001, y: 000, width: 001, height: 480),
                new Rectangle(x: 801, y: 000, width: 001, height: 480),

                // Horizontales
                new Rectangle(x:080, y:035, width:720, height:010),
                new Rectangle(x:080, y:115, width:080, height:010),
                new Rectangle(x:320, y:115, width:080, height:010),
                new Rectangle(x:560, y:115, width:160, height:010),
                new Rectangle(x:080, y:195, width:240, height:010),
                new Rectangle(x:400, y:195, width:080, height:010),
                new Rectangle(x:720, y:195, width:080, height:010),
                new Rectangle(x:000, y:275, width:080, height:010),
                new Rectangle(x:240, y:275, width:090, height:010),
                new Rectangle(x:480, y:275, width:160, height:010),
                new Rectangle(x:080, y:355, width:170, height:010),
                new Rectangle(x:400, y:355, width:170, height:010),
                new Rectangle(x:640, y:355, width:160, height:010),
                new Rectangle(x:000, y:435, width:720, height:010),

                // Verticales
                new Rectangle(x:790, y:035, width:010, height:410),
                new Rectangle(x:240, y:035, width:010, height:160),
                new Rectangle(x:080, y:115, width:010, height:080),
                new Rectangle(x:400, y:115, width:010, height:080),
                new Rectangle(x:560, y:115, width:010, height:080),
                new Rectangle(x:640, y:115, width:010, height:170),
                new Rectangle(x:160, y:195, width:010, height:080),
                new Rectangle(x:320, y:195, width:010, height:080),
                new Rectangle(x:480, y:195, width:010, height:080),
                new Rectangle(x:720, y:195, width:010, height:080),
                new Rectangle(x:240, y:275, width:010, height:080),
                new Rectangle(x:400, y:275, width:010, height:080),
                new Rectangle(x:560, y:275, width:010, height:080),
                new Rectangle(x:320, y:355, width:010, height:080),
                new Rectangle(x:480, y:355, width:010, height:080),
                new Rectangle(x:000, y:035, width:010, height:400)
            };

            //||>inicializando los valores para los muros del nivel 2.
            allPositionsWallLevel2 = new Rectangle[]
            {
                // Margenes
                new Rectangle(x: 000, y:-001, width: 800, height: 001),
                new Rectangle(x: 000, y: 480, width: 800, height: 001),
                new Rectangle(x:-001, y: 000, width: 001, height: 480),
                new Rectangle(x: 801, y: 000, width: 001, height: 480),

                //||> Horizontales 
                new Rectangle(x:000, y:000, width:800, height:010),
                new Rectangle(x:050, y:100, width:050, height:010),
                new Rectangle(x:250, y:100, width:600, height:010),
                new Rectangle(x:010, y:200, width:700, height:010),               
                new Rectangle(x:010, y:300, width:100, height:010),
                new Rectangle(x:050, y:400, width:150, height:010),
                new Rectangle(x:700, y:350, width:100, height:010),
                new Rectangle(x:010, y:470, width:780, height:010),

                //||>Adicionales 
                new Rectangle(x:210, y:350, width:200, height:010),

                //||> Verticales 
                new Rectangle(x:000, y:010, width:010, height:200),
                new Rectangle(x:100, y:010, width:010, height:150),
                new Rectangle(x:790, y:110, width:010, height:370),
                new Rectangle(x:000, y:300, width:010, height:180),
                new Rectangle(x:200, y:210, width:010, height:200),
                new Rectangle(x:500, y:270, width:010, height:200),
                
                //||>Adicionales 
                new Rectangle(x:400, y:010, width:010, height:050),
                new Rectangle(x:500, y:050, width:010, height:050),
                new Rectangle(x:600, y:010, width:010, height:050),
                new Rectangle(x:700, y:050, width:010, height:050),
                new Rectangle(x:350, y:400, width:010, height:070),
            };

            // Escena
            scene = 0;
            newScene = new Rectangle(0, 0, 0, 0);

            base.Initialize();
        }

        // Método Load: Carga elementos del juego
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            lujoBall = Content.Load<Texture2D>("LujoBall");
            wall = Content.Load<Texture2D>("Wall");
        }

        // Método Unload: Elimina elementos del juego.
        protected override void UnloadContent()
        {
            // Unload any non ContentManager content here
        }

        // Mi método: Colisión de lujoball con wall.
        private Rectangle CheckCollision()
        {
            // Rectangulo base.
            Rectangle Check = new Rectangle(0, 0, 0, 0);

            // Analizando intersecciones.
            if (scene == 1)
            {
                foreach (Rectangle positions in allPositionsWallLevel1)
                {
                    // Análisis final de intersecciones
                    if (positionLujoBall.Intersects(positions))
                    {
                        Check = positions;
                        break;
                    }
                }
            }
            if (scene == 2)
            {
                foreach (Rectangle positions in allPositionsWallLevel2)
                {
                    // Análisis final de intersecciones
                    if (positionLujoBall.Intersects(positions))
                    {
                        Check = positions;
                        break;
                    }
                }
            }

            // Envía un resultado.
            return Check;
        }

 


        // Método Update: Actualiza y ejecuta las ordenes.
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            if ((scene == 1) || (scene == 2))
            {
                MovementLujoBall(gameTime);
                SceneManager();
            }

            // seleccion de escena 
            Selection();

            // cambio de escena.
            NewNewScene();


            // Límites, Colisiónes y movimiento;
            MovementLujoBall(gameTime);

            base.Update(gameTime);
        }

        // Método Draw: Dibuja todos los sprite en la pantalla.
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(222, 222, 222));

            spriteBatch.Begin();

            if (scene == 0)
            {
                GraphicsDevice.Clear(new Color(0, 0, 0));
            }
            else if (scene == 1)
            {
                // Dibujando elementos.
                spriteBatch.Draw(wall, newScene, Color.Blue);
                spriteBatch.Draw(lujoBall, positionLujoBall, Color.White);
                foreach (Rectangle positions in allPositionsWallLevel1)
                {
                    spriteBatch.Draw(wall, positions, Color.White);
                }
            }
            else if (scene == 2)
            {
                spriteBatch.Draw(wall, newScene, Color.Blue);
                spriteBatch.Draw(lujoBall, positionLujoBall, Color.White);
                foreach (Rectangle positions in allPositionsWallLevel2)
                {
                    spriteBatch.Draw(wall, positions, Color.White);
                }
            }

            // Dibujando elementos.


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}