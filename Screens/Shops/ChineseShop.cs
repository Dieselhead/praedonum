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
    class ChineseShop : MenuScreen
    {
        #region Fields

        private Texture2D m_background;
        private MenuEntry m_back;

        private MenuEntry m_spices;
        private MenuEntry m_silk;

        private PDVehicle m_playerVehicle;

        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public ChineseShop(PDVehicle player)
            : base("Chinese trader")
        {
            m_playerVehicle = player;

            // Create our menu entries.
            m_spices = new MenuEntry(string.Empty);
            m_silk = new MenuEntry(string.Empty);

            m_spices.Selected += SpicesSelected;
            m_silk.Selected += SilkSelected;

            MenuEntry back = new MenuEntry("Back");
            back.Selected += OnCancel;

            MenuEntries.Add(m_spices);
            MenuEntries.Add(m_silk);
            MenuEntries.Add(back);

            SetMenuEntryText();

            Game1.Audio.SetParameter("ambience", "Interactive_Ambience", Game1.AMBIENCE_HARBOR);
            Game1.Audio.SetParameter("music", "Interactive_Sounds", Game1.MUSIC_HARBOR);


            MenuScreen.bPlayNext = false;

        }

        private void SetMenuEntryText()
        {
            m_spices.Text = "Sell spices: " + m_playerVehicle.Spices.ToString() + " for " + (m_playerVehicle.Spices * 4).ToString() + "g";
            m_silk.Text = "Sell silk: " + m_playerVehicle.Silk.ToString() + " for " + (m_playerVehicle.Silk * 6).ToString() + "g";

        }

        private void SpicesSelected(object sender, PlayerIndexEventArgs e)
        {
            if (m_playerVehicle.Spices > 0)
            {
                m_playerVehicle.Gold += m_playerVehicle.Spices * 4;
                m_playerVehicle.Spices = 0;

                SetMenuEntryText();

                Game1.Audio.PlaySound("menu_upgrade");
            }
            else
            {
                Game1.Audio.PlaySound("menu_upgrade_fail");
            }
        }

        private void SilkSelected(object sender, PlayerIndexEventArgs e)
        {
            if (m_playerVehicle.Silk > 0)
            {
                m_playerVehicle.Gold += m_playerVehicle.Silk * 6;
                m_playerVehicle.Silk = 0;

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

            ScreenManager.SpriteBatch.DrawString(ScreenManager.Font, "Gold: " + m_playerVehicle.Gold.ToString(), m_spices.Position - new Vector2(0, 120), Color.Black);


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
