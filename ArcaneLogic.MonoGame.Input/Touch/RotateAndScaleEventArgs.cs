// ----------------------------------------------------------------------------------------------
//  <copyright file="RotateAndScaleEventArgs.cs" company="Arcane Logic">
//      Copyright (c) Arcane Logic.  All rights reserved.
//  </copyright>
//  
//  <author email="matt.wilson@arcanelogic.net">
//       Matt Wilson
//  </author>
// ---------------------------------------------------------------------------------------------- 

namespace ArcaneLogic.MonoGame.Input.Touch
{
    public class RotateAndScaleEventArgs : TouchEventArgsBase
    {
        public RotateAndScaleEventArgs(GestureTiming state, float zoom, float rotate)
            : base(state)
        {
            this.Zoom = zoom;
            this.Rotate = rotate;
        }

        public float Rotate { get; private set; }

        public float Zoom { get; private set; }
    }
}