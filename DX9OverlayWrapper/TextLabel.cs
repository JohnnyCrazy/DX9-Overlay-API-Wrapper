using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DX9OverlayAPIWrapper
{
    public class TextLabel
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
        private String text;
        public String Text
        {
            get
            {
                return text;
            }
            set
            {
                DX9Overlay.TextSetString(id, value);
                this.text = value;
            }
        }
        private Boolean shadow;
        public Boolean Shadow
        {
            get
            {
                return shadow;
            }
            set
            {
                DX9Overlay.TextSetShadow(id, value);
                this.shadow = value;
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
                DX9Overlay.TextSetShown(id, value);
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
                DX9Overlay.TextSetColor(id, Convert.ToUInt32(DX9Overlay.ToHexValueARGB(value), 16));
                this.color = value;
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
                DX9Overlay.TextSetPos(id, value.X, value.Y);
                this.position = value;
            }
        }

        public TextLabel(String font, int size,TypeFace type, Point pos, Color color, String text, Boolean shadow, Boolean show)
        {
            Id = DX9Overlay.TextCreate(font, size, type.HasFlag(TypeFace.BOLD), type.HasFlag(TypeFace.ITALIC), pos.X, pos.Y, Convert.ToUInt32(DX9Overlay.ToHexValueARGB(color), 16), text, shadow, show);
            this.text = text;
            this.shadow = shadow;
            this.visible = show;
            this.color = color;
            this.position = pos;
        }
        public void Destroy()
        {
            DX9Overlay.TextDestroy(id);
            id = -1;
        }
        public void TextUpdate(String font, int size, Boolean bold, Boolean italic)
        {
            DX9Overlay.TextUpdate(id, font, size, bold, italic);
        }
        public override string ToString()
        {
            return "TextLabel " + Id.ToString();
        }
    }
}
