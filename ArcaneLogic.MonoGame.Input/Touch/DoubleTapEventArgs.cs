// ----------------------------------------------------------------------------------------------
//  <copyright file="DoubleTapEventArgs.cs" company="Arcane Logic">
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

    public class DoubleTapEventArgs : TouchEventArgsBase
    {
        public DoubleTapEventArgs(Vector2 location)
            : base(GestureTiming.Completed)
        {
            this.Location = location;
        }

        public Vector2 Location { get; private set; }
    }
}