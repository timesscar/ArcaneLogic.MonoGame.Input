// ----------------------------------------------------------------------------------------------
//  <copyright file="TouchStateMachine.cs" company="Arcane Logic">
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
    using System.Collections.Generic;
    using System.Diagnostics;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input.Touch;

    public class TouchStateMachine
    {
        private static readonly Queue<TouchEventArgsBase> EncounteredGestures = new Queue<TouchEventArgsBase>();

        public TouchStateMachine()
        {
            this.CurrentState = new WaitingState();
        }

        public event EventHandler<TouchEventArgsBase> GestureComplete;

        public event EventHandler<TouchEventArgsBase> GestureInProgress;

        public event EventHandler<TouchEventArgsBase> GestureStarted;

        /// <summary>
        /// Gets a value indicating whether a gesture has been submitted to the base class
        /// </summary>
        public static bool GestureAvailable { get; private set; }

        public static TouchStateConfiguration Configuration { get; set; } = new TouchStateConfiguration();

        public TouchStateBase CurrentState { get; private set; }

        /// <summary>
        /// Dequeues an available gesture.
        /// </summary>
        /// <returns>The touch event metadata</returns>
        internal static TouchEventArgsBase DequeueGestureData()
        {
            var gesture = EncounteredGestures.Dequeue();

            if (EncounteredGestures.Count == 0)
                GestureAvailable = false;

            return gesture;
        }

        /// <summary>
        /// Submits a gesture event for the state machine to process
        /// </summary>
        /// <param name="metadata">The touch event metadata.</param>
        internal static void SubmitGestureEvent(TouchEventArgsBase metadata)
        {
            EncounteredGestures.Enqueue(metadata);

            GestureAvailable = true;
        }

        public void Update(GameTime gameTime)
        {
            var current = TouchPanel.GetState();
            if (this.CurrentState.Update(gameTime, current, out var nextState))
            {
                Debug.WriteLine($"Transitioning to {nextState}.");

                if (nextState != null)
                    this.CurrentState = nextState;
            }

            if (GestureAvailable)
                this.DequeueAllGestures();
        }

        private void DequeueAllGestures()
        {
            while (GestureAvailable)
            {
                var gesture = DequeueGestureData();

                switch (gesture.State)
                {
                    case GestureTiming.Started:
                        this.GestureStarted?.Invoke(this, gesture);
                        break;
                    case GestureTiming.InProgress:
                        this.GestureInProgress?.Invoke(this, gesture);
                        break;
                    case GestureTiming.Completed:
                        this.GestureComplete?.Invoke(this, gesture);
                        break;
                }
            }
        }
    }
}