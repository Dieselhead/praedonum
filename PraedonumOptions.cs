using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Praedonum
{
    public struct PraedonumOptions
    {
        public uint ScreenWidth { get; set; }
        public uint ScreenHeight { get; set; }
        public bool Windowed { get; set; }
    }
}
