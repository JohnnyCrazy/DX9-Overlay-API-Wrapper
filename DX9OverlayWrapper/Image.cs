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

        private int rotation;
        public int Rotation
        {
            get
            {
                return rotation;
            }
            set
            {
                DX9Overlay.ImageSetRotation(Id, value);
                this.rotation = value;
            }
        }

        private Point position;
        public Point Position
        {
            get
            {
                return position;
            }
            set
            {
                DX9Overlay.ImageSetPos(Id, value.X, value.Y);
                this.position = value;
            }
        }

        private Align align;
        public Align Align
        {
            get
            {
                return align;
            }
            set
            {
                DX9Overlay.ImageSetAlign(Id, (int)value);
                this.align = value;
            }
        }

        public Image(String path, Point pos, int rotation, Align align, bool show)
        {
            Id = DX9Overlay.ImageCreate(path, pos.X, pos.Y, rotation, (int)align, show);
            this.position = pos;
            this.rotation = rotation;
            this.align = align;
            base.Visible = show;
        }

        public override void Destroy()
        {
            DX9Overlay.ImageDestroy(Id);
            base.Destroy();
        }
    }
}
