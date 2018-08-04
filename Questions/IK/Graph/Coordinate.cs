using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Graph
{
    public class Coordinate
    {
        public int r;
        public int c;
        public Coordinate(int r, int c)
        {
            this.c = c;
            this.r = r;
        }

        public override bool Equals(object obj)
        {
            var temp = obj as Coordinate;
            return (temp.c == c && temp.r == r);
        }
        public override int GetHashCode()
        {
            return r.GetHashCode() ^ c.GetHashCode();
        }
    }
}
