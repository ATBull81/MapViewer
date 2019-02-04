using System.Windows.Forms;

namespace Ksu.Cis300.StreetViewer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.uxOpenMouse = new System.Windows.Forms.ToolStripButton();
            this.ux_ZoomIn = new System.Windows.Forms.ToolStripButton();
            this.ux_ZoomOut = new System.Windows.Forms.ToolStripButton();
            this.uxMapPanel = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Map = new Ksu.Cis300.StreetViewer.Map();
            this.toolStrip1.SuspendLayout();
            this.uxMapPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxOpenMouse,
            this.ux_ZoomIn,
            this.ux_ZoomOut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(823, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // uxOpenMouse
            // 
            this.uxOpenMouse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.uxOpenMouse.Image = ((System.Drawing.Image)(resources.GetObject("uxOpenMouse.Image")));
            this.uxOpenMouse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.uxOpenMouse.Name = "uxOpenMouse";
            this.uxOpenMouse.Size = new System.Drawing.Size(83, 24);
            this.uxOpenMouse.Text = "Open Map";
            this.uxOpenMouse.Click += new System.EventHandler(this.uxOpenMouse_Click_1);
            // 
            // ux_ZoomIn
            // 
            this.ux_ZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ux_ZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("ux_ZoomIn.Image")));
            this.ux_ZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ux_ZoomIn.Name = "ux_ZoomIn";
            this.ux_ZoomIn.Size = new System.Drawing.Size(69, 24);
            this.ux_ZoomIn.Text = "Zoom In";
            this.ux_ZoomIn.Click += new System.EventHandler(this.ux_ZoomIn_Click);
            // 
            // ux_ZoomOut
            // 
            this.ux_ZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ux_ZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("ux_ZoomOut.Image")));
            this.ux_ZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ux_ZoomOut.Name = "ux_ZoomOut";
            this.ux_ZoomOut.Size = new System.Drawing.Size(81, 24);
            this.ux_ZoomOut.Text = "Zoom Out";
            this.ux_ZoomOut.Click += new System.EventHandler(this.ux_ZoomOut_Click);
            // 
            // uxMapPanel
            // 
            this.uxMapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxMapPanel.AutoScroll = true;
            this.uxMapPanel.Controls.Add(this.Map);
            this.uxMapPanel.Location = new System.Drawing.Point(0, 30);
            this.uxMapPanel.Name = "uxMapPanel";
            this.uxMapPanel.Size = new System.Drawing.Size(811, 550);
            this.uxMapPanel.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Open Street Map Files (*.osm)|*.txt|All files (*.*)|*.*";
            // 
            // Map
            // 
            this.Map.BackColor = System.Drawing.Color.White;
            this.Map.CanZoomIn = true;
            this.Map.CanZoomOut = false;
            this.Map.Location = new System.Drawing.Point(0, 0);
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(0, 0);
            this.Map.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 592);
            this.Controls.Add(this.uxMapPanel);
            this.Controls.Add(this.toolStrip1);
            this.MinimumSize = new System.Drawing.Size(559, 464);
            this.Name = "Form1";
            this.Text = "Map Viewer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.uxMapPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton uxOpenMouse;
        private System.Windows.Forms.ToolStripButton ux_ZoomIn;
        private System.Windows.Forms.ToolStripButton ux_ZoomOut;
        private System.Windows.Forms.Panel uxMapPanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Map Map;
        //private UserControl1 userControl1;
    }
}

