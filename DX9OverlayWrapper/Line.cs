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
        public override bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                DX9Overlay.LineSetShown(Id, value);
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
                DX9Overlay.LineSetColor(Id, (uint)value.ToArgb());
                _color = value;
            }
        }

        private int _width;
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                DX9Overlay.LineSetWidth(Id, value);
                _width = value;
            }
        }

        private Point _startPosition;
        public Point StartPosition
        {
            get
            {
                return _startPosition;
            }
            set
            {
                DX9Overlay.LineSetPos(Id, value.X, value.Y, _endPosition.X, _endPosition.Y);
                _startPosition = value;
            }
        }

        private Point _endPosition;
        public Point EndPosition
        {
            get
            {
                return _endPosition;
            }
            set
            {
                DX9Overlay.LineSetPos(Id, _startPosition.X, _startPosition.Y, value.X, value.Y);
                _endPosition = value;
            }
        }

        public Line(Point startPosition, Point endPosition, int width, Color color, bool show)
        {
            Id = DX9Overlay.LineCreate(startPosition.X, startPosition.Y, endPosition.X, endPosition.Y, width, (uint)color.ToArgb(), show);
            _startPosition = startPosition;
            _endPosition = endPosition;
            _width = width;
            _color = color;
            base.Visible = show;
        }

        public override void Destroy()
        {
            DX9Overlay.LineDestroy(Id);
            base.Destroy();
        }
    }
}
