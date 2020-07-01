#define HD


using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using ActorPack;
using ActorPack.Help;

using System.IO;
using System.Xml;
using System.Xml.Serialization;



namespace Praedonum
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public const float MUSIC_MAINMENU = 0.5f;
        public const float MUSIC_BATTLE = 2.5f;
        public const float MUSIC_INGAME1 = 1.5f;
        public const float MUSIC_INGAME2 = 3.5f;
        public const float MUSIC_HARBOR = 4.5f;
        public const float MUSIC_GAMEOVER = 5.5f;

        public const float AMBIENCE_MAINMENU = 100.0f;
        public const float AMBIENCE_SEA = 15.0f;
        public const float AMBIENCE_HARBOR = 35.0f;

        private static Random m_rand;
        private static AudioManager m_audio;

        public static AudioManager Audio
        {
            get { return Game1.m_audio; }
        }

        public static Random Rand
        {
            get { return Game1.m_rand; }
        }


        private GraphicsDeviceManager m_graphics;
        private static SpriteBatch m_spriteBatch;

        public static SpriteFont m_debugFont;
        public static SpriteFont m_pirateFont;
        public static SpriteFont m_pirateFontText;




        private ScreenManager m_screenManager;
        

        

        

        

        

        
  
        public Game1()
        {
            m_graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


            PraedonumOptions options = new PraedonumOptions();
            XmlSerializer xs = new XmlSerializer(typeof(PraedonumOptions));
            FileStream fs;


            if (!File.Exists("options.xml"))
            {
                options.ScreenWidth = 1024;
                options.ScreenHeight = 768;
                options.Windowed = true;
                fs = File.Open("options.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                xs.Serialize(fs, options);
                fs.Close();
            }
            else
            {
                fs = File.Open("options.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                options = (PraedonumOptions)xs.Deserialize(fs);
                fs.Close();
            }





            m_rand = new Random();

#if (HD)
            Graphics.PreferredBackBufferWidth = (int)options.ScreenWidth;
            Graphics.PreferredBackBufferHeight = (int)options.ScreenHeight;
            Graphics.IsFullScreen = !options.Windowed;
#else
            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 720;
            Graphics.IsFullScreen = false;
#endif

            
            IsMouseVisible = true;

            m_audio = new AudioManager(this);
            m_audio.Initialize();


            
            m_audio.PlaySound("music");
            m_audio.SetParameter("music", "Interactive_Sounds", MUSIC_MAINMENU);
            // 0-25 menu
            // 25-50 battle

            m_audio.PlaySound("ambience");
            m_audio.SetParameter("ambience", "Interactive_Ambience", AMBIENCE_MAINMENU);
            // 100 = menu, silent
            // 0-25 = ingame
            // 25-50 = harbor

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            

            m_debugFont = Content.Load<SpriteFont>("DebugFont");
            m_pirateFont = Content.Load<SpriteFont>("PirateFont");
            m_pirateFontText = Content.Load<SpriteFont>("PirateFontText");


            m_screenManager = new ScreenManager(this);
            
            m_screenManager.Initialize();
            m_screenManager.AddScreen(new BackgroundScreen(), null);
            m_screenManager.AddScreen(new MainMenuScreen(), null);

            
            /*
            Animation anim;
            AnimationSet set;

            anim = new Animation(this);
            anim.Initialize(ref m_debugSprites);

            set = new AnimationSet("idle", true, 16.0f, 0);
            set.AddFrame(new Rectangle(0, 0, 64, 32));
            anim.AddSet(set);
            anim.SetActiveSet("idle", 0);
            anim.Origin = new Vector2(32, 16);
             * 
            */


            


            



            /*
            m_cam = new Camera(this, null);
            m_cam.Initialize();
            m_cam.Position3 = new Vector3(0, 0, 50);
            */

            
            


            

            /*
            m_view = Matrix.CreateLookAt(new Vector3(0, 0, 10), Vector3.Zero, Vector3.Up);
            m_projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4
                , GraphicsDevice.Viewport.AspectRatio, 1.0f, 1000.0f);
            */

            

            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            m_spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Input.Update(gameTime);
            Audio.Update(gameTime);
            

            //if (Input.kp(Keys.Escape))
                //this.Exit();

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            m_screenManager.Update(gameTime);

            

            /*
            float xMod = 0;
            float yMod = 0;
            xMod = Input.mPos.X - Input.MOldState.X;
            yMod = Input.mPos.Y - Input.MOldState.Y;

            m_cam.Rotation3 += Vector3.UnitY * xMod * 0.001f;
            m_cam.Rotation3 += Vector3.UnitX * yMod * 0.001f;
            */

            // m_cam.Rotation3 += Vector3.UnitX * 0.01f * (float)gameTime.ElapsedGameTime.TotalSeconds;

            

          

            base.Update(gameTime);
        }

        

        

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            
            GraphicsDevice.Clear(Color.Black);

            m_screenManager.Draw(gameTime);

            

            

            

            

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        



        #region Properties

        public GraphicsDeviceManager Graphics
        {
            get { return m_graphics; }
            set { m_graphics = value; }
        }

        public static SpriteBatch SpriteBatch
        {
            get { return m_spriteBatch; }
            set { m_spriteBatch = value; }
        }

        #endregion
    }
}
