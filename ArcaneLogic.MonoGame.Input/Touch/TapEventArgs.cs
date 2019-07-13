// ----------------------------------------------------------------------------------------------
//  <copyright file="TapEventArgs.cs" company="Arcane Logic">
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

    /// <summary>
    /// Metadata relating to a tap gesture
    /// </summary>
    /// <seealso cref="TouchEventArgsBase" />
    public class TapEventArgs : TouchEventArgsBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TapEventArgs" /> class.
        /// </summary>
        /// <param name="location">The location of the tap</param>
        /// <param name="timing">The timing.</param>
        public TapEventArgs(Vector2 location, GestureTiming timing)
            : base(timing)
        {
            this.Location = location;
        }

        /// <summary>
        /// Gets the location of the tap
        /// </summary>
        public Vector2 Location { get; private set; }
    }
}