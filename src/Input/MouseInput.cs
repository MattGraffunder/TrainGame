using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainGame.Input
{
    class MouseInput
    {
        MouseState currentMouseState;
        MouseState priorState;

        public bool Toggle { get; set; }

        public Point Position { get; set; }

        public void Update(GameTime gametime)
        {
            //Reset
            Toggle = false;

            priorState = currentMouseState;
            currentMouseState = Mouse.GetState();

            //if (priorState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
            if (currentMouseState.LeftButton == ButtonState.Pressed)
            {
                Toggle = true;

                Position = currentMouseState.Position;
            }
        }
    }
}