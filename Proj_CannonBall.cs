using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using ActorPack;

namespace Praedonum
{
    public class Proj_CannonBall : Projectile
    {
        private float m_lifeTime = 6.0f;
        private float m_killTime = 0.0f;

        private OBB m_obb;

        private GameplayScreen m_screen;
        

       

        public OBB Obb
        {
            get { return m_obb; }
            protected set { m_obb = value; }
        }

        public Proj_CannonBall(Game game, Actor owner_, ref Texture2D tex_, GameplayScreen screen)
            : base(game, owner_, ref tex_)
        {
            this.MaxSpeed = 100;

            m_screen = screen;

            Damage = 5;

            

        }

        protected override void SetGraphics(ref Texture2D tex_)
        {
            Animation anim;
            AnimationSet set;

            anim = new Animation(Game);

            anim.Initialize(ref tex_);


            set = new AnimationSet("idle", true, 1.0f, 0);
            set.AddFrame(new Rectangle(96, 0, 8, 8));
            anim.AddSet(set);
            anim.Origin = new Vector2(4, 4);
            anim.SetActiveSet("idle", 0);

            m_gfx = anim;


        }

        public void Initialize(float rotation, Vector2 position, Actor targetActor, bool isHoming, bool isInstant, GameTime gameTime)
        {
            // m_killTime = (float)gameTime.TotalGameTime.TotalSeconds + m_lifeTime;
            m_killTime = m_lifeTime + (float)Game1.Rand.NextDouble();
            
            m_obb = new OBB(0.0f, Position, new Vector2(3, 3));

            base.Initialize(rotation, position, targetActor, isHoming, isInstant);
        }


        public override void Update(GameTime gameTime)
        {
            if (m_screen.IsActive)
            {
                m_killTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            //if ((float)gameTime.TotalGameTime.TotalSeconds > m_killTime)
            if (m_killTime < 0.0f)
            {
                bDead = true;
                // Cue c = Game1.Audio.PlaySound("sfx_cannonball_hit_water");
                Cue c = Game1.Audio.GetCue("sfx_cannonball_hit_water");

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
                c.SetVariable("Distance", (m_screen.Player.Position - Position).Length());

                Watersplash w = new Watersplash(Game);
                w.Initialize(10, Position, true);

                //Game1.Audio.SetParameter("sfx_cannonball_hit_water", "Distance", (m_screen.Player.Position - Position).Length());
            }

            

            m_obb.Orientation = Rotation;
            m_obb.Center = Position;
            m_obb.CalculateAxis();

            for (Actor a = Actors.First.Value; a != null; a = a.NextActor)
            {
                if (a is PDVehicle)
                {
                    if (a != Owner)
                    {
                        if ((a as PDVehicle).Obb.TestOBBOBB(Obb))
                        {
                            SpriteEffect e = new EffectCannonFire(Game);
                            e.Initialize(10, Position, true);

                            bDead = true;

                            // Cue c = Game1.Audio.PlaySound("sfx_cannonball_hit");
                            Cue c = Game1.Audio.GetCue("sfx_cannonball_hit");
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
                            c.SetVariable("Distance", (m_screen.Player.Position - Position).Length());
                            // Game1.Audio.SetParameter("sfx_cannonball_hit", "Distance", (m_screen.Player.Position - Position).Length());
            
                            // Damage target
                            (a as PDVehicle).Damage(Damage);
                        }
                    }
                }
            }
            
            base.Update(gameTime);
        }
        

        
    }
}
