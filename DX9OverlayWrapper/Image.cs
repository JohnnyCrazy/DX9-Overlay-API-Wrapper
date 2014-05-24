using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DX9OverlayAPIWrapper
{
    public class Image
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
                DX9Overlay.ImageSetShown(id, value);
                this.visible = value;
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
                DX9Overlay.ImageSetRotation(id, value);
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
                DX9Overlay.ImageSetPos(id, value.X, value.Y);
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
                DX9Overlay.ImageSetAlign(id, (int)value);
                this.align = value;
            }
        }
        public Image(String path, Point pos, int rotation, Align align, bool show)
        {
            Id = DX9Overlay.ImageCreate(path, pos.X, pos.Y, rotation, (int)align, show);
            this.position = pos;
            this.rotation = rotation;
            this.align = align;
            this.visible = show;
        }

        public void Destroy()
        {
            DX9Overlay.ImageDestroy(id);
            id = -1;
        }
        public override string ToString()
        {
            return "Image " + Id.ToString();
        }
    }
}
