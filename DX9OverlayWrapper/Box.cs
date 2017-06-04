using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DX9OverlayAPIWrapper
{
    public class Box : Overlay
    {
        public override bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                DX9Overlay.BoxSetShown(Id, value);
                base.Visible = value;
            }
        }

        private Color _color;
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                DX9Overlay.BoxSetColor(Id, (uint)value.ToArgb());
                _color = value;
            }
        }

        private Rectangle _rectangle;
        public Rectangle Rectangle
        {
            get
            {
                return _rectangle;
            }
            set
            {
                DX9Overlay.BoxSetPos(Id, value.X, value.Y);
                DX9Overlay.BoxSetWidth(Id, value.Width);
                DX9Overlay.BoxSetHeight(Id, value.Height);
                _rectangle = value;
            }
        }

        private bool _borderShown;
        public bool BorderShown
        {
            get
            {
                return _borderShown;
            }
            set
            {
                DX9Overlay.BoxSetBorder(Id, _borderHeight, value);
                _borderShown = value;
            }
        }

        private int _borderHeight;
        public int BorderHeight
        {
            get
            {
                return _borderHeight;
            }
            set
            {
                DX9Overlay.BoxSetBorder(Id, value, _borderShown);
                _borderHeight = value;
            }
        }

        private Color _borderColor;
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                DX9Overlay.BoxSetBorderColor(Id, (uint)value.ToArgb());
                _borderColor = value;
            }
        }

        public Box(Rectangle rectangle, Color color, bool show, bool borderShown = false, int borderHeight = 0, Color borderColor = default(Color))
        {
            Id = DX9Overlay.BoxCreate(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, (uint)color.ToArgb(), show);
            if (borderHeight != 0)
            {
                DX9Overlay.BoxSetBorder(Id, borderHeight, borderShown);
                _borderHeight = borderHeight;
                _borderShown = borderShown;
            }
            if (borderColor != default(Color))
            {
                DX9Overlay.BoxSetBorderColor(Id, (uint)borderColor.ToArgb());
                _borderColor = borderColor;
            }
            _rectangle = rectangle;
            base.Visible = show;
            _color = color;
        }

        public override void Destroy()
        {
            DX9Overlay.BoxDestroy(Id);
            base.Destroy();
        }
    }
}
