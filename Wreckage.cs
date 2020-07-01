using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ActorPack;

namespace Praedonum
{
    public class Wreckage : Actor
    {
        private float m_gold;

        public float Gold
        {
            get { return m_gold; }
            set { m_gold = value; }
        }

        private int m_silk;

        public int Silk
        {
            get { return m_silk; }
            set { m_silk = value; }
        }
        private int m_spices;

        public int Spices
        {
            get { return m_spices; }
            set { m_spices = value; }
        }
        private int m_iron;

        public int Iron
        {
            get { return m_iron; }
            set { m_iron = value; }
        }
        private int m_coal;

        public int Coal
        {
            get { return m_coal; }
            set { m_coal = value; }
        }
        private int m_leather;

        public int Leather
        {
            get { return m_leather; }
            set { m_leather = value; }
        }
        private int m_rum;

        public int Rum
        {
            get { return m_rum; }
            set { m_rum = value; }
        }
        private int m_rope;

        public int Rope
        {
            get { return m_rope; }
            set { m_rope = value; }
        }
        private int m_tools;

        public int Tools
        {
            get { return m_tools; }
            set { m_tools = value; }
        }
        


        public Wreckage(Game game)
            : base(game, null)
        {

        }

        public void Initialize(float gold, int silk, int spice, int leather, int rum, int iron, int coal, int rope, int tools)
        {
            m_gold = gold;
            m_silk = silk;
            m_spices = spice;
            m_iron = iron;
            m_coal = coal;
            m_leather = leather;
            m_rope = rope;
            m_tools = tools;
            m_rum = rum;


            Texture2D tex = GameplayScreen.tWreckage;

            Animation anim = new Animation(Game);
            anim.Initialize(ref tex);

            AnimationSet set = new AnimationSet("idle", true, 6.0f, 0);
            set.AddFrame(new Rectangle(0 ,0, 140 ,140));
            set.AddFrame(new Rectangle(140, 0, 140, 140));
            set.AddFrame(new Rectangle(280, 0, 140, 140));
            set.AddFrame(new Rectangle(420, 0, 140, 140));
            set.AddFrame(new Rectangle(560, 0 ,140, 140));
            set.AddFrame(new Rectangle(700, 0 ,140, 140));
            set.AddFrame(new Rectangle(840, 0 ,140 ,140));
            set.AddFrame(new Rectangle(980, 0 ,140 ,140));
            set.AddFrame(new Rectangle(1120, 0 ,140 ,140));

            anim.AddSet(set);
            anim.SetActiveSet("idle", 0);
            anim.Origin = new Vector2(70, 70);

            m_gfx = anim;

            
            base.Initialize();
        }
    }
}
