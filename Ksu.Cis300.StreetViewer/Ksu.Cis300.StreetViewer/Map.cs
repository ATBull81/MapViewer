using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace Ksu.Cis300.StreetViewer
{
    public partial class Map : UserControl
    {
        public Map()
        {
            InitializeComponent();
            DoubleBuffered.Equals(true);
            
        }

        public bool CanZoomIn
        { 
            get
            {
                return _zoom > _maximumZoom;
            }

            set
            {
                
            }
        }

        public bool CanZoomOut
        {
            get
            {
                return _zoom > 0;
                
            }

            set
            {
            }
        }

        private const float _maximumHeight = 1;
        private const float _maximumWidth = 2;
        private const int _maximumZoom = 6;
        private const int _minimumScale = 500;
        private int _scale;
        private int _zoom;
        private QuadTree _lineTree = null;
        private RectangleF _newRect;
        Size _newSize = new Size();

        //System.Windows.Forms.UserControl DoubleBuffered;

        /// <summary>
        /// This method sets the bounds for the map to appear in
        /// </summary>
        /// <param name="p">the xmlreader provided by Form1</param>
        /// <returns></returns>
        public RectangleF GetActualBounds(XmlReader p)
        {
            
            float a = Single.MaxValue;
            float b = Single.MaxValue;
            float c = Single.MinValue;
            float d = Single.MinValue;
            while(p.Read() && !p.Name.Equals("node"))
            {
                XmlNodeType t = p.NodeType;
                //while(!p.Name.Equals("node"))
                //{
                    if (p.NodeType.Equals(XmlNodeType.Element) && p.Name.Equals("bounds"))
                    { 
                        while(p.MoveToNextAttribute())
                        {
                            if(p.Name.Equals("minlat"))
                            {
                                c = Convert.ToSingle(p.Value);
                            }
                            if (p.Name.Equals("minlon"))
                            {
                                d = Convert.ToSingle(p.Value);
                            }
                            if (p.Name.Equals("maxlat"))
                            {
                                a = Convert.ToSingle(p.Value);
                            }
                            if (p.Name.Equals("maxlon"))
                            {
                                b = Convert.ToSingle(p.Value);
                            }
                        }
                    //}
                }

            }

                float tempH = a - c;
                float tempW = b - d;
                Height.Equals(a);
            if (tempW > 0 && tempW <= _maximumWidth && tempH > 0 && tempH <= _maximumHeight)
            {
                return _newRect = new RectangleF(d, c, tempW, tempH);
            }
            else
            {
                throw new System.IO.IOException("Bounds in the correct range were not provided");
            }
        }

        /// <summary>
        /// This method gathers all the LineSegments from the read-in file,
        /// and then compiles them all into one TreeNode
        /// </summary>
        /// <param name="p">XmlReader gained from OpenMap in Form1</param>
        /// <param name="s">List created by GetNodes method</param>
        /// <returns></returns>
        public QuadTree GetLines(XmlReader p,List<Node> s)
        {
            Pen linePen = new Pen(Color.White);
            List<Node> lineNode = new List<Node>(_zoom);
            float lineW;
            long refVal = 0;
            Node refNode = new Node();
            Rectangle newRe = new Rectangle(0, 0, Convert.ToInt32(_maximumWidth), Convert.ToInt32(_maximumHeight));
            QuadTree tempQuad = new QuadTree(_zoom,newRe);
            string highType = "";

            string highValue = "";

            do
            {
                do
                {
                    if (p.Name.Equals("nd"))
                    {
                        while (p.MoveToNextAttribute())
                        {
                            if (p.Name.Equals("ref"))
                            {

                                refVal = Convert.ToInt32(p.Value);
                                //refVal *= -1;
                                refNode.Constructor(refVal, new PointF());
                                int pos = s.BinarySearch(refNode);
                                
                                if (pos > 0)
                                {
                                    lineNode.Add(s[pos]);
                                }

                            }
                        }
                    }
                    else if (p.Name.Equals("tag"))
                    {
                        while (p.MoveToNextAttribute())
                        {

                            if (p.Name.Equals("k"))
                            {
                                highType = p.Value;
                            }
                            else if (p.Name.Equals("v"))
                            {
                                highValue = p.Value;
                            }
                            if (highType.Equals("highway"))
                            {
                                if (highValue.Equals("motorway"))
                                {
                                    _zoom = 0;
                                    lineW = 3;
                                    linePen.Color = Color.Purple;
                                    linePen.Width = lineW;
                                }
                                else if (highValue.Equals("trunk"))
                                {
                                    _zoom = 0;
                                    lineW = 3;
                                    linePen.Color = Color.Orange;
                                    linePen.Width = lineW;
                                }
                                else if (highValue.Equals("primary"))
                                {
                                    _zoom = 0;
                                    lineW = 2;
                                    linePen.Color = Color.Red;
                                    linePen.Width = lineW;
                                }
                                else if (highValue.Equals("secondary"))
                                {
                                    _zoom = 0;
                                    lineW = 1;
                                    linePen.Color = Color.Red;
                                    linePen.Width = lineW;
                                }
                                else if (highValue.Equals("tertiary")) //1 zoom
                                {
                                    _zoom = 1;
                                    lineW = 1;
                                    linePen.Color = Color.Black;
                                    linePen.Width = lineW;
                                }
                                else if (highValue.Equals("unclassified")) //3 zoom
                                {
                                    _zoom = 3;
                                    lineW = 1;
                                    linePen.Color.Equals(Color.Gray);
                                    linePen.Width = lineW;
                                }
                                else if (highValue.Equals("residential")) //3 zoom
                                {
                                    _zoom = 3;
                                    lineW = 1;
                                    linePen.Color = Color.Gray;
                                    linePen.Width = lineW;
                                }
                                else if (highValue.Equals("service")) //6 zoom
                                {
                                    _zoom = 6;
                                    lineW = 0.5f;
                                    linePen.Color = Color.LightBlue;
                                    linePen.Width = lineW;
                                }
                                else if (highValue.Equals("motorway_link")) //4 zoom
                                {
                                    _zoom = 4;
                                    lineW = 2;
                                    linePen.Color = Color.Purple;
                                    linePen.Width = lineW;
                                }
                                else if (highValue.Equals("truck_link")) //4 zoom
                                {
                                    _zoom = 4;
                                    lineW = 2;
                                    linePen.Color = Color.Orange;
                                    linePen.Width = lineW;
                                }
                                else if (highValue.Equals("primary_link")) //4 zoom
                                {
                                    _zoom = 4;
                                    lineW = 1;
                                    linePen.Color = Color.Red;
                                    linePen.Width = lineW;
                                }
                                else if (p.Value.Equals("secondary_link")) //5 zoom
                                {
                                    _zoom = 5;
                                    lineW = 1;
                                    linePen.Color = Color.Red;
                                    linePen.Width = lineW;
                                }
                                else if (highValue.Equals("tertiary_link")) //6 zoom
                                {
                                    _zoom = 6;
                                    lineW = 1;
                                    linePen.Color = Color.Black;
                                    linePen.Width = lineW;
                                }
                            }
                        }
                    }
                } while (p.Read() && !p.NodeType.Equals(XmlNodeType.EndElement)); 

                if (!(linePen.Brush.Equals(Color.White)) && _zoom > -1)
                {
                   
                    LineSegment newLine = new LineSegment();
                    //PointF newPoint;
                    //PointF newPoint2;
                    //QuadTree returnNode;

                    for (int z = 0; z < lineNode.Count - 1; z++)
                    {
                        newLine.Constructor(lineNode[z].Location(), lineNode[z + 1].Location(), linePen);
                        tempQuad.AddSegment(newLine, _zoom);
                    }
                    //return tempQuad;
                }
           } while (!p.NodeType.Equals("node"));
            return tempQuad;
        }





        /// <summary>
        /// This method gathers all the nodes from the original file into a list.
        /// </summary>
        /// <param name="p">xmlReader we are given by Form1</param>
        /// <returns></returns>
        public List<Node> GetNodes(XmlReader p)
        {
            List<Node> k = new List<Node>();

            do
            {

                if (p.NodeType.Equals(XmlNodeType.Element) && p.Name.Equals("node"))
                {
                    float c = 0;
                    float b = 0;
                    long a = 0;

                    while (p.MoveToNextAttribute())
                    {
                        if (p.Name.Equals("lat"))
                        {
                            double z = Convert.ToDouble(p.Value);
                            b = (float)  Math.Cos(z*Math.PI);
                            //Node d = new Node();

                        }
                        if (p.Name.Equals("id"))
                        {   
                            a =  Convert.ToInt32(p.Value);
                        }
                        if (p.Name.Equals("lon"))
                        {
                            double z = Convert.ToDouble(p.Value);
                            c = (float)Math.Cos(z * Math.PI);
                        }
                        
                    }

                PointF n = new PointF(b, c);
                    Node newNode = new Node();
                    newNode.Constructor(a, n);
                    
                    k.Add(newNode);

                }

            } while (p.Name.Equals("node"));
            
            k.Sort();
            return k;
        }

        /// <summary>
        /// This method overrides the original OnPaint method, causing it to run new instructions
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.Clip = new Region(e.ClipRectangle);
            if (_lineTree != null)
            {
                _lineTree.Draw(g, _scale, _zoom); 
            }
        }


        /// <summary>
        /// This is where the Form1 information is sent into.
        /// This method runs through 3 methods to build the map.
        /// </summary>
        /// <param name="p">XmlReader we get from Form1</param>
        public void ReadData(XmlReader p)
        {
            RectangleF newRect = GetActualBounds(p);
            List<Node> listNode = new List<Node>(GetNodes(p));
            QuadTree lineTree = GetLines(p,listNode);
            _newSize.Height = Convert.ToInt32(newRect.Height * _minimumScale);
            _newSize.Width = Convert.ToInt32(newRect.Width * Math.Cos((newRect.Y + (newRect.Y + newRect.Height) / 2) * (Math.PI / 180)));
            Invalidate();
        }
        /// <summary>
        /// Method adjusts the _scale and _zoom values and zooms in
        /// </summary>
        public void ZoomIn()
        {
            _scale *= 2;
            _zoom ++;
            _newSize.Height = Size.Width;
            _newSize.Width = Size.Height;
            Invalidate();
        }

        /// <summary>
        /// Method adjusts the _scale and _zoom values and zooms in
        /// </summary>
        public void ZoomOut()
        {
            _scale /= 2;
            _zoom --;
            _newSize.Height = Size.Height;
            _newSize.Width = Size.Width;
            Invalidate();
        }
    }
    }