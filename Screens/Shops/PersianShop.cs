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
    class PersianShop : MenuScreen
    {
        #region Fields

        private Texture2D m_background;
        private MenuEntry m_back;



        private MenuEntry m_tools;
        private MenuEntry m_rope;

  

        private PDVehicle m_playerVehicle;

        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public PersianShop(PDVehicle player)
            : base("Pirate shop")
        {
            m_playerVehicle = player;

            // Create our menu entries.
            m_tools = new MenuEntry(string.Empty);
            m_rope = new MenuEntry(string.Empty);

            m_tools.Selected += ToolsSelected;
            m_rope.Selected += RopeSelected;

            MenuEntry back = new MenuEntry("Back");
            back.Selected += OnCancel;

            MenuEntries.Add(m_tools);
            MenuEntries.Add(m_rope);
            MenuEntries.Add(back);

            SetMenuEntryText();

            Game1.Audio.SetParameter("ambience", "Interactive_Ambience", Game1.AMBIENCE_HARBOR);
            Game1.Audio.SetParameter("music", "Interactive_Sounds", Game1.MUSIC_HARBOR);

            MenuScreen.bPlayNext = false;

        }

        private void SetMenuEntryText()
        {
            m_tools.Text = "Sell tools: " + m_playerVehicle.Tools.ToString() + " for " + (m_playerVehicle.Tools * 5).ToString() + "g";
            m_rope.Text = "Sell rope: " + m_playerVehicle.Rope.ToString() + " for " + (m_playerVehicle.Rope * 3).ToString() + "g";
           
        }

        private void RopeSelected(object sender, PlayerIndexEventArgs e)
        {
            if (m_playerVehicle.Rope > 0)
            {
                m_playerVehicle.Gold += m_playerVehicle.Rope * 3;
                m_playerVehicle.Rope = 0;

                SetMenuEntryText();

                Game1.Audio.PlaySound("menu_upgrade");
            }
            else
            {
                Game1.Audio.PlaySound("menu_upgrade_fail");
            }
        }

        private void ToolsSelected(object sender, PlayerIndexEventArgs e)
        {
            if (m_playerVehicle.Tools > 0)
            {
                m_playerVehicle.Gold = +m_playerVehicle.Tools * 5;
                m_playerVehicle.Tools = 0;

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

            ScreenManager.SpriteBatch.DrawString(ScreenManager.Font, "Gold: " + m_playerVehicle.Gold.ToString(), m_tools.Position - new Vector2(0, 120), Color.Black);


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
