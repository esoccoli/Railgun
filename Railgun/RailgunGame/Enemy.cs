using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Railgun.RailgunGame;

// Author(s): Ella Soccoli
// Date Created: 3/10/23
// Last Updated: 3/24/23
// Details: Creates a base class for a generic enemy so that we can make multiple types of enemies more easily
public abstract class Enemy
{
    public int MaxHealth { get; set; }
    public int CurrHealth { get; set; }
   
    public Animation Move { get; set; }

    public Animation Idle { get; set; }

    public Animation Death { get; set; }

    public Rectangle Hitbox { get; set; }
    
    /// <summary>
    /// Tracks whether the enemy has health left
    /// </summary>
    public bool isAlive { get; set; }
    
    /// <summary>
    /// Creates a new generic enemy with the specified information 
    /// </summary>
    /// <param name="texture">Texture file of the enemy</param>
    /// <param name="hitbox">Enemy's position rectangle</param>
    /// <param name="maxHealth">Maximum health of the enemy</param>
    public Enemy(Animation move, Animation idle, Animation death, Rectangle hitbox, int maxHealth)
    {
        Move = move;
        Idle = idle;
        Death = death;
        Hitbox = hitbox;
        MaxHealth = maxHealth;
        CurrHealth = MaxHealth;
    }
    
    /// <summary>
    /// Each enemy type will have a different way of moving
    /// </summary>
    public abstract void Walk();
    
    /// <summary>
    /// Reduces the enemy's health by the specified amount
    /// </summary>
    /// <param name="damage">Amount of damage taken</param>
    public virtual void TakeDamage(int damage)
    {
        CurrHealth -= damage;

        if (CurrHealth <= 0)
        {
            isAlive = false;
        }
    }
    
    /// <summary>
    /// Each enemy type will shoot bullets in a different way
    /// </summary>
    public abstract void Shoot();
    
    public virtual void Update()
    {
        Walk();
        Shoot();
        
        // If enemy collides with bullet
        // TakeDamage();
    }

}