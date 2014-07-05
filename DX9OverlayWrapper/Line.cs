using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DX9OverlayAPIWrapper
{
    public class Line : Overlay
    {
        private Color color;
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                DX9Overlay.LineSetColor(Id, Convert.ToUInt32(DX9Overlay.ToHexValueARGB(value), 16));
                this.color = value;
            }
        }

        private int width;
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                DX9Overlay.LineSetWidth(Id, value);
                this.width = value;
            }
        }

        private Point startPos;
        public Point StartPos
        {
            get
            {
                return startPos;
            }
            set
            {
                DX9Overlay.LineSetPos(Id, value.X, value.Y, endPos.X, endPos.Y);
                this.startPos = value;
            }
        }

        private Point endPos;
        public Point EndPos
        {
            get
            {
                return endPos;
            }
            set
            {
                DX9Overlay.LineSetPos(Id, startPos.X, startPos.Y, value.X, value.Y);
                this.endPos = value;
            }
        }

        public Line(Point startPos, Point endPos, int width, Color color, Boolean show)
        {
            Id = DX9Overlay.LineCreate(startPos.X, startPos.Y, endPos.X, endPos.Y, width, Convert.ToUInt32(DX9Overlay.ToHexValueARGB(color), 16), show);
            this.startPos = startPos;
            this.endPos = endPos;
            this.width = width;
            this.color = color;
            this.Visible = show;
        }

        public override void Destroy()
        {
            DX9Overlay.LineDestroy(Id);
            base.Destroy();
        }
    }
}
