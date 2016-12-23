using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;

namespace TrainGame.Input
{
    abstract class GameInput
    {
        //Movement Direction
        public int XDirection { get; set; }
        public int YDirection { get; set; }

        ////Fire Weapon
        public bool Jump { get; set; }

        //Exit Game
        public bool Exit { get; set; }

        //Pause 
        public bool Pause { get; set; }

        public abstract void Update(GameTime gametime); 
    }
}