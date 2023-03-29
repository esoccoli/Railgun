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
        private bool debugMode;              //For future use, if we want to display certain stats. Other classes will decide when debug is on
        private int healthAmount;            //Current health amount of the player. Other classes will handle adding and subtracting health
                                             //UI class also handles making sure that health doesn't go past max or below 0
        private int maxHealth;               //Maximum allowed health of the player
        private Rectangle backgroundHealth;  //The background rectangle. Doesn't change. White
        private Rectangle foregroundHealth;  //The foreground rectangle. Changes based on current health. Red
        private SpriteFont font;             //Font used for all of the DrawStrings
        private int ammoAmount;              //Current ammo amount. Other classes will handle adding and subtracting ammo. UI makes sure that ammo
                                             //doesn't go past max or below 0
        private int maxAmmo;                 //Maximum allowed ammo of the player

        private Texture2D backgroundHealthTexture; //The background health bar that doesn't change size
        private Texture2D foregroundHealthTexture; //The foreground health bar that shows the amount of health left
        private Texture2D bulletUITexture;

        private Rectangle dashCooldown;

        /// <summary>
        /// Gets or sets whether Debug mode is on. When debug mode is on, extra strings are drawn. Turned on and off by other classes/methods 
        /// outside of UI
        /// </summary>
        public bool DebugMode { get; set; }

        /// <summary>
        /// Creates a UI object that displays the health bar, ammo amount, and debug features
        /// </summary>
        /// <param name="background">The texture of the background health bar</param>
        /// <param name="foreground">The texture of the foreground health bar</param>
        /// <param name="debugInitial">Sets the debug mode on or off initially</param>
        /// <param name="healthAmount">Current health of the player. Should start equal to max</param>
        /// <param name="maxHealth">Maximum health of the player</param>
        /// <param name="font">Font used for UI</param>
        /// <param name="ammoAmount">Current ammo amount of the player. Should start equal to max</param>
        /// <param name="maxAmmo">Maximum ammo of the player</param>
        public UI(Texture2D background, Texture2D foreground, Texture2D bulletUI, bool debugInitial, int healthAmount, int maxHealth, SpriteFont font, int ammoAmount, int maxAmmo)
        {
            debugMode = debugInitial;
            this.healthAmount = healthAmount;
            this.maxHealth = maxHealth;
            this.font = font;
            this.ammoAmount = ammoAmount;
            this.maxAmmo = maxAmmo;
            DebugMode = debugMode;

            backgroundHealthTexture = background;
            foregroundHealthTexture = foreground;
            bulletUITexture = bulletUI;

            backgroundHealth = new Rectangle(10, 40, maxHealth * 2, 10);
            dashCooldown = new Rectangle(10, 170, maxHealth * 2, 10);
            foregroundHealth = new Rectangle(10, 40, maxHealth * 2, 10);
        }

        /// <summary>
        /// Updates the health and ammo for the UI. For health, it changes the current health, which can increase or decrease the health bar.
        /// If the health bar goes above or below maxHealth or 0, it sets current health to maxHealth or 0. Same thing for ammo.
        /// </summary>
        /// <param name="health">The current health of the player</param>
        /// <param name="ammo">The current ammo amount of the player</param>
        public void Update(int health, int ammo, double dashTimeLeft)
        {
            healthAmount = health;
            ammoAmount = ammo;

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

            if (dashTimeLeft <= 0.0)
            {
                dashCooldown = new Rectangle(10, 170, maxHealth * 2, 10); ;
            }
            else
            {
                dashCooldown = new Rectangle(10, 170, (int)(((maxHealth * 2) / dashTimeLeft)), 10);
            }
        }

        /// <summary>
        /// Draws the updated health and ammo, alongside debug if active
        /// </summary>
        /// <param name="_spriteBatch">SpriteBatch used for drawing</param>
        public void Draw (SpriteBatch _spriteBatch)
        {
            _spriteBatch.DrawString(font, "Health: ", new Vector2(10, 0), Color.White);
            _spriteBatch.Draw(backgroundHealthTexture, backgroundHealth, Color.AntiqueWhite);

            //Changes the foreground health bar to match current health. Will be updated later if we want the
            //health bar to stay the same size no matter the health ammount. Currently, the size of the health bar is
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
            _spriteBatch.DrawString(font, "Dash: ", new Vector2(10, 130), Color.White);
            _spriteBatch.Draw(backgroundHealthTexture, new Rectangle(10, 170, maxHealth * 2, 10), Color.White);
            _spriteBatch.Draw(backgroundHealthTexture, dashCooldown, Color.Blue);


            //If debug mode is active, prints additional stats (to be added later as need)
            if (debugMode)
            {
                _spriteBatch.DrawString(font, "Debug Mode", new Vector2(10, 210), Color.White);
                _spriteBatch.DrawString(font, "Health Amt: " + healthAmount, new Vector2(10, 250), Color.White);
            }
        }
    }
}
