namespace TankWarsGraphics.Componenets
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using TankWarsGraphics;
    using TankWarsLibrary.Tanks;
    using XTankWarsLibrary;
    using XTankWarsLibrary.SpriteClasses;
    using XTankWarsLibrary.TileEngine;
    using Microsoft.Xna.Framework.Graphics;

    public class Player
    {
        #region Fields
        private Camera camera;
        private Game1 gameRef;
        private InputHandler input;
        private MovableSprite tank;
        #endregion

        #region Constructors
        public Player(Game game)
        {
            this.gameRef = (Game1)game;
            this.camera = new Camera(this.gameRef.ScreenRectangle);
        }
        #endregion

        #region Propeties
        public MovableSprite Tank
        {
            get
            {
                return this.tank;
            }

            set
            {
                this.tank = value;
            }
        }

        public Camera Camera
        {
            get
            {
                return this.camera;
            }

            set
            {
                this.camera = value;
            }
        }

        #endregion

        #region Methods
        public void Update(GameTime gameTime)
        {
            this.camera.Update(gameTime);
            this.tank.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.tank.Draw(spriteBatch);
        }
        #endregion
    }
}
