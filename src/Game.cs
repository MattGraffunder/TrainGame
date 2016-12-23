using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TrainGame.Input;

namespace TrainGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D squareTexture;

        MouseInput _mouseInput = new MouseInput();
        KeyboardInput _keyboardInput = new KeyboardInput();

        const int _screenHeight = 600;
        const int _screenWidth = 600;

        const int _gridHeight = 60;
        const int _gridWidth = 60;

        int _gridDrawHeight;
        int _gridDrawWidth;        

        byte[,] _grid = new byte[_gridHeight, _gridWidth];

        int _lastYIndexToggled = -1;
        int _lastXIndexToggled = -1;
        Point _lastMousePosition = new Point(-1, -1);
        int _lastType = -1;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 600;
            graphics.ApplyChanges();

            IsMouseVisible = true;

            _gridDrawHeight = _screenHeight / _gridHeight;
            _gridDrawWidth = _screenWidth / _gridWidth;
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

            // TODO: use this.Content to load your game content here
            squareTexture = Content.Load<Texture2D>("Images/Square");            
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

            _mouseInput.Update(gameTime);
            _keyboardInput.Update(gameTime);

            // TODO: Add your update logic here
            if (_mouseInput.Toggle && _mouseInput.Position != _lastMousePosition)
            {
                _lastMousePosition = _mouseInput.Position;

                //Get Square to toggle
                int xIndex = _mouseInput.Position.X / _gridDrawWidth;
                int yIndex = _mouseInput.Position.Y / _gridDrawHeight;
                byte type = _keyboardInput.Delete == true ? (byte)0 : (byte)1;

                if (xIndex != _lastXIndexToggled || yIndex != _lastYIndexToggled || _lastType != type)
                {
                    try
                    {   
                        _grid[yIndex, xIndex] = type;
                        _lastYIndexToggled = yIndex;
                        _lastXIndexToggled = xIndex;
                        _lastType = type;
                    }
                    catch (IndexOutOfRangeException)
                    {
                        //Ignore
                    }   
                }              
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightGreen);

            spriteBatch.Begin();

            // TODO: Add your drawing code here
            //var view = GraphicsDevice.Viewport;
            //view.Height = 300;
            //view.Width = 300;

            //GraphicsDevice.Viewport.Height = 300;
            //GraphicsDevice.Viewport.Width = 300;

            //Draw Grid

            //int height = 200;
            //int width = 200;
            for (int y = 0; y < _gridHeight; y++)
            {
                int yPosition = _gridDrawHeight * y;
                for (int x = 0; x < _gridWidth; x++)
                {
                    int xPosition = _gridDrawWidth * x;
                    //Draw tile

                    switch (_grid[y, x])
                    {
                        case 1:
                            spriteBatch.Draw(squareTexture, new Rectangle(xPosition, yPosition, _gridDrawWidth, _gridDrawHeight), Color.Gray);
                            break;
                        case 2:
                            spriteBatch.Draw(squareTexture, new Rectangle(xPosition, yPosition, _gridDrawWidth, _gridDrawHeight), Color.Green);
                            break;
                        default:
                            break;
                    }
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}