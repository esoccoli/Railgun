using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Igor Polotai
// Created: 3/6/23
// Last Updated: 3/6/23
// Purpose: To display and update the health bar and ammo amount
// Restrictions: Have to pass all information (obviously)

namespace Railgun.RailgunGame
{
    internal class UI
    {
        /// <summary>
        /// Controls whether debug mode is on or not.
        /// When it is on, displays extra info on screen
        /// </summary>
        public bool DebugMode { get; set; }

        /// <summary>
        /// Current amount of health the player has
        /// </summary>
        private int healthAmount;

        /// <summary>
        /// Maximum health the player can have
        /// </summary>
        private int maxHealth;

        /// <summary>
        /// Background of the health bar
        /// </summary>
        private Rectangle backgroundHealth;

        /// <summary>
        /// Foreground rectangle of the health bar that shows the player's current amount of health
        /// </summary>
        private Rectangle foregroundHealth;

        /// <summary>
        /// Font used for displaying text on screen
        /// </summary>
        private SpriteFont font;

        /// <summary>
        /// Amount of ammo the player currently has
        /// </summary>
        private int ammoAmount;

        /// <summary>
        /// Maximum amount of ammo the player can have
        /// </summary>
        private int maxAmmo;

        /// <summary>
        /// Appearance of the background of the health bar
        /// </summary>
        private Texture2D backgroundHealthTexture;

        /// <summary>
        /// Appearance of the foreground of the health bar
        /// </summary>
        private Texture2D foregroundHealthTexture;

        /// <summary>
        /// Texture used to show how many bullet the player has before needing to reload
        /// </summary>
        private Texture2D bulletUITexture;

        /// <summary>
        /// Rectangle used to show the dash cooldown
        /// </summary>
        private Rectangle dashCooldown;

        /// <summary>
        /// Rectangle used to show the dash cooldown
        /// </summary>
        private Rectangle dashCooldownBackground;

        private bool drawDash;


        // TODO: some suggestions:
        // - You don't need to pass in both healthAmount and maxHealth as parameters. If they are starting out equal, pass in one and have the other
        //  be a private field that is set to the same value
        //
        // - Same thing applies for ammoAmount and maxAmmo


        /// <summary>
        /// Creates a UI object that displays the health bar, ammo amount, and debug features
        /// </summary>
        /// <param name="background">Background texture of the health bar</param>
        /// <param name="foreground">Foreground texture of the health bar</param>
        /// <param name="debugInitial">Sets the initial state of debug mode</param>
        /// <param name="healthAmount">Player's starting health</param>
        /// <param name="maxHealth">Maximum health of the player</param>
        /// <param name="font">Font used for UI</param>
        /// <param name="ammoAmount">Current ammo amount of the player. Should start equal to max</param>
        /// <param name="maxAmmo">Maximum ammo of the player</param>
        public UI(Texture2D background, Texture2D foreground, Texture2D bulletUI, bool debugInitial, int healthAmount, int maxHealth, SpriteFont font, int ammoAmount, int maxAmmo)
        {
            //debugMode = debugInitial;
            this.healthAmount = healthAmount;
            this.maxHealth = maxHealth;
            this.font = font;
            this.ammoAmount = ammoAmount;
            this.maxAmmo = maxAmmo;
            DebugMode = debugInitial;

            backgroundHealthTexture = background;
            foregroundHealthTexture = foreground;
            bulletUITexture = bulletUI;

            backgroundHealth = new Rectangle(10, 40, maxHealth * 2, 10);
            dashCooldown = new Rectangle(10, 170, maxHealth * 2, 10);
            dashCooldownBackground = dashCooldown;
            foregroundHealth = new Rectangle(10, 40, maxHealth * 2, 10);
            drawDash = true;
        }

        /// <summary>
        /// Updates the health and ammo indicators on the UI
        /// </summary>
        /// <param name="health">Player's current health</param>
        /// <param name="ammo">Amount of ammo the player currently has</param>
        /// <param name="dashTimeLeft">Time remaining until the player can dash again</param>
        public void Update(int health, int ammo, double dashTimeLeft, Rectangle playerPosition)
        {
            healthAmount = health;
            ammoAmount = ammo; //comment

            if (healthAmount > maxHealth)
            {
                healthAmount = maxHealth;
            }
            else if (healthAmount < 0)
            {
                healthAmount = 0;
            }

            if (ammoAmount > maxAmmo)
            {
                ammoAmount = maxAmmo;
            }
            else if (ammoAmount < 0)
            {
                ammoAmount = 0;
            }

            // TODO: What are our thoughts on unary operators?
            // Ex: dashCooldown = dashTimeLeft <= 0.0 ? new Rectangle(10, 170, maxHealth * 2, 10) : new Rectangle(10, 170, (int)(((maxHealth * 2) / dashTimeLeft)), 10);

            drawDash = true;

            if (dashTimeLeft >= 0.1)
            {
                dashCooldown = new Rectangle(playerPosition.X, playerPosition.Y, (int)(dashTimeLeft * 100.0), 10);
                dashCooldownBackground = new Rectangle(playerPosition.X, playerPosition.Y, 100, 10);
            }
            else
            {
                //dashCooldown = new Rectangle(playerPosition.X, playerPosition.Y, (int)(((maxHealth * 2) / dashTimeLeft)), 10);
                //dashCooldownBackground = new Rectangle(playerPosition.X, playerPosition.Y, (int)(((maxHealth * 2) / dashTimeLeft)), 10);
                drawDash = false;
            }
        }

        /// <summary>
        /// Draws the updated health and ammo, alongside debug if active
        /// </summary>
        /// <param name="_spriteBatch">SpriteBatch used for drawing</param>
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.DrawString(font, "Health: ", new Vector2(10, 0), Color.White);
            _spriteBatch.Draw(backgroundHealthTexture, backgroundHealth, Color.AntiqueWhite);

            //Changes the foreground health bar to match current health. Will be updated later if we want the
            //health bar to stay the same size no matter the health amount. Currently, the size of the health bar is
            //directly tied to maxHealth, so if maxHealth is like 1000, the health bar will probably go off the screen
            //Vice versa, if the health is like 10, you may barely see the health bar. But for now it should work 
            foregroundHealth = new Rectangle(10, 40, healthAmount * 2, 10);
            _spriteBatch.Draw(foregroundHealthTexture, foregroundHealth, Color.Red);

            _spriteBatch.DrawString(font, "Ammo: " + ammoAmount, new Vector2(10, 50), Color.White);

            // Draw bullets at 10 + i, 90
            for (int i = 0; i < ammoAmount; i++)
            {
                _spriteBatch.Draw(bulletUITexture, new Rectangle(10 + (i * 20), 90, 15, 26), Color.White);
            }

            // Dash cooldown
            // _spriteBatch.DrawString(font, "Dash: ", new Vector2(10, 130), Color.White);



            //If debug mode is active, prints additional stats (to be added later as need)
            if (DebugMode)
            {
                MouseState mState = Mouse.GetState();

                _spriteBatch.DrawString(font, "Debug Mode", new Vector2(10, 210), Color.White);
                _spriteBatch.DrawString(font, "Health Amt: " + healthAmount, new Vector2(10, 250), Color.White);
                _spriteBatch.DrawString(font, "Dash X: " + dashCooldown.X, new Vector2(10, 290), Color.White);
                _spriteBatch.DrawString(font, "Dash Y: " + dashCooldown.Y, new Vector2(10, 340), Color.White);
                _spriteBatch.DrawString(font, "X: " + mState.X, new Vector2(10, 390), Color.White);
                _spriteBatch.DrawString(font, "Y: " + mState.Y, new Vector2(10, 440), Color.White);
            }
        }

        public void DrawToWorldspace(SpriteBatch _spriteBatch)
        {
            if (drawDash)
            {
                _spriteBatch.Draw(backgroundHealthTexture, dashCooldownBackground, Color.White);
                _spriteBatch.Draw(backgroundHealthTexture, dashCooldown, Color.Blue);
            }
        }
    }
}
