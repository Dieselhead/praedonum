using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using ActorPack;


// Use this class to set the right animation
/*
 * 
 * 
 * LEAN LEFT 4/4:           [0][1][2][3][4][5][6][7]
 * LEAN LEFT 3/4:           [0][1][2][3][4][5][6][7]
 * LEAN LEFT 2/4:           [0][1][2][3][4][5][6][7]
 * LEAN LEFT 1/4:           [0][1][2][3][4][5][6][7]
 * IDLE ANIMATION:          [0][1][2][3][4][5][6][7]
 * LEAN RIGHT 1/4:          [0][1][2][3][4][5][6][7]
 * LEAN RIGHT 2/4:          [0][1][2][3][4][5][6][7]
 * LEAN RIGHT 3/4:          [0][1][2][3][4][5][6][7]
 * LEAN RIGHT 4/4:          [0][1][2][3][4][5][6][7]
 * 
*/
namespace Praedonum
{
    public class PDVehicle : Vehicle
    {
        public const string ANIM_IDLE_CENTER = "idle_center";
        public const string ANIM_IDLE_LEFT1 = "idle_left1";
        public const string ANIM_IDLE_LEFT2 = "idle_left2";
        public const string ANIM_IDLE_LEFT3 = "idle_left3";
        public const string ANIM_IDLE_LEFT4 = "idle_left4";
        public const string ANIM_IDLE_RIGHT1 = "idle_right1";
        public const string ANIM_IDLE_RIGHT2 = "idle_right2";
        public const string ANIM_IDLE_RIGHT3 = "idle_right3";
        public const string ANIM_IDLE_RIGHT4 = "idle_right4";

        protected string[] m_animTable;

        protected Animation m_shadow;

        // clamps between -1 and 1
        private float m_leanValue;

        public float LeanValue
        {
            get { return m_leanValue; }
            set { m_leanValue = value; }
        }
        private float m_leanNormalize;

        // Lean change per second
        private float m_leanIncrease;


        private float m_nextShot = 0.0f;
        private float m_fireRate = 0.2f;


        private int m_cannonsMax = 20;

        
        private int m_cannonsReady = 20;

        
        private int m_pirates = 20;

        private float[] m_randomTable = null;
        private int m_randomIndex = 0;
        private float m_nextReload = 0.0f;

        private OBB m_obb;

        private GameplayScreen m_screen;



        private float m_health;

        public float Health
        {
            get { return m_health; }
            set { m_health = value; }
        }
        private float m_maxHealth;

        public float MaxHealth
        {
            get { return m_maxHealth; }
            set { m_maxHealth = value; }
        }
        private int m_crew;

        // Treasure


        private Animation m_hpBarBG;
        private Animation m_hpBar;
        private bool m_bShowHpBar = true;




        


        private bool m_bFiring = false;
        private bool m_bFireLeft = false;
        private float m_tTimeBetweenShots = 0.0f;


        private int m_gold = 600;
        private float m_cannonDamage = 7.0f;
        private float m_armor = 500.0f;

        private int m_iron = 0;
        private int m_coal = 0;
        private int m_spices = 0;
        private int m_silk = 0;
        private int m_leather = 0;
        private int m_rope = 0;
        private int m_tools = 0;
        private int m_rum = 0;


        public int Iron
        {
            get { return m_iron; }
            set { m_iron = value; }
        }
        public int Coal
        {
            get { return m_coal; }
            set { m_coal = value; }
        }
        public int Spices
        {
            get { return m_spices; }
            set { m_spices = value; }
        }
        public int Silk
        {
            get { return m_silk; }
            set { m_silk = value; }
        }
        public int Leather
        {
            get { return m_leather; }
            set { m_leather = value; }
        }
        public int Rope
        {
            get { return m_rope; }
            set { m_rope = value; }
        }
        public int Tools
        {
            get { return m_tools; }
            set { m_tools = value; }
        }
        public int Rum
        {
            get { return m_rum; }
            set { m_rum = value; }
        }




        public float Armor
        {
            get { return m_armor; }
            set { m_armor = value; }
        }

        public float CannonDamage
        {
            get { return m_cannonDamage; }
            set { m_cannonDamage = value; }
        }

        public int Gold
        {
            get { return m_gold; }
            set { m_gold = value; }
        }

        private float m_tNextWaterTrail = 0;
        
        

        public PDVehicle(Game game, GameplayScreen screen)
            : base(game)
        {
            m_screen = screen;

            m_maxHealth = m_health = 100.0f;

            Depth = 0.1f;

            m_leanValue = 0.0f;
            m_leanIncrease = 1.0f;
            m_leanNormalize = 0.90f;

            m_animTable = new string[9];

            m_animTable[0] = PDVehicle.ANIM_IDLE_LEFT4;
            m_animTable[1] = PDVehicle.ANIM_IDLE_LEFT3;
            m_animTable[2] = PDVehicle.ANIM_IDLE_LEFT2;
            m_animTable[3] = PDVehicle.ANIM_IDLE_LEFT1;
            m_animTable[4] = PDVehicle.ANIM_IDLE_CENTER;
            m_animTable[5] = PDVehicle.ANIM_IDLE_RIGHT1;
            m_animTable[6] = PDVehicle.ANIM_IDLE_RIGHT2;
            m_animTable[7] = PDVehicle.ANIM_IDLE_RIGHT3;
            m_animTable[8] = PDVehicle.ANIM_IDLE_RIGHT4;

            

            RotationRate = 0.5f;

            if (m_randomTable == null)
            {
                m_randomTable = new float[100];
                for (int i = 0; i < 100; i++)
                {
                    m_randomTable[i] = (float)Game1.Rand.NextDouble() * 1 + 0.0f;
                }
            }

            m_obb = new OBB(Rotation, Position, new Vector2(60, 20));

            Texture2D tex = GameplayScreen.m_tShadow;

            m_shadow = new Animation(game);
            m_shadow.Initialize(ref tex);

            AnimationSet set = new AnimationSet("idle", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 0, 160, 96));
            m_shadow.AddSet(set);
            m_shadow.SetActiveSet("idle", 0);
            m_shadow.Origin = new Vector2(80, 48);
            m_shadow.Depth = 0.1f;
            m_shadow.Scale = new Vector2(0.8f, 0.8f);




            m_hpBarBG = new Animation(game);
            m_hpBarBG.Initialize(ref GameplayScreen.m_tHPBarBG);

            set = new AnimationSet("idle", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 0, 140, 30));
            m_hpBarBG.AddSet(set);
            m_hpBarBG.SetActiveSet("idle", 0);
            m_hpBarBG.Depth = 0.9f;
            m_hpBarBG.Origin = new Vector2(50, 80);

            m_hpBar = new Animation(game);
            m_hpBar.Initialize(ref GameplayScreen.m_tHPBar);

            set = new AnimationSet("idle", true, 1.0f, 0);
            set.AddFrame(new Rectangle(0, 0, 140, 30));
            m_hpBar.AddSet(set);
            m_hpBar.SetActiveSet("idle", 0);
            m_hpBar.Depth = 0.95f;
            m_hpBar.Origin = new Vector2(50, 80);

            Gold = Game1.Rand.Next(0, 500);
            Silk = Game1.Rand.Next(0, 200);
            Rum = Game1.Rand.Next(0, 200);
            Tools = Game1.Rand.Next(0, 200);
            Rope = Game1.Rand.Next(0, 200);
            Leather = Game1.Rand.Next(0, 200);
            Iron = Game1.Rand.Next(0, 200);
            Coal = Game1.Rand.Next(0, 200);
            Spices = Game1.Rand.Next(0, 200);


        }

        public void Damage(float dmg)
        {
            m_health -= (Armor / (Armor + 400 + (85 * 60))) * dmg;
        }

        public override void Draw(GameTime gameTime, ref SpriteBatch sb_)
        {
            if (m_bShowHpBar)
            {
                m_hpBarBG.Draw(gameTime, ref sb_);
                m_hpBar.Draw(gameTime, ref sb_);
            }

            m_shadow.Draw(gameTime, ref sb_);
            

            base.Draw(gameTime, ref sb_);
        }

        public virtual void SetDefaultGraphics(ref Texture2D tex_)
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

        public virtual void MoveForward(GameTime gameTime)
        {
            Throttle += ThrottleMax * (float)gameTime.ElapsedGameTime.TotalSeconds;
            //Game1.Audio.PlaySound("sfx_ship_accelerate");
        }

        public virtual void Break(GameTime gameTime)
        {
            Throttle -= ThrottleDecrease * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public virtual void TurnRight(GameTime gameTime)
        {
            float newRotation = RotationRate * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (!bTurnInPlace)
                newRotation *= (Throttle / ThrottleMax);

            Rotation += newRotation;

            if (m_leanValue < 0.0f)
                LevelOut();

            m_leanValue += m_leanIncrease * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Game1.Audio.PlaySound("sfx_ship_turn_right");
        }

        public virtual void TurnLeft(GameTime gameTime)
        {
            float newRotation = RotationRate * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (!bTurnInPlace)
                newRotation *= (Throttle / ThrottleMax);

            Rotation -= newRotation;
            
            if (m_leanValue > 0.0f)
                LevelOut();

            m_leanValue -= m_leanIncrease * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Game1.Audio.PlaySound("sfx_ship_turn_left");
        }

        public void LevelOut()
        {
            m_leanValue *= m_leanNormalize;
        }

        public virtual void Fire(GameTime gameTime)
        {
            if (m_bFiring)
            {
                
                Vector2 back = Position - (Heading * 50);
                Vector2 length = Heading * 100;

                Vector2 pos = back + (length * (float)Game1.Rand.NextDouble());

                Texture2D tex = GameplayScreen.m_debugSprites;
                Proj_CannonBall p = new Proj_CannonBall(Game, this, ref tex, m_screen);
                p.Damage = m_cannonDamage;

                if (m_bFireLeft)
                    p.Initialize(Rotation - MathHelper.PiOver2, pos, null, false, false, gameTime);
                else
                    p.Initialize(Rotation + MathHelper.PiOver2, pos, null, false, false, gameTime);

                m_cannonsReady--;
            }







                /*
                Vector2 back = Position - (Heading * 50);
                Vector2 length = Heading * 100;

                Vector2 pos = back + (length * (float)Game1.Rand.NextDouble());

                Texture2D tex = GameplayScreen.m_debugSprites;
                Proj_CannonBall p = new Proj_CannonBall(Game, this, ref tex, m_screen);
                p.Initialize(Rotation - MathHelper.PiOver2, pos, null, false, false, gameTime);


                SpriteEffect se = new EffectSmoke(Game);
                se.Initialize(10, pos, true);

                m_cannonsReady--;
                */

                
         


            /*
            if (gameTime.TotalGameTime.TotalSeconds > m_nextShot)
            {
                Texture2D tex = null;
                (Game as Game1).GetDebugSprite(ref tex);
                Proj_CannonBall p = new Proj_CannonBall(Game, this, ref tex);
                p.Initialize(Rotation - MathHelper.PiOver2, Position, null, false, false, gameTime);

                m_nextShot = (float)gameTime.TotalGameTime.TotalSeconds + m_fireRate;
            }
            */
        }

        public virtual bool FireLeft(GameTime gameTime)
        {
            if (m_cannonsReady > 4)
            {
                if (!m_bFiring)
                {
                    m_bFiring = true;
                    m_bFireLeft = true;

                    Cue c = null;

                    if (m_cannonsReady > 6)
                    {
                        m_tTimeBetweenShots = 1.3f / m_cannonsReady;
                        // c = Game1.Audio.PlaySound("sfx_cannon_shoot_many");
                        c = Game1.Audio.GetCue("sfx_cannon_shoot_many");
                    }
                    else
                    {
                        m_tTimeBetweenShots = 0.4f / m_cannonsReady;
                        // c = Game1.Audio.PlaySound("sfx_cannon_shoot");
                        c = Game1.Audio.GetCue("sfx_cannon_shoot");
                    }

                    AudioListener al = new AudioListener();
                    al.Position = new Vector3(m_screen.Player.Position, 0);
                    al.Up = Vector3.Backward;
                    al.Forward = Vector3.Up;

                    AudioEmitter ae = new AudioEmitter();
                    ae.Position = new Vector3(Position, 0);
                    ae.Up = Vector3.Backward;
                    ae.Forward = Vector3.Up;

                    c.Apply3D(al, ae);
                    Game1.Audio.PlayCue(c);

                    c.SetVariable("Distance", (Screen.Player.Position - Position).Length());

                    m_nextShot = (float)gameTime.TotalGameTime.TotalSeconds;
                }


                /*
                Vector2 back = Position - (Heading * 50);
                Vector2 length = Heading * 100;

                Vector2 pos = back + (length * (float)Game1.Rand.NextDouble());

                Texture2D tex = GameplayScreen.m_debugSprites;
                Proj_CannonBall p = new Proj_CannonBall(Game, this, ref tex, m_screen);
                p.Initialize(Rotation - MathHelper.PiOver2, pos, null, false, false, gameTime);

                m_cannonsReady--;

                return true;

                */
            }

            return false;
        }

        public virtual bool FireRight(GameTime gameTime)
        {

            if (m_cannonsReady > 4)
            {
                if (!m_bFiring)
                {
                    m_bFiring = true;
                    m_bFireLeft = false;

                    Cue c = null;

                    if (m_cannonsReady > 6)
                    {
                        m_tTimeBetweenShots = 1.3f / m_cannonsReady;
                        // c = Game1.Audio.PlaySound("sfx_cannon_shoot_many");
                        c = Game1.Audio.GetCue("sfx_cannon_shoot_many");
                    }
                    else
                    {
                        m_tTimeBetweenShots = 0.5f / m_cannonsReady;
                        // c = Game1.Audio.PlaySound("sfx_cannon_shoot");
                        c = Game1.Audio.GetCue("sfx_cannon_shoot");
                    }

                    AudioListener al = new AudioListener();
                    al.Position = new Vector3(m_screen.Player.Position, 0);
                    al.Up = Vector3.Backward;
                    al.Forward = Vector3.Up;

                    AudioEmitter ae = new AudioEmitter();
                    ae.Position = new Vector3(Position, 0);
                    ae.Up = Vector3.Backward;
                    ae.Forward = Vector3.Up;

                    c.Apply3D(al, ae);
                    Game1.Audio.PlayCue(c);

                    c.SetVariable("Distance", (Screen.Player.Position - Position).Length());

                    m_nextShot = (float)gameTime.TotalGameTime.TotalSeconds;
                }

                /*
                Vector2 back = Position - (Heading * 50);
                Vector2 length = Heading * 100;

                Vector2 pos = back + (length * (float)Game1.Rand.NextDouble());

                Texture2D tex = GameplayScreen.m_debugSprites;
                Proj_CannonBall p = new Proj_CannonBall(Game, this, ref tex, m_screen);
                p.Initialize(Rotation + MathHelper.PiOver2, pos, null, false, false, gameTime);

                m_cannonsReady--;

                return true;
                 * 
                */
            }

            return false;
        }

        protected void Reload(GameTime gameTime)
        {
            if (m_cannonsReady < m_cannonsMax)
            {
                // Reload
                if (m_nextReload < gameTime.TotalGameTime.TotalSeconds)
                {
                    m_cannonsReady++;
                    m_randomIndex++;
                    
                    if (m_randomIndex >= m_randomTable.Length)
                        m_randomIndex = 0;

                    m_nextReload = (float)gameTime.TotalGameTime.TotalSeconds + m_randomTable[m_randomIndex];
                }
            }
        }


        public override void Update(GameTime gameTime)
        {
            // Set the correct animation based on Velocity/Throttle & Rotation

            // Lean percentage that increases when you hold down turning and normalizes when you don't
            // The Lean percentage is adjusted by velocity/throttle so that you can't lean hard with low velocity

            if (m_health <= 0)
            {
                bDead = true;
                // Cue c = Game1.Audio.PlaySound("sfx_ship_sink");
                Cue c = Game1.Audio.GetCue("sfx_ship_sink");
                AudioListener al = new AudioListener();
                al.Position = new Vector3(m_screen.Player.Position, 0);
                al.Up = Vector3.Backward;
                al.Forward = Vector3.Up;

                AudioEmitter ae = new AudioEmitter();
                ae.Position = new Vector3(Position, 0);
                ae.Up = Vector3.Backward;
                ae.Forward = Vector3.Up;

                c.Apply3D(al, ae);
                Game1.Audio.PlayCue(c);


                c.SetVariable("Distance", (Screen.Player.Position - Position).Length());

                Wreckage w = new Wreckage(Game);
                w.Initialize(m_gold, Silk, Spices, Leather, Rum, Iron, Coal, Rope, Tools);
                w.Position = Position;

                for (int i = 0; i < 10; i++)
                {
                    EffectCannonFire a = new EffectCannonFire(Game);
                    a.Initialize(10, Position + new Vector2(Game1.Rand.Next(-40, 40),Game1.Rand.Next(-40, 40)) , true);
                }

                for (int i = 0; i < 10; i++)
                {
                    Watersplash a = new Watersplash(Game);
                    a.Initialize(10, Position + new Vector2(Game1.Rand.Next(-40, 40), Game1.Rand.Next(-40, 40)), true);
                }

                int n = Game1.Rand.Next(0, GameplayScreen.m_waypoints.Length);

                int type = Game1.Rand.Next(0, 4);

                PDVehicle v = null;

                switch (type)
                {
                    case 0:
                        v = new PDVBritish(Game, m_screen);
                        v.Initialize();
                        v.SetDefaultGraphics(ref GameplayScreen.m_tShipBritish);
                        break;
                    case 1:
                        v = new PDVChinese(Game, m_screen);
                        v.Initialize();
                        v.SetDefaultGraphics(ref GameplayScreen.m_tShipChinese);
                        break;

                    case 2:
                        v = new PDVPersian(Game, m_screen);
                        v.Initialize();
                        v.SetDefaultGraphics(ref GameplayScreen.m_tShipPersian);
                        break;

                    case 3:
                        v = new PDVSpanish(Game, m_screen);
                        v.Initialize();
                        v.SetDefaultGraphics(ref GameplayScreen.m_tShipSpanish);
                        break;

                }

                v.Position = GameplayScreen.m_waypoints[n];
                v.ThrottleMax = 40;
                v.ThrottleDecrease = 100;
                v.bTurnInPlace = true;
                

                return;
            }



            for (int i = 0; i < Screen.m_islands.Count; i++)
            {
                if (Screen.m_islands[i].Hitbox != null)
                {
                    for (int j = 0; j < Screen.m_islands[i].Hitbox.Length; j++)
                    {
                        if (Screen.m_islands[i].Hitbox[j].TestOBBOBB(Obb))
                        {
                            // Cue c = Game1.Audio.PlaySound("sfx_ship_collide");
                            Cue c = Game1.Audio.GetCue("sfx_ship_collide");
                            AudioListener al = new AudioListener();
                            al.Position = new Vector3(m_screen.Player.Position, 0);
                            al.Up = Vector3.Backward;
                            al.Forward = Vector3.Up;

                            AudioEmitter ae = new AudioEmitter();
                            ae.Position = new Vector3(Position, 0);
                            ae.Up = Vector3.Backward;
                            ae.Forward = Vector3.Up;

                            c.Apply3D(al, ae);
                            Game1.Audio.PlayCue(c);


                            c.SetVariable("Distance", (Screen.Player.Position - Position).Length());
                           

                            Vector2 v = Obb.Center - Screen.m_islands[i].Hitbox[j].Center;
                            v.Normalize();

                            Heading = v;
                            Rotation = (float)Math.Atan2(Heading.Y, Heading.X);
                            Throttle = 100;
                            break;
                        }
                    }
                }
            }





           
            

            // Throttle -= ThrottleDecrease * (float)gameTime.ElapsedGameTime.TotalSeconds * 0.25f;

            float velMod = 0.0f;
    
            if (Throttle > 0.001f)
                velMod = Throttle / ThrottleMax;

            m_leanValue = MathHelper.Clamp(m_leanValue * velMod, -1.0f, 1.0f);

            int index = (int)Math.Round(m_leanValue * 4.0f) + 4;
            if (m_gfx != null)
            {
                if ((m_gfx as Animation).ActiveAnimationSet.Name != m_animTable[index])
                {
                    int currentFrame = (m_gfx as Animation).ActiveAnimationSet.nActiveFrame;
                    (m_gfx as Animation).SetActiveSet(m_animTable[index], currentFrame);
                }
            }


            if (m_bFiring)
            {
                if (m_nextShot < gameTime.TotalGameTime.TotalSeconds)
                {
                    Fire(gameTime);
                    m_nextShot += m_tTimeBetweenShots;

                    if (m_cannonsReady <= 0)
                        m_bFiring = false;
                }
            }
            else
            {
                Reload(gameTime);
            }


            


            m_obb.Orientation = Rotation;
            m_obb.Center = Position;
            m_obb.CalculateAxis();

            m_shadow.Position = Position;
            m_shadow.Rotation = Rotation;

            m_hpBar.Position = Position;
            m_hpBar.Update(gameTime);
            m_hpBar.Scale = new Vector2(m_health / m_maxHealth, 1);

            m_hpBarBG.Position = Position;

            m_hpBarBG.Update(gameTime);



            if (m_tNextWaterTrail < gameTime.TotalGameTime.TotalSeconds)
            {
                if (Throttle > 10.0f)
                {
                    EffectWaterTrail water = new EffectWaterTrail(Game);
                    water.Initialize((float)gameTime.TotalGameTime.TotalSeconds + 3.5f, Position + (Heading * 40), false);
                    water.Rotation = Rotation - MathHelper.PiOver2;

                    water = new EffectWaterTrail(Game);
                    water.Initialize((float)gameTime.TotalGameTime.TotalSeconds + 3.5f, Position + (Heading * 40), false);
                    water.Rotation = Rotation + MathHelper.PiOver2;

                    m_tNextWaterTrail = (float)gameTime.TotalGameTime.TotalSeconds + 0.1f;
                }
            }


            

            base.Update(gameTime);
        }

        protected override Controller SetDefaultController()
        {
            // Change to PDAIController()

           
            return new PDAIController(Game, this);
        }




        public int CannonsMax
        {
            get { return m_cannonsMax; }
            set { m_cannonsMax = value; }
        }

        public int CannonsReady
        {
            get { return m_cannonsReady; }
            set { m_cannonsReady = value; }
        }

        public GameplayScreen Screen
        {
            get { return m_screen; }
            set { m_screen = value; }
        }

        public bool bShowHpBar
        {
            get { return m_bShowHpBar; }
            set { m_bShowHpBar = value; }
        }

        public OBB Obb
        {
            get { return m_obb; }
            protected set { m_obb = value; }
        }
    }
}
