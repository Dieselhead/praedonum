using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Praedonum
{
    public class PDCamera : GameComponent
    {
        public Matrix view { get; protected set; }
        public Matrix projection { get; protected set; }

        public PDCamera(Game game, Vector3 pos_, Vector3 target_, Vector3 up)
            : base(game)
        {
            view = Matrix.CreateLookAt(pos_, target_, up);

            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4, Game.GraphicsDevice.Viewport.AspectRatio, 1.0f, 1000.0f);
        }

    }

    
}
