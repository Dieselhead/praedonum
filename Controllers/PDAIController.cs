using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using ActorPack;
using ActorPack.Help;

namespace Praedonum
{
    public class PDAIController : AIController
    {

      

        public PDAIController(Game game, Actor owner_)
            : base(game, owner_)
        {

        }

        public override void Update(GameTime gameTime)
        {


            // Priority
            // 1. Move into firing range
                // Rotate and move out if too close
                // Rotate and move in if too far away
            // 2. Rotate to fire angle
            // 3. Fire if at right angle


            // Find Vector to player
            // Find distance to player
            // if distance is greater then or lesser then N
                // Find rotation needed to move away from player
                // Rotate
                // Apply throttle

            if (Pawn != null && true)
            {

                Pawn p = null;
                for (p = Pawn.Pawns.First.Value; p != null; p = p.NextPawn)
                {
                    if (p.Controller is PDPlayerController)
                        break;
                }


                if (p != null)
                {
                    Vector2 distToP = p.Position - Pawn.Position;

                    if (distToP.LengthSquared() < 15000.0f * 15000.0f)
                    {
                        if (distToP.LengthSquared() < 256 * 256)
                        {
                            if (Vector2.Dot(Vector2.Normalize(distToP), Pawn.Right) >= 0.0f)
                            {
                                (Pawn as PDVehicle).TurnLeft(gameTime);
                            }
                            else
                            {
                                (Pawn as PDVehicle).TurnRight(gameTime);
                            }

                            (Pawn as PDVehicle).MoveForward(gameTime);
                            // Find vector to player
                            // Rotate towards the negative of that vector
                            // Apply thrust
                            // (Pawn as PDVehicle).MoveForward(gameTime);
                        }
                        else if (distToP.LengthSquared() > 350 * 350)
                        {
                            if (Vector2.Dot(Vector2.Normalize(distToP), Pawn.Right) >= 0.0f)
                            {
                                (Pawn as PDVehicle).TurnRight(gameTime);
                            }
                            else
                            {
                                (Pawn as PDVehicle).TurnLeft(gameTime);
                            }

                            (Pawn as PDVehicle).MoveForward(gameTime);
                        }
                        else
                            (Pawn as PDVehicle).MoveForward(gameTime);

                        if (true || (Pawn as PDVehicle).CannonsReady > (Pawn as PDVehicle).CannonsMax * 0.75f)
                        {


                            if (distToP.LengthSquared() < 500.0f * 500.0f)
                            {


                                if (Vector2.Dot(Vector2.Normalize(distToP), Pawn.Right) > -0.9f)
                                {
                                    // (Pawn as PDVehicle).TurnRight(gameTime);

                                }
                                else
                                {
                                    (Pawn as PDVehicle).FireLeft(gameTime);

                                }

                                if (Vector2.Dot(Vector2.Normalize(distToP), Pawn.Right) < 0.9f)
                                {
                                    // (Pawn as PDVehicle).TurnLeft(gameTime);

                                }
                                else
                                {
                                    (Pawn as PDVehicle).FireRight(gameTime);

                                }
                            }
                        }
                    }
                }
            }
              
            
            base.Update(gameTime);
        }
    }
}
