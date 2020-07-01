using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ActorPack;

namespace Praedonum
{
    public class EffectExplosion3 : SpriteEffect
    {
        public EffectExplosion3(Game game)
            : base(game)
        {

        }

        public override void SetGraphics()
        {
            Animation anim;
            AnimationSet set;

            anim = new Animation(Game);
            anim.Initialize(ref GameplayScreen.m_tExplosion3);

            set = new AnimationSet("idle", false, 16.0f, 0);
            set.AddFrame(new Rectangle(0, 0 ,128, 128));
            set.AddFrame(new Rectangle(516, 0 ,128 ,128));
            set.AddFrame(new Rectangle(516, 129 ,128 ,128));
            set.AddFrame(new Rectangle(645, 0, 128, 128));
            set.AddFrame(new Rectangle(774, 0, 128, 128));
            set.AddFrame(new Rectangle(645, 129, 128 ,128));
            set.AddFrame(new Rectangle(516, 258, 128, 128));
            set.AddFrame(new Rectangle(645, 258 ,128 ,128));
            set.AddFrame(new Rectangle(774, 129, 128, 128));
            set.AddFrame(new Rectangle(129 ,0, 128, 128));
            set.AddFrame(new Rectangle(258, 0, 128 ,128));
            set.AddFrame(new Rectangle(0, 129, 128, 128));
            set.AddFrame(new Rectangle(129, 129 ,128 ,128));
            set.AddFrame(new Rectangle(0 ,258, 128, 128));
            set.AddFrame(new Rectangle(129, 258, 128 ,128));
            set.AddFrame(new Rectangle(258, 129 ,128 ,128));
            set.AddFrame(new Rectangle(258, 258, 128, 128));
            set.AddFrame(new Rectangle(387, 0 ,128, 128));
            set.AddFrame(new Rectangle(387, 129, 128, 128));
            set.AddFrame(new Rectangle(387, 258, 128, 128));

            anim.AddSet(set);
            anim.Origin = new Vector2(64, 64);
            anim.SetActiveSet("idle", 0);
            anim.Position = Position;
            anim.Depth = 0.9f;
            anim.Scale = Vector2.One * ((float)Game1.Rand.NextDouble() * 0.25f + 0.75f);
            anim.Rotation = (float)Game1.Rand.NextDouble() * (float)Math.PI * 2;

            m_anim.Add(anim);

        }
    }
}
