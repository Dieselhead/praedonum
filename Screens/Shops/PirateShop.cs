using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Praedonum
{
    /// <summary>
    /// The options screen is brought up over the top of the main menu
    /// screen, and gives the user a chance to configure the game
    /// in various hopefully useful ways.
    /// </summary>
    class PirateShop : MenuScreen
    {
        #region Fields

        private Texture2D m_background;
        private MenuEntry m_back;

        private MenuEntry m_upgradeCannons;
        private MenuEntry m_upgradeSpeed;
        private MenuEntry m_upgradeBalls;
        private MenuEntry m_upgradeArmor;

        private MenuEntry m_repair;


        public static int m_cannons;
        public static float m_speed;
        public static float m_balls;
        public static float m_armor;

        public static float m_repairCost;
        public static float m_gold;

        

        private PDVehicle m_playerVehicle;

        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public PirateShop(PDVehicle player)
            : base("Pirate shop")
        {
            m_playerVehicle = player;

            // Create our menu entries.
            m_upgradeArmor = new MenuEntry(string.Empty);
            m_upgradeBalls = new MenuEntry(string.Empty);
            m_upgradeCannons = new MenuEntry(string.Empty);
            m_upgradeSpeed = new MenuEntry(string.Empty);
            m_repair = new MenuEntry(string.Empty);

            m_upgradeSpeed.Selected += SpeedSelected;
            m_upgradeCannons.Selected += CannonsSelected;
            m_upgradeBalls.Selected += BallsSelected;
            m_upgradeArmor.Selected += ArmorSelected;
            m_repair.Selected += RepairSelected;

            MenuEntry back = new MenuEntry("Back");
            back.Selected += OnCancel;

            MenuEntries.Add(m_upgradeArmor);
            MenuEntries.Add(m_upgradeSpeed);
            MenuEntries.Add(m_upgradeBalls);
            MenuEntries.Add(m_upgradeCannons);
            MenuEntries.Add(m_repair);
            MenuEntries.Add(back);

            SetMenuEntryText();

            Game1.Audio.SetParameter("ambience", "Interactive_Ambience", Game1.AMBIENCE_HARBOR);
            Game1.Audio.SetParameter("music", "Interactive_Sounds", Game1.MUSIC_HARBOR);

            MenuScreen.bPlayNext = false;

        }

        private void SetMenuEntryText()
        {
            m_upgradeCannons.Text = "Upgrade cannons: " + m_playerVehicle.CannonsMax.ToString() + " (+6) for 1200g";
            m_upgradeBalls.Text = "Upgrade cannon balls: " + m_playerVehicle.CannonDamage.ToString() + " (+2) for 1600g";
            m_upgradeArmor.Text = "Upgrade armor: " + m_playerVehicle.Armor.ToString() + " (+500) for 1000g";
            m_upgradeSpeed.Text = "Upgrade ship speed: " + m_playerVehicle.ThrottleMax.ToString() + " (+5) for 1400g";    // x gold
            m_repair.Text = "Repair: " + ((int)((m_playerVehicle.MaxHealth - m_playerVehicle.Health) * 5)).ToString() + " gold";
        }

        private void SpeedSelected(object sender, PlayerIndexEventArgs e)
        {
            if (m_playerVehicle.Gold >= 1400)
            {
                m_playerVehicle.Gold -= 1400;
                m_playerVehicle.ThrottleMax += 5;

                SetMenuEntryText();

                
                Game1.Audio.PlaySound("menu_upgrade");
            }
            else
            {
                
                Game1.Audio.PlaySound("menu_upgrade_fail");
            }
        }

        private void CannonsSelected(object sender, PlayerIndexEventArgs e)
        {
            if (m_playerVehicle.Gold >= 1200)
            {
                m_playerVehicle.Gold -= 1200;
                m_playerVehicle.CannonsMax += 6;

                SetMenuEntryText();

                Game1.Audio.PlaySound("menu_upgrade");
            }
            else
            {
                Game1.Audio.PlaySound("menu_upgrade_fail");
            }
        }

        private void BallsSelected(object sender, PlayerIndexEventArgs e)
        {
            if (m_playerVehicle.Gold >= 1600)
            {
                m_playerVehicle.Gold -= 1600;
                m_playerVehicle.CannonDamage += 2f;

                SetMenuEntryText();

                Game1.Audio.PlaySound("menu_upgrade");
            }
            else
            {
                Game1.Audio.PlaySound("menu_upgrade_fail");
            }
        }

        private void ArmorSelected(object sender, PlayerIndexEventArgs e)
        {
            if (m_playerVehicle.Gold >= 1000)
            {
                m_playerVehicle.Gold -= 1000;
                m_playerVehicle.Armor += 500;

                SetMenuEntryText();

                Game1.Audio.PlaySound("menu_upgrade");
            }
            else
            {
                Game1.Audio.PlaySound("menu_upgrade_fail");
            }
        }

        private void RepairSelected(object sender, PlayerIndexEventArgs e)
        {
            if (m_playerVehicle.Health >= m_playerVehicle.MaxHealth)
            {
                Game1.Audio.PlaySound("menu_upgrade_fail");
            }
            else if (m_playerVehicle.Gold >= (int)((m_playerVehicle.MaxHealth - m_playerVehicle.Health) * 5))
            {
                m_playerVehicle.Gold -= (int)((m_playerVehicle.MaxHealth - m_playerVehicle.Health) * 5);
                m_playerVehicle.Health = m_playerVehicle.MaxHealth;

                SetMenuEntryText();

                Game1.Audio.PlaySound("menu_upgrade");
            }
            else if (m_playerVehicle.Gold >= 5)
            {
                m_playerVehicle.Health += (float)Math.Floor(m_playerVehicle.Gold / 5.0f);
                m_playerVehicle.Gold %= 5;

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

            ScreenManager.SpriteBatch.DrawString(ScreenManager.Font, "Gold: " + m_playerVehicle.Gold.ToString(), m_upgradeArmor.Position - new Vector2(0, 120), Color.Black);


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
