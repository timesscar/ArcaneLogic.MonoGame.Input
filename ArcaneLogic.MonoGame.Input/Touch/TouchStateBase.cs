// ----------------------------------------------------------------------------------------------
//  <copyright file="TouchStateBase.cs" company="Arcane Logic">
//      Copyright (c) Arcane Logic.  All rights reserved.
//  </copyright>
//  
//  <author email="matt.wilson@arcanelogic.net">
//       Matt Wilson
//  </author>
// ---------------------------------------------------------------------------------------------- 

namespace ArcaneLogic.MonoGame.Input.Touch
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input.Touch;

    /// <summary>
    /// Provides common functionality for touch state machine states
    /// </summary>
    public abstract class TouchStateBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TouchStateBase"/> class.
        /// </summary>
        /// <param name="previousState">The previous state machine state</param>
        protected TouchStateBase(TouchStateBase previousState)
        {
            previousState?.ClearPrevious();
            this.Previous = previousState;
        }

        /// <summary>
        /// Gets the previous state machine state
        /// </summary>
        public TouchStateBase Previous { get; private set; }

        /// <summary>
        /// Updates the current machine state
        /// </summary>
        /// <param name="gameTime">The game time.</param>
        /// <param name="currentTouch">The current touch.</param>
        /// <param name="nextState">The next state in the state machine.</param>
        /// <returns>A value indicating whether or not the state machine should advance to the next state</returns>
        public abstract bool Update(GameTime gameTime, TouchCollection currentTouch, out TouchStateBase nextState);

        /// <summary>
        /// Clears the previous touch state
        /// </summary>
        private void ClearPrevious()
        {
            this.Previous = null;
        }
    }
}