﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace TrainGame.Input
{
    class GamePadInput:GameInput
    {
        GamePadState currentGamePadState;
        //GamePadState previousGamePadState;

        public override void Update(GameTime gametime)
        {
            XDirection = (int)Math.Round(currentGamePadState.ThumbSticks.Left.X, 0);
            YDirection = (int)Math.Round(currentGamePadState.ThumbSticks.Left.Y, 0);

            Jump = (currentGamePadState.Buttons.X == ButtonState.Pressed);
            Exit = currentGamePadState.Buttons.Back == ButtonState.Pressed;

            //Pause is when Start Button is Pressed currently, and was not pressed before
            Pause = currentGamePadState.Buttons.Start == ButtonState.Pressed 
                && currentGamePadState.Buttons.Start == ButtonState.Released;
        }
    }
}