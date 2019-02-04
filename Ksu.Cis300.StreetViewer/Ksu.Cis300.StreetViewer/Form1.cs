using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Ksu.Cis300.StreetViewer
{
    public partial class Form1 : Form
    {
       // private static int uxMapContainer;
       // private static int uxOpenMap;
       // private static int uxToolBar;
        private static Point uxZoomIn;
        private static Point uxZoomOut;
        private static XmlReader uxMap;
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// This method reacts to the opening of a new map; it reads the file into the program and sends information to the Map.cs . 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxOpenMouse_Click_1(object sender, EventArgs e)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fn = openFileDialog1.FileName;

                try
                {
                    using (StreamReader input = new StreamReader(fn))
                    {
                        while (!input.EndOfStream)
                        {
                            string name = input.ReadLine();
                            uxMap = XmlReader.Create(input, settings);
                            Map.ReadData(uxMap);
                        }
                    }
                    ux_ZoomIn.Enabled = true;
                    ux_ZoomOut.Enabled = false;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
        }


        /// <summary>
        /// This method attempts to zoom in on the map.
        /// </summary>
        private void ux_ZoomIn_Click(object sender, EventArgs e)
        {
            if (ux_ZoomIn.Enabled == true)
            {
                uxZoomIn = uxMapPanel.AutoScrollPosition;
                uxZoomIn.X *= -1;
                uxZoomIn.Y *= -1;
                Map.ZoomIn();
                if(Map.CanZoomIn == true)
                {
                    ux_ZoomIn.Enabled = true;
                }
                else
                {
                    ux_ZoomIn.Enabled = false;
                }
                uxZoomIn.X = 2 * uxZoomIn.X + (Map.ClientSize.Width / 2);
                uxZoomIn.Y = 2 * uxZoomIn.Y + (Map.ClientSize.Height / 2);
                Math.Min(uxZoomIn.X, Map.Size.Width - Map.ClientSize.Width);
                Math.Min(uxZoomIn.Y, Map.Size.Height - Map.ClientSize.Height);
                Map.AutoScrollPosition = new Point(uxZoomIn.X, uxZoomIn.Y);

            }
        }

        private void ux_ZoomOut_Click(object sender, EventArgs e)
        {
            if (ux_ZoomOut.Enabled == true)
            {
                uxZoomOut = uxMapPanel.AutoScrollPosition;
                uxZoomOut.X *= -1;
                uxZoomOut.Y *= -1;
                Map.ZoomOut();
                if(Map.CanZoomOut == true)
                {
                    ux_ZoomOut.Enabled = true;
                }
                else
                {
                    ux_ZoomOut.Enabled = false;
                }
                uxZoomOut.X = uxZoomOut.X / 2 - Map.ClientSize.Width;
                uxZoomOut.Y = uxZoomOut.Y / 2 - Map.ClientSize.Height;
                Math.Max(uxZoomOut.X, 0);
                Math.Min(uxZoomOut.Y, 0);
                Map.AutoScrollPosition = new Point(uxZoomOut.X, uxZoomOut.Y);

            }
        }
    }
}

