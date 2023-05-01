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
        private Texture2D howToPlay;
        
        // TODO: can this field be removed?
        //private bool displayGameOver;

        private Player mainPlayer;

        private List<Projectile> bulletRemovalList;

        private WorldManager world;
        private VisualManager visuals;

        #region Menu Elements
        
        // Textures used to display the Menu.
        private Texture2D menuLogo;
        private Texture2D menuPlay;
        private Texture2D menuOpti;
        private Texture2D menuQuit;
        private Texture2D menuRest;

        // Rectangles to make the Menu usable.
        private Rectangle logoRect;
        private Rectangle playRect;
        private Rectangle optiRect;
        private Rectangle quitRect;

        // Makes Pause menu work
        private GameState previous;
        
        #endregion

        #region Player, Enemy, Proj. Textures
        
        // Player, enemy, and projectile textures
        private Texture2D playerIdle;

        private Texture2D playerRun;

        private Texture2D playerDeath;

        private Texture2D bulletTexture;
        private Texture2D bulletCollideTexture;

        private Texture2D skeletonWalk;

        private Texture2D skeletonDeath;

        private Texture2D gasManMove;
        private Texture2D gasManDeath;
        private Texture2D gasManShoot;
        
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
            
            // TODO: can this field be removed?
            //displayGameOver = true;
            
            // TODO: unused variable should be removed
            GameTime gameTime = new GameTime();

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
            howToPlay = Content.Load<Texture2D>("New ControlsV3");


            //Game Menu Stuff
            menuLogo = Content.Load<Texture2D>("menuLogo");
            menuPlay = Content.Load<Texture2D>("menuPlay");
            
            // TODO: if this code not going to be used, it should be removed
            //menuOpti = Content.Load<Texture2D>("menuOptions");
            
            menuOpti = Content.Load<Texture2D>("controls");
            menuQuit = Content.Load<Texture2D>("menuQuit");
            menuRest = Content.Load<Texture2D>("reload");

            previous = GameState.Menu;

            //Game Reticle
            gameReticle = Content.Load<Texture2D>("reticle106");

            // Player, bullets, and enemies.
            playerIdle = Content.Load<Texture2D>("mainCharIdle");
            playerRun = Content.Load<Texture2D>("mainCharRun");
            playerDeath = Content.Load<Texture2D>("mainCharDeath");
            bulletTexture = Content.Load<Texture2D>($"bulletTexture");
            bulletCollideTexture = Content.Load<Texture2D>($"BulletBoom");
            skeletonWalk = Content.Load<Texture2D>($"Skeleton Walk");
            skeletonDeath = Content.Load<Texture2D>($"Skeleton Dead");
            gasManMove = Content.Load<Texture2D>("gasManMove");
            gasManDeath = Content.Load<Texture2D>("gasManDeath");
            gasManShoot = Content.Load<Texture2D>("gasManShoot");

            #endregion

            // Instantiate singletons
            visuals = VisualManager.Instance;
            world = WorldManager.Instance;

            // Add animations to manager
            visuals.PlayerIdle = new Animation(playerIdle, 1, 6, 11.0f);
            visuals.PlayerMove = new Animation(playerRun, 1, 8, 13.0f);
            visuals.PlayerDeath = new Animation(playerDeath, 1, 8, 4.0f);
            visuals.BulletCollide = new Animation(bulletCollideTexture, 4, 1, 12.4f);
            visuals.SkeletonMove = new Animation(skeletonWalk, 1, 13, 12.0f);
            visuals.SkeletonDeath = new Animation(skeletonDeath, 1, 15, 12.0f);
            visuals.DoorTexture = Content.Load<Texture2D>("Tiles/Tiles");
            visuals.GasManMove = new Animation(gasManMove, 8, 1, 12.0f);
            visuals.GasManDeath = new Animation(gasManDeath, 6, 1, 12.0f);
            visuals.GasManShoot = new Animation(gasManShoot, 4, 1, 12.0f);
            visuals.BulletTexture = bulletTexture;
            
            // TODO: all the code that is for testing stuff needs to be removed
            
            // This next line is just to test skeletons.
            Skeleton testSkelley = new Skeleton(new Rectangle(1700, 200, 100, 100));
            
            // Skeleton ttestSkelley = new Skeleton(skeletonWalkAnim.Clone(), skeletonDeathAnim.Clone(), new Rectangle(200, 200, 100, 100));
            // Skeleton tttestSkelley = new Skeleton(skeletonWalkAnim.Clone(), skeletonDeathAnim.Clone(), new Rectangle(700, 200, 100, 100));
            // Skeleton ttttestSkelley = new Skeleton(skeletonWalkAnim.Clone(), skeletonDeathAnim.Clone(), new Rectangle(1300, 200, 100, 100));
            // Skeleton tttttestSkelley = new Skeleton(skeletonWalkAnim.Clone(), skeletonDeathAnim.Clone(), new Rectangle(900, 900, 100, 100));
            //world.CurrentEnemies.Add(testSkelley);
            // enemies.Add(ttestSkelley);
            // enemies.Add(tttestSkelley);
            // enemies.Add(ttttestSkelley);
            // enemies.Add(tttttestSkelley);

            // Turret test
            Turret testTurret = new Turret(visuals.GasManDeath, new Rectangle(1700, 200, 100, 100), visuals.GasManShoot, bulletTexture, visuals.BulletCollide);
            world.CurrentEnemies.Add(testTurret);
            //enemies.Add(testTurret);

            // Creates a UI object. Values to be updated later. 
            mainPlayer = new Player(new Rectangle(0, 0, 100, 100), bulletTexture);
            userInterface = new UI(backgroundHealthUI, foregroundHealthUI, bulletUI, false, mainPlayer.Health, mainPlayer.MaxHealth, font, mainPlayer.Ammo, mainPlayer.MaxAmmo);

            // Set debug logger
            DebugLog.Instance.Font = Content.Load<SpriteFont>("Consolas20");
            DebugLog.Instance.Scale = 2f;

            // Load maps and create camera
            world.SetupWorld(
                GraphicsDevice,
                new List<Map>
                    {
                        FileManager.LoadMap(Content, "CrescentMap"),
                        FileManager.LoadMap(Content, "DonutRoom"),
                        FileManager.LoadMap(Content, "HourglassMap"),
                        FileManager.LoadMap(Content, "Longus"),
                        FileManager.LoadMap(Content, "SquareMapWithDoor"),
                        FileManager.LoadMap(Content, "TShapeMap"),
                        FileManager.LoadMap(Content, "LushHalls")
                    },
                FileManager.LoadMap(Content, "StartingRoom"));
        }

        protected override void Update(GameTime gameTime)
        {
            // Updates the currently stored keyboard and mouse states
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
                    
                    // TODO: why are we dividing twice in a row? Can it be condensed into one division?
                    logoRect = new Rectangle(
                        _graphics.PreferredBackBufferWidth / 2 - menuLogo.Width * (int)xScale / 10 / 2, 
                        20, 
                        menuLogo.Width / 10 * (int)xScale, 
                        menuLogo.Height / 10 * (int)yScale);
                    
                    playRect = new Rectangle(
                        _graphics.PreferredBackBufferWidth / 2 - menuPlay.Width * (int)xScale / 20 / 2, 
                        250, 
                        menuPlay.Width / 5 / (int)xScale, 
                        menuPlay.Height / 5 / (int)yScale);
                    
                    optiRect = new Rectangle(
                        _graphics.PreferredBackBufferWidth / 2 - menuOpti.Width * (int)xScale / 20 / 2, 
                        425, 
                        menuOpti.Width / 5 / (int)xScale, 
                        menuOpti.Height / 5 / (int)yScale);
                    
                    quitRect = new Rectangle(
                        _graphics.PreferredBackBufferWidth / 2 - menuQuit.Width * (int)xScale / 20 / 2, 
                        575,
                        menuQuit.Width / 5 / (int)xScale, 
                        menuQuit.Height / 5 / (int)yScale);

                    // The following code makes the play, option, or quit button expand in size and hitbox if you hover over them

                    if (InputManager.MouseHover(mState, playRect))
                    {
                        playRect = new Rectangle(
                            _graphics.PreferredBackBufferWidth / 2 - menuPlay.Width * (int)xScale / 20 / 2 - 50, 
                            200,
                            menuPlay.Width / 4 / (int)xScale, 
                            menuPlay.Height / 4 / (int)yScale);
                    }
                    else if (InputManager.MouseHover(mState, optiRect))
                    {
                        optiRect = new Rectangle(
                            _graphics.PreferredBackBufferWidth / 2 - menuOpti.Width * (int)xScale / 20 / 2 - 50,
                            375, 
                            menuOpti.Width / 4 / (int)xScale, 
                            menuOpti.Height / 4 / (int)yScale);
                    }
                    else if (InputManager.MouseHover(mState, quitRect))
                    {
                        quitRect = new Rectangle(
                            _graphics.PreferredBackBufferWidth / 2 - menuQuit.Width * (int)xScale / 20 / 2 - 50, 
                            525, 
                            menuQuit.Width / 4 / (int)xScale, 
                            menuQuit.Height / 4 / (int)yScale);
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
                        previous = GameState.Menu;
                        currentGameState = GameState.Pause;
                    }

                    if (InputManager.IsButtonDown(MouseButtons.Left)
                        && mState.X > quitRect.X
                        && mState.X < quitRect.X + quitRect.Width
                        && mState.Y > quitRect.Y
                        && mState.Y < quitRect.Y + quitRect.Height)
                    {
                        Exit();
                    }
                    break;
                
                #endregion

                #region Game
                
                case GameState.Game:

                    userInterface.Update(mainPlayer.Health, mainPlayer.Ammo, mainPlayer.DashCooldown, mainPlayer.Hitbox); //Updates the UI. Values to be updated later

                    //if (InputManager.IsKeyDown(Keys.R))
                    //{
                    //    currentGameState = GameState.GameOver;
                    //} // A temporary way to instantly lose the game. Or maybe an unintentional feature!!!
                    if (InputManager.IsKeyReleased(Keys.Escape))
                        
                        // TODO: THIS IS THE CODE THAT WAS HERE BEFORE MERGING CHANGES, IF ANYTHING BREAKS, CHECK THIS FIRST
                        /*// Updates the UI
                        userInterface.Update(
                            mainPlayer.Health, 
                            mainPlayer.Ammo, 
                            mainPlayer.DashCooldown, 
                            mainPlayer.Hitbox);
                        
                        // Keybind to instantly bring you from the game to the game over screen/state
                        if (InputManager.IsKeyDown(Keys.R))
                        {
                            currentGameState = GameState.GameOver;
                        }
                        
                        // Keybind to pause the game
                        if (InputManager.IsKeyDown(Keys.P))*/
                    
                    {
                        previous = GameState.Game;
                        currentGameState = GameState.Pause;
                    }
                    
                    if (mainPlayer.Health > 0)
                    {
                        mainPlayer.Update(gameTime);
                    }
                    
                    // Updates the bullets the player shoots
                    for (int i = 0; i < mainPlayer.PlayerBullets.Count; i++)
                    {
                        mainPlayer.PlayerBullets[i].Update(gameTime);
                    }
                    
                    // Updates all the enemies that currently exist
                    for (int i = 0; i < world.CurrentEnemies.Count; i++)
                    {
                        world.CurrentEnemies[i].Update(gameTime, mainPlayer.Hitbox.Center);
                    }

                    #region COLLISIONS!!!
                    
                    for (int e = 0; e < world.CurrentEnemies.Count; e++)
                    {
                        if (world.CurrentEnemies[e].Hitbox.Intersects(mainPlayer.Hitbox) && mainPlayer.DamageCooldown <= 0.0)
                        {
                            // Colliding with an enemy stops the dash and hurts you.
                            if (mainPlayer.Dashing)
                            {
                                mainPlayer.Dashing = false;
                                mainPlayer.DashCooldown = 2.0;
                            }
                            
                            mainPlayer.Damage(8);
                        }
                    }

                    for (int b = 0; b < mainPlayer.PlayerBullets.Count; b++)
                    {
                        for (int e = 0; e < world.CurrentEnemies.Count; e++)
                        {
                            if (world.CurrentEnemies[e].Hitbox.Intersects(mainPlayer.PlayerBullets[b].Hitbox) && 
                                mainPlayer.PlayerBullets[b].CurrentState != Projectile.ProjectileStates.HasCollided && 
                                world.CurrentEnemies[e].Health > 0)
                            {
                                world.CurrentEnemies[e].TakeDamage(5);
                                mainPlayer.PlayerBullets[b].CurrentState = Projectile.ProjectileStates.HasCollided;
                            }
                        }
                    }

                    // Updates enemy bullets
                    EnemyProjManager.Instance.Update(gameTime);

                    foreach (Projectile projectile in EnemyProjManager.Instance.Projectiles)
                    {
                        if (projectile.Hitbox.Intersects(mainPlayer.Hitbox) && mainPlayer.DamageCooldown <= 0)
                        {
                            mainPlayer.Damage(10);
                            projectile.CurrentState = Projectile.ProjectileStates.HasCollided;
                        }
                    }
                    #endregion

                    //DEBUG, tp to mouse
                    //if (InputManager.IsKeyDown(Keys.T))
                    //{
                    //    Rectangle playerHitbox = mainPlayer.Hitbox;
                    //    playerHitbox.Location = world.GetMouseWorldPosition().ToPoint();
                    //    mainPlayer.Hitbox = playerHitbox;
                    //}

                    /*// TODO: THIS IS THE CODE THAT WAS HERE BEFORE MERGING CHANGES, IF ANYTHING BREAKS, CHECK THIS FIRST
                    // Keybind to teleport the player to the current mouse position
                    // Intended for debug purposes
                    if (InputManager.IsKeyDown(Keys.T))
                    {
                        Rectangle playerHitbox = mainPlayer.Hitbox;
                        playerHitbox.Location = world.GetMouseWorldPosition().ToPoint();
                        mainPlayer.Hitbox = playerHitbox;
                    }*/

                    // If alive, camera slowly moves towards the mouse position
                    if (mainPlayer.Health > 0)
                    {
                        // Update camera to ease to player and mouse pos in world space
                        world.CurrentCamera.EaseTo(mainPlayer.Hitbox.Center.ToVector2(), 1.1f, 0.2f);
                        world.CurrentCamera.EaseTo(world.GetMouseWorldPosition(), 1.1f, 0.05f);
                    }
                    
                    // If dead, the camera slowly zooms in to the player
                    else 
                    {
                        world.CurrentCamera.EaseTo(mainPlayer.Hitbox.Center.ToVector2(), 2f, 0.02f);
                        
                        IsMouseVisible = true;
                        
                        //if (displayGameOver)
                        //{
                        //Debug.WriteLine("Game Over Test 1");
                        //displayGameOver = false;
                        //DrawEnd(_spriteBatch);
                        //}

                    }

                    // If all enemies defeated, open door to the next room
                    if (world.CurrentEnemies.Count == 0)
                    {
                        world.ExitDoor.IsClosed = false;
                        
                        // Check if fully within next room trigger
                        if (world.CurrentExitTrigger.Contains(mainPlayer.Hitbox))
                        {
                            world.IncrementMap();
                        }
                    }
                    
                    world.CurrentCamera.Update(gameTime);
                    break;
                
                #endregion

                #region Pause
                
                case GameState.Pause:

                    if (InputManager.IsKeyReleased(Keys.Escape))
                    {
                        currentGameState = previous;
                    }

                    if (InputManager.IsKeyDown(Keys.Q))
                    {
                        Exit();
                    }
                    break;
                
                #endregion

                #region Game Over
                
                case GameState.GameOver:

                    xScale = _graphics.PreferredBackBufferWidth / 800.0;
                    yScale = _graphics.PreferredBackBufferHeight / 480.0;

                    if (xScale < 1)
                    {
                        xScale = 1;
                    }
                    if (yScale < 1)
                    {
                        yScale = 1;
                    }
                    
                    // TODO: unused code should be removed
                    //logoRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuLogo.Width * (int)xScale / 10) / 2), 20, (menuLogo.Width / 10) * (int)xScale, (menuLogo.Height / 10) * (int)yScale);
                    //playRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuPlay.Width * (int)xScale / 20) / 2), 250, (menuPlay.Width / 5) / (int)xScale, (menuPlay.Height / 5) / (int)yScale);
                    
                    optiRect = new Rectangle(
                        _graphics.PreferredBackBufferWidth / 2 - menuOpti.Width * (int)xScale / 20 / 2, 
                        425, 
                        menuOpti.Width / 5 / (int)xScale, 
                        menuOpti.Height / 5 / (int)yScale);
                    
                    quitRect = new Rectangle(
                        _graphics.PreferredBackBufferWidth / 2 - menuQuit.Width * (int)xScale / 20 / 2, 
                        575, 
                        menuQuit.Width / 5 / (int)xScale, 
                        menuQuit.Height / 5 / (int)yScale);
                    
                    // The following code makes the play, option, or quit button expand in size and hitbox if you hover over them
                    
                    // TODO: unused code should be removed
                    //if (InputManager.MouseHover(mState, playRect))
                    //{
                    //    playRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuPlay.Width * (int)xScale / 20) / 2) - 50, 200, (menuPlay.Width / 4) / (int)xScale, (menuPlay.Height / 4) / (int)yScale);
                    //}
                    
                    if (InputManager.MouseHover(mState, optiRect))
                    {
                        optiRect = new Rectangle(
                            _graphics.PreferredBackBufferWidth / 2 - menuOpti.Width * (int)xScale / 20 / 2 - 50, 
                            375, 
                            menuOpti.Width / 4 / (int)xScale, 
                            menuOpti.Height / 4 / (int)yScale);
                    }
                    else if (InputManager.MouseHover(mState, quitRect))
                    {
                        quitRect = new Rectangle(
                            _graphics.PreferredBackBufferWidth / 2 - menuQuit.Width * (int)xScale / 20 / 2 - 50, 
                            525, 
                            menuQuit.Width / 4 / (int)xScale, 
                            menuQuit.Height / 4 / (int)yScale);
                    }
                    
                    // TODO: unused code should be removed
                    //if (InputManager.IsButtonDown(MouseButtons.Left)
                    //    && mState.X > playRect.X
                    //    && mState.X < playRect.X + playRect.Width
                    //    && mState.Y > playRect.Y
                    //    && mState.Y < playRect.Y + playRect.Height)
                    //{
                    //    currentGameState = GameState.Game;
                    //}

                    if (InputManager.IsButtonDown(MouseButtons.Left)
                        && mState.X > optiRect.X
                        && mState.X < optiRect.X + optiRect.Width
                        && mState.Y > optiRect.Y
                        && mState.Y < optiRect.Y + optiRect.Height)
                    {
                        IsMouseVisible = false;
                        mainPlayer.ResetPlayer();
                        world.ResetWorld();
                        currentGameState = GameState.Game;
                    }

                    if (InputManager.IsButtonDown(MouseButtons.Left)
                        && mState.X > quitRect.X
                        && mState.X < quitRect.X + quitRect.Width
                        && mState.Y > quitRect.Y
                        && mState.Y < quitRect.Y + quitRect.Height)
                    {
                        this.Exit();
                    }

                    if (InputManager.IsKeyDown(Keys.Enter))
                    {
                        IsMouseVisible = false;
                        mainPlayer.ResetPlayer();
                        world.ResetWorld();
                        currentGameState = GameState.Game;
                    }
                    break;
                
                    #endregion
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

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
                    
                    // TODO: unused code should be removed
                    //_spriteBatch.DrawString(font, "xScale: " + xScale, new Vector2(_graphics.PreferredBackBufferWidth - 180, 50), Color.White);
                    //_spriteBatch.DrawString(font, "yScale: " + yScale, new Vector2(_graphics.PreferredBackBufferWidth - 180, 80), Color.White);

                    _spriteBatch.DrawString(font, "X: " + mState.X, new Vector2(_graphics.PreferredBackBufferWidth - 180, 110), Color.White);
                    _spriteBatch.DrawString(font, "Y: " + mState.Y, new Vector2(_graphics.PreferredBackBufferWidth - 180, 140), Color.White);

                    // Draws reticle
                    _spriteBatch.Draw(gameReticle, new Rectangle(mState.X - 25, mState.Y - 25, 50, 50), Color.White);

                    _spriteBatch.End();
                    break;
                
                #endregion

                #region Game
                case GameState.Game:

                    // Begin with pixel precision, opacity, and camera matrix
                    _spriteBatch.Begin(samplerState: SamplerState.PointClamp,
                        blendState: BlendState.AlphaBlend,
                        transformMatrix: world.CurrentCamera.TransformationMatrix);

                    // Draw world on bottom
                    world.Draw(_spriteBatch);
                    
                    MouseState mStateGame = Mouse.GetState();
                    List<Enemy> removalList = new List<Enemy>();

                    if (mainPlayer.Draw(_spriteBatch, gameTime))
                    {
                        currentGameState = GameState.GameOver;
                    }

                    #region Enemies/Bullets
                    
                    // This will draw the enemies and bullets, and remove them if they have finished their death animation.
                    for (int i = 0; i < mainPlayer.PlayerBullets.Count; i++)
                    {
                        // Draw the player bullets!
                        if (mainPlayer.PlayerBullets[i].Draw(_spriteBatch, gameTime) && mainPlayer.PlayerBullets[i].CurrentState == Projectile.ProjectileStates.HasCollided)
                        {
                            bulletRemovalList.Add(mainPlayer.PlayerBullets[i]);
                        }
                    }
                    for (int i = 0; i < world.CurrentEnemies.Count; i++)
                    {
                        // Draw the enemies!!!
                        if (world.CurrentEnemies[i].Draw(_spriteBatch, gameTime, mainPlayer.Hitbox.Center))
                        {
                            removalList.Add(world.CurrentEnemies[i]);
                        }
                    }
                    foreach (Enemy enemy in removalList)
                    {
                        world.CurrentEnemies.Remove(enemy);
                    }
                    foreach (Projectile bullet in bulletRemovalList)
                    {
                        mainPlayer.PlayerBullets.Remove(bullet);
                    }

                    // Enemy bullets gets drawn/removed
                    EnemyProjManager.Instance.Draw(_spriteBatch, gameTime);

                    userInterface.DrawToWorldspace(_spriteBatch);

                    #endregion

                    _spriteBatch.End();
                    
                    // TODO: unused code should be removed
                    //DEBUG Draw world debug
                    //world.DrawDebug(_spriteBatch, GraphicsDevice);

                    // Draw overlay
                    _spriteBatch.Begin(samplerState: SamplerState.PointClamp,
                        blendState: BlendState.AlphaBlend);

                    _spriteBatch.DrawString(font, "Game", new Vector2(_graphics.PreferredBackBufferWidth - 100, 20), Color.White);
                    
                    // Draws game UI
                    userInterface.Draw(_spriteBatch);

                    // Draws reticle
                    _spriteBatch.Draw(gameReticle, new Rectangle(mStateGame.X - 25, mStateGame.Y - 25, 50, 50), Color.White);

                    _spriteBatch.End();
                    break;
                
                #endregion

                #region Pause
                
                case GameState.Pause:

                    _spriteBatch.Begin();

                    _spriteBatch.Draw(howToPlay, new Rectangle(0, 0, 1920, 1080), Color.White);
                    _spriteBatch.DrawString(font, "Pause", new Vector2(_graphics.PreferredBackBufferWidth - 100, 20), Color.White);

                    _spriteBatch.End();
                    break;
                
                #endregion

                #region Game Over
                
                case GameState.GameOver:

                    _spriteBatch.Begin();

                    _spriteBatch.Draw(menuRest, optiRect, Color.White);
                    _spriteBatch.Draw(menuQuit, quitRect, Color.White);

                    _spriteBatch.DrawString(font, "Game Over", new Vector2(_graphics.PreferredBackBufferWidth - 175, 20), Color.White);

                    _spriteBatch.DrawString(font, "Rooms Passed: " + world.Score, Vector2.Zero, Color.Gold);

                    _spriteBatch.End();
                    break;
                
                #endregion
            }


            // Draw debug logger with fading
            _spriteBatch.Begin(blendState: BlendState.AlphaBlend);
            
            DebugLog.Instance.Draw(_spriteBatch,
                _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        
        // TODO: unused code should be removed
        // Abandon all hope, ye who travel. Below are only the wastelands. None dare venture here.
        //public void DrawEnd(SpriteBatch _spriteBatch)
        //{
        //    Debug.WriteLine("Game Over Test 2");

        //    _spriteBatch.Begin();

        //    double xScale = _graphics.PreferredBackBufferWidth / 800.0;
        //    double yScale = _graphics.PreferredBackBufferHeight / 480.0;

        //    if (xScale < 1)
        //    {
        //        xScale = 1;
        //    }
        //    if (yScale < 1)
        //    {
        //        yScale = 1;
        //    }

        //    bool check = false;
        //    int count = 0;

        //    while (check == false)
        //    {
        //        optiRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuOpti.Width * (int)xScale / 20) / 2), 425, (menuOpti.Width / 5) / (int)xScale, (menuOpti.Height / 5) / (int)yScale);
        //        quitRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuQuit.Width * (int)xScale / 20) / 2), 575, (menuQuit.Width / 5) / (int)xScale, (menuQuit.Height / 5) / (int)yScale);

        //        Debug.WriteLine("Game Over Test 3: " + count);

        //        MouseState mState = Mouse.GetState();

        //        if (InputManager.MouseHover(mState, optiRect))
        //        {
        //            optiRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuOpti.Width * (int)xScale / 20) / 2) - 50, 375, (menuOpti.Width / 4) / (int)xScale, (menuOpti.Height / 4) / (int)yScale);
        //        }
        //        else if (InputManager.MouseHover(mState, quitRect))
        //        {
        //            quitRect = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - ((menuQuit.Width * (int)xScale / 20) / 2) - 50, 525, (menuQuit.Width / 4) / (int)xScale, (menuQuit.Height / 4) / (int)yScale);
        //        }

        //        _spriteBatch.Draw(menuPlay, optiRect, Color.White);
        //        _spriteBatch.Draw(menuQuit, quitRect, Color.White);

        //        if (InputManager.IsButtonDown(MouseButtons.Left)
        //            && mState.X > optiRect.X
        //            && mState.X < optiRect.X + optiRect.Width
        //            && mState.Y > optiRect.Y
        //            && mState.Y < optiRect.Y + optiRect.Height)
        //        {
        //            mainPlayer.ResetPlayer();
        //            world.ResetWorld();
        //            currentGameState = GameState.Game;
        //            check = true;
        //        }

        //        if (InputManager.IsButtonDown(MouseButtons.Left)
        //            && mState.X > quitRect.X
        //            && mState.X < quitRect.X + quitRect.Width
        //            && mState.Y > quitRect.Y
        //            && mState.Y < quitRect.Y + quitRect.Height)
        //        {
        //            this.Exit();
        //        }

        //        count++;
        //    }

        //    _spriteBatch.End();
        //}
    }
}