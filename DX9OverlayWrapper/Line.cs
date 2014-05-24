using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DX9OverlayAPIWrapper
{
    public class Line
    {
        private int id = -1;
        public int Id
        {
            get
            {
                return id;
            }
            private set
            {
                this.id = value;
            }
        }
        private Boolean visible;
        public Boolean Visible
        {
            get
            {
                return visible;
            }
            set
            {
                DX9Overlay.LineSetShown(id, value);
                this.visible = value;
            }
        }
        private Color color;
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                DX9Overlay.LineSetColor(id, Convert.ToUInt32(DX9Overlay.ToHexValueARGB(value), 16));
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
                DX9Overlay.LineSetWidth(id, value);
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
                DX9Overlay.LineSetPos(id, value.X, value.Y, endPos.X, endPos.Y);
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
                DX9Overlay.LineSetPos(id, startPos.X, startPos.Y, value.X, value.Y);
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
            this.visible = show;
        }

        public void Destroy()
        {
            DX9Overlay.LineDestroy(id);
            id = -1;
        }
        public override string ToString()
        {
            return "Line " + Id.ToString();
        }
    }
}
