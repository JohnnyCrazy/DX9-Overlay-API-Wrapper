using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DX9OverlayAPIWrapper
{
    public class Image : Overlay
    {
        public override bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                DX9Overlay.ImageSetShown(Id, value);
                base.Visible = value;
            }
        }

        private int _rotation;
        public int Rotation
        {
            get
            {
                return _rotation;
            }
            set
            {
                DX9Overlay.ImageSetRotation(Id, value);
                _rotation = value;
            }
        }

        private Point _position;
        public Point Position
        {
            get
            {
                return _position;
            }
            set
            {
                DX9Overlay.ImageSetPos(Id, value.X, value.Y);
                _position = value;
            }
        }

        private Align _align;
        public Align Align
        {
            get
            {
                return _align;
            }
            set
            {
                DX9Overlay.ImageSetAlign(Id, (int)value);
                _align = value;
            }
        }

        public Image(string path, Point position, int rotation, Align align, bool show)
        {
            Id = DX9Overlay.ImageCreate(path, position.X, position.Y, rotation, (int)align, show);
            _position = position;
            _rotation = rotation;
            _align = align;
            base.Visible = show;
        }

        public override void Destroy()
        {
            DX9Overlay.ImageDestroy(Id);
            base.Destroy();
        }
    }
}
