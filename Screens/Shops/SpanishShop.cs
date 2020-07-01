using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Praedonum
{
    /// <summary>
    /// The options screen is brought up over the top of the main menu
    /// screen, and gives the user a chance to configure the game
    /// in various hopefully useful ways.
    /// </summary>
    /// 
    /*
     * 1 Iron       British
     * 2 Coal       British
     * 3 Spices     Chinese
     * 4 Leather    Spanish
     * 5 Rope       Persian    
     * 6 Rum        Spanish
     * 7 Silk       Chinese
     * 8 Tools      Persian
     * 
     * 
     * */
    class SpanishShop : MenuScreen
    {
        #region Fields

        private Texture2D m_background;
        private MenuEntry m_back;

        private MenuEntry m_rum;
        private MenuEntry m_leather;

        private PDVehicle m_playerVehicle;

        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public SpanishShop(PDVehicle player)
            : base("Spanish trader")
        {
            m_playerVehicle = player;

            // Create our menu entries.
            m_rum = new MenuEntry(string.Empty);
            m_leather = new MenuEntry(string.Empty);

            m_rum.Selected += RumSelected;
            m_leather.Selected += LeatherSelected;

            MenuEntry back = new MenuEntry("Back");
            back.Selected += OnCancel;

            MenuEntries.Add(m_rum);
            MenuEntries.Add(m_leather);
            MenuEntries.Add(back);

            SetMenuEntryText();

            Game1.Audio.SetParameter("ambience", "Interactive_Ambience", Game1.AMBIENCE_HARBOR);
            Game1.Audio.SetParameter("music", "Interactive_Sounds", Game1.MUSIC_HARBOR);

            MenuScreen.bPlayNext = false;

        }

        private void SetMenuEntryText()
        {
            m_rum.Text = "Sell rum: " + m_playerVehicle.Rum.ToString() + " for " + (m_playerVehicle.Rum * 6).ToString() + "g";
            m_leather.Text = "Sell leather: " + m_playerVehicle.Leather.ToString() + " for " + (m_playerVehicle.Leather * 3).ToString() + "g";

        }

        private void RumSelected(object sender, PlayerIndexEventArgs e)
        {
            if (m_playerVehicle.Rum > 0)
            {
                m_playerVehicle.Gold += m_playerVehicle.Rum * 6;
                m_playerVehicle.Rum = 0;

                SetMenuEntryText();

                Game1.Audio.PlaySound("menu_upgrade");
            }
            else
            {
                Game1.Audio.PlaySound("menu_upgrade_fail");
            }
        }

        private void LeatherSelected(object sender, PlayerIndexEventArgs e)
        {
            if (m_playerVehicle.Leather > 0)
            {
                m_playerVehicle.Gold += m_playerVehicle.Leather * 3;
                m_playerVehicle.Leather = 0;

                SetMenuEntryText();

                Game1.Audio.PlaySound("menu_upgrade");
            }
            else
            {
                Game1.Audio.PlaySound("menu_upgrade_fail");
            }
        }



        public override void Draw(GameTime gameTime)
        {
            ScreenManager.SpriteBatch.Begin();
            ScreenManager.SpriteBatch.Draw(GameplayScreen.m_tPirateShop
                , new Rectangle(0, 0, ScreenManager.Game.GraphicsDevice.Viewport.Width, ScreenManager.Game.GraphicsDevice.Viewport.Height)
                , Color.White);

            ScreenManager.SpriteBatch.DrawString(ScreenManager.Font, "Gold: " + m_playerVehicle.Gold.ToString(), m_rum.Position - new Vector2(0, 120), Color.Black);


            ScreenManager.SpriteBatch.End();
            base.Draw(gameTime);
        }

        public override void ExitScreen()
        {

            Game1.Audio.SetParameter("ambience", "Interactive_Ambience", Game1.AMBIENCE_SEA);
            if (Game1.Rand.Next() > 0.5)
                Game1.Audio.SetParameter("music", "Interactive_Sounds", Game1.MUSIC_INGAME1);
            else
                Game1.Audio.SetParameter("music", "Interactive_Sounds", Game1.MUSIC_INGAME2);

            MenuScreen.bPlayNext = true;

            base.ExitScreen();
        }


        #endregion

        #region Handle Input

        #endregion
    }
}
