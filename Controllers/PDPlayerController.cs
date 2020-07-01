using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ActorPack;
using ActorPack.Help;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Praedonum
{
    public class PDPlayerController : PlayerController
    {
        private bool m_bShotLastFrame = false;
        private bool m_bShotLeft = false;
        private bool m_bShotRight = false;
        private int m_shotsFired = 0;


        private int m_gold = 0;
        private GameplayScreen.ShopID m_shopToOpen;

        public int Gold
        {
            get { return m_gold; }
            set { m_gold = value; }
        }

        public PDPlayerController(Game game, Actor owner_)
            : base(game, owner_)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, ref SpriteBatch sb_)
        {
            base.Draw(gameTime, ref sb_);


            if (m_shopToOpen != GameplayScreen.ShopID.None)
            {
              
                

                switch (m_shopToOpen)
                {
                    case GameplayScreen.ShopID.British:
                        sb_.DrawString(Game1.m_pirateFontText
                            , "Press ENTER to dock at the British Trade harbor"
                            , Position + (Vector2.UnitY * 120) - (Game1.m_pirateFontText.MeasureString("Press ENTER to dock at the British Trade harbor") * 0.5f)
                            , Color.White);
                        break;
                    case GameplayScreen.ShopID.Chinese:
                        sb_.DrawString(Game1.m_pirateFontText
                            , "Press ENTER to dock at the Chinese Trade harbor"
                            , Position + (Vector2.UnitY * 120) - (Game1.m_pirateFontText.MeasureString("Press ENTER to dock at the Chinese Trade harbor") * 0.5f)
                            , Color.White);
                        
                        break;
                    case GameplayScreen.ShopID.Persian:
                        sb_.DrawString(Game1.m_pirateFontText
                            , "Press ENTER to dock at the Persian Trade harbor"
                            , Position + (Vector2.UnitY * 120) - (Game1.m_pirateFontText.MeasureString("Press ENTER to dock at the Persian Trade harbor") * 0.5f)
                            , Color.White);
                        
                        break;
                    case GameplayScreen.ShopID.Pirate:
                        sb_.DrawString(Game1.m_pirateFontText
                            , "Press ENTER to dock at the Pirate hideout"
                            , Position + (Vector2.UnitY * 120) - (Game1.m_pirateFontText.MeasureString("Press ENTER to dock at the Pirate hideout") * 0.5f)
                            , Color.White);
                        
                        break;
                    case GameplayScreen.ShopID.Spanish:
                        sb_.DrawString(Game1.m_pirateFontText
                            , "Press ENTER to dock at the Spanish Trade harbor"
                            , Position + (Vector2.UnitY * 120) - (Game1.m_pirateFontText.MeasureString("Press ENTER to dock at the Spanish Trade harbor") * 0.5f)
                            , Color.White);
                        
                        break;

                }
            }
        }

        protected override void CaptureInput(GameTime gameTime)
        {

            if (Pawn != null)
            {
                if (Input.kd(Keys.A))
                {
                    (Pawn as PDVehicle).TurnLeft(gameTime);
                }
                else if (Input.kd(Keys.D))
                {
                    (Pawn as PDVehicle).TurnRight(gameTime);
                }
                else 
                {
                    (Pawn as PDVehicle).LevelOut();
                }

                if (Input.kd(Keys.W))
                {
                    // Pawn.AddInternalForce(Pawn.Heading * Pawn.MaxForce * 10);
                    (Pawn as PDVehicle).MoveForward(gameTime);
                }
                else if (Input.kd(Keys.S))
                {
                    (Pawn as PDVehicle).Break(gameTime);
                }
                else
                {


                }

                

                m_bShotRight = false;
                m_bShotLeft = false;

                if (Input.kd(Keys.Left))
                    if ((Pawn as PDVehicle).FireLeft(gameTime))
                        m_bShotLeft = true;
                

                if (Input.kd(Keys.Right))
                    if ((Pawn as PDVehicle).FireRight(gameTime))
                        m_bShotRight = true;
                


                if (m_bShotRight || m_bShotLeft)
                {
                    if (m_bShotLastFrame)
                    {
                        m_shotsFired++;
                    }
                    else
                    {
                        m_shotsFired = 1;

                    }

                    m_bShotLastFrame = true;
                }
                else
                {
                    if (m_bShotLastFrame)
                    {
                        if (m_shotsFired < 6)
                        {
                            Game1.Audio.PlaySound("sfx_cannon_shoot");
                            Game1.Audio.SetParameter("sfx_cannon_shoot", "Distance",
                                ((Pawn as PDVehicle).Screen.Player.Position - Position).Length());
                        }
                        else
                        {
                            Game1.Audio.PlaySound("sfx_cannon_shoot_many");
                            Game1.Audio.SetParameter("sfx_cannon_shoot_many", "Distance",
                                ((Pawn as PDVehicle).Screen.Player.Position - Position).Length());
                        }
                    }

                    m_shotsFired = 0;
                    m_bShotLastFrame = false;
                }


                bool check = false;
                for (int i = 0; i < GameplayScreen.m_shopPositions.Length; i++)
                {
                    if ((GameplayScreen.m_shopPositions[i].Position - Position).LengthSquared() < 512 * 512)
                    {
                        m_shopToOpen = GameplayScreen.m_shopPositions[i].Id;
                        check = true;
                        break;
                    }
                    
                }

                if (!check)
                    m_shopToOpen = GameplayScreen.ShopID.None;

                if (Input.kp(Keys.Enter))
                {
                    if (m_shopToOpen != GameplayScreen.ShopID.None)
                    {
                        switch (m_shopToOpen)
                        {
                            case GameplayScreen.ShopID.Pirate:
                                (Pawn as PDVehicle).Screen.ScreenManager.AddScreen(new PirateShop((Pawn as PDVehicle)), (Pawn as PDVehicle).Screen.ControllingPlayer);
                                Game1.Audio.SetParameter("sfx_ship_accelerate", "DopplerPitchScalar", 0);
                                break;
                            case GameplayScreen.ShopID.British:
                                (Pawn as PDVehicle).Screen.ScreenManager.AddScreen(new BritishShop((Pawn as PDVehicle)), (Pawn as PDVehicle).Screen.ControllingPlayer);
                                Game1.Audio.SetParameter("sfx_ship_accelerate", "DopplerPitchScalar", 0);
                                break;
                            case GameplayScreen.ShopID.Chinese:
                                (Pawn as PDVehicle).Screen.ScreenManager.AddScreen(new ChineseShop((Pawn as PDVehicle)), (Pawn as PDVehicle).Screen.ControllingPlayer);
                                Game1.Audio.SetParameter("sfx_ship_accelerate", "DopplerPitchScalar", 0);
                                break;
                            case GameplayScreen.ShopID.Persian:
                                (Pawn as PDVehicle).Screen.ScreenManager.AddScreen(new PersianShop((Pawn as PDVehicle)), (Pawn as PDVehicle).Screen.ControllingPlayer);
                                Game1.Audio.SetParameter("sfx_ship_accelerate", "DopplerPitchScalar", 0);
                                break;
                            case GameplayScreen.ShopID.Spanish:
                                (Pawn as PDVehicle).Screen.ScreenManager.AddScreen(new SpanishShop((Pawn as PDVehicle)), (Pawn as PDVehicle).Screen.ControllingPlayer);
                                Game1.Audio.SetParameter("sfx_ship_accelerate", "DopplerPitchScalar", 0);
                                break;
                        }
                    }
                }

               

                if (Input.kp(Keys.H))
                {
                    (Pawn as PDVehicle).bShowHpBar = !(Pawn as PDVehicle).bShowHpBar;
                }
            }



            PlayerCamera.Position3 = Vector3.UnitX * PlayerCamera.Position.X + Vector3.UnitY * -PlayerCamera.Position.Y + Vector3.UnitZ * 1;
            PlayerCamera.ViewMatrix = Matrix.CreateLookAt(PlayerCamera.Position3
                                                            , PlayerCamera.Position3 * Vector3.UnitX + PlayerCamera.Position3 * Vector3.UnitY + Vector3.UnitZ * -10
                                                            , Vector3.Up);
           

        
        }
    }
}
