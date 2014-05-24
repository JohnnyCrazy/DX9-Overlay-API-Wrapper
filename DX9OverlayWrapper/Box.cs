using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DX9OverlayAPIWrapper
{
    public class Box
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
                DX9Overlay.BoxSetShown(id, value);
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
                DX9Overlay.BoxSetColor(id, Convert.ToUInt32(DX9Overlay.ToHexValueARGB(value), 16));
                this.color = value;
            }
        }
        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
            set
            {
                DX9Overlay.BoxSetPos(id, value.X, value.Y);
                DX9Overlay.BoxSetWidth(id, value.Width);
                DX9Overlay.BoxSetHeight(id, value.Height);
                this.rectangle = value;
            }
        }
        private Boolean borderShown;
        public Boolean BorderShown
        {
            get
            {
                return borderShown;
            }
            set
            {
                DX9Overlay.BoxSetBorder(id, borderHeight, value);
                this.borderShown = value;
            }
        }
        private int borderHeight;
        public int BorderHeight
        {
            get
            {
                return borderHeight;
            }
            set
            {
                DX9Overlay.BoxSetBorder(id, value, borderShown);
                this.borderHeight = value;
            }
        }
        private Color borderColor;
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                DX9Overlay.BoxSetBorderColor(id, Convert.ToUInt32(DX9Overlay.ToHexValueARGB(value), 16));
                this.borderColor = value;
            }
        }
        public Box(Rectangle rectangle, Color color, Boolean show, Boolean borderShown = false, int borderHeight = 0, Color borderColor = default(Color))
        {
            Id = DX9Overlay.BoxCreate(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, Convert.ToUInt32(DX9Overlay.ToHexValueARGB(color), 16), show);
            if (borderHeight != 0)
            {
                DX9Overlay.BoxSetBorder(id, borderHeight, borderShown);
                this.borderHeight = borderHeight;
                this.borderShown = borderShown;
            }
            if (borderColor != default(Color))
            {
                DX9Overlay.BoxSetBorderColor(id, Convert.ToUInt32(DX9Overlay.ToHexValueARGB(borderColor), 16));
                this.borderColor = borderColor;
            }
            this.rectangle = rectangle;
            this.visible = show;
            this.color = color;
        }
        public void Destroy()
        {
            DX9Overlay.BoxDestroy(id);
            id = -1;
        }
        public override string ToString()
        {
            return "Box " + Id.ToString();
        }
    }
}
