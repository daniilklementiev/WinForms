using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms.Services
{
    public class SimpleRandom : IRandom
    {
        private double state;
        public SimpleRandom()
        {
            state = DateTime.Now.Ticks / 1e17;
        }
        public double NextDouble()
        {
            state = (state + Math.PI) * state;
            state = state - Math.Floor(state);
            return state;
        }
    }
}
