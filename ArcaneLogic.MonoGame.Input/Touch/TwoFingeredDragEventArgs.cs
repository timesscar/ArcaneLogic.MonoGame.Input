// ----------------------------------------------------------------------------------------------
//  <copyright file="TwoFingeredDragEventArgs.cs" company="Arcane Logic">
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

    public class TwoFingeredDragEventArgs : TouchEventArgsBase
    {
        public TwoFingeredDragEventArgs(GestureTiming state, Vector2 position)
            : base(state)
        {
            this.Position = position;
        }

        public Vector2 Position { get; private set; }
    }
}