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
        /// The content manager to be used for loading textures
        /// </summary>
        private static ContentManager content;

        /// <summary>
        /// The path of the current map
        /// </summary>
        public static string CurrentMapPath { get; private set; }

        #region File Writing

        /// <summary>
        /// Saves the specified map to a file specified by the user
        /// </summary>
        /// <param name="map">The map to save as</param>
        /// <returns>TRUE if saved, FALSE if cancelled</returns>
        public static bool SaveMapAs(Map map)
        {
            //Create a new save file dialog
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Railgun Map files (*.rgm)|*.rgm";
            dialog.Title = "Save map as:";

            //If canceled, return null
            if (dialog.ShowDialog() != DialogResult.OK)
                return false;

            //Set the new map path
            CurrentMapPath = dialog.FileName;

            //Save the map
            SaveMap(map);

            //It saved
            return true;
        }

        /// <summary>
        /// Saves the specified map to the current map path
        /// </summary>
        /// <param name="map">The map to save</param>
        public static void SaveMap(Map map)
        {
            //If a new file, prompt user to save
            if(CurrentMapPath == null)
            {
                SaveMapAs(map);
                return;
            }

            //Create a file writer from this path
            BinaryWriter writer = new BinaryWriter(File.OpenWrite(CurrentMapPath));

            //Create an identifier that can make sure this is a valid file
            writer.Write(FileIdentifier);

            //Write tile size
            writer.Write(map.TileSize);

            //Write layer count
            writer.Write(map.Layers.Count);

            //Repeat for each layer of tiles
            foreach (Dictionary<Vector2, Tile> tileLayer in map.Layers)
            {
                WriteLayer(writer, tileLayer);
            }

            //Close the writer
            writer.Close();

            //DEBUG
            DebugLog.Instance.LogPersistant(
                "Saved map: " + FileManager.GetFileName(FileManager.CurrentMapPath),
                Microsoft.Xna.Framework.Color.Yellow, 5f);
        }

        /// <summary>
        /// Writes all attributes of the specified layer
        /// </summary>
        /// <param name="writer">Writer to write to</param>
        /// <param name="layer">Layer to write</param>
        private static void WriteLayer(BinaryWriter writer, Dictionary<Vector2, Tile> layer)
        {
            //Write tile coordinate count
            writer.Write(layer.Count);

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
        /// <param name="tilePair">Tile coordinate pair to write</param>
        private static void WriteTilePair(BinaryWriter writer, KeyValuePair<Vector2,Tile> tilePair)
        {
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
            WriteVisual(writer, tile.Visual);
            writer.Write(tile.IsSolid);
        }

        /// <summary>
        /// Writes all attributes of the specified visual
        /// </summary>
        /// <param name="writer">Writer to write to</param>
        /// <param name="visual">Visual to write</param>
        private static void WriteVisual(BinaryWriter writer, TextureVisual visual)
        {
            //write in order of constructor
            writer.Write(visual.Tint.PackedValue);//Write as packed val
            WritePathedTexture(writer, visual.Texture);
            WriteRectangle(writer, visual.Source);
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

        #region File Reading

        /// <summary>
        /// Loads a map from the specified path
        /// </summary>
        /// <param name="content">The content manager to load textures from</param>
        /// <returns>The map loaded, null if cancelled or unreadable</returns>
        public static Map LoadMap(ContentManager contentManager)
        {
            //New load file dialog with file extension
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Railgun Map files (*.rgm)|*.rgm";
            dialog.Title = "Save map as:";

            //If the user cancels, return null
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            //Update current path
            CurrentMapPath = dialog.FileName;

            //Set content manager
            content = contentManager;

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
                Map map = new Map(reader.ReadInt32());

                int layerCount = reader.ReadInt32();

                //Read and add each layer
                for (int i = 0; i < layerCount; i++)
                {
                    map.Layers.Add(ReadLayer(reader));
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
            finally
            {
                //Close reader
                reader.Close();

                //DEBUG
                DebugLog.Instance.LogPersistant(
                    "Loaded map: " + FileManager.GetFileName(FileManager.CurrentMapPath),
                    Microsoft.Xna.Framework.Color.Yellow, 5f);
            }
        }

        /// <summary>
        /// Reads all attributes of the specified layer from the reader
        /// </summary>
        /// <param name="reader">The reader to read with</param>
        /// <returns>The layer (dictionary) of the </returns>
        private static Dictionary<Vector2, Tile> ReadLayer(BinaryReader reader)
        {
            Dictionary<Vector2, Tile> layer = new Dictionary<Vector2, Tile>();

            int tileCount = reader.ReadInt32();

            //Repeat for the count of the layer
            for(int i = 0; i < tileCount; i++)
            {
                //Add tile coordinate pair
                KeyValuePair<Vector2, Tile> tilePair = ReadTilePair(reader);
                layer[tilePair.Key] = tilePair.Value;
            }

            return layer;
        }

        /// <summary>
        /// Reads all attributes of the specified tile coordinate pair from the reader
        /// </summary>
        /// <param name="reader">The reader to read with</param>
        /// <returns>The tile coordinate pair</returns>
        private static KeyValuePair<Vector2, Tile> ReadTilePair(BinaryReader reader)
        {
            //Create position from next two floats (singles), then read tile
            return new KeyValuePair<Vector2, Tile>(
                new Vector2(reader.ReadSingle(), reader.ReadSingle()),
                ReadTile(reader));
        }

        /// <summary>
        /// Reads all attributes of the specified tile from the reader
        /// </summary>
        /// <param name="reader">The reader to read with</param>
        /// <returns>The tile to read</returns>
        private static Tile ReadTile(BinaryReader reader)
        {
            return new Tile(ReadVisual(reader), reader.ReadBoolean());
        }

        /// <summary>
        /// Reads all attributes of the specified visual from the reader
        /// </summary>
        /// <param name="reader">The reader to read with</param>
        /// <returns>The texture visual read in</returns>
        private static TextureVisual ReadVisual(BinaryReader reader)
        {
            return new TextureVisual(
                new Color(reader.ReadUInt32()),//Unpack color
                ReadPathedTexture(reader),//Read texture
                ReadRectangle(reader),//source rect
                reader.ReadSingle(),//Rotation
                reader.ReadSingle(),//Scale
                (SpriteEffects)reader.ReadInt32());//Flip
        }

        /// <summary>
        /// Reads all attributes of the specified pathed texture from the reader
        /// </summary>
        /// <param name="reader">The reader to read with</param>
        /// <param name="texture">The pathed texture to write</param>
        private static PathedTexture? ReadPathedTexture(BinaryReader reader)
        {
            //Read in as string
            string path = reader.ReadString();

            //If null texture
            if(path == "*")
            {
                return null;
            }

            //Else, return load in pathed texture
            return LoadPathedTexture(content, path);
        }

        /// <summary>
        /// Reads all attributes of the specified nullable rectangle from the reader
        /// </summary>
        /// <param name="reader">The reader to read with</param>
        /// <returns>The read in rectangle</returns>
        private static Rectangle? ReadRectangle(BinaryReader reader)
        {
            //If has value, read in rectangle
            if(reader.ReadBoolean())
            {
                return new Rectangle(
                    reader.ReadInt32(),//x
                    reader.ReadInt32(),//y
                    reader.ReadInt32(),//width
                    reader.ReadInt32());//height
            }

            //If not, return null
            return null;
        }

        #endregion

        #region Utility

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

        /// <summary>
        /// Returns the name or directory from the specified path
        /// </summary>
        /// <param name="path">The path of the file or directory to get its name</param>
        /// <returns>The name of the file or directory</returns>
        public static string GetFileName(string path)
        {
            return path.Substring(path.LastIndexOf('\\') + 1);
        }

        /// <summary>
        /// Returns the name or directory from the specified path without the extension
        /// <para>(For example ".rgm" )</para>
        /// </summary>
        /// <param name="path">The path of the file or directory to get its name</param>
        /// <returns>The name of the file or directory</returns>
        public static string GetFileNameNoExtension(string path)
        {
            //Cuts off the '.' end of the name
            return GetFileName(path).Split('.')[0];
        }

        #endregion
    }
}
