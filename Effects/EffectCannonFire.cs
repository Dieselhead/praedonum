using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ActorPack;

namespace Praedonum
{
    public class EffectCannonFire : SpriteEffect
    {
        public EffectCannonFire(Game game)
            : base(game)
        {

        }

        public override void SetGraphics()
        {
            Animation anim = null;
            AnimationSet set;

            for (int i = 0; i < 1; i++)
            {
                anim = new Animation(Game);
                anim.Initialize(ref GameplayScreen.m_tExplosion);

                set = new AnimationSet("idle", false, 16.0f, 0);
                set.AddFrame(new Rectangle(0, 0, 320, 240));
                set.AddFrame(new Rectangle(0, 240, 320, 240));
                set.AddFrame(new Rectangle(320, 0, 320, 240));
                set.AddFrame(new Rectangle(320, 240, 320, 240));
                set.AddFrame(new Rectangle(640, 0, 320, 240));
                set.AddFrame(new Rectangle(640, 240, 320, 240));
                set.AddFrame(new Rectangle(0, 480, 320, 240));
                set.AddFrame(new Rectangle(0, 720, 320, 240));
                set.AddFrame(new Rectangle(320, 480, 320, 240));
                set.AddFrame(new Rectangle(320, 720, 320, 240));
                set.AddFrame(new Rectangle(640, 480, 320, 240));
                set.AddFrame(new Rectangle(640, 720, 320, 240));
                set.AddFrame(new Rectangle(960, 0, 320, 240));
                set.AddFrame(new Rectangle(960, 240, 320, 240));
                set.AddFrame(new Rectangle(1280, 0, 320, 240));
                set.AddFrame(new Rectangle(960, 480, 320, 240));
                set.AddFrame(new Rectangle(1280, 240, 320, 240));
                set.AddFrame(new Rectangle(1600, 0, 320, 240));
                set.AddFrame(new Rectangle(960, 720, 320, 240));
                set.AddFrame(new Rectangle(1280, 480, 320, 240));
                set.AddFrame(new Rectangle(1600, 240, 320, 240));
                set.AddFrame(new Rectangle(1280, 720, 320, 240));
                set.AddFrame(new Rectangle(1600, 480, 320, 240));
                set.AddFrame(new Rectangle(1600, 720, 320, 240));
                set.AddFrame(new Rectangle(0, 960, 320, 240));
                set.AddFrame(new Rectangle(0, 1200, 320, 240));

                anim.AddSet(set);
                anim.Origin = new Vector2(160, 120);
                anim.SetActiveSet("idle", 0);
                anim.Position = Position + new Vector2(Game1.Rand.Next(-20, 20), Game1.Rand.Next(-20, 20));
                anim.Depth = 0.9f;
                anim.Scale = Vector2.One * ((float)Game1.Rand.NextDouble() * 0.25f + 0.25f);
                anim.Rotation = (float)Game1.Rand.NextDouble() * (float)Math.PI;


                m_anim.Add(anim);
            }

            

        }
    }
}
