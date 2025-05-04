using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Slutprojekt_Programmering2;

public class Game1 : Game
{
    Texture2D texture;
    Player player;
    Bullet bullet;
    Vector2 playerPos = new Vector2(100,300);
    Vector2 enemyPos = new Vector2(500,300);
    double timer = 0;
    Random random = new Random();

    List<BaseClass> entities = new List<BaseClass>();

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        texture = Content.Load<Texture2D>("polis");

        player = new Player(texture, playerPos, Color.Blue);
        Enemy enemy = new Enemy(texture, enemyPos, Color.Red);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        var bullets = player.Bullets;
        // TODO: Add your update logic here
        player.Update();   

        foreach(var enemy in entities){
            enemy.Update();
        }
        foreach (var bullet in bullets){
            bullet.Update();
        }

        timer += gameTime.ElapsedGameTime.TotalSeconds;

        if (timer >= 1){
            int x = random.Next(100, 700);
            int y = random.Next(100, 400);
            Vector2 randomPos = new Vector2(x, y);

            Enemy newEnemy = new Enemy(texture, randomPos, Color.Red);
            entities.Add(newEnemy);

            timer = 0;
        }


        for(int i = 0; i < bullets.Count; i++){
            for(int j = 0; j < entities.Count; j++){
                if(bullets[i].Hitbox.Intersects(entities[j].Hitbox)){
                    entities.RemoveAt(j);
                    j--;
                }
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.SlateGray);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        player.Draw(_spriteBatch);
        foreach (var bullet in player.Bullets){
            bullet.Draw(_spriteBatch);
        }
        foreach (var enemy in entities){
            enemy.Draw(_spriteBatch);
        }
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
