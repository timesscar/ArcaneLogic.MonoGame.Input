// ----------------------------------------------------------------------------------------------
//  <copyright file="GestureActiveState.cs" company="Arcane Logic">
//      Copyright (c) Arcane Logic.  All rights reserved.
//  </copyright>
//  
//  <author email="matt.wilson@arcanelogic.net">
//       Matt Wilson
//  </author>
// ---------------------------------------------------------------------------------------------- 

namespace ArcaneLogic.MonoGame.Input.Touch
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input.Touch;

    public class GestureActiveState : TouchStateBase
    {
        public override bool Update(GameTime gameTime, TouchCollection currentTouch, out TouchStateBase nextState)
        {
            switch (currentTouch.Count)
            {
                case 1:
                    nextState = TouchStateMachine.GetTouchState(typeof(DragState));
                    TouchStateMachine.SubmitGestureEvent(new DragEventArgs(GestureTiming.Started, currentTouch[0].Position));
                    return true;
                case 2:
                    TouchStateMachine.SubmitGestureEvent(new RotateAndScaleEventArgs(GestureTiming.Started, 0, 0));
                    nextState = TouchStateMachine.GetTouchState(typeof(RotateAndScaleState));

                    return true;
                default:
                    // bail because no gesture is active anymore
                    nextState = new WaitingState();
                    return true;
            }
        }
    }
}