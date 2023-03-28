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
                    //Repeat for each tile in the layer
                    foreach(KeyValuePair<Vector2, Tile> tilePair in tileLayer)
                    {
                        //Define the key and value
                        Vector2 position = tilePair.Key;

                        //Write position of tile
                        writer.Write(position.X);
                        writer.Write(position.Y);
                        WriteTile(tilePair.Value, writer);
                    }
                }

                return dialog.FileName;
            }

            //If it gets here, return null
            return null;
        }

        /// <summary>
        /// Writes all attributes of the specified tile
        /// </summary>
        /// <param name="tile">Tile to write</param>
        /// <param name="writer">Writier to write to</param>
        private static void WriteTile(Tile tile, BinaryWriter writer)
        {
            writer.Write(tile.IsSolid);
            
            //Visual
            TextureVisual visual = tile.Visual;

            //writer.Write();
        }

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
