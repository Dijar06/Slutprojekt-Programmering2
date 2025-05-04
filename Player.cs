using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt_Programmering2
{
    public class Player : BaseClass
    {
        List<Bullet> bullets = new List<Bullet>();
        MouseState oldState;

        public List<Bullet> Bullets{
            get{return bullets;}
        }
        public Player(Texture2D texture, Vector2 position, Color color) : base(texture, position, color){
            hitbox.Size = new Point(50,50);
        }

        public override void Update(){
            KeyboardState kstate = Keyboard.GetState();
            if(kstate.IsKeyDown(Keys.D)){
                position.X++;
            }
            if(kstate.IsKeyDown(Keys.A)){
                position.X--;
            }
            if(kstate.IsKeyDown(Keys.W)){
                position.Y--;
            }
            if(kstate.IsKeyDown(Keys.S)){
                position.Y++;
            }

            MouseState mState = Mouse.GetState();
            Vector2 vel = mState.Position.ToVector2() - position;
            vel.Normalize();

            if(mState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released){
                Bullet bullet1 = new Bullet(texture, position, Color.Yellow, vel);
                bullets.Add(bullet1);
            }

            oldState = mState;
            hitbox.Location = position.ToPoint();
        }
    }
}