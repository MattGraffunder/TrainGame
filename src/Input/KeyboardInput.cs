﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TrainGame.Input
{
    class KeyboardInput : GameInput
    {
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        public bool Delete { get; set; }

        public override void Update(GameTime gametime)
        {
            //ResetDirections();

            XDirection = 0;
            YDirection = 0;

            Jump = false;
            Delete = false;

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.LeftShift))
            {
                Delete = true;
            }

            //if(previousKeyboardState.IsKeyUp(Keys.Up) && currentKeyboardState.IsKeyDown(Keys.Up))
            //{
            //    Jump = true;
            //}

            //// Keyboard and GamePad Dpad Controls
            //if (currentKeyboardState.IsKeyDown(Keys.Left))
            //{
            //    XDirection += -1;
            //}

            //if (currentKeyboardState.IsKeyDown(Keys.Right))
            //{
            //    XDirection += 1;
            //}

            //if (currentKeyboardState.IsKeyDown(Keys.Up))
            //{
            //    YDirection += -1;
            //}

            //if (currentKeyboardState.IsKeyDown(Keys.Down))
            //{
            //    YDirection += 1;
            //}

            //Fire = currentKeyboardState.IsKeyDown(Keys.Space);
            //Exit = currentKeyboardState.IsKeyDown(Keys.Escape);

            //Pause is when Left Control is Pressed currently, and was not pressed before
            //Pause = currentKeyboardState.IsKeyDown(Keys.LeftControl) 
            //    && previousKeyboardState.IsKeyUp(Keys.LeftControl);
        }
    }
}