// ----------------------------------------------------------------------------------------------
//  <copyright file="TwoFingeredDragState.cs" company="Arcane Logic">
//      Copyright (c) Arcane Logic.  All rights reserved.
//  </copyright>
//  
//  <author email="matt.wilson@arcanelogic.net">
//       Matt Wilson
//  </author>
// ---------------------------------------------------------------------------------------------- 

namespace ArcaneLogic.MonoGame.Input.Touch
{
    using ArcaneLogic.MonoGame.Input.Extensions;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input.Touch;

    public class TwoFingeredDragState : TouchStateBase
    {
        public TwoFingeredDragState(TouchStateBase previousState)
            : base(previousState)
        {
        }

        public override bool Update(GameTime gameTime, TouchCollection currentTouch, out TouchStateBase nextState)
        {
            if (currentTouch.Count != 2)
            {
                TouchStateMachine.SubmitGestureEvent(new TwoFingeredDragEventArgs(GestureTiming.Completed, new Vector2()));
                nextState = new CooldownState(this);
                return true;
            }

            if (currentTouch[0].TryGetPreviousLocation(out var prevFinger1)
                && currentTouch[1].TryGetPreviousLocation(out var prevFinger2))
            {
                nextState = null;
                if (!Vector2.Normalize(prevFinger1.Position - currentTouch[0].Position)
                        .MovingInSameDirection(Vector2.Normalize(prevFinger2.Position - currentTouch[1].Position)))
                {
                    TouchStateMachine.SubmitGestureEvent(new TwoFingeredDragEventArgs(GestureTiming.Completed, new Vector2()));
                    nextState = new RotateAndScaleState(this);
                    return true;
                }
            }

            var midpoint = Vector2.Lerp(currentTouch[0].Position, currentTouch[1].Position, 0);

            TouchStateMachine.SubmitGestureEvent(new TwoFingeredDragEventArgs(GestureTiming.InProgress, midpoint));

            nextState = null;
            return false;
        }
    }
}