// ----------------------------------------------------------------------------------------------
//  <copyright file="CooldownState.cs" company="Arcane Logic">
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

    /// <summary>
    /// A state machine state when a gesture has just been completed.  Waits 100 ms before releasing
    /// </summary>
    /// <seealso cref="TouchStateBase" />
    public class CooldownState : TouchStateBase
    {
        private float cooldown;

        /// <summary>
        /// Initializes a new instance of the <see cref="CooldownState"/> class.
        /// </summary>
        /// <param name="previousState">The previous state machine state</param>
        public CooldownState(TouchStateBase previousState)
            : base(previousState)
        {
        }

        /// <summary>
        /// Updates the specified game time.
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <param name="currentTouchout">The current touchout.</param>
        /// <param name="nextState">State of the next.</param>
        /// <returns></returns>
        public override bool Update(GameTime gameTime, TouchCollection currentTouchout, out TouchStateBase nextState)
        {
            if (this.cooldown > TouchStateMachine.Configuration.CooldownTime)
            {
                nextState = new WaitingState(this);
                return true;
            }

            this.cooldown += gameTime.ElapsedGameTime.Milliseconds;

            nextState = null;
            return false;
        }
    }
}