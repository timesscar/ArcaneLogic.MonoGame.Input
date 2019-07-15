// ----------------------------------------------------------------------------------------------
//  <copyright file="DragState.cs" company="Arcane Logic">
//      Copyright (c) Arcane Logic.  All rights reserved.
//  </copyright>
//  
//  <author email="matt.wilson@arcanelogic.net">
//       Matt Wilson
//  </author>
// ---------------------------------------------------------------------------------------------- 

namespace ArcaneLogic.MonoGame.Input.Touch
{
    using System.Linq;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input.Touch;

    public class DragState : TouchStateBase
    {
        public DragState(TouchStateBase previousState)
            : base(previousState)
        {
        }

        public override bool Update(GameTime gameTime, TouchCollection currentTouch, out TouchStateBase nextState)
        {
            if (currentTouch.Count != 1)
            {
                nextState = new CooldownState(this);
                TouchStateMachine.SubmitGestureEvent(new DragEventArgs(GestureTiming.Completed, new Vector2()));
                return true;
            }

            TouchStateMachine.SubmitGestureEvent(new DragEventArgs(GestureTiming.InProgress, currentTouch.First().Position));
            nextState = null;
            return false;
        }
    }
}