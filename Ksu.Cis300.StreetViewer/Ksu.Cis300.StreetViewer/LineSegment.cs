using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.StreetViewer
{
    public struct LineSegment
    {
        private PointF _start;
        private PointF _end;
        private Pen _nPen;
        //private Pen nPen = new Pen(Color.White);
        public void Constructor(PointF s, PointF e, Pen p)
        {
            //Pen nPen = new Pen(Color.White);
            _nPen = p;
            int t = s.X.CompareTo(e.X);
            if (t < 0)
            {
                _start = s;
                _end = e;
            }
            else                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
                _start = e;
                _end = s;
        }
        public void drawLine(Graphics g,int scale)
        {
            //Point x = start.
            float x1 = _start.X * scale;
            float y1 = _start.Y * scale;
            float x2 = _end.X * scale;
            float y2 = _end.Y * scale;
            g.DrawLine(_nPen, x1,y1,x2,y2);

        }
        public bool Intersect(RectangleF p)
        {
            float y = _start.Y - _end.Y;
            float x = _start.X - _end.X;
            float slope = y / x;
            if(x == 0 && y > 0)
            {
                slope = Single.PositiveInfinity;

            }
            else if(x == 0 && y < 0)
            {
                slope = Single.NegativeInfinity;

            }
            float xCoord = (y - _start.Y) / slope;
            xCoord += _start.X;
            float yCoord = (x - _start.X) / slope;
            yCoord += _start.Y;
            PointF new1 = new PointF(xCoord, yCoord);

            if (p.Contains(xCoord, yCoord))
            {
                return false;

            }
            else if (p.X.CompareTo(xCoord) < 0 && p.Y.CompareTo(yCoord) < 0)
            {
                return true;

            }
            else if (p.X.CompareTo(xCoord) > 0 && p.Y.CompareTo(yCoord) > 0)
            {
                return true;
            }
            else if(p.Left.CompareTo(xCoord) > 0)
            {
                return false;
            }
            else if(p.Top.CompareTo(yCoord) < 0)
            {
                return false;
            }
            else if (p.Bottom.CompareTo(yCoord) > 0)
            {
                return false;

            }
            else
            {
              return true;
            }

            
        }
    }
}
