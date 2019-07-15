// ----------------------------------------------------------------------------------------------
//  <copyright file="TappedState.cs" company="Arcane Logic">
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
    /// A state machine state that occurs when the screen is touched and released in less than 300ms
    /// </summary>
    /// <seealso cref="TouchStateBase" />
    public class TappedState : TouchStateBase
    {
        private float delayTimer;

        private bool fingerDown;

        /// <summary>
        /// Initializes a new instance of the <see cref="TappedState"/> class.
        /// </summary>
        /// <param name="previousState">State of the previous.</param>
        /// <param name="position">The position.</param>
        public TappedState(Vector2 position)
        {
            this.TapLocation = position;
        }

        /// <summary>
        /// Gets the tap location.
        /// </summary>
        public Vector2 TapLocation { get; private set; }

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
            this.delayTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (this.delayTimer > TouchStateMachine.Configuration.TapDelay)
            {
                TouchStateMachine.SubmitGestureEvent(new TapEventArgs(this.TapLocation, GestureTiming.Completed));
                nextState = new CooldownState();
                return true;
            }

            var touched = currentTouch.Any();

            if (!touched && this.fingerDown)
            {
                // TODO: detect if taps are far apart and start a new tap
                nextState = new CooldownState();
                TouchStateMachine.SubmitGestureEvent(new DoubleTapEventArgs(this.TapLocation));
                return true;
            }

            if (touched)
                this.fingerDown = true;

            nextState = null;
            return false;
        }
    }
}