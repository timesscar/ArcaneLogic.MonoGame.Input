// ----------------------------------------------------------------------------------------------
//  <copyright file="RotateAndScaleState.cs" company="Arcane Logic">
//      Copyright (c) Arcane Logic.  All rights reserved.
//  </copyright>
//  
//  <author email="matt.wilson@arcanelogic.net">
//       Matt Wilson
//  </author>
// ---------------------------------------------------------------------------------------------- 

namespace ArcaneLogic.MonoGame.Input.Touch
{
    using System;
    using ArcaneLogic.MonoGame.Input.Extensions;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input.Touch;

    public class RotateAndScaleState : TouchStateBase
    {
        public RotateAndScaleState(TouchStateBase previousState)
            : base(previousState)
        {
        }

        public override bool Update(GameTime gameTime, TouchCollection currentTouch, out TouchStateBase nextState)
        {
            if (currentTouch.Count != 2)
            {
                TouchStateMachine.SubmitGestureEvent(new RotateAndScaleEventArgs(GestureTiming.Completed, 0, 0));
                nextState = new CooldownState(this);
                return true;
            }

            if (!currentTouch[0].TryGetPreviousLocation(out var prevFinger1)
                || !currentTouch[1].TryGetPreviousLocation(out var prevFinger2))
            {
                nextState = null;
                return false;
            }

            if (Vector2.Normalize(prevFinger1.Position - currentTouch[0].Position)
                .MovingInSameDirection(Vector2.Normalize(prevFinger2.Position - currentTouch[1].Position)))
            {
                var pos = Vector2.Lerp(currentTouch[0].Position, currentTouch[1].Position, 0);
                TouchStateMachine.SubmitGestureEvent(new TwoFingeredDragEventArgs(GestureTiming.Started, pos));
                nextState = new TwoFingeredDragState(this);
                return true;
            }

            var currZoom = Vector2.Distance(currentTouch[0].Position, currentTouch[1].Position);
            var prevZoom = Vector2.Distance(prevFinger1.Position, prevFinger2.Position);

            var currAngle = (currentTouch[0].Position - currentTouch[1].Position).GetAngleDegrees();
            var prevAngle = (prevFinger1.Position - prevFinger2.Position).GetAngleDegrees();

            var diff = currAngle - prevAngle;

            // Round tiny numbers to zero to stop drift
            if (Math.Abs(diff) < .3)
                diff = 0;

            // Handle very large or very small rotation amounts caused by gimbal locks
            else if (diff > 340)
                diff = 360 - diff;
            else if (diff < -340)
                diff = -(360 + diff);

            var zoom = currZoom - prevZoom;

            // Round tiny numbers to zero to stop drift
            if (Math.Abs(zoom) < 1)
                zoom = 0;

            TouchStateMachine.SubmitGestureEvent(new RotateAndScaleEventArgs(GestureTiming.InProgress, zoom, diff));

            nextState = null;
            return false;
        }
    }
}