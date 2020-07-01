using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ActorPack;

namespace Praedonum
{
    public class EffectWaterTrail : SpriteEffect
    {
        private float m_startTime = 0;
        private float m_alpha = 1.0f;
        

        public EffectWaterTrail(Game game)
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
                anim.Initialize(ref GameplayScreen.m_tWatersplash);

                set = new AnimationSet("idle", true, 16.0f, 0);
                set.AddFrame(new Rectangle(640, 240, 320, 240));

                anim.AddSet(set);
                anim.Origin = new Vector2(160, 120);
                anim.SetActiveSet("idle", 0);
                anim.Position = Position;
                anim.Depth = 0.3f;
                anim.Scale = Vector2.One * ((float)Game1.Rand.NextDouble() * 0.1f + 0.1f);
                anim.Rotation = (float)Game1.Rand.NextDouble() * (float)Math.PI;


                m_anim.Add(anim);
            }



        }

        public override void Initialize(float killTime, Vector2 pos, bool bKillAtFinish)
        {
            m_startTime = killTime - 3.5f;

            base.Initialize(killTime, pos, bKillAtFinish);
        }

        public override void Update(GameTime gameTime)
        {
            // Move in heading direction
            Position += Heading * 10.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            m_alpha = 1 - (((float)gameTime.TotalGameTime.TotalSeconds - m_startTime) / 3.5f);

            for (int i = 0; i < m_anim.Count; i++)
            {
                m_anim[i].Color = new Color(0.5f, 0.5f, 0.7f, m_alpha - 0.1f);
                m_anim[i].Position = Position;
            }
            
            base.Update(gameTime);
        }
    }
}
