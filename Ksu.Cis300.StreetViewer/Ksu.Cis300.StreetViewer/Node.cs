using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Ksu.Cis300.StreetViewer
{
    public struct Node : IComparable<Node>
    {
        
        private long _nodeID;
        private PointF _nodeLoc;

        public Node(long id, PointF n)
        {
            _nodeID = id;
            _nodeLoc = n;
        }

        /// <summary>
        /// Constructs the node
        /// </summary>
        /// <param name="id">Stored information about Node</param>
        /// <param name="n">PointF provided, shows where Node is located</param>
        public void Constructor(long id, PointF n)
        {
            _nodeID = id;
            _nodeLoc = n;
        }
        
        /// <summary>
        /// Compares current stored node to other nodes entered.
        /// </summary>
        /// <param name="other">any node sent in</param>
        /// <returns></returns>
        public int CompareTo(Node other)
        {
            return other._nodeID.CompareTo(_nodeID);
        }
        public PointF Location()
        {
            return _nodeLoc;
        }
    }
}
