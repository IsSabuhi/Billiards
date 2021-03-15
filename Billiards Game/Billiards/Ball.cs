using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Billiards;

namespace Billiards
{
    public class Ball
    {
        public Vector position;
        public Color color;
        public Vector velocity;

        public Ball(Color color, Vector position)
        {
            this.position = position;
            this.color = color;
            this.velocity = new Vector();
        }
    }
}
