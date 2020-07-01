using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ActorPack;

namespace Praedonum
{
    public class PDVPersian : PDVehicle
    {
        public PDVPersian(Game game, GameplayScreen screen)
            : base(game, screen)
        {
            RotationOffset = MathHelper.PiOver2;   
        }

        public override void SetDefaultGraphics(ref Texture2D tex_)
        {
            

            Animation anim;
            AnimationSet set;

            anim = new Animation(Game);
            anim.Initialize(ref tex_);
            anim.Origin = new Vector2(48, 80);


            set = new AnimationSet(PDVehicle.ANIM_IDLE_CENTER, true, 8.0f, 0);
            set.AddFrame(new Rectangle(970, 1288 ,96 ,160));
            set.AddFrame(new Rectangle(1455 ,1127, 96, 160));
            set.AddFrame(new Rectangle(1649, 966 ,96, 160));
            set.AddFrame(new Rectangle(1358 ,1288 ,96, 160));
            set.AddFrame(new Rectangle(1552 ,1127 ,96 ,160));
            set.AddFrame(new Rectangle(1455, 1288 ,96, 160));
            set.AddFrame(new Rectangle(1649 ,1127 ,96 ,160));
            set.AddFrame(new Rectangle(1552 ,1288, 96 ,160));
            set.AddFrame(new Rectangle(1649 ,1288, 96, 160));
            set.AddFrame(new Rectangle(1164 ,1127 ,96 ,160));
            set.AddFrame(new Rectangle(1358, 966, 96 ,160));
            set.AddFrame(new Rectangle(1067, 1288 ,96 ,160));
            set.AddFrame(new Rectangle(1261 ,1127, 96 ,160));
            set.AddFrame(new Rectangle(1455, 966, 96 ,160));
            set.AddFrame(new Rectangle(1164, 1288, 96 ,160));
            set.AddFrame(new Rectangle(1358, 1127, 96 ,160));
            set.AddFrame(new Rectangle(1552 ,966 ,96 ,160));
            set.AddFrame(new Rectangle(1261, 1288 ,96, 160));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT1, true, 8.0f, 0);
            set.AddFrame(new Rectangle(1358 ,483 ,96 ,160));
            set.AddFrame(new Rectangle(1455 ,644 ,96 ,160));
            set.AddFrame(new Rectangle(1649 ,483, 96 ,160));
            set.AddFrame(new Rectangle(1358 ,805 ,96 ,160));
            set.AddFrame(new Rectangle(1552 ,644, 96 ,160));
            set.AddFrame(new Rectangle(1455 ,805 ,96, 160));
            set.AddFrame(new Rectangle(1649, 644, 96, 160));
            set.AddFrame(new Rectangle(1552, 805 ,96, 160));
            set.AddFrame(new Rectangle(1649 ,805 ,96 ,160));
            set.AddFrame(new Rectangle(1067 ,805 ,96 ,160));
            set.AddFrame(new Rectangle(1552, 322 ,96, 160));
            set.AddFrame(new Rectangle(1261 ,644 ,96 ,160));
            set.AddFrame(new Rectangle(1455,483 ,96 ,160));
            set.AddFrame(new Rectangle(1164, 805 ,96 ,160));
            set.AddFrame(new Rectangle(1649, 322 ,96, 160));
            set.AddFrame(new Rectangle(1358 ,644, 96 ,160));
            set.AddFrame(new Rectangle(1552, 483 ,96, 160));
            set.AddFrame(new Rectangle(1261 ,805 ,96, 160));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT2, true, 8.0f, 0);
            set.AddFrame(new Rectangle(388 ,1288, 96 ,160));
            set.AddFrame(new Rectangle(873 ,1127 ,96 ,160));
            set.AddFrame(new Rectangle(1067 ,966, 96, 160));
            set.AddFrame(new Rectangle(776 ,1288 ,96, 160));
            set.AddFrame(new Rectangle(970 ,1127 ,96 ,160));
            set.AddFrame(new Rectangle(1164 ,966, 96 ,160));
            set.AddFrame(new Rectangle(873, 1288, 96 ,160));
            set.AddFrame(new Rectangle(1067 ,1127 ,96 ,160));
            set.AddFrame(new Rectangle(1261, 966 ,96, 160));
            set.AddFrame(new Rectangle(582 ,1127 ,96 ,160));
            set.AddFrame(new Rectangle(776 ,966 ,96, 160));
            set.AddFrame(new Rectangle(485, 1288 ,96 ,160));
            set.AddFrame(new Rectangle(679 ,1127, 96 ,160));
            set.AddFrame(new Rectangle(873 ,966, 96 ,160));
            set.AddFrame(new Rectangle(582, 1288, 96, 160));
            set.AddFrame(new Rectangle(776 ,1127, 96 ,160));
            set.AddFrame(new Rectangle(970 ,966 ,96 ,160));
            set.AddFrame(new Rectangle(679 ,1288, 96 ,160));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT3, true, 8.0f, 0);
            set.AddFrame(new Rectangle(0 ,0 ,96, 160));
            set.AddFrame(new Rectangle(291 ,161 ,96 ,160));
            set.AddFrame(new Rectangle(194 ,322 ,96 ,160));
            set.AddFrame(new Rectangle(388, 161, 96 ,160));
            set.AddFrame(new Rectangle(291, 322 ,96, 160));
            set.AddFrame(new Rectangle(388 ,322 ,96 ,160));
            set.AddFrame(new Rectangle(485, 0 ,96 ,160));
            set.AddFrame(new Rectangle(582 ,0 ,96, 160));
            set.AddFrame(new Rectangle(485 ,161, 96 ,160));
            set.AddFrame(new Rectangle(97, 0 ,96 ,160));
            set.AddFrame(new Rectangle(194, 0, 96, 160));
            set.AddFrame(new Rectangle(291 ,0, 96 ,160));
            set.AddFrame(new Rectangle(388, 0 ,96 ,160));
            set.AddFrame(new Rectangle(0 ,161 ,96, 160));
            set.AddFrame(new Rectangle(97 ,161 ,96, 160));
            set.AddFrame(new Rectangle(0 ,322, 96 ,160));
            set.AddFrame(new Rectangle(194 ,161, 96, 160));
            set.AddFrame(new Rectangle(97 ,322 ,96, 160));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT4, true, 8.0f, 0);
            set.AddFrame(new Rectangle(679 ,0 ,96 ,160));
            set.AddFrame(new Rectangle(776, 322 ,96, 160));
            set.AddFrame(new Rectangle(873 ,322 ,96, 160));
            set.AddFrame(new Rectangle(0 ,483, 96, 160));
            set.AddFrame(new Rectangle(97 ,483 ,96 ,160));
            set.AddFrame(new Rectangle(0 ,644 ,96 ,160));
            set.AddFrame(new Rectangle(194 ,483 ,96 ,160));
            set.AddFrame(new Rectangle(97, 644 ,96 ,160));
            set.AddFrame(new Rectangle(291 ,483, 96, 160));
            set.AddFrame(new Rectangle(582, 161, 96 ,160));
            set.AddFrame(new Rectangle(776, 0, 96 ,160));
            set.AddFrame(new Rectangle(485 ,322, 96, 160));
            set.AddFrame(new Rectangle(679 ,161 ,96 ,160));
            set.AddFrame(new Rectangle(873, 0, 96, 160));
            set.AddFrame(new Rectangle(582 ,322 ,96 ,160));
            set.AddFrame(new Rectangle(776 ,161 ,96 ,160));
            set.AddFrame(new Rectangle(679, 322, 96, 160));
            set.AddFrame(new Rectangle(873 ,161, 96, 160));
            anim.AddSet(set);


            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT1, true, 8.0f, 0);
            set.AddFrame(new Rectangle(1455, 0, 96, 160));
            set.AddFrame(new Rectangle(1358 ,322 ,96 ,160));
            set.AddFrame(new Rectangle(1067, 644 ,96 ,160));
            set.AddFrame(new Rectangle(1552 ,161, 96, 160));
            set.AddFrame(new Rectangle(1261 ,483, 96 ,160));
            set.AddFrame(new Rectangle(970 ,805 ,96 ,160));
            set.AddFrame(new Rectangle(1455 ,322 ,96 ,160));
            set.AddFrame(new Rectangle(1164 ,644 ,96, 160));
            set.AddFrame(new Rectangle(1649, 161, 96, 160));
            set.AddFrame(new Rectangle(1164 ,322 ,96, 160));
            set.AddFrame(new Rectangle(1358, 161, 96 ,160));
            set.AddFrame(new Rectangle(1067 ,483 ,96 ,160));
            set.AddFrame(new Rectangle(1552, 0 ,96, 160));
            set.AddFrame(new Rectangle(1261 ,322 ,96 ,160));
            set.AddFrame(new Rectangle(970 ,644, 96 ,160));
            set.AddFrame(new Rectangle(1455, 161 ,96, 160));
            set.AddFrame(new Rectangle(1164 ,483 ,96 ,160));
            set.AddFrame(new Rectangle(1649, 0 ,96, 160));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT2, true, 8.0f, 0);
            set.AddFrame(new Rectangle(0, 966 ,96 ,160));
            set.AddFrame(new Rectangle(291, 1127 ,96 ,160));
            set.AddFrame(new Rectangle(485 ,966 ,96 ,160));
            set.AddFrame(new Rectangle(194 ,1288 ,96 ,160));
            set.AddFrame(new Rectangle(388 ,1127 ,96 ,160));
            set.AddFrame(new Rectangle(582, 966 ,96 ,160));
            set.AddFrame(new Rectangle(291 ,1288, 96, 160));
            set.AddFrame(new Rectangle(485, 1127 ,96, 160));
            set.AddFrame(new Rectangle(679,966 ,96 ,160));
            set.AddFrame(new Rectangle(97 ,966 ,96 ,160));
            set.AddFrame(new Rectangle(0 ,1127, 96, 160));
            set.AddFrame(new Rectangle(194, 966, 96 ,160));
            set.AddFrame(new Rectangle(97 ,1127 ,96 ,160));
            set.AddFrame(new Rectangle(291 ,966 ,96 ,160));
            set.AddFrame(new Rectangle(0 ,1288 ,96, 160));
            set.AddFrame(new Rectangle(194, 1127 ,96, 160));
            set.AddFrame(new Rectangle(388 ,966, 96 ,160));
            set.AddFrame(new Rectangle(97 ,1288 ,96 ,160));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT3, true, 8.0f, 0);
            set.AddFrame(new Rectangle(0 ,805 ,96 ,160));
            set.AddFrame(new Rectangle(485 ,644, 96 ,160));
            set.AddFrame(new Rectangle(679, 483, 96, 160));
            set.AddFrame(new Rectangle(388 ,805 ,96, 160));
            set.AddFrame(new Rectangle(582 ,644, 96, 160));
            set.AddFrame(new Rectangle(776 ,483 ,96, 160));
            set.AddFrame(new Rectangle(485, 805 ,96 ,160));
            set.AddFrame(new Rectangle(679 ,644 ,96 ,160));
            set.AddFrame(new Rectangle(873, 483 ,96, 160));
            set.AddFrame(new Rectangle(194, 644, 96, 160));
            set.AddFrame(new Rectangle(388 ,483 ,96, 160));
            set.AddFrame(new Rectangle(97 ,805, 96 ,160));
            set.AddFrame(new Rectangle(291 ,644 ,96, 160));
            set.AddFrame(new Rectangle(485, 483 ,96, 160));
            set.AddFrame(new Rectangle(194 ,805, 96 ,160));
            set.AddFrame(new Rectangle(388, 644, 96 ,160));
            set.AddFrame(new Rectangle(582 ,483, 96, 160));
            set.AddFrame(new Rectangle(291, 805, 96 ,160));
            anim.AddSet(set);

            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT4, true, 8.0f, 0);
            set.AddFrame(new Rectangle(582 ,805 ,96 ,160));
            set.AddFrame(new Rectangle(1067 ,161, 96 ,160));
            set.AddFrame(new Rectangle(1261, 0, 96 ,160));
            set.AddFrame(new Rectangle(970 ,322 ,96, 160));
            set.AddFrame(new Rectangle(1164 ,161 ,96, 160));
            set.AddFrame(new Rectangle(1358, 0, 96 ,160));
            set.AddFrame(new Rectangle(1067 ,322, 96 ,160));
            set.AddFrame(new Rectangle(1261, 161 ,96,160));
            set.AddFrame(new Rectangle(970 ,483 ,96, 160));
            set.AddFrame(new Rectangle(776 ,644, 96, 160));
            set.AddFrame(new Rectangle(679, 805 ,96 ,160));
            set.AddFrame(new Rectangle(873, 644, 96, 160));
            set.AddFrame(new Rectangle( 776 ,805 ,96 ,160));
            set.AddFrame(new Rectangle(873, 805 ,96 ,160));
            set.AddFrame(new Rectangle(970, 0 ,96 ,160));
            set.AddFrame(new Rectangle(1067, 0, 96, 160));
            set.AddFrame(new Rectangle(970, 161 ,96 ,160));
            set.AddFrame(new Rectangle(1164, 0, 96, 160));
            anim.AddSet(set);

            anim.SetActiveSet(PDVehicle.ANIM_IDLE_CENTER, 0);

            anim.Depth = 0.5f;

            m_gfx = anim;
        }


    }
}
