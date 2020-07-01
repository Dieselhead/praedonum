using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ActorPack;

namespace Praedonum
{
    public class PDVChinese : PDVehicle
    {
        public PDVChinese(Game game, GameplayScreen screen)
            : base(game, screen)
        {

        }

        public override void SetDefaultGraphics(ref Texture2D tex_)
        {
            Animation anim;
            AnimationSet set;

            anim = new Animation(Game);
            anim.Initialize(ref tex_);
            anim.Origin = new Vector2(80, 48);


            set = new AnimationSet(PDVehicle.ANIM_IDLE_CENTER, true, 8.0f, 0);
            set.AddFrame(new Rectangle(0, 0, 160, 96));
            set.AddFrame(new Rectangle(160, 0, 160, 96));
            set.AddFrame(new Rectangle(320, 0, 160, 96));
            set.AddFrame(new Rectangle(480, 0, 160, 96));
            set.AddFrame(new Rectangle(640, 0, 160, 96));
            set.AddFrame(new Rectangle(800, 0, 160, 96));
            set.AddFrame(new Rectangle(960, 0, 160, 96));
            set.AddFrame(new Rectangle(1120, 0, 160, 96));
            set.AddFrame(new Rectangle(1280, 0, 160, 96));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT1, true, 8.0f, 0);
            set.AddFrame(new Rectangle(0, 96, 160, 96));
            set.AddFrame(new Rectangle(160, 96, 160, 96));
            set.AddFrame(new Rectangle(320, 96, 160, 96));
            set.AddFrame(new Rectangle(480, 96, 160, 96));
            set.AddFrame(new Rectangle(640, 96, 160, 96));
            set.AddFrame(new Rectangle(800, 96, 160, 96));
            set.AddFrame(new Rectangle(960, 96, 160, 96));
            set.AddFrame(new Rectangle(1120, 96, 160, 96));
            set.AddFrame(new Rectangle(1280, 96, 160, 96));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT2, true, 8.0f, 0);
            set.AddFrame(new Rectangle(0, 192, 160, 96));
            set.AddFrame(new Rectangle(160, 192, 160, 96));
            set.AddFrame(new Rectangle(320, 192, 160, 96));
            set.AddFrame(new Rectangle(480, 192, 160, 96));
            set.AddFrame(new Rectangle(640, 192, 160, 96));
            set.AddFrame(new Rectangle(800, 192, 160, 96));
            set.AddFrame(new Rectangle(960, 192, 160, 96));
            set.AddFrame(new Rectangle(1120, 192, 160, 96));
            set.AddFrame(new Rectangle(1280, 192, 160, 96));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT3, true, 8.0f, 0);
            set.AddFrame(new Rectangle(0, 288, 160, 96));
            set.AddFrame(new Rectangle(160, 288, 160, 96));
            set.AddFrame(new Rectangle(320, 288, 160, 96));
            set.AddFrame(new Rectangle(480, 288, 160, 96));
            set.AddFrame(new Rectangle(640, 288, 160, 96));
            set.AddFrame(new Rectangle(800, 288, 160, 96));
            set.AddFrame(new Rectangle(960, 288, 160, 96));
            set.AddFrame(new Rectangle(1120, 288, 160, 96));
            set.AddFrame(new Rectangle(1280, 288, 160, 96));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT4, true, 8.0f, 0);
            set.AddFrame(new Rectangle(0, 384, 160, 96));
            set.AddFrame(new Rectangle(160, 384, 160, 96));
            set.AddFrame(new Rectangle(320, 384, 160, 96));
            set.AddFrame(new Rectangle(480, 384, 160, 96));
            set.AddFrame(new Rectangle(640, 384, 160, 96));
            set.AddFrame(new Rectangle(800, 384, 160, 96));
            set.AddFrame(new Rectangle(960, 384, 160, 96));
            set.AddFrame(new Rectangle(1120, 384, 160, 96));
            set.AddFrame(new Rectangle(1280, 384, 160, 96));
            anim.AddSet(set);


            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT1, true, 8.0f, 0);
            set.AddFrame(new Rectangle(0, 480, 160, 96));
            set.AddFrame(new Rectangle(160, 480, 160, 96));
            set.AddFrame(new Rectangle(320, 480, 160, 96));
            set.AddFrame(new Rectangle(480, 480, 160, 96));
            set.AddFrame(new Rectangle(640, 480, 160, 96));
            set.AddFrame(new Rectangle(800, 480, 160, 96));
            set.AddFrame(new Rectangle(960, 480, 160, 96));
            set.AddFrame(new Rectangle(1120, 480, 160, 96));
            set.AddFrame(new Rectangle(1280, 480, 160, 96));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT2, true, 8.0f, 0);
            set.AddFrame(new Rectangle(0, 576, 160, 96));
            set.AddFrame(new Rectangle(160, 576, 160, 96));
            set.AddFrame(new Rectangle(320, 576, 160, 96));
            set.AddFrame(new Rectangle(480, 576, 160, 96));
            set.AddFrame(new Rectangle(640, 576, 160, 96));
            set.AddFrame(new Rectangle(800, 576, 160, 96));
            set.AddFrame(new Rectangle(960, 576, 160, 96));
            set.AddFrame(new Rectangle(1120, 576, 160, 96));
            set.AddFrame(new Rectangle(1280, 576, 160, 96));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT3, true, 8.0f, 0);
            set.AddFrame(new Rectangle(0, 672, 160, 96));
            set.AddFrame(new Rectangle(160, 672, 160, 96));
            set.AddFrame(new Rectangle(320, 672, 160, 96));
            set.AddFrame(new Rectangle(480, 672, 160, 96));
            set.AddFrame(new Rectangle(640, 672, 160, 96));
            set.AddFrame(new Rectangle(800, 672, 160, 96));
            set.AddFrame(new Rectangle(960, 672, 160, 96));
            set.AddFrame(new Rectangle(1120, 672, 160, 96));
            set.AddFrame(new Rectangle(1280, 672, 160, 96));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT4, true, 8.0f, 0);
            set.AddFrame(new Rectangle(0, 768, 160, 96));
            set.AddFrame(new Rectangle(160, 768, 160, 96));
            set.AddFrame(new Rectangle(320, 768, 160, 96));
            set.AddFrame(new Rectangle(480, 768, 160, 96));
            set.AddFrame(new Rectangle(640, 768, 160, 96));
            set.AddFrame(new Rectangle(800, 768, 160, 96));
            set.AddFrame(new Rectangle(960, 768, 160, 96));
            set.AddFrame(new Rectangle(1120, 768, 160, 96));
            set.AddFrame(new Rectangle(1280, 768, 160, 96));
            anim.AddSet(set);

            anim.SetActiveSet(PDVehicle.ANIM_IDLE_CENTER, 0);

            anim.Depth = 0.5f;

            m_gfx = anim;
        }
    }
}
