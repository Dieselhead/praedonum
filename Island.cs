using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ActorPack;

namespace Praedonum
{
    public class Island : Actor
    {
        private Sprite[] m_tiles;
        private OBB[] m_hitbox;

        public OBB[] Hitbox
        {
            get { return m_hitbox; }
        }

        public Island(Game game)
            : base(game, null)
        {


        }

        public void Initialize(Sprite[] sprites, OBB[] hitbox = null)
        {
            m_hitbox = hitbox;
            if (m_hitbox != null)
            {
                for (int j = 0; j < m_hitbox.Length; j++)
                {
                    m_hitbox[j].Center = m_hitbox[j].Center + Position;
                    m_hitbox[j].CalculateAxis();
                }
            }

            m_tiles = sprites;
            for (int i = 0; i < m_tiles.Length; i++)
            {
                m_tiles[i].Position = Position + m_tiles[i].Position;
                m_tiles[i].Rotation = Rotation;
                m_tiles[i].Origin = Origin;
            }
        }

        public override void Draw(GameTime gameTime, ref SpriteBatch sb_)
        {
            for (int i = 0; i < m_tiles.Length; i++)
            {
                m_tiles[i].Draw(gameTime, ref sb_);

            }
            
            base.Draw(gameTime, ref sb_);
        }




    }
}
