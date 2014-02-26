namespace XTankWarsLibrary.SpriteClasses
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using XTankWarsLibrary.TileEngine;

    public class MovableSprite
    {
        #region Field 
        private const float MaxSpeed = 16.0f;
        private const float MinSpeed = 1.00f;
        private const float DefaultSpeed = 2.0f;

        private Tileset tileset;
        private Tile tile;
        private Vector2 position;
        private Vector2 velocity;
        private float rotationAngle = 0.00f;
        private float speed = DefaultSpeed;
        private bool isActive = false;
        private Direction direction = Direction.Up;
        #endregion

        #region Constructor
        public MovableSprite(Tileset tileset, Tile tile)
        {
            this.tileset = tileset;
            this.tile = tile;
            this.isActive = true;
            this.rotationAngle = 0.0f;
            this.speed = DefaultSpeed;
            this.direction = Direction.Up;
        }
        #endregion

        #region Property
        public Tileset Tileset
        {
            get
            {
                return this.tileset;
            }
        }

        public Tile Tile
        {
            get
            {
                return this.tile;
            }
        }

        public int Width
        {
            get 
            {
                return this.tileset.TileWidth; 
            }
        }

        public int Height
        {
            get 
            {
                return this.tileset.TileHeight; 
            }
        }

        public float Speed
        {
            get 
            {
                return this.speed; 
            }

            set 
            {
                this.speed = MathHelper.Clamp(this.speed, MinSpeed, MaxSpeed); 
            }
        }

        public Vector2 Position
        {
            get 
            {
                return this.position; 
            }

            set
            {

                this.position = value;
            }
        }

        public Vector2 Velocity
        {
            get 
            {
                return this.velocity; 
            }

            set
            {
                this.velocity = value;
                if (this.velocity != Vector2.Zero)
                {
                    this.velocity.Normalize();
                }
            }
        }
        #endregion

        #region Method 
        public void Update(GameTime gameTime)
        {
            if (this.isActive)
            {

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.tileset.Texture,
                this.position,
                this.tileset.SourceRectangle[this.tile.TileIndex],
                Color.White);
        }

        public void LockToMap()
        {
            this.position.X = MathHelper.Clamp(this.position.X, 0, TileMap.WidthInPixels - this.Width);
            this.position.Y = MathHelper.Clamp(this.position.Y, 0, TileMap.HeightInPixels - this.Height);
        }

        #endregion
    }
}
