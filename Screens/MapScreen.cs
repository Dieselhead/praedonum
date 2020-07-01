#region File Description
//-----------------------------------------------------------------------------
// PauseMenuScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using ActorPack.Help;
#endregion

namespace Praedonum
{
    /// <summary>
    /// The pause menu comes up over the top of the game,
    /// giving the player options to resume or quit.
    /// </summary>
    class MapScreen : MenuScreen
    {
        private Texture2D m_map;


        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public MapScreen()
            : base("")
        {

            this.TransitionOffTime = TimeSpan.FromSeconds(0.0f);
            
            /*
            // Create our menu entries.
            MenuEntry resumeGameMenuEntry = new MenuEntry("Resume Game");
            MenuEntry quitGameMenuEntry = new MenuEntry("Quit Game");
            
            // Hook up menu event handlers.
            resumeGameMenuEntry.Selected += OnCancel;
            quitGameMenuEntry.Selected += QuitGameMenuEntrySelected;

            // Add entries to the menu.
            MenuEntries.Add(resumeGameMenuEntry);
            MenuEntries.Add(quitGameMenuEntry);
            */


        }

        public override void LoadContent()
        {
            m_map = ScreenManager.Game.Content.Load<Texture2D>("map");
            base.LoadContent();

            Game1.Audio.PlaySound("map_open");
        }


        #endregion

        #region Handle Input


        /// <summary>
        /// Event handler for when the Quit Game menu entry is selected.
        /// </summary>
        void QuitGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            /*
            const string message = "Are you sure you want to quit this game?";

            MessageBoxScreen confirmQuitMessageBox = new MessageBoxScreen(message);

            confirmQuitMessageBox.Accepted += ConfirmQuitMessageBoxAccepted;

            ScreenManager.AddScreen(confirmQuitMessageBox, ControllingPlayer);
             * */
        }


        /// <summary>
        /// Event handler for when the user selects ok on the "are you sure
        /// you want to quit" message box. This uses the loading screen to
        /// transition from the game back to the main menu screen.
        /// </summary>
        void ConfirmQuitMessageBoxAccepted(object sender, PlayerIndexEventArgs e)
        {
            /*
            LoadingScreen.Load(ScreenManager, false, null, new BackgroundScreen(),
                                                           new MainMenuScreen());
            */

            Game1.Audio.PlaySound("map_close");
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);

            if (Input.kp(Microsoft.Xna.Framework.Input.Keys.M))
            {
                Game1.Audio.PlaySound("map_close");
                ExitScreen();
            }
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Begin();
            Game1.SpriteBatch.Draw(m_map, ScreenManager.Game.GraphicsDevice.Viewport.Bounds, Color.White);
            //Game1.SpriteBatch.Draw(m_map, Vector2.Zero, Color.White);
            Game1.SpriteBatch.End();

            

            base.Draw(gameTime);
        }


        #endregion
    }
}
