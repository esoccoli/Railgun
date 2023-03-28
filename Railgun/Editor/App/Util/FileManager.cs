using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Railgun.Editor.App.Objects;
using Railgun.Editor.App.Objects.Visuals;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railgun.Editor.App.Util
{
    /// <summary>
    /// An enum that defines the type of data being written
    /// </summary>
    internal enum DataTypeIndicator
    {
        Layer,
        Tile,
        Entity
    }

    /// <summary>
    /// A manager that preforms common file tasks
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 3/28/2023
    /// </summary>
    internal class FileManager
    {
        /// <summary>
        /// Saves the specified map to a file specified by the user
        /// </summary>
        /// <param name="map">The map to save as</param>
        /// <returns>The path to the file, null if canceled by user</returns>
        public static string SaveMapAs(Map map)
        {
            //Create a new save file dialog
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Railgun Map files (*.rgm)|*.rgm";
            dialog.Title = "Save map as:";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //Create a file writer from this path
                BinaryWriter writer = new BinaryWriter(File.OpenWrite(dialog.FileName));

                //Write tile size
                writer.Write(map.TileSize);

                //Repeat for each layer of tiles
                foreach(Dictionary<Vector2, Tile> tileLayer in map.Layers)
                {
                    //Put indicator for where we are
                    writer.Write((int)DataTypeIndicator.Layer);

                    //Repeat for each tile in the layer
                    foreach(KeyValuePair<Vector2, Tile> tilePair in tileLayer)
                    {
                        //Put intdicator for tile
                        writer.Write((int)DataTypeIndicator.Tile);

                        //Define the key and value
                        Vector2 position = tilePair.Key;

                        //Write position of tile
                        writer.Write(position.X);
                        writer.Write(position.Y);
                        WriteTile(writer, tilePair.Value);
                    }
                }

                writer.Close();
                //Return the path of the newly written file
                return dialog.FileName;
            }

            //If it gets here, return null
            return null;
        }

        #region Object Writer Methods

        /// <summary>
        /// Writes all attributes of the specified tile
        /// </summary>
        /// <param name="writer">Writer to write to</param>
        /// <param name="tile">Tile to write</param>
        private static void WriteTile(BinaryWriter writer, Tile tile)
        {
            writer.Write(tile.IsSolid);
            WriteVisual(writer, tile.Visual);
        }

        /// <summary>
        /// Writes all attributes of the specified visual
        /// </summary>
        /// <param name="writer">Writer to write to</param>
        /// <param name="visual">Visual to write</param>
        private static void WriteVisual(BinaryWriter writer, TextureVisual visual)
        {
            //Write the texture'sits path
            WritePathedTexture(writer, visual.Texture);
            WriteRectangle(writer, visual.Source);
            writer.Write(visual.Tint.PackedValue);//Write as packed val
            writer.Write(visual.Rotation);
            writer.Write(visual.Scale);
            writer.Write((int)visual.Flip);//The enum as an int value
        }

        /// <summary>
        /// Writes all attributes of the specified pathed texture
        /// </summary>
        /// <param name="writer">The writer to write to</param>
        /// <param name="texture">The pathed texture to write</param>
        private static void WritePathedTexture(BinaryWriter writer, PathedTexture? texture)
        {
            //If not null, write path
            if(texture.HasValue)
            {
                writer.Write(texture.Value.Path);
                return;
            }
            //If null path, write an invalid character
            writer.Write("*");
        }

        /// <summary>
        /// Writes all attributes of the specified nullable rectangle
        /// </summary>
        /// <param name="writer">The writer to write to</param>
        /// <param name="rectangle">The nullable rectangle to write</param>
        private static void WriteRectangle(BinaryWriter writer, Rectangle? rectangle)
        {
            //If not null, write path
            if (rectangle.HasValue)
            {
                writer.Write(true);
                writer.Write(rectangle.Value.X);
                writer.Write(rectangle.Value.Y);
                writer.Write(rectangle.Value.Width);
                writer.Write(rectangle.Value.Height);
                return;
            }
            //If null, return false and move on
            writer.Write(false);
        }

        #endregion

        /// <summary>
        /// Returns a pathed texture using the specified content manager and texture path
        /// </summary>
        /// <param name="content">The content manager to load from</param>
        /// <param name="path">The path of the texture to use</param>
        /// <returns>The pathed texture</returns>
        public static PathedTexture LoadPathedTexture(ContentManager content, string path)
        {
            return new PathedTexture(path, content.Load<Texture2D>(path));
        }
    }
}
