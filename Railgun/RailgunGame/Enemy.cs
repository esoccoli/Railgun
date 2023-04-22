using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Railgun.RailgunGame;

// Author(s): Ella Soccoli
// Date Created: 3/10/23
// Last Updated: 3/24/23
// Details: Creates a base class for a generic enemy so that we can make multiple types of enemies more easily
abstract class Enemy : Entity
{
    public int Health { get; set; }
   
    public Animation Move { get; set; }

    public Animation Idle { get; set; }

    public Animation Death { get; set; }

    public Rectangle Hitbox { get; set; }
    
    /// <summary>
    /// An additional constructor that Josh needs for the Skeleton class. It doesn't need an idle animation, it's always moving.
    /// </summary>
    /// <param name="move"> The Skeleton's move animation. </param>
    /// <param name="death"> The animation for when the Skeleton dies. </param>
    /// <param name="hitbox"> The hitbox of the Skeleton. </param>
    public Enemy(Animation move, Animation death, Rectangle hitbox) : base(hitbox)
    {
        Move = move;
        Death = death;
        Hitbox = hitbox;
    }

    /// <summary>
    /// Creates a new generic enemy with the specified information 
    /// </summary>
    /// <param name="texture">Texture file of the enemy</param>
    /// <param name="hitbox">Enemy's position rectangle</param>
    /// <param name="maxHealth">Maximum health of the enemy</param>
    public Enemy(Animation move, Animation idle, Animation death, Rectangle hitbox) : base(hitbox)
    {
        Move = move;
        Idle = idle;
        Death = death;
        Hitbox = hitbox;
    }

    /// <summary>
    /// Each enemy type will have a different way of moving
    /// </summary>
    /// <param name="playerPos"> Where the player is located. Needed for some enemies. </param>
    public abstract void Walk(Point playerPos);
    
    /// <summary>
    /// Reduces the enemy's health by the specified amount
    /// </summary>
    /// <param name="damage">Amount of damage taken</param>
    public virtual void TakeDamage(int damage)
    {
        this.Health -= damage;
    }

    /// <summary>
    /// Each enemy type will shoot bullets in a different way
    /// </summary>
    /// <param name="playerPos"> Where the player is located. Needed for some enemies. </param>
    public virtual void Shoot(Point playerPos)
    {
        // To be implemented by specific enemies.
    }
    
    /// <summary>
    /// This is called for each enemy every frame. Needed so enemies can walk/shoot at players.
    /// </summary>
    /// <param name="playerPos"> The location of the player. Needed to find them for some enemies. </param>
    public virtual void Update(Point playerPos)
    {
        // Walk(playerPos);
        // Shoot(playerPos);
        
        // If enemy collides with bullet
        // TakeDamage();
    }

    /// <summary>
    /// updates the enemy with gameTime parameter
    /// </summary>
    /// <param name="gameTime">gameTime</param>
    /// <param name="playerPos">current position of player</param>
    public virtual void Update(GameTime gameTime, Point playerPos)
    {
        this.Update(playerPos);
    }

    /// <summary>
    /// Needed to put the enemies onto the screen.
    /// </summary>
    /// <param name="sb"> The sprite batch the enemies are being drawn with. </param>
    /// <param name="gameTime"> The time passed in game. </param>
    /// <param name="playerPos"> The location of the player. Needed to find them for some enemies. </param>
    /// <returns> Whether or not the enemy has finished the death animation. </returns>
    public abstract bool Draw(SpriteBatch sb, GameTime gameTime, Point playerPos);
}