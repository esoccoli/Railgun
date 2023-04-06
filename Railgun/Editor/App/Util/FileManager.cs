using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Railgun.Editor.App.Objects;
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

        /// <summary>
        /// Called when the status of modified is changed
        /// </summary>
        public static event GenericDelegate OnModifyInvalidate;

        /// <summary>
        /// If the current map has been modified.
        /// <para>Note: when changing the current value to a different value,
        /// the value will be invalidated and the resulting event will be called</para>
        /// </summary>
        public static bool Modified
        {
            get => modified;
            set
            {
                //Notify if different
                if(modified != value)
                {
                    modified = value;
                    //Notify anything that needs to be called when this is changed
                    OnModifyInvalidate?.Invoke();
                }
            }
        }
        private static bool modified;

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
            foreach(Dictionary<Vector2, Tile> tileLayer in map.Layers)
            {
                WriteLayer(writer, tileLayer);
            }

            //Write hitbox count
            writer.Write(map.Hitboxes.Count);
            //Write hitboxes
            foreach(KeyValuePair<Vector2, bool> hitbox in map.Hitboxes)
            {
                WriteVector(writer, hitbox.Key);
                writer.Write(hitbox.Value);
            }

            //Close the writer
            writer.Close();

            //Set modified to false
            Modified = false;

            //DEBUG
            DebugLog.Instance.LogPersistant(
                "Saved map: " + GetFileName(CurrentMapPath),
                Color.LawnGreen, 5f);
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
            WriteVector(writer, tilePair.Key);
            WriteTile(writer, tilePair.Value);
        }

        /// <summary>
        /// Writes the specified vector to the writer
        /// </summary>
        /// <param name="writer">Writer to write to</param>
        /// <param name="position">Vector to write</param>
        private static void WriteVector(BinaryWriter writer, Vector2 position)
        {
            writer.Write(position.X);
            writer.Write(position.Y);
        }

        /// <summary>
        /// Writes all attributes of the specified tile
        /// </summary>
        /// <param name="writer">Writer to write to</param>
        /// <param name="tile">Tile to write</param>
        private static void WriteTile(BinaryWriter writer, Tile tile)
        {
            //write in order of constructor
            writer.Write(tile.Tint.PackedValue);//Write as packed val
            WritePathedTexture(writer, tile.Texture);
            WriteRectangle(writer, tile.Source);
            writer.Write(tile.Rotation);
            writer.Write((int)tile.SpriteEffect);//The enum as an int value
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
            //Prompt if there are unsaved changes
            if (Modified)
            {
                //Made a local var here just to make it easier to read
                DialogResult choice = MessageBox.Show(
                    $"The current map has unsaved changes. Are you sure you want to open a diferrent map?",
                    "Unsaved Changes:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //If not yes, return
                if (choice != DialogResult.Yes)
                    return null;
            }

            //New load file dialog with file extension
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Railgun Map files (*.rgm)|*.rgm",
                Title = "Save map as:",
                InitialDirectory = Path.GetFullPath("../../Resources/")
            };


            //If the user cancels, return null
            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

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
                        "Error Reading File:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                //Begin actually reading the map
                Map map = new Map(reader.ReadInt32());

                //Store tile layer count
                int layerCount = reader.ReadInt32();
                //Read and add each layer
                for (int i = 0; i < layerCount; i++)
                {
                    map.Layers.Add(ReadLayer(reader));
                }

                //Store hitbox count
                int hitboxCount = reader.ReadInt32();
                //Read and add each hitbox
                for (int i = 0; i < hitboxCount; i++)
                {
                    map.Hitboxes[ReadVector(reader)] = reader.ReadBoolean();
                }

                //Update current path if it makes it all the way through
                CurrentMapPath = dialog.FileName;

                //Set modified to false
                Modified = false;

                //DEBUG
                DebugLog.Instance.LogPersistant(
                    "Loaded map: " + GetFileName(CurrentMapPath),
                    Microsoft.Xna.Framework.Color.Yellow, 5f);

                return map;
            }
            catch (Exception e)
            {
                //Show error dialog
                MessageBox.Show("An error occured: " + e.Message,
                    "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //DEBUG
                DebugLog.Instance.LogPersistant(
                    "Error loading map!",
                    Microsoft.Xna.Framework.Color.Red, 5f);

                return null;
            }
            finally
            {
                //Close reader
                reader.Close();
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
        /// Reads the next two floats (singles) from the reader and returns a vector2
        /// </summary>
        /// <param name="reader">Reader to read with</param>
        /// <returns>The vector2</returns>
        private static Vector2 ReadVector(BinaryReader reader)
        {
            return new Vector2(reader.ReadSingle(), reader.ReadSingle());
        }

        /// <summary>
        /// Reads all attributes of the specified tile coordinate pair from the reader
        /// </summary>
        /// <param name="reader">The reader to read with</param>
        /// <returns>The tile coordinate pair</returns>
        private static KeyValuePair<Vector2, Tile> ReadTilePair(BinaryReader reader)
        {
            //Create position from next two floats (singles), then read tile
            return new KeyValuePair<Vector2, Tile>(ReadVector(reader), ReadTile(reader));
        }

        /// <summary>
        /// Reads all attributes of the specified tile from the reader
        /// </summary>
        /// <param name="reader">The reader to read with</param>
        /// <returns>The tile to read</returns>
        private static Tile ReadTile(BinaryReader reader)
        {
            return new Tile(
                new Color(reader.ReadUInt32()),//Unpack color
                ReadPathedTexture(reader),//Read texture
                ReadRectangle(reader),//source rect
                reader.ReadSingle(),//Rotation
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
            //If no path, return null
            if(path == null)
                return null;

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
            //If no path, return null
            if (path == null)
                return null;

            //Cuts off the '.' end of the name
            string fileName = GetFileName(path);
            return fileName.Substring(0, fileName.LastIndexOf('.'));
        }

        #endregion
    }
}
