namespace TankWarsGraphics.Componenets
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using TankWarsGraphics;
    using XTankWarsLibrary;
    using XTankWarsLibrary.TileEngine;

    public class Player
    {
        #region Fields
        private Camera camera;
        private Game1 gameRef;
        private InputHandler input;
        // private Tank tank;
        #endregion

        #region Constructors
        public Player(Game game)
        {
            this.gameRef = (Game1)game;
            this.camera = new Camera(this.gameRef.ScreenRectangle);
        }
        #endregion

        #region Propeties
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
        }
        #endregion
    }
}
