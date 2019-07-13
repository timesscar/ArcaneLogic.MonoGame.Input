// ----------------------------------------------------------------------------------------------
//  <copyright file="TouchEventArgsBase.cs" company="Arcane Logic">
//      Copyright (c) Arcane Logic.  All rights reserved.
//  </copyright>
//  
//  <author email="matt.wilson@arcanelogic.net">
//       Matt Wilson
//  </author>
// ---------------------------------------------------------------------------------------------- 

namespace ArcaneLogic.MonoGame.Input.Touch
{
    using System;

    public abstract class TouchEventArgsBase : EventArgs
    {
        protected TouchEventArgsBase(GestureTiming state)
        {
            this.State = state;
        }

        public GestureTiming State { get; private set; }
    }
}