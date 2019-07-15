# ArcaneLogic.MonoGame.Input
Input helpers for the MonoGame framework


Includes a touch state machine that is reasonably performant and I think works better than the existing gesture engine.

0.8.3 is the first working prerelease version.  It has some unnecessary garbage collection and 1.0.0 should be more memory efficient.

To use;

var stateMachine = new TouchStateMachine();

stateMachine.GestureStarted += YourMethod;

public void YourMethod(object sender, TouchEventArgsBase e)
{
  // Handle the event
}

Then in your update loop call stateMachine.Update(gameTime);
