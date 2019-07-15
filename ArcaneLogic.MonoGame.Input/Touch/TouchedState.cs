// ----------------------------------------------------------------------------------------------
//  <copyright file="TouchedState.cs" company="Arcane Logic">
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
    /// State when the screen has been touched by any number of fingers and not yet released
    /// </summary>
    /// <seealso cref="TouchStateBase" />
    public class TouchedState : TouchStateBase
    {
        private TouchCollection previousTouch;

        private float touchedTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="TouchedState" /> class.
        /// </summary>
        /// <param name="previousState">State of the previous.</param>
        /// <param name="previousTouch">The previous touch.</param>
        public TouchedState(TouchCollection previousTouch)
        {
            this.previousTouch = previousTouch;
        }

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
            this.touchedTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (this.touchedTimer > TouchStateMachine.Configuration.TouchDelay || currentTouch.Count > 1)
            {
                nextState = new GestureActiveState();
                return true;
            }

            if (currentTouch.Any())
            {
                if (currentTouch.Count == 1)
                {
                    var prevFirst = this.previousTouch[0].Position;
                    var currFirst = currentTouch[0].Position;

                    var direction = Vector2.Normalize(currFirst - prevFirst);
                    var distance = Vector2.Distance(currFirst, prevFirst);

                    if (distance > TouchStateMachine.Configuration.FlickDistance)
                    {
                        TouchStateMachine.SubmitGestureEvent(new FlickEventArgs(prevFirst, direction, distance));
                        nextState = new CooldownState();
                        return true;
                    }
                }

                this.previousTouch = currentTouch;
                nextState = null;
                return false;
            }

            TouchStateMachine.SubmitGestureEvent(new TapEventArgs(this.previousTouch[0].Position, GestureTiming.Started));
            nextState = new TappedState(this.previousTouch[0].Position);
            return true;
        }
    }
}