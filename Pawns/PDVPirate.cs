using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ActorPack;

namespace Praedonum
{
    public class PDVPirate : PDVehicle
    {
        private Animation[] m_anim_pirate;
        private int m_anim_lean_index = 4;
        private int m_anim_vel_index = 0;
        private Animation m_anim_pirate_idle;

        public PDVPirate(Game game, GameplayScreen screen)
            : base(game, screen)
        {
            Game1.Audio.PlaySound("sfx_ship_accelerate");

            RotationRate = 0.5f;
            CannonDamage = 13;
            CannonsMax = 30;
            Armor = 1000;
            Gold = 100;
        }

        public override void SetDefaultGraphics(ref Texture2D tex_)
        {

            
/*
* 
* 
* LEAN LEFT 4/4:    [0][1][2][3][4][5][6][7][8][9][10][11][12][13]
* LEAN LEFT 3/4:    [0][1][2][3][4][5][6][7][8][9][10][11][12][13]
* LEAN LEFT 2/4:    [0][1][2][3][4][5][6][7][8][9][10][11][12][13]
* LEAN LEFT 1/4:    [0][1][2][3][4][5][6][7][8][9][10][11][12][13]
* IDLE ANIMATION:   [0][1][2][3][4][5][6][7][8][9][10][11][12][13]
* LEAN RIGHT 1/4:   [0][1][2][3][4][5][6][7][8][9][10][11][12][13]
* LEAN RIGHT 2/4:   [0][1][2][3][4][5][6][7][8][9][10][11][12][13]
* LEAN RIGHT 3/4:   [0][1][2][3][4][5][6][7][8][9][10][11][12][13]
* LEAN RIGHT 4/4:   [0][1][2][3][4][5][6][7][8][9][10][11][12][13]
* 
*/




            AnimationSet set;


            m_anim_pirate_idle = new Animation(Game);
            m_anim_pirate_idle.Initialize(ref tex_);
            m_anim_pirate_idle.Origin = new Vector2(80, 48);
            m_anim_pirate_idle.Depth = 0.8f;
 

            set = new AnimationSet("idle", true, 12.0f, 0);
            set.AddFrame(new Rectangle(0, 0, 160, 96));
            set.AddFrame(new Rectangle(160, 0, 160, 96));
            set.AddFrame(new Rectangle(320, 0, 160, 96));
            set.AddFrame(new Rectangle(480, 0, 160, 96));
            set.AddFrame(new Rectangle(640, 0, 160, 96));
            set.AddFrame(new Rectangle(800, 0, 160, 96));
            set.AddFrame(new Rectangle(960, 0, 160, 96));
            set.AddFrame(new Rectangle(1120, 0, 160, 96));
            set.AddFrame(new Rectangle(1280, 0, 160, 96));
            set.AddFrame(new Rectangle(1440, 0, 160, 96));
            set.AddFrame(new Rectangle(1600, 0, 160, 96));
            set.AddFrame(new Rectangle(1760, 0, 160, 96));
            set.AddFrame(new Rectangle(0, 96, 160, 96));
            set.AddFrame(new Rectangle(160, 96, 160, 96));

            m_anim_pirate_idle.AddSet(set);
            m_anim_pirate_idle.SetActiveSet("idle", 0);




            m_anim_pirate = new Animation[9];

            // Lean left 4/4
            m_anim_pirate[0] = new Animation(Game);
            m_anim_pirate[0].Initialize(ref tex_);
            m_anim_pirate[0].Origin = m_anim_pirate_idle.Origin;
            m_anim_pirate[0].Depth = 0.8f;

            set = new AnimationSet("1", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 1440, 160, 96));
            m_anim_pirate[0].AddSet(set);
            set = new AnimationSet("2", true, 1.0f, 0);
            set.AddFrame(new Rectangle(160, 1440, 160, 96));
            m_anim_pirate[0].AddSet(set);
            set = new AnimationSet("3", true, 1.0f, 0);
            set.AddFrame(new Rectangle(320, 1440, 160, 96));
            m_anim_pirate[0].AddSet(set);
            set = new AnimationSet("4", true, 1.0f, 0);
            set.AddFrame(new Rectangle(480, 1440, 160, 96));
            m_anim_pirate[0].AddSet(set);
            set = new AnimationSet("5", true, 1.0f, 0);
            set.AddFrame(new Rectangle(640, 1440, 160, 96));
            m_anim_pirate[0].AddSet(set);
            set = new AnimationSet("6", true, 1.0f, 0);
            set.AddFrame(new Rectangle(800, 1440, 160, 96));
            m_anim_pirate[0].AddSet(set);
            set = new AnimationSet("7", true, 1.0f, 0);
            set.AddFrame(new Rectangle(960, 1440, 160, 96));
            m_anim_pirate[0].AddSet(set);
            set = new AnimationSet("8", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1120, 1440, 160, 96));
            m_anim_pirate[0].AddSet(set);
            set = new AnimationSet("9", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1280, 1440, 160, 96));
            m_anim_pirate[0].AddSet(set);
            set = new AnimationSet("10", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1440, 1440, 160, 96));
            m_anim_pirate[0].AddSet(set);
            set = new AnimationSet("11", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1600, 1440, 160, 96));
            m_anim_pirate[0].AddSet(set);
            set = new AnimationSet("12", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1760, 1440, 160, 96));
            m_anim_pirate[0].AddSet(set);
            set = new AnimationSet("13", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 1536, 160, 96));
            m_anim_pirate[0].AddSet(set);
            set = new AnimationSet("14", true, 1.0f, 0);
            set.AddFrame(new Rectangle(160, 1536, 160, 96));
            m_anim_pirate[0].AddSet(set);
            m_anim_pirate[0].SetActiveSet("1", 0);

            // Lean left 3/4
            m_anim_pirate[1] = new Animation(Game);
            m_anim_pirate[1].Initialize(ref tex_);
            m_anim_pirate[1].Origin = m_anim_pirate_idle.Origin;
            m_anim_pirate[1].Depth = 0.8f;

            set = new AnimationSet("1", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1440, 1248, 160, 96));
            m_anim_pirate[1].AddSet(set);
            set = new AnimationSet("2", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1600, 1248, 160, 96));
            m_anim_pirate[1].AddSet(set);
            set = new AnimationSet("3", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1760, 1248, 160, 96));
            m_anim_pirate[1].AddSet(set);
            set = new AnimationSet("4", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 1344, 160, 96));
            m_anim_pirate[1].AddSet(set);
            set = new AnimationSet("5", true, 1.0f, 0);
            set.AddFrame(new Rectangle(160, 1344, 160, 96));
            m_anim_pirate[1].AddSet(set);
            set = new AnimationSet("6", true, 1.0f, 0);
            set.AddFrame(new Rectangle(320, 1344, 160, 96));
            m_anim_pirate[1].AddSet(set);
            set = new AnimationSet("7", true, 1.0f, 0);
            set.AddFrame(new Rectangle(480, 1344, 160, 96));
            m_anim_pirate[1].AddSet(set);
            set = new AnimationSet("8", true, 1.0f, 0);
            set.AddFrame(new Rectangle(640, 1344, 160, 96));
            m_anim_pirate[1].AddSet(set);
            set = new AnimationSet("9", true, 1.0f, 0);
            set.AddFrame(new Rectangle(800, 1344, 160, 96));
            m_anim_pirate[1].AddSet(set);
            set = new AnimationSet("10", true, 1.0f, 0);
            set.AddFrame(new Rectangle(960, 1344, 160, 96));
            m_anim_pirate[1].AddSet(set);
            set = new AnimationSet("11", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1120, 1344, 160, 96));
            m_anim_pirate[1].AddSet(set);
            set = new AnimationSet("12", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1280, 1344, 160, 96));
            m_anim_pirate[1].AddSet(set);
            set = new AnimationSet("13", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1440, 1344, 160, 96));
            m_anim_pirate[1].AddSet(set);
            set = new AnimationSet("14", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1600, 1344, 160, 96));
            m_anim_pirate[1].AddSet(set);
            m_anim_pirate[1].SetActiveSet("1", 0);

            // Lean left 2/4
            m_anim_pirate[2] = new Animation(Game);
            m_anim_pirate[2].Initialize(ref tex_);
            m_anim_pirate[2].Origin = m_anim_pirate_idle.Origin;
            m_anim_pirate[2].Depth = 0.8f;

            set = new AnimationSet("1", true, 1.0f, 0);
            set.AddFrame(new Rectangle(960, 1152, 160, 96));
            m_anim_pirate[2].AddSet(set);
            set = new AnimationSet("2", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1120, 1152, 160, 96));
            m_anim_pirate[2].AddSet(set);
            set = new AnimationSet("3", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1280, 1152, 160, 96));
            m_anim_pirate[2].AddSet(set);
            set = new AnimationSet("4", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1440, 1152, 160, 96));
            m_anim_pirate[2].AddSet(set);
            set = new AnimationSet("5", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1600, 1152, 160, 96));
            m_anim_pirate[2].AddSet(set);
            set = new AnimationSet("6", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1760, 1152, 160, 96));
            m_anim_pirate[2].AddSet(set);
            set = new AnimationSet("7", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 1248, 160, 96));
            m_anim_pirate[2].AddSet(set);
            set = new AnimationSet("8", true, 1.0f, 0);
            set.AddFrame(new Rectangle(160, 1248, 160, 96));
            m_anim_pirate[2].AddSet(set);
            set = new AnimationSet("9", true, 1.0f, 0);
            set.AddFrame(new Rectangle(320, 1248, 160, 96));
            m_anim_pirate[2].AddSet(set);
            set = new AnimationSet("10", true, 1.0f, 0);
            set.AddFrame(new Rectangle(480, 1248, 160, 96));
            m_anim_pirate[2].AddSet(set);
            set = new AnimationSet("11", true, 1.0f, 0);
            set.AddFrame(new Rectangle(640, 1248, 160, 96));
            m_anim_pirate[2].AddSet(set);
            set = new AnimationSet("12", true, 1.0f, 0);
            set.AddFrame(new Rectangle(800, 1248, 160, 96));
            m_anim_pirate[2].AddSet(set);
            set = new AnimationSet("13", true, 1.0f, 0);
            set.AddFrame(new Rectangle(960, 1248, 160, 96));
            m_anim_pirate[2].AddSet(set);
            set = new AnimationSet("14", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1120, 1248, 160, 96));
            m_anim_pirate[2].AddSet(set);
            m_anim_pirate[2].SetActiveSet("1", 0);

            // Lean left 1/4
            m_anim_pirate[3] = new Animation(Game);
            m_anim_pirate[3].Initialize(ref tex_);
            m_anim_pirate[3].Origin = m_anim_pirate_idle.Origin;
            m_anim_pirate[3].Depth = 0.8f;

            set = new AnimationSet("1", true, 1.0f, 0);
            set.AddFrame(new Rectangle(480, 1056, 160, 96));
            m_anim_pirate[3].AddSet(set);
            set = new AnimationSet("2", true, 1.0f, 0);
            set.AddFrame(new Rectangle(640, 1056, 160, 96));
            m_anim_pirate[3].AddSet(set);
            set = new AnimationSet("3", true, 1.0f, 0);
            set.AddFrame(new Rectangle(800, 1056, 160, 96));
            m_anim_pirate[3].AddSet(set);
            set = new AnimationSet("4", true, 1.0f, 0);
            set.AddFrame(new Rectangle(960, 1056, 160, 96));
            m_anim_pirate[3].AddSet(set);
            set = new AnimationSet("5", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1120, 1056, 160, 96));
            m_anim_pirate[3].AddSet(set);
            set = new AnimationSet("6", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1280, 1056, 160, 96));
            m_anim_pirate[3].AddSet(set);
            set = new AnimationSet("7", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1440, 1056, 160, 96));
            m_anim_pirate[3].AddSet(set);
            set = new AnimationSet("8", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1600, 1056, 160, 96));
            m_anim_pirate[3].AddSet(set);
            set = new AnimationSet("9", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1760, 1056, 160, 96));
            m_anim_pirate[3].AddSet(set);
            set = new AnimationSet("10", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 1152, 160, 96));
            m_anim_pirate[3].AddSet(set);
            set = new AnimationSet("11", true, 1.0f, 0);
            set.AddFrame(new Rectangle(160, 1152, 160, 96));
            m_anim_pirate[3].AddSet(set);
            set = new AnimationSet("12", true, 1.0f, 0);
            set.AddFrame(new Rectangle(320, 1152, 160, 96));
            m_anim_pirate[3].AddSet(set);
            set = new AnimationSet("13", true, 1.0f, 0);
            set.AddFrame(new Rectangle(480, 1152, 160, 96));
            m_anim_pirate[3].AddSet(set);
            set = new AnimationSet("14", true, 1.0f, 0);
            set.AddFrame(new Rectangle(640, 1152, 160, 96));
            m_anim_pirate[3].AddSet(set);
            m_anim_pirate[3].SetActiveSet("1", 0);

            // Center
            m_anim_pirate[4] = new Animation(Game);
            m_anim_pirate[4].Initialize(ref tex_);
            m_anim_pirate[4].Origin = m_anim_pirate_idle.Origin;
            m_anim_pirate[4].Depth = 0.8f;

            set = new AnimationSet("1", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 960, 160, 96));
            m_anim_pirate[4].AddSet(set);
            set = new AnimationSet("2", true, 1.0f, 0);
            set.AddFrame(new Rectangle(160, 960, 160, 96));
            m_anim_pirate[4].AddSet(set);
            set = new AnimationSet("3", true, 1.0f, 0);
            set.AddFrame(new Rectangle(320, 960, 160, 96));
            m_anim_pirate[4].AddSet(set);
            set = new AnimationSet("4", true, 1.0f, 0);
            set.AddFrame(new Rectangle(480, 960, 160, 96));
            m_anim_pirate[4].AddSet(set);
            set = new AnimationSet("5", true, 1.0f, 0);
            set.AddFrame(new Rectangle(640, 960, 160, 96));
            m_anim_pirate[4].AddSet(set);
            set = new AnimationSet("6", true, 1.0f, 0);
            set.AddFrame(new Rectangle(800, 960, 160, 96));
            m_anim_pirate[4].AddSet(set);
            set = new AnimationSet("7", true, 1.0f, 0);
            set.AddFrame(new Rectangle(960, 960, 160, 96));
            m_anim_pirate[4].AddSet(set);
            set = new AnimationSet("8", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1120, 960, 160, 96));
            m_anim_pirate[4].AddSet(set);
            set = new AnimationSet("9", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1280, 960, 160, 96));
            m_anim_pirate[4].AddSet(set);
            set = new AnimationSet("10", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1440, 960, 160, 96));
            m_anim_pirate[4].AddSet(set);
            set = new AnimationSet("11", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1600, 960, 160, 96));
            m_anim_pirate[4].AddSet(set);
            set = new AnimationSet("12", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1760, 960, 160, 96));
            m_anim_pirate[4].AddSet(set);
            set = new AnimationSet("13", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 1056, 160, 96));
            m_anim_pirate[4].AddSet(set);
            set = new AnimationSet("14", true, 1.0f, 0);
            set.AddFrame(new Rectangle(160, 1056, 160, 96));
            m_anim_pirate[4].AddSet(set);
            m_anim_pirate[4].SetActiveSet("1", 0);

            // Lean right 1/4
            m_anim_pirate[5] = new Animation(Game);
            m_anim_pirate[5].Initialize(ref tex_);
            m_anim_pirate[5].Origin = m_anim_pirate_idle.Origin;
            m_anim_pirate[5].Depth = 0.8f;

            set = new AnimationSet("1", true, 1.0f, 0);
            set.AddFrame(new Rectangle(480, 1536, 160, 96));
            m_anim_pirate[5].AddSet(set);
            set = new AnimationSet("2", true, 1.0f, 0);
            set.AddFrame(new Rectangle(640, 1536, 160, 96));
            m_anim_pirate[5].AddSet(set);
            set = new AnimationSet("3", true, 1.0f, 0);
            set.AddFrame(new Rectangle(800, 1536, 160, 96));
            m_anim_pirate[5].AddSet(set);
            set = new AnimationSet("4", true, 1.0f, 0);
            set.AddFrame(new Rectangle(960, 1536, 160, 96));
            m_anim_pirate[5].AddSet(set);
            set = new AnimationSet("5", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1120, 1536, 160, 96));
            m_anim_pirate[5].AddSet(set);
            set = new AnimationSet("6", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1280, 1536, 160, 96));
            m_anim_pirate[5].AddSet(set);
            set = new AnimationSet("7", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1440, 1536, 160, 96));
            m_anim_pirate[5].AddSet(set);
            set = new AnimationSet("8", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1600, 1536, 160, 96));
            m_anim_pirate[5].AddSet(set);
            set = new AnimationSet("9", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1760, 1536, 160, 96));
            m_anim_pirate[5].AddSet(set);
            set = new AnimationSet("10", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 1632, 160, 96));
            m_anim_pirate[5].AddSet(set);
            set = new AnimationSet("11", true, 1.0f, 0);
            set.AddFrame(new Rectangle(160, 1632, 160, 96));
            m_anim_pirate[5].AddSet(set);
            set = new AnimationSet("12", true, 1.0f, 0);
            set.AddFrame(new Rectangle(320, 1632, 160, 96));
            m_anim_pirate[5].AddSet(set);
            set = new AnimationSet("13", true, 1.0f, 0);
            set.AddFrame(new Rectangle(480, 1632, 160, 96));
            m_anim_pirate[5].AddSet(set);
            set = new AnimationSet("14", true, 1.0f, 0);
            set.AddFrame(new Rectangle(640, 1632, 160, 96));
            m_anim_pirate[5].AddSet(set);
            m_anim_pirate[5].SetActiveSet("1", 0);

            // Lean right 2/4
            m_anim_pirate[6] = new Animation(Game);
            m_anim_pirate[6].Initialize(ref tex_);
            m_anim_pirate[6].Origin = m_anim_pirate_idle.Origin;
            m_anim_pirate[6].Depth = 0.8f;

            set = new AnimationSet("1", true, 1.0f, 0);
            set.AddFrame(new Rectangle(960, 1632, 160, 96));
            m_anim_pirate[6].AddSet(set);
            set = new AnimationSet("2", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1120, 1632, 160, 96));
            m_anim_pirate[6].AddSet(set);
            set = new AnimationSet("3", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1280, 1632, 160, 96));
            m_anim_pirate[6].AddSet(set);
            set = new AnimationSet("4", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1440, 1632, 160, 96));
            m_anim_pirate[6].AddSet(set);
            set = new AnimationSet("5", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1600, 1632, 160, 96));
            m_anim_pirate[6].AddSet(set);
            set = new AnimationSet("6", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1760, 1632, 160, 96));
            m_anim_pirate[6].AddSet(set);
            set = new AnimationSet("7", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 1728, 160, 96));
            m_anim_pirate[6].AddSet(set);
            set = new AnimationSet("8", true, 1.0f, 0);
            set.AddFrame(new Rectangle(160, 1728, 160, 96));
            m_anim_pirate[6].AddSet(set);
            set = new AnimationSet("9", true, 1.0f, 0);
            set.AddFrame(new Rectangle(320, 1728, 160, 96));
            m_anim_pirate[6].AddSet(set);
            set = new AnimationSet("10", true, 1.0f, 0);
            set.AddFrame(new Rectangle(480, 1728, 160, 96));
            m_anim_pirate[6].AddSet(set);
            set = new AnimationSet("11", true, 1.0f, 0);
            set.AddFrame(new Rectangle(640, 1728, 160, 96));
            m_anim_pirate[6].AddSet(set);
            set = new AnimationSet("12", true, 1.0f, 0);
            set.AddFrame(new Rectangle(800, 1728, 160, 96));
            m_anim_pirate[6].AddSet(set);
            set = new AnimationSet("13", true, 1.0f, 0);
            set.AddFrame(new Rectangle(960, 1728, 160, 96));
            m_anim_pirate[6].AddSet(set);
            set = new AnimationSet("14", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1120, 1728, 160, 96));
            m_anim_pirate[6].AddSet(set);
            m_anim_pirate[6].SetActiveSet("1", 0);

            // Lean right 3/4
            m_anim_pirate[7] = new Animation(Game);
            m_anim_pirate[7].Initialize(ref tex_);
            m_anim_pirate[7].Origin = m_anim_pirate_idle.Origin;
            m_anim_pirate[7].Depth = 0.8f;

            set = new AnimationSet("1", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1440, 1728, 160, 96));
            m_anim_pirate[7].AddSet(set);
            set = new AnimationSet("2", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1600, 1728, 160, 96));
            m_anim_pirate[7].AddSet(set);
            set = new AnimationSet("3", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1760, 1728, 160, 96));
            m_anim_pirate[7].AddSet(set);
            set = new AnimationSet("4", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 1824, 160, 96));
            m_anim_pirate[7].AddSet(set);
            set = new AnimationSet("5", true, 1.0f, 0);
            set.AddFrame(new Rectangle(160, 1824, 160, 96));
            m_anim_pirate[7].AddSet(set);
            set = new AnimationSet("6", true, 1.0f, 0);
            set.AddFrame(new Rectangle(320, 1824, 160, 96));
            m_anim_pirate[7].AddSet(set);
            set = new AnimationSet("7", true, 1.0f, 0);
            set.AddFrame(new Rectangle(480, 1824, 160, 96));
            m_anim_pirate[7].AddSet(set);
            set = new AnimationSet("8", true, 1.0f, 0);
            set.AddFrame(new Rectangle(640, 1824, 160, 96));
            m_anim_pirate[7].AddSet(set);
            set = new AnimationSet("9", true, 1.0f, 0);
            set.AddFrame(new Rectangle(800, 1824, 160, 96));
            m_anim_pirate[7].AddSet(set);
            set = new AnimationSet("10", true, 1.0f, 0);
            set.AddFrame(new Rectangle(960, 1824, 160, 96));
            m_anim_pirate[7].AddSet(set);
            set = new AnimationSet("11", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1120, 1824, 160, 96));
            m_anim_pirate[7].AddSet(set);
            set = new AnimationSet("12", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1280, 1824, 160, 96));
            m_anim_pirate[7].AddSet(set);
            set = new AnimationSet("13", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1440, 1824, 160, 96));
            m_anim_pirate[7].AddSet(set);
            set = new AnimationSet("14", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1600, 1824, 160, 96));
            m_anim_pirate[7].AddSet(set);
            m_anim_pirate[7].SetActiveSet("1", 0);

            // Lean right 4/4
            m_anim_pirate[8] = new Animation(Game);
            m_anim_pirate[8].Initialize(ref tex_);
            m_anim_pirate[8].Origin = m_anim_pirate_idle.Origin;
            m_anim_pirate[8].Depth = 0.8f;

            set = new AnimationSet("1", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 1920, 160, 96));
            m_anim_pirate[8].AddSet(set);
            set = new AnimationSet("2", true, 1.0f, 0);
            set.AddFrame(new Rectangle(160, 1920, 160, 96));
            m_anim_pirate[8].AddSet(set);
            set = new AnimationSet("3", true, 1.0f, 0);
            set.AddFrame(new Rectangle(320, 1920, 160, 96));
            m_anim_pirate[8].AddSet(set);
            set = new AnimationSet("4", true, 1.0f, 0);
            set.AddFrame(new Rectangle(480, 1920, 160, 96));
            m_anim_pirate[8].AddSet(set);
            set = new AnimationSet("5", true, 1.0f, 0);
            set.AddFrame(new Rectangle(640, 1920, 160, 96));
            m_anim_pirate[8].AddSet(set);
            set = new AnimationSet("6", true, 1.0f, 0);
            set.AddFrame(new Rectangle(800, 1920, 160, 96));
            m_anim_pirate[8].AddSet(set);
            set = new AnimationSet("7", true, 1.0f, 0);
            set.AddFrame(new Rectangle(960, 1920, 160, 96));
            m_anim_pirate[8].AddSet(set);
            set = new AnimationSet("8", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1120, 1920, 160, 96));
            m_anim_pirate[8].AddSet(set);
            set = new AnimationSet("9", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1280, 1920, 160, 96));
            m_anim_pirate[8].AddSet(set);
            set = new AnimationSet("10", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1440, 1920, 160, 96));
            m_anim_pirate[8].AddSet(set);
            set = new AnimationSet("11", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1600, 1920, 160, 96));
            m_anim_pirate[8].AddSet(set);
            set = new AnimationSet("12", true, 1.0f, 0);
            set.AddFrame(new Rectangle(1760, 1920, 160, 96));
            m_anim_pirate[8].AddSet(set);
            set = new AnimationSet("13", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 2016, 160, 96));
            m_anim_pirate[8].AddSet(set);
            set = new AnimationSet("14", true, 1.0f, 0);
            set.AddFrame(new Rectangle(160, 2016, 160, 96));
            m_anim_pirate[8].AddSet(set);
            m_anim_pirate[8].SetActiveSet("1", 0);


            /*
            Animation anim;
            AnimationSet set;

            anim = new Animation(Game);
            anim.Initialize(ref tex_);
            anim.Origin = new Vector2(80, 48);


            set = new AnimationSet(PDVehicle.ANIM_IDLE_CENTER, true, 1.0f, 0);
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

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT1, true, 1.0f, 0);
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

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT2, true, 1.0f, 0);
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

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT3, true, 1.0f, 0);
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

            set = new AnimationSet(PDVehicle.ANIM_IDLE_LEFT4, true, 1.0f, 0);
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


            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT1, true, 1.0f, 0);
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

            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT2, true, 1.0f, 0);
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

            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT3, true, 1.0f, 0);
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

            set = new AnimationSet(PDVehicle.ANIM_IDLE_RIGHT4, true, 1.0f, 0);
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

            m_gfx = anim;
            */
        }

        public override void MoveForward(GameTime gameTime)
        {
            base.MoveForward(gameTime);
        }

        public override void Break(GameTime gameTime)
        {
            base.Break(gameTime);
        }


        public override void TurnRight(GameTime gameTime)
        {
            Game1.Audio.PlaySound("sfx_ship_turn_right");

            base.TurnRight(gameTime);
        }

        public override void TurnLeft(GameTime gameTime)
        {
            Game1.Audio.PlaySound("sfx_ship_turn_left");
            
            base.TurnLeft(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            Game1.Audio.SetParameter("sfx_ship_accelerate", "DopplerPitchScalar", (Throttle / ThrottleMax) * 1000);

            bool inCombat = false;

            for (Actor a = Actor.Actors.First.Value; a != null; a = a.NextActor)
            {
                if (a is Wreckage)
                {
                    if ((a.Position - Position).LengthSquared() < 100 * 100)
                    {
                        Game1.Audio.PlaySound("gold_gain");
                        Gold += (int)(a as Wreckage).Gold;
                        Rum += (a as Wreckage).Rum;
                        Leather += (a as Wreckage).Leather;
                        Rope += (a as Wreckage).Rope;
                        Tools += (a as Wreckage).Tools;
                        Iron += (a as Wreckage).Iron;
                        Coal += (a as Wreckage).Coal;
                        Spices += (a as Wreckage).Spices;
                        Silk += (a as Wreckage).Silk;

                        a.bDead = true;
                    }
                }
                else if (a is PDVehicle && a != this)
                {
                    if ((a.Position - Position).LengthSquared() < 1000 * 1000)
                    {
                        inCombat = true;
                    }
                }
            }

            if (inCombat)
            {
                Game1.Audio.SetParameter("music", "Interactive_Sounds", Game1.MUSIC_BATTLE);
            }
            else
            {
                if (Game1.Audio.GetParameter("music", "Interactive_Sounds") == Game1.MUSIC_BATTLE)
                {
                    if (Game1.Rand.Next() > 0.5)
                        Game1.Audio.SetParameter("music", "Interactive_Sounds", Game1.MUSIC_INGAME1);
                    else
                        Game1.Audio.SetParameter("music", "Interactive_Sounds", Game1.MUSIC_INGAME2);
                }
            }

            m_anim_pirate_idle.Position = Position;
            m_anim_pirate_idle.Rotation = Rotation;
            m_anim_pirate_idle.Update(gameTime);
            
            for (int i = 0; i < m_anim_pirate.Length; i++)
            {
                m_anim_pirate[i].Position = Position;
                m_anim_pirate[i].Rotation = Rotation;
                m_anim_pirate[i].Update(gameTime);
            }
            
            base.Update(gameTime);

            m_anim_lean_index = (int)Math.Round(LeanValue * 4.0f) + 4;
            m_anim_vel_index = (int)MathHelper.Clamp(((float)Math.Round((Throttle / ThrottleMax) * 14)), 0.0f, 13.0f);
            m_anim_pirate[m_anim_lean_index].SetActiveSet((m_anim_vel_index + 1).ToString(), 0);
        }

        public override void Draw(GameTime gameTime, ref SpriteBatch sb_)
        {
            if (Throttle < 0.1f)
            {
                m_anim_pirate_idle.Draw(gameTime, ref sb_);
            }
            else
            {
                m_anim_pirate[m_anim_lean_index].Draw(gameTime, ref sb_);
            }
            
            base.Draw(gameTime, ref sb_);
        }
    }
}
