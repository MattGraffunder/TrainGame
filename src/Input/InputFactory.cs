using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainGame.Input
{
    static class InputFactory
    {
        public static GameInput GetInput()
        {
            //return new MouseInput();
            return new KeyboardInput();
            //return new GamePadInput();
        }
    }
}