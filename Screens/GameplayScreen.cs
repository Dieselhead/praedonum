#region File Description
//-----------------------------------------------------------------------------
// GameplayScreen.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ActorPack;
using ActorPack.Help;
#endregion

namespace Praedonum
{
    /// <summary>
    /// This screen implements the actual game logic. It is just a
    /// placeholder to get the idea across: you'll probably want to
    /// put some more interesting gameplay in here!
    /// </summary>
    public class GameplayScreen : GameScreen
    {
        #region Fields

        ContentManager content;
        SpriteFont gameFont;

        

        float pauseAlpha;

        public struct ShopPositions
        {
            public Vector2 Position;
            public ShopID Id;
        };


        public enum ShopID
        {
            None
            , Pirate
            , British
            , Chinese
            , Spanish
            , Persian
        }

        public static ShopPositions[] m_shopPositions;


        public static Texture2D m_debugSprites;
        private Texture2D m_skyTexture;
        private Texture2D m_waterNormal;
        private Texture2D m_cloudTexture;

        public static Texture2D m_tShipSpanish;
        public static Texture2D m_tShipChinese;
        public static Texture2D m_tShipBritish;
        public static Texture2D m_tShipPersian;
        public static Texture2D m_tShipPirate;

        public static Texture2D m_tShadow;
        public static Texture2D m_tHPBarBG;
        public static Texture2D m_tHPBar;
        public static Texture2D m_tWatersplash;
        public static Texture2D m_tBarsBG;
        public static Texture2D[] m_tBars;
        public static Texture2D m_tGoldFocus;

        public static Texture2D m_tExplosion;
        public static Texture2D m_tExplosion2;
        public static Texture2D m_tExplosion3;
        public static Texture2D m_tSmoke;
        public static int m_explosionIndex = 0;
        private Texture2D m_tMoney;

        private Texture2D[] m_tIsland1;

        private Texture2D[] m_tIsland8;
        private Texture2D[] m_tIsland15;
        private Texture2D[] m_tIsland19;
        private Texture2D[] m_tIsland44;
        private Texture2D[] m_tIsland48;
        private Texture2D[] m_tIsland61;
        private Texture2D[] m_tIsland62;
        
        private Texture2D[] m_tIsland72;
        private Texture2D[] m_tIsland83;
        private Texture2D[] m_tIsland86;

        public static Texture2D m_tPirateShop;
        public static Texture2D m_tBritishShop;
        public static Texture2D m_tChineseShop;
        public static Texture2D m_tPersianShop;
        public static Texture2D m_tSpanishShop;

        private Texture2D m_tMoneyBag;
        private Texture2D m_tJollyRoger;

        private static Texture2D m_tWreckage;

        public static Texture2D tWreckage
        {
            get { return GameplayScreen.m_tWreckage; }
            set { GameplayScreen.m_tWreckage = value; }
        }

        private RenderTarget2D m_rtWater;

        private PDVehicle m_player;

        public PDVehicle Player
        {
            get { return m_player; }
        }
        private PlayerController m_pc;

        private Camera m_cam;

        private VertexPositionTexture[] m_waterVerts;
        private VertexBuffer m_vertexBuffer;
        private BasicEffect m_effect;
        private float m_waterSize = 2000;
        private const float m_waterSizeX = 12288;
        private const float m_waterSizeY = 9216;

        private Effect m_waterEffect;
        private Effect m_bloomEffect;

        private Matrix m_view;
        private Matrix m_projection;

        private RenderTarget2D m_renderTarget;

        private RenderTarget2D m_miniMap;
        private const int m_miniMapWidth = 320;
        private const int m_miniMapHeight = 240;
        private float m_mmRatioX = m_miniMapWidth / (m_waterSizeX * 2);
        private float m_mmRatioY = m_miniMapHeight / (m_waterSizeY * 2);

        private Texture2D m_tWhitePixel;

        private BloomComponent m_bloom;
        int bloomSettingsIndex = 5;


        public List<Island> m_islands;

        public static Vector2[] m_waypoints;



        public Texture2D tShadow
        {
            get { return m_tShadow; }
            set { m_tShadow = value; }
        }



        public void GetDebugSprite(ref Texture2D tex_)
        {
            tex_ = m_debugSprites;
        }






        #endregion

        #region Initialization


        /// <summary>
        /// Constructor.
        /// </summary>
        public GameplayScreen()
        {
            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
        }


        /// <summary>
        /// Load graphics content for the game.
        /// </summary>
        public override void LoadContent()
        {
            if (content == null)
                content = new ContentManager(ScreenManager.Game.Services, "Content");

            gameFont = content.Load<SpriteFont>("DebugFont");

            m_tPirateShop = content.Load<Texture2D>(@"Textures\Shops\upgradescreen2");
            m_tBritishShop = content.Load<Texture2D>(@"Textures\Shops\British_port");
            m_tChineseShop = content.Load<Texture2D>(@"Textures\Shops\Chinese_trade");
            m_tPersianShop = content.Load<Texture2D>(@"Textures\Shops\Persian_trade");
            m_tSpanishShop = content.Load<Texture2D>(@"Textures\Shops\Spanish_port");


            m_debugSprites = content.Load<Texture2D>(@"Textures\DebugSprites");
            m_skyTexture = content.Load<Texture2D>(@"Textures\SkyTexture");
            m_waterNormal = content.Load<Texture2D>(@"Textures\WaterNormal");
            m_cloudTexture = content.Load<Texture2D>(@"Textures\CloudTexture");
            m_tShipSpanish = content.Load<Texture2D>(@"Textures\S-SPskepp_SS");
            m_tShipChinese = content.Load<Texture2D>(@"Textures\kinesk_skeppSS");
            m_tShipBritish = content.Load<Texture2D>(@"Textures\Britiskt_Spritesheat");
            m_tShipPersian = content.Load<Texture2D>(@"Textures\Persian");
            m_tShipPirate = content.Load<Texture2D>(@"Textures\PIRATE_SPRITE_SHEET_OMG");

            m_tShadow = content.Load<Texture2D>(@"Textures\shadow");

            m_tMoneyBag = content.Load<Texture2D>(@"pengapung");
            m_tJollyRoger = content.Load<Texture2D>(@"JollyRogerIcon");

            m_tExplosion = content.Load<Texture2D>(@"Textures\explosion");
            m_tExplosion2 = content.Load<Texture2D>(@"Textures\AE_exp_Sprite");
            m_tExplosion3 = content.Load<Texture2D>(@"Textures\Explosion_Spritesheet");
            m_tSmoke = content.Load<Texture2D>(@"Textures\smoke");

            m_tHPBar = content.Load<Texture2D>(@"Textures\Fiende_HPbar");
            m_tHPBarBG = content.Load<Texture2D>(@"Textures\Fiende_HPbakgrund");

            m_tWreckage = content.Load<Texture2D>(@"Textures\Wreckage\Vrakdelar_SS");

            m_tWatersplash = content.Load<Texture2D>(@"watersplash");

            m_tMoney = content.Load<Texture2D>(@"Cashmoney");
            m_tGoldFocus = content.Load<Texture2D>(@"Textures\Shops\Upgradescreen_knapptryck");
            m_tBarsBG = content.Load<Texture2D>(@"Textures\Shops\bars");
            m_tBars = new Texture2D[10];
            m_tBars[0] = content.Load<Texture2D>(@"Textures\Shops\Upgradescren_bar1");
            m_tBars[1] = content.Load<Texture2D>(@"Textures\Shops\Upgradescren_bar2");
            m_tBars[2] = content.Load<Texture2D>(@"Textures\Shops\Upgradescren_bar3");
            m_tBars[3] = content.Load<Texture2D>(@"Textures\Shops\Upgradescren_bar4");
            m_tBars[4] = content.Load<Texture2D>(@"Textures\Shops\Upgradescren_bar5");
            m_tBars[5] = content.Load<Texture2D>(@"Textures\Shops\Upgradescren_bar6");
            m_tBars[6] = content.Load<Texture2D>(@"Textures\Shops\Upgradescren_bar7");
            m_tBars[7] = content.Load<Texture2D>(@"Textures\Shops\Upgradescren_bar8");
            m_tBars[8] = content.Load<Texture2D>(@"Textures\Shops\Upgradescren_bar9");
            m_tBars[9] = content.Load<Texture2D>(@"Textures\Shops\Upgradescren_bar10");
            

            m_tIsland1 = new Texture2D[1];
            m_tIsland1[0] = content.Load<Texture2D>(@"Textures\Islands\Island1");

            m_tIsland15 = new Texture2D[1];
            m_tIsland15[0] = content.Load<Texture2D>(@"Textures\Islands\Island15");

            m_tIsland19 = new Texture2D[25];
            m_tIsland19[0] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile1");
            m_tIsland19[1] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile2");
            m_tIsland19[2] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile3");
            m_tIsland19[3] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile4");
            m_tIsland19[4] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile5");
            m_tIsland19[5] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile6");
            m_tIsland19[6] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile2_1");
            m_tIsland19[7] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile2_2");
            m_tIsland19[8] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile2_3");
            m_tIsland19[9] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile2_4");
            m_tIsland19[10] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile2_5");
            m_tIsland19[11] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile2_6");
            m_tIsland19[12] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile3_1");
            m_tIsland19[13] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile3_2");
            m_tIsland19[14] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile3_3");
            m_tIsland19[15] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile3_4");
            m_tIsland19[16] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile3_5");
            m_tIsland19[17] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile3_6");
            m_tIsland19[18] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile3_7");
            m_tIsland19[19] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile3_8");
            m_tIsland19[20] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile4_1");
            m_tIsland19[21] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile4_2");
            m_tIsland19[22] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile4_3");
            m_tIsland19[23] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile4_4");
            m_tIsland19[24] = content.Load<Texture2D>(@"Textures\Islands\Island19_tile4_5");

            m_tIsland8 = new Texture2D[6];
            m_tIsland8[0] = content.Load<Texture2D>(@"Textures\Islands\Island8_tile1");
            m_tIsland8[1] = content.Load<Texture2D>(@"Textures\Islands\Island8_tile2");
            m_tIsland8[2] = content.Load<Texture2D>(@"Textures\Islands\Island8_tile3");
            m_tIsland8[3] = content.Load<Texture2D>(@"Textures\Islands\Island8_tile4");
            m_tIsland8[4] = content.Load<Texture2D>(@"Textures\Islands\Island8_tile5");
            m_tIsland8[5] = content.Load<Texture2D>(@"Textures\Islands\Island8_tile6");

            m_tIsland61 = new Texture2D[1];
            m_tIsland61[0] = content.Load<Texture2D>(@"Textures\Islands\Island61.1");

            m_tIsland48 = new Texture2D[1];
            m_tIsland48[0] = content.Load<Texture2D>(@"Textures\Islands\Island48_utrenderad");

            m_tIsland72 = new Texture2D[1];
            m_tIsland72[0] = content.Load<Texture2D>(@"Textures\Islands\VulkanTransparensTEST");

            m_tIsland62 = new Texture2D[24];
            m_tIsland62[0] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile1_1");
            m_tIsland62[1] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile1_2");
            m_tIsland62[2] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile1_3");
            m_tIsland62[3] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile1_4");
            m_tIsland62[4] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile1_5");
            m_tIsland62[5] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile1_6");
            m_tIsland62[6] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile1_7");
            m_tIsland62[7] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile2_1");
            m_tIsland62[8] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile2_2");
            m_tIsland62[9] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile2_3");
            m_tIsland62[10] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile2_4");
            m_tIsland62[11] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile3_1");
            m_tIsland62[12] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile3_2");
            m_tIsland62[13] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile3_3");
            m_tIsland62[14] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile3_4");
            m_tIsland62[15] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile3_5");
            m_tIsland62[16] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile4_1");
            m_tIsland62[17] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile4_2");
            m_tIsland62[18] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile4_3");
            m_tIsland62[19] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile4_4");
            m_tIsland62[20] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile5_1");
            m_tIsland62[21] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile5_2");
            m_tIsland62[22] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile5_3");
            m_tIsland62[23] = content.Load<Texture2D>(@"Textures\Islands\Island62_tile5_4");

            m_tIsland44 = new Texture2D[1];
            m_tIsland44[0] = content.Load<Texture2D>(@"Textures\Islands\Island44.1");

            m_tIsland83 = new Texture2D[1];
            m_tIsland83[0] = content.Load<Texture2D>(@"Textures\Islands\Island83");

            m_tIsland86 = new Texture2D[1];
            m_tIsland86[0] = content.Load<Texture2D>(@"Textures\Islands\Island86.1");

            m_islands = new List<Island>();

            m_rtWater = new RenderTarget2D((ScreenManager.Game).GraphicsDevice, (ScreenManager.Game).GraphicsDevice.Viewport.Width, (ScreenManager.Game).GraphicsDevice.Viewport.Height, false, SurfaceFormat.Color, DepthFormat.Depth24);

            m_bloomEffect = content.Load<Effect>("Bloom");


            m_miniMap = new RenderTarget2D((ScreenManager.Game).GraphicsDevice, m_miniMapWidth, m_miniMapHeight, false, SurfaceFormat.Color, DepthFormat.Depth24); // new RenderTarget2D(GraphicsDevice, m_miniMapWidth, m_miniMapHeight);

       

            Color[] c = new Color[1];
            c[0] = new Color(1.0f, 1.0f, 1.0f);

            m_tWhitePixel = new Texture2D((ScreenManager.Game).GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            m_tWhitePixel.SetData(c);



            m_waypoints = new Vector2[12];
            m_waypoints[0] = new Vector2(-1150, 400);
            m_waypoints[1] = new Vector2(-5500, -5500);

            m_waypoints[2] = new Vector2(-3600, -800);
            m_waypoints[3] = new Vector2(750, -2300);

            m_waypoints[4] = new Vector2(1300, 1500);
            m_waypoints[5] = new Vector2(2600, 3900);

            m_waypoints[6] = new Vector2(6500, 3200);
            m_waypoints[7] = new Vector2(8900, 0);

            m_waypoints[8] = new Vector2(-2000, 2800);
            m_waypoints[9] = new Vector2(-6300, 3200);

            m_waypoints[10] = new Vector2(-8500, 200);
            m_waypoints[11] = new Vector2(-7700, -4200);


            // -1700, -4400 Big tropical island west    // Pirate
            // 9900, -6800 East big island             // British
            // 7300, -7600	North big island            // Spanish
            // 6800, -1600 south big island             // Chinese
            // -8100, 7300 island in sw corner          // Persian
            m_shopPositions = new ShopPositions[5];
            m_shopPositions[0] = new ShopPositions();
            m_shopPositions[0].Position = new Vector2(-1700, -4400);
            m_shopPositions[0].Id = ShopID.Pirate;

            m_shopPositions[1] = new ShopPositions();
            m_shopPositions[1].Position = new Vector2(7300, -7600);
            m_shopPositions[1].Id = ShopID.Spanish;

            m_shopPositions[2] = new ShopPositions();
            m_shopPositions[2].Position = new Vector2(9900, -6800);
            m_shopPositions[2].Id = ShopID.British;

            m_shopPositions[3] = new ShopPositions();
            m_shopPositions[3].Position = new Vector2(6800, -1600);
            m_shopPositions[3].Id = ShopID.Chinese;

            m_shopPositions[4] = new ShopPositions();
            m_shopPositions[4].Position = new Vector2(-8100, 7300);
            m_shopPositions[4].Id = ShopID.Persian;




            // Create Player
            m_pc = new PDPlayerController(ScreenManager.Game, null);
            m_pc.Initialize();
            m_pc.PlayerCamera.Position3 = new Vector3(0, 0, 50);


            m_player = new PDVPirate(ScreenManager.Game, this);
            m_player.Initialize();
            m_player.SetDefaultGraphics(ref m_tShipPirate);
            m_player.Position = m_shopPositions[0].Position;

            m_player.Possess(m_pc);
            m_player.Origin = new Vector2(80, 48);
            m_player.MaxSpeed = 200;
            m_player.MaxForce = 10;
            m_player.ThrottleMax = 60;
            m_player.RotationRate = 0.5f;
            m_player.ThrottleDecrease = 100;


            // Add some enemies
            PDVehicle pdvc = new PDVPersian(ScreenManager.Game, this);
            pdvc.Initialize();
            pdvc.SetDefaultGraphics(ref m_tShipPersian);
            pdvc.Origin = new Vector2(48, 80);
            pdvc.ThrottleMax = 40;
            pdvc.ThrottleDecrease = 100;
            pdvc.bTurnInPlace = true;
            pdvc.Position = m_waypoints[5];

            pdvc = new PDVBritish(ScreenManager.Game, this);
            pdvc.Initialize();
            pdvc.SetDefaultGraphics(ref m_tShipBritish);
            pdvc.Origin = new Vector2(80, 48);
            pdvc.ThrottleMax = 40;
            pdvc.ThrottleDecrease = 100;
            pdvc.bTurnInPlace = true;

            pdvc.Position = m_waypoints[7];

            pdvc = new PDVChinese(ScreenManager.Game, this);
            pdvc.Initialize();
            pdvc.SetDefaultGraphics(ref m_tShipChinese);
            pdvc.Origin = new Vector2(80, 48);
            pdvc.ThrottleMax = 40;
            pdvc.ThrottleDecrease = 100;
            pdvc.bTurnInPlace = true;

            pdvc.Position = m_waypoints[10];

            pdvc = new PDVSpanish(ScreenManager.Game, this);
            pdvc.Initialize();
            pdvc.SetDefaultGraphics(ref m_tShipSpanish);
            pdvc.Origin = new Vector2(80, 48);
            pdvc.ThrottleMax = 40;
            pdvc.ThrottleDecrease = 100;
            pdvc.bTurnInPlace = true;
            pdvc.Position = m_shopPositions[0].Position + new Vector2(2500, 0);


            // Set UV positions over 1 to wrap
            m_waterVerts = new VertexPositionTexture[4];
            m_waterVerts[0] = new VertexPositionTexture(new Vector3(-1 * m_waterSizeX, 1 * m_waterSizeY, -10), new Vector2(0, 32) * 1);
            m_waterVerts[1] = new VertexPositionTexture(new Vector3(1 * m_waterSizeX, 1 * m_waterSizeY, -10), new Vector2(40, 32) * 1);
            m_waterVerts[2] = new VertexPositionTexture(new Vector3(-1 * m_waterSizeX, -1 * m_waterSizeY, -10), new Vector2(0, 0) * 1);
            m_waterVerts[3] = new VertexPositionTexture(new Vector3(1 * m_waterSizeX, -1 * m_waterSizeY, -10), new Vector2(40, 0) * 1);

            m_vertexBuffer = new VertexBuffer(ScreenManager.Game.GraphicsDevice, typeof(VertexPositionTexture), m_waterVerts.Length, BufferUsage.None);
            m_vertexBuffer.SetData(m_waterVerts);

            m_effect = new BasicEffect(ScreenManager.Game.GraphicsDevice);

            m_waterEffect = content.Load<Effect>("Water");

            m_waterEffect.Parameters["xSkyTexture"].SetValue(m_skyTexture);
            m_waterEffect.Parameters["xWaterNormalMap"].SetValue(m_waterNormal);
            m_waterEffect.Parameters["xCloudTexture"].SetValue(m_cloudTexture);
            m_waterEffect.Parameters["xLightDirection"].SetValue(new Vector3(0, 0, 0));
            m_waterEffect.Parameters["World"].SetValue(Matrix.Identity);


            m_renderTarget = new RenderTarget2D(ScreenManager.Game.GraphicsDevice, ScreenManager.Game.GraphicsDevice.Viewport.Width, ScreenManager.Game.GraphicsDevice.Viewport.Height, false, ScreenManager.Game.GraphicsDevice.DisplayMode.Format, DepthFormat.Depth24);

            m_bloom = new BloomComponent(ScreenManager.Game);
            m_bloom.Initialize();
            m_bloom.Settings = BloomSettings.PresetSettings[bloomSettingsIndex];


            CreateIslands();

            // Change to MUSIC_IDLE
            Game1.Audio.SetParameter("music", "Interactive_Sounds", Game1.MUSIC_INGAME1);
            Game1.Audio.SetParameter("ambience", "Interactive_Ambience", Game1.AMBIENCE_SEA);



            

            // A real game would probably have more content than this sample, so
            // it would take longer to load. We simulate that by delaying for a
            // while, giving you a chance to admire the beautiful loading screen.
            // Thread.Sleep(1000);

            // once the load has finished, we use ResetElapsedTime to tell the game's
            // timing mechanism that we have just finished a very long frame, and that
            // it should not try to catch up.
            ScreenManager.Game.ResetElapsedTime();
        }

        public void CreateIslands()
        {
            Sprite[] sprites;
            Island island;
            OBB[] hb;

            // Island1
            sprites = new Sprite[1];
            sprites[0] = new Sprite(ScreenManager.Game);
            sprites[0].Initialize(ref m_tIsland1[0]);

            hb = new OBB[9];
            hb[0] = new OBB(0, new Vector2(262, 738), new Vector2(452, 574) * 0.5f);
            hb[1] = new OBB(0, new Vector2(1030, 758), new Vector2(132, 76) * 0.5f);
            hb[2] = new OBB(0, new Vector2(435, 484), new Vector2(566, 216) * 0.5f);
            hb[3] = new OBB(0, new Vector2(389, 1041), new Vector2(566, 182) * 0.5f);
            hb[4] = new OBB(0, new Vector2(672, 1153), new Vector2(640, 146) * 0.5f);
            hb[5] = new OBB(0, new Vector2(964, 1059), new Vector2(640, 146) * 0.5f);
            hb[6] = new OBB(0, new Vector2(776, 341), new Vector2(640, 146) * 0.5f);
            hb[7] = new OBB(0, new Vector2(992, 451), new Vector2(640, 146) * 0.5f);
            hb[8] = new OBB(0, new Vector2(1688, 762), new Vector2(640, 212) * 0.5f);


            island = new Island(ScreenManager.Game);
            island.Position = new Vector2(580 - m_waterSizeX, 8048 - m_waterSizeY);
            island.Initialize(sprites);
            m_islands.Add(island);


            // Island8
            sprites = new Sprite[6];
            sprites[0] = new Sprite(ScreenManager.Game);
            sprites[0].Initialize(ref m_tIsland8[0]);
            sprites[0].Position = new Vector2(1024, 0);

            sprites[1] = new Sprite(ScreenManager.Game);
            sprites[1].Initialize(ref m_tIsland8[1]);
            sprites[1].Position = new Vector2(2048, 0);

            sprites[2] = new Sprite(ScreenManager.Game);
            sprites[2].Initialize(ref m_tIsland8[2]);
            sprites[2].Position = new Vector2(3072, 0);

            sprites[3] = new Sprite(ScreenManager.Game);
            sprites[3].Initialize(ref m_tIsland8[3]);
            sprites[3].Position = new Vector2(0, 3072);

            sprites[4] = new Sprite(ScreenManager.Game);
            sprites[4].Initialize(ref m_tIsland8[4]);
            sprites[4].Position = new Vector2(1024, 3072);

            sprites[5] = new Sprite(ScreenManager.Game);
            sprites[5].Initialize(ref m_tIsland8[5]);
            sprites[5].Position = new Vector2(2048, 3072);


            // TODODODODOOD
            /*
            hb = new OBB[10];
            hb[0] = new OBB(0, new Vector2(850, 520), new Vector2(500, 180) * 0.5f);
            hb[1] = new OBB(0, new Vector2(2340, 520), new Vector2(2600, 390) * 0.5f);
            hb[2] = new OBB(0, new Vector2(3380, 550), new Vector2(260, 590) * 0.5f);
            hb[3] = new OBB(0, new Vector2(3590, 550), new Vector2(260, 770) * 0.5f);
            hb[4] = new OBB(0, new Vector2(3900, 510), new Vector2(600, 1011) * 0.5f);
            hb[5] = new OBB(0, new Vector2(4380, 480), new Vector2(1180, 1160) * 0.5f);
            hb[6] = new OBB(0, new Vector2(4970, 240), new Vector2(480, 360) * 0.5f);
            hb[7] = new OBB(0, new Vector2(5020, 770), new Vector2(480, 360) * 0.5f);
            hb[8] = new OBB(0, new Vector2(5870, 470), new Vector2(2600, 500) * 0.5f);
            hb[9] = new OBB(0, new Vector2(7310, 470), new Vector2(780, 180) * 0.5f);
            */

            hb = new OBB[42];
            hb[0] = new OBB(0, new Vector2(1656, 3480), new Vector2(276, 1162) * 0.5f);
            hb[1] = new OBB(0, new Vector2(1139, 4611), new Vector2(119, 154) * 0.5f);
            hb[2] = new OBB(0, new Vector2(588, 5852), new Vector2(169, 208) * 0.5f);
            hb[3] = new OBB(0, new Vector2(695, 5663), new Vector2(229, 208) * 0.5f);
            hb[4] = new OBB(0, new Vector2(798, 5473), new Vector2(297, 208) * 0.5f);
            hb[5] = new OBB(0, new Vector2(864, 5300), new Vector2(338, 208) * 0.5f);
            hb[6] = new OBB(0, new Vector2(976, 5123), new Vector2(338, 208) * 0.5f);
            hb[7] = new OBB(0, new Vector2(1050, 4947), new Vector2(338, 208) * 0.5f);
            hb[8] = new OBB(0, new Vector2(1170, 4765), new Vector2(352, 201) * 0.5f);
            hb[9] = new OBB(0, new Vector2(1272, 4545), new Vector2(193, 335) * 0.5f);
            hb[10] = new OBB(0, new Vector2(1346, 4399), new Vector2(193, 335) * 0.5f);
            hb[11] = new OBB(0, new Vector2(1431, 4280), new Vector2(193, 335) * 0.5f);
            hb[12] = new OBB(0, new Vector2(1528, 4061), new Vector2(225, 455) * 0.5f);
            hb[13] = new OBB(0, new Vector2(2130, 3670), new Vector2(225, 197) * 0.5f);
            hb[14] = new OBB(0, new Vector2(2223, 3556), new Vector2(350, 197) * 0.5f);
            hb[15] = new OBB(0, new Vector2(1967, 3702), new Vector2(187, 261) * 0.5f);
            hb[16] = new OBB(0, new Vector2(1841, 3821), new Vector2(180, 261) * 0.5f);
            hb[17] = new OBB(0, new Vector2(2358, 3375), new Vector2(276, 261) * 0.5f);
            hb[18] = new OBB(0, new Vector2(2480, 3175), new Vector2(276, 261) * 0.5f);
            hb[19] = new OBB(0, new Vector2(2581, 2960), new Vector2(276, 261) * 0.5f);
            hb[20] = new OBB(0, new Vector2(1751, 2798), new Vector2(276, 261) * 0.5f);
            hb[21] = new OBB(0, new Vector2(1889, 2596), new Vector2(276, 204) * 0.5f);
            hb[22] = new OBB(0, new Vector2(2665, 2786), new Vector2(276, 204) * 0.5f);
            hb[23] = new OBB(0, new Vector2(1992, 2424), new Vector2(276, 204) * 0.5f);
            hb[24] = new OBB(0, new Vector2(2105, 2257), new Vector2(276, 204) * 0.5f);
            hb[25] = new OBB(0, new Vector2(2733, 2392), new Vector2(245, 612) * 0.5f);
            hb[26] = new OBB(0, new Vector2(2278, 2117), new Vector2(360, 279) * 0.5f);
            hb[27] = new OBB(0, new Vector2(2641, 1977), new Vector2(415, 233) * 0.5f);
            hb[28] = new OBB(0, new Vector2(2733, 1800), new Vector2(377, 233) * 0.5f);
            hb[29] = new OBB(0, new Vector2(2816, 1576), new Vector2(468, 233) * 0.5f);
            hb[30] = new OBB(0, new Vector2(2941, 1415), new Vector2(451, 233) * 0.5f);
            hb[31] = new OBB(0, new Vector2(3010, 1204), new Vector2(439, 233) * 0.5f);
            hb[32] = new OBB(0, new Vector2(3110, 803), new Vector2(176, 233) * 0.5f);
            hb[33] = new OBB(0, new Vector2(3100, 990), new Vector2(404, 233) * 0.5f);
            hb[34] = new OBB(0, new Vector2(3280, 749), new Vector2(251, 372) * 0.5f);
            hb[35] = new OBB(0, new Vector2(3387, 622), new Vector2(275, 363) * 0.5f);
            hb[36] = new OBB(0, new Vector2(3481, 362), new Vector2(212, 257) * 0.5f);
            hb[37] = new OBB(0, new Vector2(3567, 225), new Vector2(109, 147) * 0.5f);
            hb[38] = new OBB(0, new Vector2(3622, 131), new Vector2(109, 147) * 0.5f);
            hb[39] = new OBB(0, new Vector2(3667, 38), new Vector2(109, 147) * 0.5f);
            hb[40] = new OBB(0, new Vector2(2855, 2213), new Vector2(118, 103) * 0.5f);
            hb[41] = new OBB(0, new Vector2(2953, 2191), new Vector2(118, 103) * 0.5f);



            island = new Island(ScreenManager.Game);
            island.Position = new Vector2(7231 - m_waterSizeX, 2693 - m_waterSizeY);
            island.Initialize(sprites, hb);
            m_islands.Add(island);

            
            // Island15
            sprites = new Sprite[1];
            sprites[0] = new Sprite(ScreenManager.Game);
            sprites[0].Initialize(ref m_tIsland15[0]);


            hb = new OBB[12];
            hb[0] = new OBB(0, new Vector2(3742, 257), new Vector2(322, 133) * 0.5f);
            hb[1] = new OBB(0, new Vector2(3474, 248), new Vector2(254, 179) * 0.5f);
            hb[2] = new OBB(0, new Vector2(3267, 247), new Vector2(208, 256) * 0.5f);
            hb[3] = new OBB(0, new Vector2(3059, 264), new Vector2(208, 327) * 0.5f);
            hb[4] = new OBB(0, new Vector2(2776, 265), new Vector2(418, 379) * 0.5f);
            hb[5] = new OBB(0, new Vector2(2528, 241), new Vector2(418, 333) * 0.5f);
            hb[6] = new OBB(0, new Vector2(2152, 219), new Vector2(418, 289) * 0.5f);
            hb[7] = new OBB(0, new Vector2(1733, 230), new Vector2(418, 289) * 0.5f);
            hb[8] = new OBB(0, new Vector2(1344, 263), new Vector2(418, 289) * 0.5f);
            hb[9] = new OBB(0, new Vector2(200, 275), new Vector2(270, 89) * 0.5f);
            hb[10] = new OBB(0, new Vector2(502, 257), new Vector2(469, 217) * 0.5f);
            hb[11] = new OBB(0, new Vector2(924, 254), new Vector2(469, 307) * 0.5f);


            island = new Island(ScreenManager.Game);
            //island.Origin = new Vector2(2048, 256);
            island.Position = new Vector2(2126 - m_waterSizeX, 13094 - m_waterSizeY);
            island.Initialize(sprites, hb);
            m_islands.Add(island);

            // Island 19
            sprites = new Sprite[25];
            sprites[0] = new Sprite(ScreenManager.Game);
            sprites[0].Initialize(ref m_tIsland19[0]);
            sprites[0].Position = new Vector2(0, 0);

            sprites[1] = new Sprite(ScreenManager.Game);
            sprites[1].Initialize(ref m_tIsland19[1]);
            sprites[1].Position = new Vector2(512, 0);

            sprites[2] = new Sprite(ScreenManager.Game);
            sprites[2].Initialize(ref m_tIsland19[2]);
            sprites[2].Position = new Vector2(1024, 0);

            sprites[3] = new Sprite(ScreenManager.Game);
            sprites[3].Initialize(ref m_tIsland19[3]);
            sprites[3].Position = new Vector2(1536, 0);

            sprites[4] = new Sprite(ScreenManager.Game);
            sprites[4].Initialize(ref m_tIsland19[4]);
            sprites[4].Position = new Vector2(2048, 0);

            sprites[5] = new Sprite(ScreenManager.Game);
            sprites[5].Initialize(ref m_tIsland19[5]);
            sprites[5].Position = new Vector2(2560, 0);

            sprites[6] = new Sprite(ScreenManager.Game);
            sprites[6].Initialize(ref m_tIsland19[6]);
            sprites[6].Position = new Vector2(0, 768);

            sprites[7] = new Sprite(ScreenManager.Game);
            sprites[7].Initialize(ref m_tIsland19[7]);
            sprites[7].Position = new Vector2(512, 768);

            sprites[8] = new Sprite(ScreenManager.Game);
            sprites[8].Initialize(ref m_tIsland19[8]);
            sprites[8].Position = new Vector2(1024, 768);

            sprites[9] = new Sprite(ScreenManager.Game);
            sprites[9].Initialize(ref m_tIsland19[9]);
            sprites[9].Position = new Vector2(1536, 768);

            sprites[10] = new Sprite(ScreenManager.Game);
            sprites[10].Initialize(ref m_tIsland19[10]);
            sprites[10].Position = new Vector2(2048, 768);

            sprites[11] = new Sprite(ScreenManager.Game);
            sprites[11].Initialize(ref m_tIsland19[11]);
            sprites[11].Position = new Vector2(2560, 768);

            sprites[12] = new Sprite(ScreenManager.Game);
            sprites[12].Initialize(ref m_tIsland19[12]);
            sprites[12].Position = new Vector2(0, 1536);

            sprites[13] = new Sprite(ScreenManager.Game);
            sprites[13].Initialize(ref m_tIsland19[13]);
            sprites[13].Position = new Vector2(512, 1536);

            sprites[14] = new Sprite(ScreenManager.Game);
            sprites[14].Initialize(ref m_tIsland19[14]);
            sprites[14].Position = new Vector2(1024, 1536);

            sprites[15] = new Sprite(ScreenManager.Game);
            sprites[15].Initialize(ref m_tIsland19[15]);
            sprites[15].Position = new Vector2(1536, 1536);

            sprites[16] = new Sprite(ScreenManager.Game);
            sprites[16].Initialize(ref m_tIsland19[16]);
            sprites[16].Position = new Vector2(2048, 1536);

            sprites[17] = new Sprite(ScreenManager.Game);
            sprites[17].Initialize(ref m_tIsland19[17]);
            sprites[17].Position = new Vector2(2560, 1536);

            sprites[18] = new Sprite(ScreenManager.Game);
            sprites[18].Initialize(ref m_tIsland19[18]);
            sprites[18].Position = new Vector2(3072, 1536);

            sprites[19] = new Sprite(ScreenManager.Game);
            sprites[19].Initialize(ref m_tIsland19[19]);
            sprites[19].Position = new Vector2(3584, 1536);

            sprites[20] = new Sprite(ScreenManager.Game);
            sprites[20].Initialize(ref m_tIsland19[20]);
            sprites[20].Position = new Vector2(1024, 2304);

            sprites[21] = new Sprite(ScreenManager.Game);
            sprites[21].Initialize(ref m_tIsland19[21]);
            sprites[21].Position = new Vector2(1536, 2304);

            sprites[22] = new Sprite(ScreenManager.Game);
            sprites[22].Initialize(ref m_tIsland19[22]);
            sprites[22].Position = new Vector2(2048, 2304);

            sprites[23] = new Sprite(ScreenManager.Game);
            sprites[23].Initialize(ref m_tIsland19[23]);
            sprites[23].Position = new Vector2(2560, 2304);

            sprites[24] = new Sprite(ScreenManager.Game);
            sprites[24].Initialize(ref m_tIsland19[24]);
            sprites[24].Position = new Vector2(3072, 2304);

            // OTOODODODODODOOD
            hb = new OBB[27];
            hb[0] = new OBB(0, new Vector2(493, 969), new Vector2(435, 550) * 0.5f);
            hb[1] = new OBB(0, new Vector2(2422, 2462), new Vector2(88, 368) * 0.5f);
            hb[2] = new OBB(0, new Vector2(2752, 2291), new Vector2(571, 368) * 0.5f);
            hb[3] = new OBB(0, new Vector2(1867, 1043), new Vector2(248, 253) * 0.5f);
            hb[4] = new OBB(0, new Vector2(1940, 641), new Vector2(248, 253) * 0.5f);
            hb[5] = new OBB(0, new Vector2(1743, 842), new Vector2(248, 253) * 0.5f);
            hb[6] = new OBB(0, new Vector2(2750, 1674), new Vector2(248, 253) * 0.5f);
            hb[7] = new OBB(0, new Vector2(2626, 1454), new Vector2(248, 253) * 0.5f);
            hb[8] = new OBB(0, new Vector2(2502, 1274), new Vector2(248, 253) * 0.5f);
            hb[9] = new OBB(0, new Vector2(2169, 1147), new Vector2(604, 275) * 0.5f);
            hb[10] = new OBB(0, new Vector2(3081, 2214), new Vector2(279, 213) * 0.5f);
            hb[11] = new OBB(0, new Vector2(3038, 1847), new Vector2(437, 213) * 0.5f);
            hb[12] = new OBB(0, new Vector2(3537, 1987), new Vector2(631, 453) * 0.5f);
            hb[13] = new OBB(0, new Vector2(2082, 2367), new Vector2(592, 368) * 0.5f);
            hb[14] = new OBB(0, new Vector2(1120, 1871), new Vector2(208, 368) * 0.5f);
            hb[15] = new OBB(0, new Vector2(897, 1801), new Vector2(208, 368) * 0.5f);
            hb[16] = new OBB(0, new Vector2(1200, 2084), new Vector2(208, 368) * 0.5f);
            hb[17] = new OBB(0, new Vector2(1328, 2317), new Vector2(208, 368) * 0.5f);
            hb[18] = new OBB(0, new Vector2(1545, 2637), new Vector2(481, 368) * 0.5f);
            hb[19] = new OBB(0, new Vector2(532, 1900), new Vector2(481, 566) * 0.5f);
            hb[20] = new OBB(0, new Vector2(633, 1454), new Vector2(279, 465) * 0.5f);
            hb[21] = new OBB(0, new Vector2(711, 743), new Vector2(279, 262) * 0.5f);
            hb[22] = new OBB(0, new Vector2(899, 637), new Vector2(279, 262) * 0.5f);
            hb[23] = new OBB(0, new Vector2(1141, 481), new Vector2(279, 262) * 0.5f);
            hb[24] = new OBB(0, new Vector2(1545, 375), new Vector2(643, 262) * 0.5f);
            hb[25] = new OBB(0, new Vector2(2195, 461), new Vector2(643, 465) * 0.5f);
            hb[26] = new OBB(0, new Vector2(2716, 416), new Vector2(643, 393) * 0.5f);



            island = new Island(ScreenManager.Game);
            island.Position = new Vector2(1770 - m_waterSizeX, 13640 - m_waterSizeY);
            island.Initialize(sprites, hb);
            m_islands.Add(island);

            // Island44
            sprites = new Sprite[1];
            sprites[0] = new Sprite(ScreenManager.Game);
            sprites[0].Initialize(ref m_tIsland44[0]);
            sprites[0].Origin = new Vector2(2048, 512);
            sprites[0].Rotation = 0.8f;


            hb = new OBB[11];
            hb[0] = new OBB(0, new Vector2(3507, 535), new Vector2(228, 159) * 0.5f);
            hb[1] = new OBB(0, new Vector2(3621, 654), new Vector2(350, 216) * 0.5f);
            hb[2] = new OBB(0, new Vector2(2922, 414), new Vector2(344, 131) * 0.5f);
            hb[3] = new OBB(0, new Vector2(2847, 546), new Vector2(344, 131) * 0.5f);
            hb[4] = new OBB(0, new Vector2(2612, 710), new Vector2(701, 305) * 0.5f);
            hb[5] = new OBB(0, new Vector2(3020, 525), new Vector2(150, 589) * 0.5f);
            hb[6] = new OBB(0, new Vector2(3257, 441), new Vector2(392, 686) * 0.5f);
            hb[7] = new OBB(0, new Vector2(1420, 784), new Vector2(496, 115) * 0.5f);
            hb[8] = new OBB(0, new Vector2(1967, 699), new Vector2(715, 284) * 0.5f);
            hb[9] = new OBB(0, new Vector2(1333, 653), new Vector2(715, 191) * 0.5f);
            hb[10] = new OBB(0, new Vector2(647, 631), new Vector2(715, 191) * 0.5f);

            island = new Island(ScreenManager.Game);
            island.Rotation = 0;
            island.Origin = new Vector2(0, 0);
            // island.Position = new Vector2(18958 - m_waterSizeX, 16843 - m_waterSizeY);
            island.Position = Vector2.Zero;
            island.Initialize(sprites, hb);
            
            m_islands.Add(island);





            // Island48
            sprites = new Sprite[1];
            sprites[0] = new Sprite(ScreenManager.Game);
            sprites[0].Initialize(ref m_tIsland48[0]);


            hb = new OBB[2];
            hb[0] = new OBB(0, new Vector2(538, 277), new Vector2(755, 174) * 0.5f);
            hb[1] = new OBB(0, new Vector2(429, 271), new Vector2(302, 299) * 0.5f);


            island = new Island(ScreenManager.Game);
            island.Position = new Vector2(23021 - m_waterSizeX, 13031 - m_waterSizeY);
            island.Initialize(sprites, hb);
            m_islands.Add(island);




            // Island61
            sprites = new Sprite[1];
            sprites[0] = new Sprite(ScreenManager.Game);
            sprites[0].Initialize(ref m_tIsland61[0]);

            hb = new OBB[5];
            hb[0] = new OBB(0, new Vector2(485, 803), new Vector2(211, 169) * 0.5f);
            hb[1] = new OBB(0, new Vector2(442, 676), new Vector2(295, 112) * 0.5f);
            hb[2] = new OBB(0, new Vector2(419, 555), new Vector2(390, 130) * 0.5f);
            hb[3] = new OBB(0, new Vector2(379, 263), new Vector2(310, 194) * 0.5f);
            hb[4] = new OBB(0, new Vector2(491, 419), new Vector2(593, 194) * 0.5f);



            island = new Island(ScreenManager.Game);
            island.Position = new Vector2(22780 - m_waterSizeX, 8686 - m_waterSizeY);
            island.Initialize(sprites, hb);
            m_islands.Add(island);





            // Island62
            sprites = new Sprite[24];
            sprites[0] = new Sprite(ScreenManager.Game);
            sprites[0].Initialize(ref m_tIsland62[0]);
            sprites[0].Position = new Vector2(0, 0);

            sprites[1] = new Sprite(ScreenManager.Game);
            sprites[1].Initialize(ref m_tIsland62[1]);
            sprites[1].Position = new Vector2(1572, 0);

            sprites[2] = new Sprite(ScreenManager.Game);
            sprites[2].Initialize(ref m_tIsland62[2]);
            sprites[2].Position = new Vector2(3013, 0);

            sprites[3] = new Sprite(ScreenManager.Game);
            sprites[3].Initialize(ref m_tIsland62[3]);
            sprites[3].Position = new Vector2(3359, 0);

            sprites[4] = new Sprite(ScreenManager.Game);
            sprites[4].Initialize(ref m_tIsland62[4]);
            sprites[4].Position = new Vector2(4326, 0);

            sprites[5] = new Sprite(ScreenManager.Game);
            sprites[5].Initialize(ref m_tIsland62[5]);
            sprites[5].Position = new Vector2(5798, 0);

            sprites[6] = new Sprite(ScreenManager.Game);
            sprites[6].Initialize(ref m_tIsland62[6]);
            sprites[6].Position = new Vector2(6850, 0);

            sprites[7] = new Sprite(ScreenManager.Game);
            sprites[7].Initialize(ref m_tIsland62[7]);
            sprites[7].Position = new Vector2(0, 1875);

            sprites[8] = new Sprite(ScreenManager.Game);
            sprites[8].Initialize(ref m_tIsland62[8]);
            sprites[8].Position = new Vector2(1572, 1875);

            sprites[9] = new Sprite(ScreenManager.Game);
            sprites[9].Initialize(ref m_tIsland62[9]);
            sprites[9].Position = new Vector2(4326, 1875);

            sprites[10] = new Sprite(ScreenManager.Game);
            sprites[10].Initialize(ref m_tIsland62[10]);
            sprites[10].Position = new Vector2(5798, 1875);

            sprites[11] = new Sprite(ScreenManager.Game);
            sprites[11].Initialize(ref m_tIsland62[11]);
            sprites[11].Position = new Vector2(1572, 3568);

            sprites[12] = new Sprite(ScreenManager.Game);
            sprites[12].Initialize(ref m_tIsland62[12]);
            sprites[12].Position = new Vector2(3031, 3568);

            sprites[13] = new Sprite(ScreenManager.Game);
            sprites[13].Initialize(ref m_tIsland62[13]);
            sprites[13].Position = new Vector2(4326, 3568);

            sprites[14] = new Sprite(ScreenManager.Game);
            sprites[14].Initialize(ref m_tIsland62[14]);
            sprites[14].Position = new Vector2(5798, 3568);

            sprites[15] = new Sprite(ScreenManager.Game);
            sprites[15].Initialize(ref m_tIsland62[15]);
            sprites[15].Position = new Vector2(6850, 3568);

            sprites[16] = new Sprite(ScreenManager.Game);
            sprites[16].Initialize(ref m_tIsland62[16]);
            sprites[16].Position = new Vector2(1572, 4807);

            sprites[17] = new Sprite(ScreenManager.Game);
            sprites[17].Initialize(ref m_tIsland62[17]);
            sprites[17].Position = new Vector2(3013, 4807);

            sprites[18] = new Sprite(ScreenManager.Game);
            sprites[18].Initialize(ref m_tIsland62[18]);
            sprites[18].Position = new Vector2(3359, 4807);

            sprites[19] = new Sprite(ScreenManager.Game);
            sprites[19].Initialize(ref m_tIsland62[19]);
            sprites[19].Position = new Vector2(4326, 4807);

            sprites[20] = new Sprite(ScreenManager.Game);
            sprites[20].Initialize(ref m_tIsland62[20]);
            sprites[20].Position = new Vector2(1572, 5819);

            sprites[21] = new Sprite(ScreenManager.Game);
            sprites[21].Initialize(ref m_tIsland62[21]);
            sprites[21].Position = new Vector2(3013, 5819);

            sprites[22] = new Sprite(ScreenManager.Game);
            sprites[22].Initialize(ref m_tIsland62[22]);
            sprites[22].Position = new Vector2(3359, 5819);

            sprites[23] = new Sprite(ScreenManager.Game);
            sprites[23].Initialize(ref m_tIsland62[23]);
            sprites[23].Position = new Vector2(4326, 5819);


            // TODOODODODO
            /*
            hb = new OBB[14];
            hb[0] = new OBB(0, new Vector2(2740, 1180), new Vector2(3850, 700) * 0.5f);
            hb[1] = new OBB(0, new Vector2(5880, 960), new Vector2(2670, 700) * 0.5f);
            hb[2] = new OBB(0, new Vector2(5880, 1310), new Vector2(620, 660) * 0.5f);
            hb[3] = new OBB(0, new Vector2(5560, 2510), new Vector2(620, 2470) * 0.5f);
            hb[4] = new OBB(0, new Vector2(6030, 3120), new Vector2(680, 650) * 0.5f);
            hb[5] = new OBB(0, new Vector2(6360, 3560), new Vector2(680, 650) * 0.5f);
            hb[6] = new OBB(0, new Vector2(6780, 4010), new Vector2(1920, 800) * 0.5f);
            hb[7] = new OBB(0, new Vector2(5570, 4450), new Vector2(700, 800) * 0.5f);
            hb[8] = new OBB(0, new Vector2(5010, 5010), new Vector2(700, 800) * 0.5f);
            hb[9] = new OBB(0, new Vector2(3570, 5440), new Vector2(2530, 860) * 0.5f);
            hb[10] = new OBB(0, new Vector2(3890, 6180), new Vector2(1610, 1280) * 0.5f);
            hb[11] = new OBB(0, new Vector2(2270, 4400), new Vector2(570, 1350) * 0.5f);
            hb[12] = new OBB(0, new Vector2(1740, 3320), new Vector2(570, 1350) * 0.5f);
            hb[13] = new OBB(0, new Vector2(1380, 2070), new Vector2(570, 1350) * 0.5f);
            */

            hb = new OBB[74];
            hb[0] = new OBB(0, new Vector2(3929, 6220), new Vector2(118, 107) * 0.5f);
            hb[1] = new OBB(0, new Vector2(3950, 6317), new Vector2(85, 78) * 0.5f);
            hb[2] = new OBB(0, new Vector2(3897, 6356), new Vector2(85, 78) * 0.5f);
            hb[3] = new OBB(0, new Vector2(3857, 6395), new Vector2(85, 78) * 0.5f);
            hb[4] = new OBB(0, new Vector2(3889, 6116), new Vector2(123, 110) * 0.5f);
            hb[5] = new OBB(0, new Vector2(3737, 5810), new Vector2(123, 110) * 0.5f);
            hb[6] = new OBB(0, new Vector2(3809, 5969), new Vector2(123, 316) * 0.5f);
            hb[7] = new OBB(0, new Vector2(3648, 5744), new Vector2(123, 109) * 0.5f);
            hb[8] = new OBB(0, new Vector2(3525, 5788), new Vector2(123, 109) * 0.5f);
            hb[9] = new OBB(0, new Vector2(3443, 5865), new Vector2(123, 109) * 0.5f);
            hb[10] = new OBB(0, new Vector2(3288, 5998), new Vector2(277, 465) * 0.5f);
            hb[11] = new OBB(0, new Vector2(3117, 5744), new Vector2(188, 169) * 0.5f);
            hb[12] = new OBB(0, new Vector2(3002, 5648), new Vector2(188, 169) * 0.5f);
            hb[13] = new OBB(0, new Vector2(2864, 5552), new Vector2(188, 169) * 0.5f);
            hb[14] = new OBB(0, new Vector2(2691, 5467), new Vector2(188, 169) * 0.5f);
            hb[15] = new OBB(0, new Vector2(2472, 5266), new Vector2(188, 169) * 0.5f);
            hb[16] = new OBB(0, new Vector2(2541, 5593), new Vector2(188, 545) * 0.5f);
            hb[17] = new OBB(0, new Vector2(2344, 4699), new Vector2(146, 1084) * 0.5f);
            hb[18] = new OBB(0, new Vector2(2270, 4071), new Vector2(125, 227) * 0.5f);
            hb[19] = new OBB(0, new Vector2(2190, 3903), new Vector2(125, 227) * 0.5f);
            hb[20] = new OBB(0, new Vector2(2104, 3779), new Vector2(125, 227) * 0.5f);
            hb[21] = new OBB(0, new Vector2(1994, 3650), new Vector2(125, 227) * 0.5f);
            hb[22] = new OBB(0, new Vector2(1868, 3536), new Vector2(125, 227) * 0.5f);
            hb[23] = new OBB(0, new Vector2(1782, 3374), new Vector2(125, 227) * 0.5f);
            hb[24] = new OBB(0, new Vector2(1719, 3202), new Vector2(125, 227) * 0.5f);
            hb[25] = new OBB(0, new Vector2(1656, 3039), new Vector2(125, 227) * 0.5f);
            hb[26] = new OBB(0, new Vector2(1593, 2891), new Vector2(125, 227) * 0.5f);
            hb[27] = new OBB(0, new Vector2(1530, 2740), new Vector2(125, 227) * 0.5f);
            hb[28] = new OBB(0, new Vector2(1467, 2582), new Vector2(125, 227) * 0.5f);
            hb[29] = new OBB(0, new Vector2(1404, 2428), new Vector2(125, 227) * 0.5f);
            hb[30] = new OBB(0, new Vector2(1341, 2252), new Vector2(125, 227) * 0.5f);
            hb[31] = new OBB(0, new Vector2(1258, 2107), new Vector2(125, 227) * 0.5f);
            hb[32] = new OBB(0, new Vector2(1215, 1672), new Vector2(125, 662) * 0.5f);
            hb[33] = new OBB(0, new Vector2(1152, 1301), new Vector2(125, 123) * 0.5f);
            hb[34] = new OBB(0, new Vector2(1035, 1067), new Vector2(292, 101) * 0.5f);
            hb[35] = new OBB(0, new Vector2(1168, 1125), new Vector2(362, 101) * 0.5f);
            hb[36] = new OBB(0, new Vector2(1258, 1196), new Vector2(473, 101) * 0.5f);
            hb[37] = new OBB(0, new Vector2(1609, 1257), new Vector2(306, 101) * 0.5f);
            hb[38] = new OBB(0, new Vector2(1806, 1199), new Vector2(119, 101) * 0.5f);
            hb[39] = new OBB(0, new Vector2(1893, 1145), new Vector2(119, 101) * 0.5f);
            hb[40] = new OBB(0, new Vector2(2958, 1045), new Vector2(2147, 101) * 0.5f);
            hb[41] = new OBB(0, new Vector2(4171, 1024), new Vector2(70, 187) * 0.5f);
            hb[42] = new OBB(0, new Vector2(4161, 1125), new Vector2(259, 118) * 0.5f);
            hb[43] = new OBB(0, new Vector2(4366, 1042), new Vector2(178, 151) * 0.5f);
            hb[44] = new OBB(0, new Vector2(4545, 940), new Vector2(178, 151) * 0.5f);
            hb[45] = new OBB(0, new Vector2(4823, 692), new Vector2(260, 151) * 0.5f);
            hb[46] = new OBB(0, new Vector2(4829, 808), new Vector2(430, 160) * 0.5f);
            hb[47] = new OBB(0, new Vector2(6008, 1299), new Vector2(230, 82) * 0.5f);
            hb[48] = new OBB(0, new Vector2(6171, 1248), new Vector2(230, 82) * 0.5f);
            hb[49] = new OBB(0, new Vector2(6298, 1198), new Vector2(230, 82) * 0.5f);
            hb[50] = new OBB(0, new Vector2(6352, 1154), new Vector2(230, 82) * 0.5f);
            hb[51] = new OBB(0, new Vector2(6422, 1118), new Vector2(156, 59) * 0.5f);
            hb[52] = new OBB(0, new Vector2(6531, 1156), new Vector2(63, 85) * 0.5f);
            hb[53] = new OBB(0, new Vector2(5772, 874), new Vector2(1455, 132) * 0.5f);
            hb[54] = new OBB(0, new Vector2(6778, 1002), new Vector2(446, 257) * 0.5f);
            hb[55] = new OBB(0, new Vector2(6854, 916), new Vector2(815, 262) * 0.5f);
            hb[56] = new OBB(0, new Vector2(5461, 2107), new Vector2(476, 1337) * 0.5f);
            hb[57] = new OBB(0, new Vector2(5746, 2912), new Vector2(377, 344) * 0.5f);
            hb[58] = new OBB(0, new Vector2(5934, 3176), new Vector2(377, 344) * 0.5f);
            hb[59] = new OBB(0, new Vector2(6123, 3374), new Vector2(377, 344) * 0.5f);
            hb[60] = new OBB(0, new Vector2(6475, 3579), new Vector2(377, 344) * 0.5f);
            hb[61] = new OBB(0, new Vector2(6703, 3708), new Vector2(235, 251) * 0.5f);
            hb[62] = new OBB(0, new Vector2(6094, 4282), new Vector2(597, 251) * 0.5f);
            hb[63] = new OBB(0, new Vector2(6585, 4156), new Vector2(597, 251) * 0.5f);
            hb[64] = new OBB(0, new Vector2(7226, 3974), new Vector2(881, 443) * 0.5f);
            hb[65] = new OBB(0, new Vector2(5737, 4370), new Vector2(394, 291) * 0.5f);
            hb[66] = new OBB(0, new Vector2(5466, 4443), new Vector2(394, 549) * 0.5f);
            hb[67] = new OBB(0, new Vector2(5269, 4628), new Vector2(394, 549) * 0.5f);
            hb[68] = new OBB(0, new Vector2(5120, 4865), new Vector2(394, 549) * 0.5f);
            hb[69] = new OBB(0, new Vector2(4157, 6392), new Vector2(378, 767) * 0.5f);
            hb[70] = new OBB(0, new Vector2(4275, 5884), new Vector2(649, 809) * 0.5f);
            hb[71] = new OBB(0, new Vector2(4438, 5320), new Vector2(812, 581) * 0.5f);
            hb[72] = new OBB(0, new Vector2(4733, 5101), new Vector2(812, 581) * 0.5f);
            hb[73] = new OBB(0, new Vector2(5803, 1401), new Vector2(330, 193) * 0.5f);



            island = new Island(ScreenManager.Game);
            island.Position = new Vector2(15480 - m_waterSizeX, 983 - m_waterSizeY);
            island.Initialize(sprites, hb);
            m_islands.Add(island);




            // Island72
            sprites = new Sprite[1];
            sprites[0] = new Sprite(ScreenManager.Game);
            sprites[0].Initialize(ref m_tIsland72[0]);

            hb = new OBB[7];
            hb[0] = new OBB(0, new Vector2(2106, 940), new Vector2(1131, 400) * 0.5f);
            hb[1] = new OBB(0, new Vector2(2125, 1283), new Vector2(766, 400) * 0.5f);
            hb[2] = new OBB(0, new Vector2(2159, 1786), new Vector2(458, 643) * 0.5f);
            hb[3] = new OBB(0, new Vector2(2306, 271), new Vector2(319, 191) * 0.5f);
            hb[4] = new OBB(0, new Vector2(1770, 293), new Vector2(319, 191) * 0.5f);
            hb[5] = new OBB(0, new Vector2(2049, 214), new Vector2(413, 275) * 0.5f);
            hb[6] = new OBB(0, new Vector2(1993, 524), new Vector2(1465, 433) * 0.5f);

            island = new Island(ScreenManager.Game);
            island.Position = new Vector2(14428 - m_waterSizeX, 8415 - m_waterSizeY);
            island.Initialize(sprites, hb);
            m_islands.Add(island);



            // Island83
            sprites = new Sprite[1];
            sprites[0] = new Sprite(ScreenManager.Game);
            sprites[0].Initialize(ref m_tIsland83[0]);

            hb = new OBB[6];
            hb[0] = new OBB(0, new Vector2(211, 851), new Vector2(262, 225) * 0.5f);
            hb[1] = new OBB(0, new Vector2(304, 714), new Vector2(282, 164) * 0.5f);
            hb[2] = new OBB(0, new Vector2(394, 587), new Vector2(282, 164) * 0.5f);
            hb[3] = new OBB(0, new Vector2(518, 462), new Vector2(378, 164) * 0.5f);
            hb[4] = new OBB(0, new Vector2(686, 379), new Vector2(249, 250) * 0.5f);
            hb[5] = new OBB(0, new Vector2(788, 223), new Vector2(249, 250) * 0.5f);

            island = new Island(ScreenManager.Game);
            island.Position = new Vector2(12288 - m_waterSizeX, 1598 - m_waterSizeY);
            island.Initialize(sprites, hb);
            m_islands.Add(island);



            // Island86
            sprites = new Sprite[1];
            sprites[0] = new Sprite(ScreenManager.Game);
            sprites[0].Initialize(ref m_tIsland86[0]);

            hb = new OBB[15];
            hb[0] = new OBB(0, new Vector2(916, 965), new Vector2(263, 255) * 0.5f);
            hb[1] = new OBB(0, new Vector2(1048, 860), new Vector2(198, 255) * 0.5f);
            hb[2] = new OBB(0, new Vector2(1179, 750), new Vector2(244, 310) * 0.5f);
            hb[3] = new OBB(0, new Vector2(1630, 752), new Vector2(244, 200) * 0.5f);
            hb[4] = new OBB(0, new Vector2(1679, 515), new Vector2(357, 307) * 0.5f);
            hb[5] = new OBB(0, new Vector2(1572, 334), new Vector2(332, 175) * 0.5f);
            hb[6] = new OBB(0, new Vector2(1317, 669), new Vector2(227, 439) * 0.5f);
            hb[7] = new OBB(0, new Vector2(1447, 670), new Vector2(227, 637) * 0.5f);
            hb[8] = new OBB(0, new Vector2(784, 1093), new Vector2(227, 209) * 0.5f);
            hb[9] = new OBB(0, new Vector2(697, 1176), new Vector2(227, 209) * 0.5f);
            hb[10] = new OBB(0, new Vector2(604, 1281), new Vector2(227, 209) * 0.5f);
            hb[11] = new OBB(0, new Vector2(513, 1386), new Vector2(227, 209) * 0.5f);
            hb[12] = new OBB(0, new Vector2(446, 1491), new Vector2(227, 209) * 0.5f);
            hb[13] = new OBB(0, new Vector2(376, 1620), new Vector2(227, 209) * 0.5f);
            hb[14] = new OBB(0, new Vector2(285, 1725), new Vector2(227, 209) * 0.5f);


            island = new Island(ScreenManager.Game);
            island.Position = new Vector2(13140 - m_waterSizeX, 686 - m_waterSizeY);
            island.Initialize(sprites, hb);
            m_islands.Add(island);
            
        }


       

        /// <summary>
        /// Unload graphics content used by the game.
        /// </summary>
        public override void UnloadContent()
        {
            content.Unload();


            /*
            if (Actor.Actors.First != null)
            {
                for (Actor a = Actor.Actors.First.Value; a != null; a = a.NextActor)
                {
                    a.Destroy();
                }
            }
            */
            
        }


        #endregion

        #region Update and Draw


        /// <summary>
        /// Updates the state of the game. This method checks the GameScreen.IsActive
        /// property, so the game will stop updating when the pause menu is active,
        /// or if you tab away to a different application.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                                       bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);

            if (m_player.Health <= 0)
            {
                ExitScreen();

                LoadingScreen.Load(ScreenManager, false, null, new BackgroundScreen(),
                                                           new GameoverScreen());
                return;
            }

            // Gradually fade in or out depending on whether we are covered by the pause screen.
            if (coveredByOtherScreen)
                pauseAlpha = Math.Min(pauseAlpha + 1f / 32, 1);
            else
                pauseAlpha = Math.Max(pauseAlpha - 1f / 32, 0);

            if (IsActive)
            {
                for (Actor a = Actor.Actors.First.Value; a != null; a = a.NextActor)
                {
                    if (a != null)
                    {
                        a.Update(gameTime);

                        if (a.bDead)
                            a.Destroy();
                    }
                }

                m_player.Position = Vector2.Clamp(m_player.Position
                    , new Vector2(-m_waterSizeX + (ScreenManager.Game.GraphicsDevice.Viewport.Width * 0.5f), -m_waterSizeY + (ScreenManager.Game.GraphicsDevice.Viewport.Height * 0.5f))
                    , new Vector2(m_waterSizeX - (ScreenManager.Game.GraphicsDevice.Viewport.Width * 0.5f), m_waterSizeY - (ScreenManager.Game.GraphicsDevice.Viewport.Height * 0.5f)));
                m_pc.Position = Vector2.Clamp(m_player.Position
                    , new Vector2(-m_waterSizeX - (ScreenManager.Game.GraphicsDevice.Viewport.Width * 0.5f), -m_waterSizeY - (ScreenManager.Game.GraphicsDevice.Viewport.Height * 0.5f))
                    , new Vector2(m_waterSizeX - (ScreenManager.Game.GraphicsDevice.Viewport.Width * 0.5f), m_waterSizeY - (ScreenManager.Game.GraphicsDevice.Viewport.Height * 0.5f)));

                /*
                if (Input.kd(Keys.Left))
                {
                    m_pc.PlayerCamera.Position3 -= Vector3.UnitX * 100.0f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }

                if (Input.kd(Keys.Right))
                {
                    m_pc.PlayerCamera.Position3 += Vector3.UnitX * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                }
                */
                /*
                if (Input.kd(Keys.Up))
                    m_pc.PlayerCamera.Position3 += Vector3.UnitY * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (Input.kd(Keys.Down))
                    m_pc.PlayerCamera.Position3 -= Vector3.UnitY * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;

                */


                // Only used for specular
                m_waterEffect.Parameters["xCamPos"].SetValue(m_pc.PlayerCamera.Position3);
                // m_waterEffect.Parameters["xCamPos"].SetValue(new Vector3(0, 0, 50));

                m_bloom.Update(gameTime);

                /*
                if (Input.kp(Keys.L))
                {
                    bloomSettingsIndex = (bloomSettingsIndex + 1) %
                                         BloomSettings.PresetSettings.Length;

                    m_bloom.Settings = BloomSettings.PresetSettings[bloomSettingsIndex];
                    m_bloom.Visible = true;
                }

                if (Input.kp(Keys.K))
                {
                    // m_bloom.Visible = !m_bloom.Visible;
                }

                //if (Input.kp(Keys.I))
                    // m_explosionIndex++;
                 */
            }
            else
            {
                
            }
        }

        private void DrawMiniMap()
        {

            Game1.SpriteBatch.Begin();

            ScreenManager.Game.GraphicsDevice.SetRenderTarget(m_miniMap);

            Game1.SpriteBatch.Draw(m_tWhitePixel, new Rectangle(0, 0, m_miniMap.Width, m_miniMap.Height), Color.Black);

            for (int i = 0; i < m_shopPositions.Length; i++)
            {
                Vector2 pos = m_shopPositions[i].Position;
                pos.X = pos.X * m_mmRatioX + (m_miniMapWidth * 0.5f);
                pos.Y = pos.Y * m_mmRatioY + (m_miniMapHeight * 0.5f);

                if (m_shopPositions[i].Id == ShopID.Pirate)
                {
                    Game1.SpriteBatch.Draw(m_tJollyRoger, new Rectangle((int)pos.X - 12, (int)pos.Y - 12, 24, 24), Color.White);
                }
                else
                {
                    Game1.SpriteBatch.Draw(m_tMoneyBag, new Rectangle((int)pos.X - 12, (int)pos.Y - 12, 24, 24), Color.White);
                }
            }


            if (Actor.Actors.First != null)
            {
                for (Actor a = Actor.Actors.First.Value; a != null; a = a.NextActor)
                {
                    if (a != null)
                    {
                        if (a is PDVehicle)
                        {
                            if ((a as PDVehicle).Controller is PDPlayerController)
                            {
                                Vector2 pos = a.Position;
                                pos.X = pos.X * m_mmRatioX + (m_miniMapWidth * 0.5f);
                                pos.Y = pos.Y * m_mmRatioY + (m_miniMapHeight * 0.5f);

                                Game1.SpriteBatch.Draw(m_tWhitePixel, new Rectangle((int)pos.X - 2, (int)pos.Y - 2, 4, 4), Color.Green);
                            }
                            else
                            {
                                Vector2 pos = a.Position;
                                pos.X = pos.X * m_mmRatioX + (m_miniMapWidth * 0.5f);
                                pos.Y = pos.Y * m_mmRatioY + (m_miniMapHeight * 0.5f);

                                Game1.SpriteBatch.Draw(m_tWhitePixel, new Rectangle((int)pos.X - 2, (int)pos.Y - 2, 4, 4), Color.Red);
                            }
                        }
                    }

                }
            }

            

            // GraphicsDevice.SetRenderTarget(null);
            Game1.SpriteBatch.End();



        }

        private void DrawWater(GameTime gameTime)
        {
            ScreenManager.Game.GraphicsDevice.SetRenderTarget(m_rtWater);
            ScreenManager.Game.GraphicsDevice.SetVertexBuffer(m_vertexBuffer);
            m_waterEffect.CurrentTechnique = m_waterEffect.Techniques["Technique1"];

            // m_waterEffect.Parameters["World"].SetValue(Matrix.Identity);
            //m_waterEffect.Parameters["View"].SetValue(m_cam.ViewMatrix);
            //m_waterEffect.Parameters["Projection"].SetValue(m_cam.ProjectionMatrix);

            m_waterEffect.Parameters["xTime"].SetValue((float)gameTime.TotalGameTime.TotalSeconds);
            m_waterEffect.Parameters["xScrollDir1"].SetValue(new Vector2(0, 1));
            m_waterEffect.Parameters["xScrollDir2"].SetValue(new Vector2(-0.25f, -0.75f));
            m_waterEffect.Parameters["xScrollDirClouds"].SetValue(new Vector2(0.25f, 0.5f));

            // Using standalone camera
            // m_waterEffect.Parameters["WorldViewProjection"].SetValue(Matrix.Identity * m_cam.ViewMatrix * m_cam.ProjectionMatrix);

            // Using player camera
            m_waterEffect.Parameters["WorldViewProjection"].SetValue(
                                                                        m_pc.PlayerCamera.World
                                                                        * m_pc.PlayerCamera.ViewMatrix
                // * Matrix.CreateLookAt(new Vector3(0, 0, 50), Vector3.Zero, Vector3.Up)
                                                                        * m_pc.PlayerCamera.ProjectionMatrix
                                                                        );


            foreach (EffectPass pass in m_waterEffect.CurrentTechnique.Passes)
            {

                pass.Apply();

                // GraphicsDevice.SetRenderTarget(m_renderTarget);
                ScreenManager.Game.GraphicsDevice.DrawUserPrimitives<VertexPositionTexture>(PrimitiveType.TriangleStrip, m_waterVerts, 0, 2);

            }
        }

        private void DrawDebugPoints(Vector2[] positions, Color color)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                Game1.SpriteBatch.Draw(m_tWhitePixel, new Rectangle((int)positions[i].X, (int)positions[i].Y, 4, 4), color);
            }

        }
        

        


        /// <summary>
        /// Lets the game respond to player input. Unlike the Update method,
        /// this will only be called when the gameplay screen is active.
        /// </summary>
        public override void HandleInput(InputState input)
        {
            if (input == null)
                throw new ArgumentNullException("input");

            // Look up inputs for the active player profile.
            int playerIndex = (int)ControllingPlayer.Value;

            KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
            GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];

            // The game pauses either if the user presses the pause button, or if
            // they unplug the active gamepad. This requires us to keep track of
            // whether a gamepad was ever plugged in, because we don't want to pause
            // on PC if they are playing with a keyboard and have no gamepad at all!
            bool gamePadDisconnected = !gamePadState.IsConnected &&
                                       input.GamePadWasConnected[playerIndex];

            if (input.IsPauseGame(ControllingPlayer) || gamePadDisconnected)
            {
                ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
            }
            else if(Input.kp(Keys.M))
            {

                ScreenManager.AddScreen(new MapScreen(), ControllingPlayer);


            }
            /*
            else if (Input.kp(Keys.Enter))
            {
                Game1.Audio.SetParameter("sfx_ship_accelerate", "DopplerPitchScalar", 0);

                // ScreenManager.AddScreen(new PirateShop(m_player), ControllingPlayer);
                ScreenManager.AddScreen(new PersianShop(m_player), ControllingPlayer);
            }
            */
        }

        public override void ExitScreen()
        {
            if (Actor.Actors.First != null)
            {
                for (Actor a = Actor.Actors.First.Value; a != null; a = a.NextActor)
                {
                    a.Destroy();
                }
            }

            Game1.Audio.SetParameter("music", "Interactive_Sounds", Game1.MUSIC_MAINMENU);
            Game1.Audio.SetParameter("ambience", "Interactive_Ambience", Game1.AMBIENCE_MAINMENU);
            Game1.Audio.SetParameter("sfx_ship_accelerate", "DopplerPitchScalar", 0);
            base.ExitScreen();


        }

        /// <summary>
        /// Draws the gameplay screen.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            // This game has a blue background. Why? Because!
            ScreenManager.GraphicsDevice.Clear(ClearOptions.Target,
                                               Color.CornflowerBlue, 0, 0);

            // Our player and enemy are both actually just text strings.
            SpriteBatch spriteBatch = ScreenManager.SpriteBatch;
            SpriteBatch sb = Game1.SpriteBatch;


            DrawMiniMap();
            DrawWater(gameTime);

            if (m_bloom.Visible)
                m_bloom.BeginDraw();
            else
                ScreenManager.Game.GraphicsDevice.SetRenderTarget(null);

            Game1.SpriteBatch.Begin();

            Game1.SpriteBatch.Draw(m_rtWater, Vector2.Zero, Color.White);


            Game1.SpriteBatch.End();



            Game1.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.Additive, null, null, null, null, m_pc.PlayerCamera.TransformMatrix);


            if (Actor.Actors.First != null)
            {
                for (Actor a = Actor.Actors.First.Value; a != null; a = a.NextActor)
                {
                    if (a != null)
                    {
                        if ((a is EffectSmoke) || (a is Watersplash) || (a is EffectWaterTrail))
                        {
                            a.Draw(gameTime, ref sb);
                        }
                    }

                }
            }



            Game1.SpriteBatch.End();


            Game1.SpriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend, null, null, null, null, m_pc.PlayerCamera.TransformMatrix);

            if (Actor.Actors.First != null)
            {
                for (Actor a = Actor.Actors.First.Value; a != null; a = a.NextActor)
                {
                    if (a != null)
                    {
                        if (!(a is EffectSmoke) && !(a is Watersplash) && !(a is EffectWaterTrail))
                        {
                            a.Draw(gameTime, ref sb);
                            //if (a is PDVehicle)
                                //DrawDebugPoints((a as PDVehicle).Obb.GetDebugPoints(), Color.Red);

                            if (a is Island && (a as Island).Hitbox != null)
                            {
                                /*
                                for (int i = 0; i < (a as Island).Hitbox.Length; i++)
                                {
                                    DrawDebugPoints((a as Island).Hitbox[i].GetDebugPoints(), Color.Red);
                                }
                                */
                            }
                        }
                    }


                }
            }

            
           
            Game1.SpriteBatch.End();


            



            if (m_bloom.Visible)
                m_bloom.Draw(gameTime);




            Game1.SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);



            Game1.SpriteBatch.Draw(m_tMoney, new Vector2(20, 20), Color.White);
            Game1.SpriteBatch.DrawString(Game1.m_pirateFontText, m_player.Gold.ToString(), new Vector2(70, 10), Color.Gold);
            Game1.SpriteBatch.DrawString(Game1.m_pirateFontText, "Cannons ready: " + m_player.CannonsReady.ToString() + " / " + m_player.CannonsMax.ToString(), new Vector2(10, 40), Color.Wheat);
            Game1.SpriteBatch.DrawString(Game1.m_pirateFontText, "Loot: ", new Vector2(10, 70), Color.Gold);
            Game1.SpriteBatch.DrawString(Game1.m_pirateFontText, "Iron: " + m_player.Iron.ToString(), new Vector2(10, 100), Color.Wheat);
            Game1.SpriteBatch.DrawString(Game1.m_pirateFontText, "Coal: " + m_player.Coal.ToString(), new Vector2(10, 130), Color.Wheat);
            Game1.SpriteBatch.DrawString(Game1.m_pirateFontText, "Silk: " + m_player.Silk.ToString(), new Vector2(10, 160), Color.Wheat);
            Game1.SpriteBatch.DrawString(Game1.m_pirateFontText, "Spices: " + m_player.Spices.ToString(), new Vector2(10, 190), Color.Wheat);
            Game1.SpriteBatch.DrawString(Game1.m_pirateFontText, "Leather: " + m_player.Leather.ToString(), new Vector2(10, 220), Color.Wheat);
            Game1.SpriteBatch.DrawString(Game1.m_pirateFontText, "Rum: " + m_player.Rum.ToString(), new Vector2(10, 250), Color.Wheat);
            Game1.SpriteBatch.DrawString(Game1.m_pirateFontText, "Rope: " + m_player.Rope.ToString(), new Vector2(10, 280), Color.Wheat);
            Game1.SpriteBatch.DrawString(Game1.m_pirateFontText, "Tools: " + m_player.Tools.ToString(), new Vector2(10, 310), Color.Wheat);


            // Game1.SpriteBatch.DrawString(Game1.m_debugFont, (m_pc.Position).ToString(), new Vector2(10, 300), Color.Red);
            /*
            Game1.SpriteBatch.DrawString(Game1.m_debugFont, "'L' for att byta bloom typ: " + m_bloom.Settings.Name, Vector2.One * 10, Color.White);
            Game1.SpriteBatch.DrawString(Game1.m_debugFont, "'K' for att bloom av/pa: " + (m_bloom.Visible ? "On" : "Off"), new Vector2(10, 40), Color.White);
            Game1.SpriteBatch.DrawString(Game1.m_debugFont, "'I' to change explosion sprite: " + ExplosionType(), new Vector2(10, 70), Color.White);
            Game1.SpriteBatch.DrawString(Game1.m_debugFont, "'M' to open Map", new Vector2(10, 100), Color.White);
            */
            

            Game1.SpriteBatch.Draw(m_miniMap, new Vector2(ScreenManager.Game.GraphicsDevice.Viewport.Width - 10 - 320, 10), new Color(1.0f, 1.0f, 1.0f, 0.5f));

            Game1.SpriteBatch.End();









            // If the game is transitioning on or off, fade it out to black.
            if (TransitionPosition > 0 || pauseAlpha > 0)
            {
                float alpha = MathHelper.Lerp(1f - TransitionAlpha, 1f, pauseAlpha / 2);

                ScreenManager.FadeBackBufferToBlack(alpha);
            }
        }


       


        #endregion
    }
}
