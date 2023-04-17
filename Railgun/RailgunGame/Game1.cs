using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Railgun.RailgunGame.Tilemapping;
using Railgun.RailgunGame.Util;
using System.Collections.Generic;

namespace Railgun.RailgunGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;

        private Texture2D backgroundHealthUI;
        private Texture2D foregroundHealthUI;
        private Texture2D bulletUI;

        private Player mainPlayer;

        private List<Enemy> enemies;
        private List<Projectile> bulletRemovalList;

        private WorldManager world;

        #region Menu Elements
        // Textures used to display the Menu.
        private Texture2D menuLogo;
        private Texture2D menuPlay;
        private Texture2D menuOpti;
        private Texture2D menuQuit;

        // Rectangles to make the Menu usable.
        private Rectangle logoRect;
        private Rectangle playRect;
        private Rectangle optiRect;
        private Rectangle quitRect;
        #endregion

        #region Player, Enemy, Proj. Textures
        // Player, enemy, and projectile textures
        private Texture2D playerIdle;
        private Animation playerIdleAnim;
        
        private Texture2D playerRun;
        private Animation playerRunAnim;
        
        private Texture2D playerDeath;
        private Animation playerDeathAnim;
        
        private Texture2D bulletTexture;
        private Texture2D bulletCollideTexture;
        private Animation bulletCollideAnim;
        
        private Texture2D skeletonWalk;
        private Animation skeletonWalkAnim;
        
        private Texture2D skeletonDeath;
        private Animation skeletonDeathAnim;
        #endregion

        // Reticle
        private Texture2D gameReticle;

        private GameState currentGameState;

        private UI userInterface;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
        }
        
        /// <summary>
        /// Tracks the possible game states
        /// </summary>
        public enum GameState
        {
            Menu,
            Game,
            Pause,
            GameOver
        }

        protected override void Initialize()
        {
            #region Set Screen Resolution
            // I just set it to 1920x1080p cuz that's standard. We can change it later if needed, and full screen it when we're done.

            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.IsFullScreen = false;
            _graphics.ApplyChanges();
            #endregion

            currentGameState = GameState.Menu;
            font = this.Content.Load<SpriteFont>("Mynerve24");

            GameTime gameTime = new GameTime();
            enemies = new List<Enemy>();

            bulletRemovalList = new List<Projectile>();

            DebugLog.Instance.LogPersistant("?????", Color.White, 3);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            #region Texture Loading
            //UI Stuff
            backgroundHealthUI = Content.Load<Texture2D>("WhiteHealthSquare");
            foregroundHealthUI = Content.Load<Texture2D>("RedHealthSquare");
            bulletUI = Content.Load<Texture2D>("uiBullet");


            //Game Menu Stuff
            menuLogo = Content.Load<Texture2D>("menuLogo");
            menuPlay = Content.Load<Texture2D>("menuPlay");
            menuOpti = Content.Load<Texture2D>("menuOptions");
            menuQuit = Content.Load<Texture2D>("menuQuit");

            //Game Reticle
            gameReticle = Content.Load<Texture2D>("gameReticle");

            // Player, bullets, and enemies.
            playerIdle = Content.Load<Texture2D>("mainCharIdle");
            playerRun = Content.Load<Texture2D>("mainCharRun");
            playerDeath = Content.Load<Texture2D>("mainCharDeath");
            bulletTexture = Content.Load<Texture2D>($"bulletTexture");
            bulletCollideTexture = Content.Load<Texture2D>($"BulletBoom");
            skeletonWalk = Content.Load<Texture2D>($"Skeleton Walk");
            skeletonDeath = Content.Load<Texture2D>($"Skeleton Dead");

            #endregion

            playerIdleAnim = new Animation(playerIdle, 1, 6, 11.0f);
            playerRunAnim = new Animation(playerRun, 1, 8, 13.0f);
            bulletCollideAnim = new Animation(bulletCollideTexture, 4, 1, 12.4f);
            skeletonWalkAnim = new Animation(skeletonWalk, 1, 13, 12.0f);
            skeletonDeathAnim = new Animation(skeletonDeath, 1, 15, 12.0f);

            // This next line is just to test skeletons.
            Skeleton testSkelley = new Skeleton(skeletonWalkAnim.Clone(), skeletonDeathAnim.Clone(), new Rectangle(1700, 200, 100, 100));
            Skeleton ttestSkelley = new Skeleton(skeletonWalkAnim.Clone(), skeletonDeathAnim.Clone(), new Rectangle(200, 200, 100, 100));
            Skeleton tttestSkelley = new Skeleton(skeletonWalkAnim.Clone(), skeletonDeathAnim.Clone(), new Rectangle(700, 200, 100, 100));
            Skeleton ttttestSkelley = new Skeleton(skeletonWalkAnim.Clone(), skeletonDeathAnim.Clone(), new Rectangle(1300, 200, 100, 100));
            Skeleton tttttestSkelley = new Skeleton(skeletonWalkAnim.Clone(), skeletonDeathAnim.Clone(), new Rectangle(900, 900, 100, 100));
            enemies.Add(testSkelley);
            enemies.Add(ttestSkelley);
            enemies.Add(tttestSkelley);
            enemies.Add(ttttestSkelley);
            enemies.Add(tttttestSkelley);
            
            //Creates a UI object. Values to be updated later. 
            mainPlayer = new Player(new Rectangle(0, 0, 100, 100), playerIdleAnim, playerRunAnim, bulletTexture, bulletCollideAnim);
            userInterface = new UI(backgroundHealthUI, foregroundHealthUI, bulletUI, false, mainPlayer.Health, mainPlayer.MaxHealth, font, mainPlayer.Ammo, mainPlayer.MaxAmmo);

            //Set debug logger
            DebugLog.Instance.Font = Content.Load<SpriteFont>("Consolas20");
            DebugLog.Instance.Scale = 2f;

            //Create world manager shortcut
            world = WorldManager.Instance;

            //Load map sequence
            world.AddMap(FileManager.LoadMap(Content, "HourglassMap"));
            world.AddMap(FileManager.LoadMap(Content, "SquareMapWithDoor"));
            world.AddMap(FileManager.LoadMap(Content, "CrescentMap"));
            world.AddMap(FileManager.LoadMap(Content, "TestMap"));

            //Create camera
            world.CurrentCamera = new Camera(GraphicsDevice, Rectangle.Empty);
        }

        protected override void Update(GameTime gameTime)
        {
            InputManager.UpdateInputState();
            MouseState mState = Mouse.GetState();

            switch (currentGameState)
            {
                #region Menu
                case GameState.Menu:

                    // This creates the default menu buttons

                    double xScale = _graphics.PreferredBackBufferWidth / 800.0;
                    double yScale = _graphics.PreferredBackBufferHeight / 480.0;

                    if (xScale < 1)
                    {
                        xScale = 1;
                    }
                    if (yScale < 1)
                    {
                        yScale = 1;
                    }

                    logoRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuLogo.Width * (int)xScale / 10) / 2), 20, (menuLogo.Width / 10) * (int)xScale, (menuLogo.Height / 10) * (int)yScale);
                    playRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuPlay.Width * (int)xScale / 20) / 2), 250, (menuPlay.Width / 5) / (int)xScale, (menuPlay.Height / 5) / (int)yScale);
                    optiRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuOpti.Width * (int)xScale / 20) / 2), 425, (menuOpti.Width / 5) / (int)xScale, (menuOpti.Height / 5) / (int)yScale);
                    quitRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuQuit.Width * (int)xScale / 20) / 2), 575, (menuQuit.Width / 5) / (int)xScale, (menuQuit.Height / 5) / (int)yScale);

                    // The following code makes the play, option, or quit button expand in size and hitbox if you hover over them

                    if (InputManager.MouseHover(mState, playRect))
                    {
                        playRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuPlay.Width * (int)xScale / 20) / 2) - 50, 200, (menuPlay.Width / 4) / (int)xScale, (menuPlay.Height / 4) / (int)yScale);
                    }
                    else if (InputManager.MouseHover(mState, optiRect))
                    {
                        optiRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuOpti.Width * (int)xScale / 20) / 2) - 50, 375, (menuOpti.Width / 4) / (int)xScale, (menuOpti.Height / 4) / (int)yScale);
                    }
                    else if (InputManager.MouseHover(mState, quitRect))
                    {
                        quitRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuQuit.Width * (int)xScale / 20) / 2) - 50, 525, (menuQuit.Width / 4) / (int)xScale, (menuQuit.Height / 4) / (int)yScale);
                    }

                    if (InputManager.IsButtonDown(MouseButtons.Left)
                        && mState.X > playRect.X
                        && mState.X < playRect.X + playRect.Width
                        && mState.Y > playRect.Y
                        && mState.Y < playRect.Y + playRect.Height)
                    {
                        currentGameState = GameState.Game;
                    }

                    if (InputManager.IsButtonDown(MouseButtons.Left)
                        && mState.X > optiRect.X
                        && mState.X < optiRect.X + optiRect.Width
                        && mState.Y > optiRect.Y
                        && mState.Y < optiRect.Y + optiRect.Height)
                    {
                        currentGameState = GameState.Pause;
                    }

                    if (InputManager.IsButtonDown(MouseButtons.Left)
                        && mState.X > quitRect.X
                        && mState.X < quitRect.X + quitRect.Width
                        && mState.Y > quitRect.Y
                        && mState.Y < quitRect.Y + quitRect.Height)
                    {
                        this.Exit();
                    }


                    break;
                #endregion

                #region Game
                case GameState.Game:

                    userInterface.Update(mainPlayer.Health, mainPlayer.Ammo, mainPlayer.DashTime, mainPlayer.Hitbox); //Updates the UI. Values to be updated later

                    if (InputManager.IsKeyDown(Keys.R))
                    {
                        currentGameState = GameState.GameOver;
                    } // A temporary way to instantly lose the game. Or maybe an unintentional feature!!!
                    if (InputManager.IsKeyDown(Keys.P))
                    {
                        currentGameState = GameState.Pause;
                    } // A way to pause the game.

                    // Ends the game when the player's HP falls below one.
                    if (mainPlayer.Health <= 0)
                    {
                        currentGameState = GameState.GameOver;
                    }


                    mainPlayer.Update(gameTime);
                    for (int i = 0; i < mainPlayer.PlayerBullets.Count; i++)
                    {
                        mainPlayer.PlayerBullets[i].Update(gameTime);
                    } // Update player bullets!
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        enemies[i].Update(mainPlayer.Hitbox.Center);
                    } // Update enemies!

                    #region COLLISIONS!!!
                    for (int e = 0; e < enemies.Count; e++)
                    {
                        if(enemies[e].Hitbox.Intersects(mainPlayer.Hitbox) && mainPlayer.DamageCooldown <= 0.0)
                        {
                            if(mainPlayer.Dashing)
                            {
                                mainPlayer.Dashing = false;
                                mainPlayer.DashCooldown = 7;
                            } // Colliding with an enemy stops the dash and hurts you.
                            mainPlayer.Damage(8);
                        }
                    }

                    for (int b = 0; b < mainPlayer.PlayerBullets.Count; b++)
                    {
                        for(int e = 0; e < enemies.Count; e++)
                        {
                            if(enemies[e].Hitbox.Intersects(mainPlayer.PlayerBullets[b].Hitbox) && mainPlayer.PlayerBullets[b].CurrentState != Projectile.ProjectileStates.HasCollided && enemies[e].Health > 0)
                            {
                                enemies[e].TakeDamage(5);
                                mainPlayer.PlayerBullets[b].CurrentState = Projectile.ProjectileStates.HasCollided;
                            }
                        }
                    }
                    #endregion


                    //DEBUG, tp to mouse
                    if (InputManager.IsKeyDown(Keys.T))
                    {
                        Rectangle playerHitbox = mainPlayer.Hitbox;
                        playerHitbox.Location = world.GetMouseWorldPosition().ToPoint();
                        mainPlayer.Hitbox = playerHitbox;
                    }
                    
                    //Update camera to ease to player and mouse pos in world space
                    world.CurrentCamera.EaseTo(mainPlayer.Hitbox.Location.ToVector2(), 1f, 0.2f);
                    world.CurrentCamera.EaseTo(world.GetMouseWorldPosition(), 1f, 0.05f);
                    world.CurrentCamera.Update(gameTime);

                    break;
                #endregion

                #region Pause
                case GameState.Pause:

                    if (InputManager.IsKeyDown(Keys.Enter))
                    {
                        currentGameState = GameState.Game;
                    }

                    if (InputManager.IsKeyDown(Keys.Escape))
                    {
                        this.Exit();
                    }

                    break;
                #endregion

                #region Game Over
                case GameState.GameOver:

                    if (InputManager.IsKeyDown(Keys.Enter))
                    {
                        mainPlayer.ResetPlayer();
                        currentGameState = GameState.Game;
                    }

                    break;
                #endregion
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkSlateGray);

            switch (currentGameState)
            {
                #region Menu
                case GameState.Menu:

                    _spriteBatch.Begin();

                    _spriteBatch.Draw(menuLogo, logoRect, Color.White);
                    _spriteBatch.Draw(menuPlay, playRect, Color.White);
                    _spriteBatch.Draw(menuOpti, optiRect, Color.White);
                    _spriteBatch.Draw(menuQuit, quitRect, Color.White);

                    MouseState mState = Mouse.GetState();

                    _spriteBatch.DrawString(font, "Menu", new Vector2(_graphics.PreferredBackBufferWidth - 180, 20), Color.White);

                    //_spriteBatch.DrawString(font, "xScale: " + xScale, new Vector2(_graphics.PreferredBackBufferWidth - 180, 50), Color.White);
                    //_spriteBatch.DrawString(font, "yScale: " + yScale, new Vector2(_graphics.PreferredBackBufferWidth - 180, 80), Color.White);

                    _spriteBatch.DrawString(font, "X: " + mState.X, new Vector2(_graphics.PreferredBackBufferWidth - 180, 110), Color.White);
                    _spriteBatch.DrawString(font, "Y: " + mState.Y, new Vector2(_graphics.PreferredBackBufferWidth - 180, 140), Color.White);

                    //Draws reticle
                    _spriteBatch.Draw(gameReticle, new Rectangle(mState.X - 25, mState.Y - 25, 50, 50), Color.White);

                    _spriteBatch.End();

                    break;
                #endregion

                #region Game
                case GameState.Game:

                    //Begin with pixel percision, opacity, and cam matrix
                    _spriteBatch.Begin(samplerState: SamplerState.PointClamp,
                        blendState: BlendState.AlphaBlend,
                        transformMatrix: world.CurrentCamera.TransformationMatrix);

                    //Draw test map
                    world.CurrentMap.DrawTiles(_spriteBatch);
                    //Draw next and prev
                    world.PreviousMap.DrawTiles(_spriteBatch);
                    world.NextMap.DrawTiles(_spriteBatch);


                    MouseState mStateGame = Mouse.GetState();
                    List<Enemy> removalList = new List<Enemy>();
                    mainPlayer.Draw(_spriteBatch, gameTime);

                    #region Enemies/Bullets
                    // This will draw the enemies and bullets, and remove them if they have finished their death animation.
                    for (int i = 0; i < mainPlayer.PlayerBullets.Count; i++)
                    {
                        // Draw the player bullets!
                        if(mainPlayer.PlayerBullets[i].Draw(_spriteBatch, gameTime) && mainPlayer.PlayerBullets[i].CurrentState == Projectile.ProjectileStates.HasCollided)
                        {
                            bulletRemovalList.Add(mainPlayer.PlayerBullets[i]);
                        }
                    }
                    for(int i = 0; i < enemies.Count; i++)
                    {
                        // Draw the enemies!!!
                        if(enemies[i].Draw(_spriteBatch, gameTime, mainPlayer.Hitbox.Center))
                        {
                            removalList.Add(enemies[i]);
                        }
                    }
                    foreach (Enemy enemy in removalList)
                    {
                        enemies.Remove(enemy);
                    }
                    foreach (Projectile bullet in bulletRemovalList)
                    {
                        mainPlayer.PlayerBullets.Remove(bullet);
                    }
                    #endregion

                    _spriteBatch.End();

                    //DEBUG Draw map hitboxes on top
                    GraphicsDevice.DepthStencilState = DepthStencilState.None;
                    ShapeBatch.Begin(GraphicsDevice);
                    world.CurrentMap.DrawHitboxes(new Vector2(
                        world.CurrentCamera.TransformationMatrix.Translation.X,
                        world.CurrentCamera.TransformationMatrix.Translation.Y),
                        world.CurrentCamera.Zoom);
                    ShapeBatch.End();

                    //Draw overlay
                    _spriteBatch.Begin(samplerState: SamplerState.PointClamp,
                        blendState: BlendState.AlphaBlend);

                    _spriteBatch.DrawString(font, "Game", new Vector2(_graphics.PreferredBackBufferWidth - 100, 20), Color.White);
                    userInterface.Draw(_spriteBatch); //Draws UI

                    //Draws reticle
                    _spriteBatch.Draw(gameReticle, new Rectangle(mStateGame.X - 25, mStateGame.Y - 25, 50, 50), Color.White);

                    _spriteBatch.End();

                    break;
                #endregion

                #region Pause
                case GameState.Pause:

                    _spriteBatch.Begin();

                    _spriteBatch.DrawString(font, "Pause", new Vector2(_graphics.PreferredBackBufferWidth - 100, 20), Color.White);

                    _spriteBatch.End();

                    break;
                #endregion

                #region Game Over
                case GameState.GameOver:

                    _spriteBatch.Begin();

                    _spriteBatch.DrawString(font, "Game Over", new Vector2(_graphics.PreferredBackBufferWidth - 175, 20), Color.White);

                    _spriteBatch.End();

                    break;
                #endregion
            }


            //Draw debug logger with fading
            _spriteBatch.Begin(blendState: BlendState.AlphaBlend);
            DebugLog.Instance.Draw(_spriteBatch,
                _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}