#region File Description
//-----------------------------------------------------------------------------
// MainMenuScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
#endregion

namespace Praedonum
{
    /// <summary>
    /// The main menu screen is the first thing displayed when the game starts up.
    /// </summary>
    class GameoverScreen : MenuScreen
    {

        ContentManager content;
        private Texture2D m_background;


        #region Initialization


        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public GameoverScreen()
            : base("")
        {
            // Create our menu entries.
            MenuEntry playGameMenuEntry = new MenuEntry("Restart");
            MenuEntry exitMenuEntry = new MenuEntry("Return to main menu");

            // Hook up menu event handlers.
            playGameMenuEntry.Selected += PlayGameMenuEntrySelected;
            exitMenuEntry.Selected += OnCancel;

            // Add entries to the menu.
            MenuEntries.Add(playGameMenuEntry);
            MenuEntries.Add(exitMenuEntry);
        }


        #endregion

        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            m_background = content.Load<Texture2D>(@"Textures\Startscreen");

            Game1.Audio.SetParameter("music", "Interactive_Sounds", Game1.MUSIC_GAMEOVER);
            Game1.Audio.SetParameter("ambience", "Interactive_Ambience", Game1.AMBIENCE_MAINMENU);


            base.LoadContent();
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

            ScreenManager.SpriteBatch.End();

            base.Draw(gameTime);
        }

        #region Handle Input


        /// <summary>
        /// Event handler for when the Play Game menu entry is selected.
        /// </summary>
        void PlayGameMenuEntrySelected(object sender, PlayerIndexEventArgs e)
        {
            LoadingScreen.Load(ScreenManager, true, e.PlayerIndex,
                               new GameplayScreen());
        }


        


        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected override void OnCancel(PlayerIndex playerIndex)
        {
            LoadingScreen.Load(ScreenManager, false, null, new BackgroundScreen(),
                                                           new MainMenuScreen());
        }


       


        #endregion
    }
}
