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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Railgun.Editor.App.Util
{
    /// <summary>
    /// An enum that defines the type of data being written
    /// </summary>
    internal enum TypeIndicator
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
        /// The identifier for a Railgun map file
        /// </summary>
        private const string FileIdentifier = "RailgunMapRGM";

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

            //If canceled, return null
            if (dialog.ShowDialog() != DialogResult.OK)
                return null;

            //Create a file writer from this path
            BinaryWriter writer = new BinaryWriter(File.OpenWrite(dialog.FileName));

            //Create an identifier that can make sure this is a valid file
            writer.Write(FileIdentifier);

            //Write tile size
            writer.Write(map.TileSize);

            //Repeat for each layer of tiles
            foreach (Dictionary<Vector2, Tile> tileLayer in map.Layers)
            {
                WriteLayer(writer, tileLayer);
            }

            writer.Close();
            //Return the path of the newly written file
            return dialog.FileName;
        }

        /// <summary>
        /// Loads a map from the specified path
        /// </summary>
        /// <param name="path">The path to load from</param>
        /// <returns>The map loaded, null if cancelled or unreadable</returns>
        public static Map LoadMap(string path)
        {
            //New load file dialog with file extension
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Railgun Map files (*.rgm)|*.rgm";
            dialog.Title = "Save map as:";

            //If the user cancels, return null
            if (dialog.ShowDialog() != DialogResult.OK)
                return null;

            //Create file reader
            BinaryReader reader = new BinaryReader(File.OpenRead(dialog.FileName));

            try
            {
                //Check if the file is valid, if not return null
                if (reader.ReadString() != FileIdentifier)
                {
                    //Show error dialog
                    MessageBox.Show("File was unreadable: Incorrect identifier",
                        "Error Reading File:", MessageBoxButtons.OK);
                    return null;
                }

                //Begin actually reading the map
                Map map = new Map(reader.Read());

                //Set initial indicator
                int indicator = reader.Read();

                //While it hasn't finished, read the next data type
                while(indicator != -1)
                {
                    //Try each type
                    switch(indicator)
                    {
                        case (int)TypeIndicator.Layer:
                            
                            break;
                        case (int)TypeIndicator.Tile:

                            break;
                        case (int)TypeIndicator.Entity:
                            
                            break;
                        default:
                            //Show error dialog
                            MessageBox.Show("File was unreadable: " +
                                "Invalid type indicator",
                                "Error Reading File:", MessageBoxButtons.OK);
                            return null;
                    }
                }

                
                return map;
            }
            catch (Exception e)
            {
                //Show error dialog
                MessageBox.Show("An error occured: " + e.Message,
                    "Error:", MessageBoxButtons.OK);
                return null;
            }
            finally { reader.Close(); }//Close reader
        }

        #region Object Writer Methods

        /// <summary>
        /// Writes all attributes of the specified layer
        /// </summary>
        /// <param name="writer">Writer to write to</param>
        /// <param name="layer">Layer to write</param>
        private static void WriteLayer(BinaryWriter writer, Dictionary<Vector2, Tile> layer)
        {
            //Put indicator for where we are
            writer.Write((int)TypeIndicator.Layer);

            //Repeat for each tile in the layer
            foreach (KeyValuePair<Vector2, Tile> tilePair in layer)
            {
                WriteTilePair(writer, tilePair);
            }
        }

        /// <summary>
        /// Writes all attributes of the specified tile coordinate pair
        /// </summary>
        /// <param name="writer">Writer to write to</param>
        /// <param name="layer">Tile coordinate pair to write</param>
        private static void WriteTilePair(BinaryWriter writer, KeyValuePair<Vector2,Tile> tilePair)
        {
            //Put intdicator for tile
            writer.Write((int)TypeIndicator.Tile);

            //Define the key and value
            Vector2 position = tilePair.Key;

            //Write position of tile
            writer.Write(position.X);
            writer.Write(position.Y);
            WriteTile(writer, tilePair.Value);
        }

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

        #region Object Reader Methods

        /// <summary>
        /// Reads all attributes of the specified layer
        /// </summary>
        /// <param name="writer">Writer to write to</param>
        /// <param name="layer">Layer to write</param>
        private static void ReadLayer(BinaryWriter writer, Dictionary<Vector2, Tile> layer)
        {
            //Put indicator for where we are
            writer.Write((int)TypeIndicator.Layer);

            //Repeat for each tile in the layer
            foreach (KeyValuePair<Vector2, Tile> tilePair in layer)
            {
                ReadTilePair(writer, tilePair);
            }
        }

        /// <summary>
        /// Reads all attributes of the specified tile coordinate pair
        /// </summary>
        /// <param name="writer">Writer to write to</param>
        /// <param name="layer">Tile coordinate pair to write</param>
        private static void ReadTilePair(BinaryWriter writer, KeyValuePair<Vector2, Tile> tilePair)
        {
            //Put intdicator for tile
            writer.Write((int)TypeIndicator.Tile);

            //Define the key and value
            Vector2 position = tilePair.Key;

            //Write position of tile
            writer.Write(position.X);
            writer.Write(position.Y);
            ReadTile(writer, tilePair.Value);
        }

        /// <summary>
        /// Reads all attributes of the specified tile
        /// </summary>
        /// <param name="writer">Writer to write to</param>
        /// <param name="tile">Tile to write</param>
        private static void ReadTile(BinaryWriter writer, Tile tile)
        {
            writer.Write(tile.IsSolid);
            WriteVisual(writer, tile.Visual);
        }

        /// <summary>
        /// Reads all attributes of the specified visual
        /// </summary>
        /// <param name="writer">Writer to write to</param>
        /// <param name="visual">Visual to write</param>
        private static void ReadVisual(BinaryWriter writer, TextureVisual visual)
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
        /// Reads all attributes of the specified pathed texture
        /// </summary>
        /// <param name="writer">The writer to write to</param>
        /// <param name="texture">The pathed texture to write</param>
        private static void ReadPathedTexture(BinaryWriter writer, PathedTexture? texture)
        {
            //If not null, write path
            if (texture.HasValue)
            {
                writer.Write(texture.Value.Path);
                return;
            }
            //If null path, write an invalid character
            writer.Write("*");
        }

        /// <summary>
        /// Reads all attributes of the specified nullable rectangle
        /// </summary>
        /// <param name="writer">The writer to write to</param>
        /// <param name="rectangle">The nullable rectangle to write</param>
        private static void ReadRectangle(BinaryWriter writer, Rectangle? rectangle)
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
