// ----------------------------------------------------------------------------------------------
//  <copyright file="FlickEventArgs.cs" company="Arcane Logic">
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

    public class FlickEventArgs : TouchEventArgsBase
    {
        public FlickEventArgs(Vector2 startingPosition, Vector2 direction, float distance)
            : base(GestureTiming.Completed)
        {
            this.Distance = distance;
            this.Direction = direction;
            this.Start = startingPosition;
        }

        public Vector2 Direction { get; private set; }

        public float Distance { get; private set; }

        public Vector2 Start { get; private set; }
    }
}