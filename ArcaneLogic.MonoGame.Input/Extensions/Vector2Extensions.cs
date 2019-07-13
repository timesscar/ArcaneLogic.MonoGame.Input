// ----------------------------------------------------------------------------------------------
//  <copyright file="Vector2Extensions.cs" company="Arcane Logic">
//      Copyright (c) Arcane Logic.  All rights reserved.
//  </copyright>
//  
//  <author email="matt.wilson@arcanelogic.net">
//       Matt Wilson
//  </author>
// ---------------------------------------------------------------------------------------------- 

namespace ArcaneLogic.MonoGame.Input.Extensions
{
    using System;
    using System.Diagnostics;
    using Microsoft.Xna.Framework;

    public static class Vector2Extensions
    {
        /// <summary>
        /// Gets the angle in degrees of a vector assuming its base it as 0,0
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <returns>The angle</returns>
		public static float GetAngleDegrees(this Vector2 vector)
        {
            if (vector.X == 0)
                return (vector.Y > 0) ? 90 : (vector.Y == 0) ? 0 : 270;
            else if (vector.Y == 0) // special cases
                return (vector.X >= 0) ? 0 : 180;
            var ret = MathHelper.ToDegrees((float)Math.Atan((float)vector.Y / vector.X));
            if (vector.X < 0 && vector.Y < 0) // quadrant Ⅲ
                ret = 180 + ret;
            else if (vector.X < 0) // quadrant Ⅱ
                ret = 180 + ret; // it actually substracts
            else if (vector.Y < 0) // quadrant Ⅳ
                ret = 270 + (90 + ret); // it actually substracts

            return ret;
        }

        /// <summary>
        /// Gets the angle of a vector in radians
        /// </summary>
        /// <param name="vector">The vector</param>
        /// <returns>The angle</returns>
		public static float GetAngleRadians(this Vector2 vector)
        {
            return MathHelper.ToRadians(GetAngleDegrees(vector));
        }

        /// <summary>
        /// Determines whether or not two vectors are moving in the same direction
        /// </summary>
        /// <param name="first">The first vector</param>
        /// <param name="second">The second vector</param>
        /// <returns>A value indicating whether or not the two vectors are moving in the same direction</returns>
		public static bool MovingInSameDirection(this Vector2 first, Vector2 second)
        {
            var dot = Vector2.Dot(first, second);

            return dot > 0;
        }
    }
}