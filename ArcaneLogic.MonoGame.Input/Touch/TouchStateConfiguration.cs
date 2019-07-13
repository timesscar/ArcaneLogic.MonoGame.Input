// ----------------------------------------------------------------------------------------------
//  <copyright file="TouchStateConfiguration.cs" company="Arcane Logic">
//      Copyright (c) Arcane Logic.  All rights reserved.
//  </copyright>
//  
//  <author email="matt.wilson@arcanelogic.net">
//       Matt Wilson
//  </author>
// ---------------------------------------------------------------------------------------------- 

namespace ArcaneLogic.MonoGame.Input.Touch
{
    public class TouchStateConfiguration
    {
        /// <summary>
        /// Gets or sets the time in millseconds that the gesture
        /// state machine should pause between completed gestures
        /// </summary>
        public int CooldownTime { get; set; } = 100;

        /// <summary>
        /// Gets or sets the distance at which a single finger tap becomes a flick
        /// </summary>
        public float FlickDistance { get; set; } = 50;

        /// <summary>
        /// Gets or sets the time in millseconds that the gesture state machine should wait before declaring
        /// a tap complete
        /// </summary>
        public int TapDelay { get; set; } = 150;

        /// <summary>
        /// Gets or sets the time in milliseconds that the gesture state machine should wait before it starts
        /// a gesture while the screen is touched by a single finger
        /// </summary>
        public int TouchDelay { get; set; } = 150;
    }
}