using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.RailgunGame.Util
{
    /// <summary>
    /// Represents a camera based on matrix transformations
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/15/2023
    /// </summary>
    internal class Camera
    {
        /// <summary>
        /// The absolute minimum that the minimum zoom can be set to
        /// </summary>
        private const float AbsoluteMinZoom = 0.000001f;

        /// <summary>
        /// The graphics of the game
        /// </summary>
        private GraphicsDevice graphics;

        /// <summary>
        /// The current viewport of the game in camera space
        /// </summary>
        public Rectangle CurrentWorldViewRectangle { get; private set; }

        /// <summary>
        /// The center of this camera in world space
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// The current scale or zoom of the camera
        /// </summary>
        public float Zoom
        {
            get => zoom;
            set
            {
                //Make sure it is within the bounds
                if (value < MinZoom)
                {
                    zoom = MinZoom;
                    return;
                }
                if (value > MaxZoom)
                {
                    zoom = MaxZoom;
                    return;
                }
                zoom = value;
            }
        }
        private float zoom;

        /// <summary>
        /// The maximum zoom allowed for the camera
        /// </summary>
        public float MaxZoom
        {
            get => maxZoom;
            set
            {
                //Make sure it is not below the min
                if (value < MinZoom)
                {
                    maxZoom = MinZoom;
                    return;
                }
                maxZoom = value;
            }
        }
        private float maxZoom;

        /// <summary>
        /// The minimum zoom allowed for the camera
        /// </summary>
        public float MinZoom
        {
            get => minZoom;
            set
            {
                //If less than abs min
                if (value < AbsoluteMinZoom)
                {
                    minZoom = AbsoluteMinZoom;
                    return;
                }
                //Make sure it is not 
                minZoom = value;
            }
        }
        private float minZoom;

        /// <summary>
        /// The rotation of the matrix
        /// </summary>
        public float Rotation { get; set; }

        /// <summary>
        /// The boundries that the camera can move within. Set to Rectangle.Empty
        /// to not have camera bounds
        /// </summary>
        public Rectangle CameraBounds { get; set; }

        /// <summary>
        /// The target boundries that the camera bounds should ease to
        /// </summary>
        public Rectangle TargetBounds { get; set; }

        /// <summary>
        /// The matrix of the camera created by the last update
        /// </summary>
        public Matrix TransformationMatrix { get; private set; }

        /// <summary>
        /// Creates a camera rendering within the bounds of the specified viewport
        /// </summary>
        /// <param name="graphicsDevice">The graphics device of the game to use</param>
        /// <param name="bounds">The bounds that the camera can move to
        /// (if none, use Rectangle.Empty)</param>
        /// <param name="minZoom">The minimum zoom</param>
        /// <param name="maxZoom">The maximum zoom</param>
        public Camera(GraphicsDevice graphicsDevice, Rectangle bounds,
            float minZoom = AbsoluteMinZoom, float maxZoom = 9999f)
        {
            graphics = graphicsDevice;
            CameraBounds = bounds;
            MinZoom = minZoom;
            MaxZoom = maxZoom;
            Zoom = 1f;
            Position = Vector2.Zero;
            Rotation = 0f;
            CreateMatrix();//Create an initial matrix
        }

        /// <summary>
        /// Zooms the camera by the specified amount
        /// </summary>
        /// <param name="amount">Amount to zoom by</param>
        public void ZoomBy(float amount)
        {
            Zoom += amount;
        }

        /// <summary>
        /// Pans (translates) the camera by the specified amount
        /// </summary>
        /// <param name="amount">Amount to pan by</param>
        public void PanBy(Vector2 amount)
        {
            Position += amount;
        }

        /// <summary>
        /// Tilts (rotates) the camera by the specified amount
        /// </summary>
        /// <param name="amount">Amount to tilt by</param>
        public void TiltBy(float amount)
        {
            Rotation += amount;
        }

        /// <summary>
        /// Zooms to the specified point and zoom using the specified easing factor
        /// (it will ease out exponentially). Easing factor should usually be between
        /// 0 and 1 unless you want some type of 
        /// </summary>
        /// <param name="targetPosition">Position to try to ease to</param>
        /// <param name="targetZoom">The zoom to try to ease to</param>
        /// <param name="easingFactor">The factor to ease by (for example 0.1f would 
        /// move and zoom by 1 tenth the distance each time it is called)</param>
        public void EaseTo(Vector2 targetPosition, float targetZoom,
            float easingFactor)
        {
            //Ease pan and zoom
            PanBy((targetPosition - Position) * easingFactor);
            ZoomBy((targetZoom - Zoom) * easingFactor);
        }

        /// <summary>
        /// Preforms boundry checking and creates the transformation matrix
        /// </summary>
        /// <param name="gameTime">The game time for this frame</param>
        public void Update(GameTime gameTime)
        {
            CreateMatrix();

            //Update world view rectangle and center
            CurrentWorldViewRectangle = GetWorldViewRectangle();

            //Update camera bounds to ease to target
            if(TargetBounds.IsEmpty)
            {
                CameraBounds = Rectangle.Empty;
            }
            else
            {
                float easing = 0.05f;

                Rectangle bounds = CameraBounds;
                bounds.Location += 
                    ((TargetBounds.Location - bounds.Location).ToVector2() * easing).ToPoint();
                bounds.Size +=
                    ((TargetBounds.Size - bounds.Size).ToVector2() * easing).ToPoint();
                CameraBounds = bounds;
            }


            //If there are bounds, resolve them
            if (!CameraBounds.IsEmpty)
            {
                //Check if current view is within rectangle bounds
                Vector2 newPosition = Position;

                //Check if width are too small for viewport, center it
                if(CameraBounds.Width < CurrentWorldViewRectangle.Width)
                {
                    newPosition.X = CameraBounds.Center.X;
                }
                //Otherwise check left or right
                else if (CameraBounds.X > CurrentWorldViewRectangle.X)
                {
                    newPosition.X += CameraBounds.X - CurrentWorldViewRectangle.X;
                }
                else if (CameraBounds.Right < CurrentWorldViewRectangle.Right)
                {
                    newPosition.X -= CurrentWorldViewRectangle.Right - CameraBounds.Right;
                }

                //Check if height are too small for viewport, center it
                if (CameraBounds.Height < CurrentWorldViewRectangle.Height)
                {
                    newPosition.Y = CameraBounds.Center.Y;
                }
                //Otherwise check top or bottom
                else if (CameraBounds.Y > CurrentWorldViewRectangle.Y)
                {
                    newPosition.Y += CameraBounds.Y - CurrentWorldViewRectangle.Y;
                }
                else if (CameraBounds.Bottom < CurrentWorldViewRectangle.Bottom)
                {
                    newPosition.Y -= CurrentWorldViewRectangle.Bottom - CameraBounds.Bottom;
                }

                //Resolve position
                Position = Vector2.Floor(newPosition);
                DebugLog.Instance.LogFrame(Position);

                //Update view matrix with resolved (I know, this is terrible, I'll
                //Change it later if I have time) Reason I'm doing this is to
                //First compute the matrix to find the bounding box of the cam, then resolve
                CreateMatrix();

            }

        }

        /// <summary>
        /// Creates a matrix based on the current transformations
        /// </summary>
        private void CreateMatrix()
        {
            //Update view matrix raw
            TransformationMatrix =
                Matrix.CreateTranslation(new Vector3(-Position, 0f))//Translate
                * Matrix.CreateRotationZ(Rotation)//Rotate
                * Matrix.CreateScale(Zoom, Zoom, 1f)//Zoom
                * Matrix.CreateTranslation(new Vector3(
                        graphics.Viewport.Width * 0.5f,
                        graphics.Viewport.Height * 0.5f, 0f));//Translate to center of screen
        }

        /// <summary>
        /// Computes the world view rectangle
        /// </summary>
        /// <returns>The world viewport as a rectangle in camera space</returns>
        private Rectangle GetWorldViewRectangle()
        {
            //Idk if there is a more efficient way to do this but for now it is this

            //Use matrix to figure out rectangle bounds
            Matrix inversion = Matrix.Invert(TransformationMatrix);

            //Half width and height
            Vector2 halfSize =
                new Vector2(
                    graphics.Viewport.Width * 0.5f,
                    graphics.Viewport.Height * 0.5f);

            //Compute important points of the view rectangle
            Vector2 topLeft = Vector2.Transform(-halfSize, inversion);
            Vector2 bottomRight = Vector2.Transform(halfSize, inversion);

            //Create a rectangle from the two points and translate by half width and height scaled by inverse
            return new Rectangle((topLeft + halfSize / Zoom).ToPoint(), (bottomRight - topLeft).ToPoint());
        }

        /// <summary>
        /// Returns the specified screen point in the world space
        /// </summary>
        /// <param name="point">Absolute screen position</param>
        /// <returns>Camera or world position of point</returns>
        public Vector2 ScreenToWorld(Vector2 point)
            => Vector2.Transform(point, Matrix.Invert(TransformationMatrix));
    }
}
