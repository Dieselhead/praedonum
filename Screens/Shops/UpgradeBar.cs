using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ActorPack;

namespace Praedonum
{
    public class UpgradeBar : Actor
    {
        private int m_upgradeIndex = 0;

        public int UpgradeIndex
        {
            get { return m_upgradeIndex; }
            set { m_upgradeIndex = value; }
        }

        public UpgradeBar(Game game)
            : base(game, null)
        {

        }

        public override void Draw(GameTime gameTime, ref SpriteBatch sb_)
        {
            sb_.Draw(GameplayScreen.m_tBarsBG, Position, Color.White);

            for (int i = 0; i < m_upgradeIndex; i++)
            {
                sb_.Draw(GameplayScreen.m_tBars[i], new Vector2(Position.X + (i * (20 + 8)), Position.Y + (93 - GameplayScreen.m_tBars[i].Height)), Color.White);
            }

            base.Draw(gameTime, ref sb_);
        }
    }
}
