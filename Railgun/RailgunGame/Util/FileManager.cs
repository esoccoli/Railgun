using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Railgun.RailgunGame.Tilemapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.RailgunGame.Util
{
    /// <summary>
    /// A manager that preforms common file tasks
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/9/2023
    /// </summary>
    internal class FileManager
    {
        /// <summary>
        /// The identifier for a Railgun map file
        /// </summary>
        private const string FileIdentifier = "RailgunMapRGMV2";

        /// <summary>
        /// The content manager to be used for loading textures
        /// </summary>
        private static ContentManager content;

        #region File Reading

        /// <summary>
        /// Loads a map from the specified path
        /// </summary>
        /// <param name="contentManager">The content manager to load textures from</param>
        /// <param name="mapName">The name of the map to load</param>
        /// <returns>The map loaded, null if cancelled or unreadable</returns>
        public static Map LoadMap(ContentManager contentManager, string mapName)
        {
            //Set content manager
            content = contentManager;

            //Create file reader
            BinaryReader reader = null;

            try
            {
                //Read map from the map folder
                reader = new BinaryReader(
                    File.OpenRead($"{content.RootDirectory}/Maps/{mapName}.rgm"));

                //Check if the file is valid, if not return null
                if (reader.ReadString() != FileIdentifier)
                {
                    //Show error log
                    DebugLog.Instance.LogPersistant(
                        $"Loading Map: {mapName} was unreadable: " +
                        $"Map is old, please open and save in the editor",
                        Color.Red, 10f);
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

                //Store entity count
                int entityCount = reader.ReadInt32();
                //Read and add each entity
                for (int i = 0; i < entityCount; i++)
                {
                    map.EntitiesDictionary[ReadVector(reader)] = reader.ReadInt32();
                }

                //Read enterence and exit
                map.Entrence = ReadVector(reader);
                map.Exit = ReadVector(reader);

                //Populate hitbox list
                map.GenerateMapValues();

                return map;
            }
            catch (Exception e)
            {
                //Show error log
                DebugLog.Instance.LogPersistant(
                    $"Loading Map: {mapName}, an error occured: Check Debug Console",
                    Color.Red, 10f);
                System.Diagnostics.Debug.WriteLine(
                    $"Loading Map: {mapName}, an error occured: {e.Message}");

                return null;
            }
            finally
            {
                //Close reader if opened
                reader?.Close();
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
            for (int i = 0; i < tileCount; i++)
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
            Color tint = new Color(reader.ReadUInt32());//Unpack color
            Texture2D texture = ReadPathedTexture(reader);//Read texture
            Rectangle? sourceRect = ReadRectangle(reader);//Read source rect
            float rotation = reader.ReadSingle();//Read rotation
            SpriteEffects flip = (SpriteEffects)reader.ReadInt32();//Read flip

            return new Tile(tint, texture, sourceRect, rotation, flip);
        }

        /// <summary>
        /// Reads all attributes of the specified pathed texture from the reader
        /// </summary>
        /// <param name="reader">The reader to read with</param>
        /// <returns>The read in texture</returns>
        private static Texture2D ReadPathedTexture(BinaryReader reader)
        {
            //Read in as string
            string path = reader.ReadString();

            //If null texture
            if (path == "*")
            {
                return null;
            }

            //Else, return load in texture
            return content.Load<Texture2D>(path);
        }

        /// <summary>
        /// Reads all attributes of the specified nullable rectangle from the reader
        /// </summary>
        /// <param name="reader">The reader to read with</param>
        /// <returns>The read in rectangle</returns>
        private static Rectangle? ReadRectangle(BinaryReader reader)
        {
            //If has value, read in rectangle
            if (reader.ReadBoolean())
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
        /// Returns the name or directory from the specified path
        /// </summary>
        /// <param name="path">The path of the file or directory to get its name</param>
        /// <returns>The name of the file or directory</returns>
        public static string GetFileName(string path)
        {
            //If no path, return null
            if (path == null)
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
