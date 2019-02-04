using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.StreetViewer
{
    public class QuadTree
    {
        QuadTree[] _qTree = new QuadTree[4];
        private RectangleF recNode;
        List<LineSegment> lineNode = new List<LineSegment>();

        public QuadTree(int h, RectangleF a)
        {
            recNode = a;
            if(h > 0)
            {
                _qTree[0] = new QuadTree(h - 1, new RectangleF(recNode.X, recNode.Y, (recNode.Width / 2), (recNode.Height / 2)));
                _qTree[1] = new QuadTree(h - 1, new RectangleF((recNode.X + recNode.Width) / 2, recNode.Y, (recNode.Width / 2), (recNode.Height / 2)));
                _qTree[2] = new QuadTree(h - 1, new RectangleF(recNode.X, (recNode.Y + recNode.Height) / 2, (recNode.Width / 2), (recNode.Height / 2)));
                _qTree[3] = new QuadTree(h - 1, new RectangleF((recNode.X + recNode.Width)/2, (recNode.Y + recNode.Height) / 2, (recNode.Width / 2), (recNode.Height / 2)));

            }
            

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <param name="d"></param>
        public void AddSegment(LineSegment n,int d)
        {
            if(d == 0)
            {
                lineNode.Add(n);
            }
            else
            {
                foreach(QuadTree item in _qTree)
                {
                    item.AddSegment(n, d - 1);
                }
            }
        }
        /// <summary>
        /// Drawing the map with the size correct.
        /// </summary>
        /// <param name="g">Graphics field</param>
        /// <param name="scaleFactor">How big the whole thing should be shrunk or grow by</param>
        /// <param name="maxDepth"></param>
        public void Draw(Graphics g,int scaleFactor, int maxDepth)
        {
            float p = g.ClipBounds.X / scaleFactor;
            float x = g.ClipBounds.Y / scaleFactor;
            Pen w = new Pen(Color.Red);
            RectangleF z = new RectangleF();
            z.X = p;
            z.Y = p;

            if (recNode.IntersectsWith(z)== true)
            {
                g.DrawLine(w, recNode.X, recNode.Y, z.X, z.Y);
                if(maxDepth > 0)
                {  
                    Draw(g, scaleFactor, maxDepth - 1);
                }
            }
            else if(maxDepth > 0)
            {
                for (int k = 0; k < 4; k++)
                {
                    _qTree[k].Draw(g, scaleFactor,maxDepth-1);
                }

            }
        }
    }
}
