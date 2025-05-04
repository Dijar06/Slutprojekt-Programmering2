using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Slutprojekt_Programmering2
{
    public abstract class BaseClass
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Color color;
        protected Rectangle hitbox = new Rectangle();

        public Rectangle Hitbox{
            get {return hitbox;}
        }

        public BaseClass(Texture2D texture, Vector2 position, Color color){
            this.texture = texture;
            this.position = position;
            this.color = color;
        }

        public abstract void Update();

        public virtual void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture, hitbox, color);
        }
    }
}