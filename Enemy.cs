using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Slutprojekt_Programmering2
{
    public class Enemy : BaseClass
    {
        float velocity = -1;
        float timer = 0;
        public Enemy(Texture2D texture, Vector2 position, Color color) : base(texture, position, color){
            hitbox.Size = new Point(30,30);
        }

        public override void Update(){
            timer += 1f/60f;
            if(position.Y <= 0 || position.Y >= 470){
                velocity *= -1;
            }
            if(timer >= 100){
                velocity = 0;
            }
            position.Y += velocity;
            hitbox.Location = position.ToPoint();
            // y = y + (+1) = y + 1
        }
    }
}