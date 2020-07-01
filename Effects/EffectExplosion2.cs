using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ActorPack;

namespace Praedonum
{
    public class EffectExplosion2 : SpriteEffect
    {
        public EffectExplosion2(Game game)
            : base(game)
        {

        }

        public override void SetGraphics()
        {
            Animation anim;
            AnimationSet set;

            anim = new Animation(Game);
            anim.Initialize(ref GameplayScreen.m_tExplosion2);

            set = new AnimationSet("idle", false, 16.0f, 0);
            set.AddFrame(new Rectangle(0, 0, 160 ,160));
            set.AddFrame(new Rectangle(320, 0, 160 ,160));
            set.AddFrame(new Rectangle(480 ,0 ,160 ,160));
            set.AddFrame(new Rectangle(640, 0 ,160, 160));
            set.AddFrame(new Rectangle(800, 0, 160, 160));
            set.AddFrame(new Rectangle(960, 0, 160, 160));
            set.AddFrame(new Rectangle(1120, 0 ,160 ,160));
            set.AddFrame(new Rectangle(1280 ,0, 160, 160));
            set.AddFrame(new Rectangle(1440, 0 ,160, 160));
            set.AddFrame(new Rectangle(160, 0 ,160 ,160));

            anim.AddSet(set);
            anim.Origin = new Vector2(80, 80);
            anim.SetActiveSet("idle", 0);
            anim.Position = Position;
            anim.Depth = 0.9f;
            anim.Scale = Vector2.One * ((float)Game1.Rand.NextDouble() * 0.75f + 0.25f);
            anim.Rotation = (float)Game1.Rand.NextDouble() * (float)Math.PI * 2;

            m_anim.Add(anim);

        }
    }
}
