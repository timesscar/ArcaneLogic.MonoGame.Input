// ----------------------------------------------------------------------------------------------
//  <copyright file="WaitingState.cs" company="Arcane Logic">
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

    /// <summary>
    /// A state machine state when waiting for a touch event
    /// </summary>
    /// <seealso cref="TouchStateBase" />
    public class WaitingState : TouchStateBase
    {
        /// <summary>
        /// Updates the current machine state
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <param name="currentTouch">The current touch.</param>
        /// <param name="nextState">The next state in the state machine.</param>
        /// <returns>
        /// A value indicating whether or not the state machine should advance to the next state
        /// </returns>
        public override bool Update(GameTime gameTime, TouchCollection currentTouch, out TouchStateBase nextState)
        {
            var touched = currentTouch.Any();

            if (touched)
            {
                nextState = TouchStateMachine.GetTouchState(typeof(TouchedState));
                return true;
            }

            nextState = null;
            return false;
        }
    }
}