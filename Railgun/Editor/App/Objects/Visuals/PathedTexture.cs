using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Railgun.Editor.App.Objects.Visuals
{
    internal struct PathedTexture
    {
        /// <summary>
        /// The path of this texture relative to the content folder
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// The texture object
        /// </summary>
        public Texture2D Texture { get; }

        /// <summary>
        /// Creates a new pathed texture with the specified texture and path
        /// </summary>
        /// <param name="path">The path of the specified texture
        /// relative to the content folder</param>
        /// <param name="texture">The texture2d</param>
        public PathedTexture(string path, Texture2D texture)
        {
            Path = path;
            Texture = texture;
        }
    }
}
