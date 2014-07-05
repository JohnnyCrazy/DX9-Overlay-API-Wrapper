using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DX9OverlayAPIWrapper
{
    public class TextLabel : Overlay
    {
        private String text;
        public String Text
        {
            get
            {
                return text;
            }
            set
            {
                DX9Overlay.TextSetString(Id, value);
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
                DX9Overlay.TextSetShadow(Id, value);
                this.shadow = value;
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
                DX9Overlay.TextSetColor(Id, Convert.ToUInt32(DX9Overlay.ToHexValueARGB(value), 16));
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
                DX9Overlay.TextSetPos(Id, value.X, value.Y);
                this.position = value;
            }
        }

        public TextLabel(String font, int size, TypeFace type, Point pos, Color color, String text, Boolean shadow, Boolean show)
        {
            Id = DX9Overlay.TextCreate(font, size, type.HasFlag(TypeFace.BOLD), type.HasFlag(TypeFace.ITALIC), pos.X, pos.Y, Convert.ToUInt32(DX9Overlay.ToHexValueARGB(color), 16), text, shadow, show);
            this.text = text;
            this.shadow = shadow;
            this.Visible = show;
            this.color = color;
            this.position = pos;
        }

        public override void Destroy()
        {
            DX9Overlay.TextDestroy(Id);
            base.Destroy();
        }

        public void TextUpdate(String font, int size, Boolean bold, Boolean italic)
        {
            DX9Overlay.TextUpdate(Id, font, size, bold, italic);
        }
    }
}
