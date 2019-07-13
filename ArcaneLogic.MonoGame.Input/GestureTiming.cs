// ----------------------------------------------------------------------------------------------
//  <copyright file="GestureTiming.cs" company="Arcane Logic">
//      Copyright (c) Arcane Logic.  All rights reserved.
//  </copyright>
//  
//  <author email="matt.wilson@arcanelogic.net">
//       Matt Wilson
//  </author>
// ---------------------------------------------------------------------------------------------- 

namespace ArcaneLogic.MonoGame.Input
{
    /// <summary>
    /// Enumeration that describes the timing of event metadata
    /// </summary>
    public enum GestureTiming
    {
        /// <summary>
        /// Indicates that the metadata relates to the beginning of a gesture
        /// </summary>
        Started,

        /// <summary>
        /// Indicates that the metadata relates an ongoing gesture
        /// </summary>
        InProgress,

        /// <summary>
        /// Indicates that the metadata relates to the end of a gesture
        /// </summary>
        Completed
    }
}