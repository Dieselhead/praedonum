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
using Microsoft.Xna.Framework.Content;
#endregion

namespace Praedonum
{
    /// <summary>
    /// The pause menu comes up over the top of the game,
    /// giving the player options to resume or quit.
    /// </summary>
    class HelpScreen : MenuScreen
    {
        ContentManager content;
        private Texture2D m_background;
        MenuEntry back;
        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public HelpScreen()
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
             * 
            */


            back = new MenuEntry("Back");
            back.Selected += OnCancel;

            MenuEntries.Add(back);

        }

        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            m_background = content.Load<Texture2D>(@"Textures\Startscreen");
            base.LoadContent();

           
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

           
        }

        public override void UnloadContent()
        {
            content.Unload();

            base.UnloadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.SpriteBatch.Begin();

            ScreenManager.SpriteBatch.Draw(m_background, new Rectangle(0, 0, ScreenManager.Game.GraphicsDevice.Viewport.Width, ScreenManager.Game.GraphicsDevice.Viewport.Height), Color.White);


            ScreenManager.SpriteBatch.DrawString(Game1.m_pirateFontText
                , "Sail the ocean with WSAD!"
                , new Vector2((ScreenManager.Game.GraphicsDevice.Viewport.Width * 0.5f) - (Game1.m_pirateFontText.MeasureString("Sail the ocean with WSAD!") * 0.5f).X
                                    , back.Position.Y + 30)
                                    , Color.Black);

            ScreenManager.SpriteBatch.DrawString(Game1.m_pirateFontText
                , "Fire the cannons with Left and Right!"
                , new Vector2((ScreenManager.Game.GraphicsDevice.Viewport.Width * 0.5f) - (Game1.m_pirateFontText.MeasureString("Fire the cannons with Left and Right!") * 0.5f).X
                                    , back.Position.Y + 60)
                                    , Color.Black);

            ScreenManager.SpriteBatch.DrawString(Game1.m_pirateFontText
                , "Plunder the shipwrecks"
                , new Vector2((ScreenManager.Game.GraphicsDevice.Viewport.Width * 0.5f) - (Game1.m_pirateFontText.MeasureString("Plunder the shipwrecks") * 0.5f).X
                                    , back.Position.Y + 90)
                                    , Color.Black);

            ScreenManager.SpriteBatch.DrawString(Game1.m_pirateFontText
                , "and sell the loot at the trade outposts!"
                , new Vector2((ScreenManager.Game.GraphicsDevice.Viewport.Width * 0.5f) - (Game1.m_pirateFontText.MeasureString("and sell the loot at the trade outposts!") * 0.5f).X
                                    , back.Position.Y + 120)
                                    , Color.Black);


            
                    
                    


            ScreenManager.SpriteBatch.End();


            base.Draw(gameTime);
        }


        #endregion
    }
}
