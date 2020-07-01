using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ActorPack;

namespace Praedonum
{
    public class PDVBritish : PDVehicle
    {
        public PDVBritish(Game game, GameplayScreen screen)
            : base(game, screen)
        {

        }

        public override void SetDefaultGraphics(ref Texture2D tex_)
        {
            Animation anim;
            AnimationSet set;

            anim = new Animation(Game);
            anim.Initialize(ref tex_);
            anim.Origin = new Vector2(80, 60);


            set = new AnimationSet(PDVehicle.ANIM_IDLE_CENTER, true, 1.0f, 0);
            set.AddFrame(new Rectangle(480 ,600 ,160, 120));
            set.AddFrame(new Rectangle(640 ,480 ,160 ,120));
            set.AddFrame(new Rectangle(320, 840, 160 ,120));
            set.AddFrame(new Rectangle(480, 720, 160, 120));
            set.AddFrame(new Rectangle(640 ,600 ,160 ,120));
            set.AddFrame(new Rectangle(800 ,480 ,160 ,120));
            set.AddFrame(new Rectangle(480 ,840 ,160 ,120));
            set.AddFrame(new Rectangle(640, 720 ,160 ,120));
            set.AddFrame(new Rectangle(800 ,600 ,160 ,120));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT1, true, 1.0f, 0);
            set.AddFrame(new Rectangle(480, 360 ,160 ,120));
            set.AddFrame(new Rectangle(640, 240 ,160 ,120));
            set.AddFrame(new Rectangle(800 ,120 ,160 ,120));
            set.AddFrame(new Rectangle(640 ,360 ,160, 120));
            set.AddFrame(new Rectangle(800, 240, 160 ,120));
            set.AddFrame(new Rectangle(800 ,360, 160 ,120));
            set.AddFrame(new Rectangle(0 ,480 ,160, 120));
            set.AddFrame(new Rectangle(0, 600 ,160 ,120));
            set.AddFrame(new Rectangle(160 ,480 ,160 ,120));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT2, true, 1.0f, 0);
            set.AddFrame(new Rectangle(0 ,720 ,160, 120));
            set.AddFrame(new Rectangle(160, 600, 160 ,120));
            set.AddFrame(new Rectangle(320, 480, 160 ,120));
            set.AddFrame(new Rectangle(0, 840 ,160 ,120));
            set.AddFrame(new Rectangle(160 ,720, 160 ,120));
            set.AddFrame(new Rectangle(320 ,600, 160 ,120));
            set.AddFrame(new Rectangle(480 ,480 ,160, 120));
            set.AddFrame(new Rectangle(160 ,840, 160 ,120));
            set.AddFrame(new Rectangle(320, 720, 160, 120));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT3, true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 0 ,160 ,120));
            set.AddFrame(new Rectangle(0 ,120 ,160, 120));
            set.AddFrame(new Rectangle(160, 0, 160 ,120));
            set.AddFrame(new Rectangle(160 ,120 ,160 ,120));
            set.AddFrame(new Rectangle(320, 0 ,160, 120));
            set.AddFrame(new Rectangle(320, 120, 160, 120));
            set.AddFrame(new Rectangle(0 ,240 ,160 ,120));
            set.AddFrame(new Rectangle(0 ,360 ,160 ,120));
            set.AddFrame(new Rectangle(160 ,240 ,160, 120));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT4, true, 1.0f, 0);
            set.AddFrame(new Rectangle(160, 360 ,160 ,120));
            set.AddFrame(new Rectangle(320 ,240 ,160 ,120));
            set.AddFrame(new Rectangle(320 ,360, 160, 120));
            set.AddFrame(new Rectangle(480, 0 ,160 ,120));
            set.AddFrame(new Rectangle(480 ,120, 160 ,120));
            set.AddFrame(new Rectangle(640, 0 ,160 ,120));
            set.AddFrame(new Rectangle(480 ,240, 160, 120));
            set.AddFrame(new Rectangle(640 ,120 ,160 ,120));
            set.AddFrame(new Rectangle(800, 0 ,160 ,120));
            anim.AddSet(set);


            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT1, true, 1.0f, 0);
            set.AddFrame(new Rectangle(1120 ,480, 160 ,120));
            set.AddFrame(new Rectangle(1600, 0 ,160, 120));
            set.AddFrame(new Rectangle(1280 ,360 ,160, 120));
            set.AddFrame(new Rectangle(1440, 240, 160 ,120));
            set.AddFrame(new Rectangle(960, 720 ,160 ,120));
            set.AddFrame(new Rectangle(1120, 600 ,160 ,120));
            set.AddFrame(new Rectangle(1600 ,120, 160 ,120));
            set.AddFrame(new Rectangle(1280 ,480 ,160, 120));
            set.AddFrame(new Rectangle(1760, 0 ,160 ,120));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT2, true, 1.0f, 0);
            set.AddFrame(new Rectangle(960 ,840, 160 ,120));
            set.AddFrame(new Rectangle(1440 ,360 ,160 ,120));
            set.AddFrame(new Rectangle(1600, 240 ,160 ,120));
            set.AddFrame(new Rectangle(1120 ,720, 160 ,120));
            set.AddFrame(new Rectangle(1760, 120 ,160 ,120));
            set.AddFrame(new Rectangle(1280, 600 ,160 ,120));
            set.AddFrame(new Rectangle(1440 ,480, 160, 120));
            set.AddFrame(new Rectangle(1120 ,840, 160, 120));
            set.AddFrame(new Rectangle(1600, 360 ,160, 120));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT3, true, 1.0f, 0);
            set.AddFrame(new Rectangle(640, 840, 160 ,120));
            set.AddFrame(new Rectangle(800, 720 ,160 ,120));
            set.AddFrame(new Rectangle(800, 840 ,160, 120));
            set.AddFrame(new Rectangle(960 ,0, 160, 120));
            set.AddFrame(new Rectangle(960, 120, 160, 120));
            set.AddFrame(new Rectangle(1120, 0 ,160, 120));
            set.AddFrame(new Rectangle(960 ,240, 160, 120));
            set.AddFrame(new Rectangle(1120 ,120, 160, 120));
            set.AddFrame(new Rectangle(1280, 0, 160 ,120));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT4, true, 1.0f, 0);
            set.AddFrame(new Rectangle(960, 360 ,160, 120));
            set.AddFrame(new Rectangle(1120 ,240 ,160 ,120));
            set.AddFrame(new Rectangle(1280 ,120 ,160, 120));
            set.AddFrame(new Rectangle(960 ,480 ,160, 120));
            set.AddFrame(new Rectangle(1440, 0, 160, 120));
            set.AddFrame(new Rectangle(1120 ,360 ,160 ,120));
            set.AddFrame(new Rectangle(1280, 240 ,160, 120));
            set.AddFrame(new Rectangle(960, 600, 160, 120));
            set.AddFrame(new Rectangle(1440 ,120 ,160, 120));
            anim.AddSet(set);

            anim.SetActiveSet(PDVehicle.ANIM_IDLE_CENTER, 0);

            anim.Depth = 0.5f;

            m_gfx = anim;
        }


    }
}
